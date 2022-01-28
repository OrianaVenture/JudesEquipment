using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ServerSync;
using YamlDotNet.Serialization;

namespace JudesEquipment.Configuration
{
    public class RecipeConfig
    {
        public class RequirementConfig
        {
            [YamlMember(Alias = "item")]
            public string item;
            [YamlMember(Alias = "amount")]
            public int amount = 0;
            [YamlMember(Alias = "amount per level")]
            public int amountPerLevel = 0;

            public Piece.Requirement GetRequirement()
            {
                Piece.Requirement requirement = new Piece.Requirement();
                requirement.m_resItem = ObjectDB.instance.m_items.Find(_item => _item.name == item)?.GetComponent<ItemDrop>();
                if (requirement.m_resItem == null) return null;
                requirement.m_amount = amount;
                requirement.m_amountPerLevel = amountPerLevel;
                requirement.m_recover = true;
                return requirement;
            }
        }

        [YamlMember(Alias = "enabled")]
        public bool enabled = true;
        [YamlIgnore]
        public int amount = 1;
        [YamlMember(Alias = "station")]
        public string station = string.Empty;
        [YamlMember(Alias = "minimum station level")]
        public int minimumStationLevel = 1;
        [YamlMember(Alias = "requirements")]
        public List<RequirementConfig> requirements = new List<RequirementConfig>();

        public void ApplyConfig(string prefabName)
        {
            bool createNew = false;
            string recipeName = prefabName + "_recipe";

            if (ObjectDB.instance == null || ZNetScene.instance == null || !enabled) return;
            Recipe recipe = ObjectDB.instance.m_recipes?.Find(_recipe => _recipe.name == recipeName);
            if (recipe == null) createNew = true;

            ItemDrop item = ItemManager.prefabs.Find(_prefab => _prefab.GetPrefab().name == prefabName)?.GetPrefab()?.GetComponent<ItemDrop>();
            if (item == null) return;

            if(createNew)
            {
                recipe = ScriptableObject.CreateInstance<Recipe>();
                recipe.name = recipeName;
                ObjectDB.instance.m_recipes.Add(recipe);
            }

            recipe.m_enabled = enabled;
            recipe.m_item = item;
            recipe.m_amount = amount;
            recipe.m_craftingStation = ZNetScene.instance.GetPrefab(station)?.GetComponent<CraftingStation>();
            recipe.m_repairStation = recipe.m_craftingStation;
            recipe.m_minStationLevel = minimumStationLevel;

            List<Piece.Requirement> resolvedRequirements = new List<Piece.Requirement>();
            requirements.ForEach(reqCfg =>
            {
                Piece.Requirement req = reqCfg.GetRequirement();
                if (req != null) resolvedRequirements.Add(req);
            });
            recipe.m_resources = resolvedRequirements.ToArray();

            return;
        }

    }
}