using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ServerSync;

namespace JudesEquipment.Configuration
{
    /*
    def_enabled,
    def_outputPrefabName,
    def_outputAmount,
    def_craftingStation,
    def_minStationLvl,

    def_itemRequirement1,
    def_itemRequirement2,
    def_itemRequirement3,
    def_itemRequirement4,
    */

    public class RecipeConfig
    {
        public string configHeader;
        public ConfigFile cfg;
        public Recipe recipe;

        public ConfigEntry<bool> enabled;

        //item requirement format: [prefabName];[intitialAmount];[amountPerLevel]
        public ConfigEntry<string> itemRequirement1, itemRequirement2, itemRequirement3, itemRequirement4,
                                    craftingStation;
        public ConfigEntry<int> minStationLvl, outputAmount;

        public bool def_enabled = true;
        public string def_itemRequirement1, def_itemRequirement2, def_itemRequirement3, def_itemRequirement4,
                        def_craftingStation, outputPrefabName;
        public int def_minStationLvl, def_outputAmount = 1;

        public virtual bool Load()
        {
            cfg = Main.recipeCfgFile;

            enabled = Sync.SyncConfig(cfg.Bind(configHeader, "Enabled", def_enabled, ""));

            craftingStation = Sync.SyncConfig(cfg.Bind(configHeader, "Crafting station", def_craftingStation, ""));
            minStationLvl = Sync.SyncConfig(cfg.Bind(configHeader, "Min station lvl", def_minStationLvl, ""));
            outputAmount = Sync.SyncConfig(cfg.Bind(configHeader, "Output amount", def_outputAmount, ""));

            itemRequirement1 = Sync.SyncConfig(cfg.Bind(configHeader, "Item requirement 1", def_itemRequirement1, "Item requirements are in the format [PrefabName];[InitialCost];[CostPerLevel]"));
            itemRequirement2 = Sync.SyncConfig(cfg.Bind(configHeader, "Item requirement 2", def_itemRequirement2, ""));
            itemRequirement3 = Sync.SyncConfig(cfg.Bind(configHeader, "Item requirement 3", def_itemRequirement3, ""));
            itemRequirement4 = Sync.SyncConfig(cfg.Bind(configHeader, "Item requirement 4", def_itemRequirement4, ""));

            //updates

            enabled.SettingChanged          += (object sender, EventArgs e) => { if (recipe != null) recipe.m_enabled = enabled.Value; };

            craftingStation.SettingChanged  += (object sender, EventArgs e) => { if (recipe != null) recipe.m_craftingStation = ZNetScene.instance?.GetPrefab(craftingStation.Value)?.GetComponent<CraftingStation>(); };
            minStationLvl.SettingChanged    += (object sender, EventArgs e) => { if (recipe != null) recipe.m_minStationLevel = minStationLvl.Value; };
            outputAmount.SettingChanged     += (object sender, EventArgs e) => { if (recipe != null) recipe.m_amount = outputAmount.Value; };

            itemRequirement1.SettingChanged += (object sender, EventArgs e) => { if (recipe != null) recipe.m_resources = ParseRequirements().ToArray(); };
            itemRequirement2.SettingChanged += (object sender, EventArgs e) => { if (recipe != null) recipe.m_resources = ParseRequirements().ToArray(); };
            itemRequirement3.SettingChanged += (object sender, EventArgs e) => { if (recipe != null) recipe.m_resources = ParseRequirements().ToArray(); };
            itemRequirement4.SettingChanged += (object sender, EventArgs e) => { if (recipe != null) recipe.m_resources = ParseRequirements().ToArray(); };

            return true;
        }

        //objects:0-objectdb, 1-znetscene
        public virtual bool ApplyConfig()
        {
            if(recipe == null)
            {
                recipe = ScriptableObject.CreateInstance<Recipe>();
            }

            ObjectDB odb = ObjectDB.instance;
            if (odb == null)
            {
                Main.log.LogWarning("Could not configure recipe " + configHeader + ": ObjectDB is null");
                return false;
            }

            ZNetScene zns = ZNetScene.instance;
            if (zns == null)
            {
                // no need to log anything, this should only happen in main menu, which is expected
                return false;
            }

            if (!enabled.Value)
            {
                Main.log.LogMessage("Recipe " + configHeader + " for " + outputPrefabName + " is disabled");
            }

            GameObject prefab = zns.GetPrefab(outputPrefabName);
            if (prefab == null)
            {
                Main.log.LogWarning("Could not create recipe " + configHeader + " for " + outputPrefabName + ": output prefab does not exist");
                return false;
            }
            ItemDrop item = prefab.GetComponent<ItemDrop>();
            if (item == null)
            {
                Main.log.LogWarning("Could not create recipe " + configHeader + ": prefab does not contain ItemDrop");
                return false;
            }

            recipe.name = prefab.name + "_recipe";
            recipe.m_enabled = enabled.Value;
            recipe.m_item = item;
            recipe.m_amount = outputAmount.Value;
            recipe.m_craftingStation = zns.GetPrefab(craftingStation.Value)?.GetComponent<CraftingStation>();
            recipe.m_repairStation = recipe.m_craftingStation;//zns.GetPrefab(craftingStation.Value)?.GetComponent<CraftingStation>();
            recipe.m_minStationLevel = minStationLvl.Value;

            recipe.m_resources = ParseRequirements().ToArray();

            return true;
        }

        public List<Piece.Requirement> ParseRequirements()
        {
            List<Piece.Requirement> requirements = new List<Piece.Requirement>();

            if (ParseRequirementCfg(itemRequirement1.Value) != null) requirements.Add(ParseRequirementCfg(itemRequirement1.Value));
            if (ParseRequirementCfg(itemRequirement2.Value) != null) requirements.Add(ParseRequirementCfg(itemRequirement2.Value));
            if (ParseRequirementCfg(itemRequirement3.Value) != null) requirements.Add(ParseRequirementCfg(itemRequirement3.Value));
            if (ParseRequirementCfg(itemRequirement4.Value) != null) requirements.Add(ParseRequirementCfg(itemRequirement4.Value));

            return requirements;
        }

        //item requirement format: [prefabName];[intitialAmount];[amountPerLevel]
        public Piece.Requirement ParseRequirementCfg(string requirementCfg)
        {
            if (ZNetScene.instance == null) return null;

            Piece.Requirement requirement = new Piece.Requirement();

            string[] splitCfg = requirementCfg.Split(';');
            if(splitCfg.Length != 3)
            {
                return null;
            }

            if (int.TryParse(splitCfg[1], out var amount) == false || int.TryParse(splitCfg[2], out var amountPerLvl) == false) return null;

            GameObject reqPrefab = ZNetScene.instance.GetPrefab(splitCfg[0].Trim());
            if (reqPrefab == null) return null;

            ItemDrop reqDrop = reqPrefab.GetComponent<ItemDrop>();

            requirement.m_resItem = reqDrop;
            requirement.m_amount = amount;
            requirement.m_amountPerLevel = amountPerLvl;
            requirement.m_recover = true;

            return requirement;
        }
    }
}