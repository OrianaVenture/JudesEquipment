using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using YamlDotNet.Serialization;

namespace JudesEquipment.Configuration
{
    public class ArmorSetConfig
    {
        [YamlMember(Alias = "set effect")]
        public SetEffect setEffect = new SetEffect();
        public Dictionary<string, ArmorConfig> pieces = new Dictionary<string, ArmorConfig>();

        public void ApplyArmorConfigs()
        {
            pieces.Values.ToList().ForEach(piece => piece.ApplyConfig());
        }

        public void ApplyRecipeConfigs()
        {
            pieces.Values.ToList().ForEach(piece => piece.recipe.ApplyConfig(piece.prefabName));
        }

        public void ApplySetConfig(string effectName)
        {
            if (ObjectDB.instance == null) return;

            SE_Stats effect = (SE_Stats)ItemManager.customSEs.Find(se => se.name == effectName);
            if(effect == null)
            {
                effect = ScriptableObject.CreateInstance<SE_Stats>();
                effect.name = effectName;
                effect.m_icon = ObjectDB.instance.m_items.Find(iconSource => iconSource.name == pieces.Values.ToList()[0].prefabName).GetComponent<ItemDrop>().m_itemData.m_shared.m_icons[0];
                effect.m_name = "$" + Main.setEffectLocalizationToken;
                ObjectDB.instance.m_StatusEffects.Add(effect);
                ItemManager.customSEs.Add(effect);
            }

            effect.m_healthRegenMultiplier = setEffect.healthRegenModifier / 100f + 1;
            effect.m_staminaRegenMultiplier = setEffect.staminaReregenModifier / 100f + 1;
            effect.m_addMaxCarryWeight = setEffect.carryWeightModifier;
            effect.m_mods = ArmorConfig.ParseModPairs(setEffect.damageModifiers);
            effect.m_skillLevel = (Skills.SkillType)Enum.Parse(typeof(Skills.SkillType), setEffect.skillModifier.skill);
            effect.m_skillLevelModifier = setEffect.skillModifier.modifier;
            effect.m_runStaminaDrainModifier = setEffect.runStaminaDrainModifier / 100f;
            effect.m_jumpStaminaUseModifier = setEffect.jumpStaminaDrainModifier / 100f;

            pieces.Values.ToList().ForEach(piece =>
            {
                if(piece.countsTowardsSetBonus)
                {
                    ItemDrop setPieceDrop = ItemManager.prefabs.Find(armor => armor.GetPrefab().name == piece.prefabName).GetPrefab()?.GetComponent<ItemDrop>();
                    setPieceDrop.m_itemData.m_shared.m_setStatusEffect = effect;
                    setPieceDrop.m_itemData.m_shared.m_setName = effectName;
                    setPieceDrop.m_itemData.m_shared.m_setSize = GetSetSize();
                }
            });
        }

        public int GetSetSize()
        {
            int size = 0;
            foreach(ArmorConfig cfg in pieces.Values)
            {
                if (cfg.countsTowardsSetBonus) size += 1;
            }
            return size;
        }
    }
}
