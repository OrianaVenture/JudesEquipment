using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace JudesEquipment.Configuration
{
    public class ArmorConfig
    {
        [YamlMember(Alias = "item prefab name")]
        public string prefabName = string.Empty;
        [YamlMember(Alias = "required for set bonus")]
        public bool countsTowardsSetBonus = true;

        public int armor = 0;
        [YamlMember(Alias = "armor per level")]
        public int armorPerLevel = 2;

        [YamlMember(Alias = "enable durability")]
        public bool enableDurability = true;
        public int baseDurability = 1000;
        [YamlMember(Alias = "durability per level")]
        public int durabilityPerLevel = 200;
        public bool repairable = true;
        [YamlMember(Alias = "destroy when broken")]
        public bool destroyBroken = false;

        public int weight = 0;
        public bool teleportable = true;
        [YamlMember(Alias = "maximum upgrade level")]
        public int maxUpgradeLevel = 4;

        [YamlMember(Alias = "movement speed modifier")]
        public int movementSpeedModifier = 0;

        // Valid damage type names: Blunt, Slash, Pierce, Chop, Pickaxe, Fire, Frost, Lightning, Poison, Spirit, Physical, Elemental
        // Valid modifier names: Normal, Resistant, Weak, Immune, Ignore, VeryResistant, VeryWeak
        [YamlMember(Alias = "damage modifiers")]
        public Dictionary<string, string> damageModifiers = new Dictionary<string, string>()
        {
            { HitData.DamageType.Blunt.ToString(), "none" },
            { HitData.DamageType.Slash.ToString(), "none" },
            { HitData.DamageType.Pierce.ToString(), "none" },
            { HitData.DamageType.Chop.ToString(), "none" },
            { HitData.DamageType.Fire.ToString(), "none" },
            { HitData.DamageType.Frost.ToString(), "none" },
            { HitData.DamageType.Lightning.ToString(), "none" },
            { HitData.DamageType.Poison.ToString(), "none" },
            { HitData.DamageType.Spirit.ToString(), "none" }

        };

        [YamlMember(Alias = "recipe")]
        public RecipeConfig recipe = new RecipeConfig();

        public void ApplyConfig()
        {
            ItemDrop.ItemData.SharedData stats = ItemManager.prefabs.Find(prefab =>
                prefab.GetPrefab().name == prefabName)?.GetPrefab()?.GetComponent<ItemDrop>().m_itemData.m_shared;
            if (stats == null) return;

            stats.m_weight =                weight;
            stats.m_armor =                 armor;
            stats.m_armorPerLevel =         armorPerLevel;
            stats.m_damageModifiers =       ParseModPairs(damageModifiers);
            stats.m_maxDurability =         baseDurability;
            stats.m_durabilityPerLevel =    durabilityPerLevel;
            stats.m_destroyBroken =         destroyBroken;
            stats.m_canBeReparied =         repairable;
            stats.m_movementModifier =      movementSpeedModifier / 100f;
            stats.m_equipDuration =         1;
            stats.m_maxQuality =            maxUpgradeLevel;

            stats.m_useDurability =         enableDurability;

            return;
        }

        public static List<HitData.DamageModPair> ParseModPairs(Dictionary<string, string> mods)
        {
            List<HitData.DamageModPair> modPairs = new List<HitData.DamageModPair>();
            foreach (KeyValuePair<string, string> mod in mods)
            {
                if (mod.Value.ToLower() == "none") continue;

                HitData.DamageType dmgType = (HitData.DamageType)Enum.Parse(typeof(HitData.DamageType), mod.Key);
                HitData.DamageModifier dmgMod = (HitData.DamageModifier)Enum.Parse(typeof(HitData.DamageModifier), mod.Value);

                modPairs.Add(new HitData.DamageModPair() { m_type = dmgType, m_modifier = dmgMod });
            }

            return modPairs;
        }
    }
}
