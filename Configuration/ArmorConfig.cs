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
    public class ArmorConfig : ItemConfig
    {
        /*
        def_Armor,
        def_ArmorPerLevel,
        def_BaseDurability,
        def_DurabilityPerLevel,
        def_MovementSpeedModifier,
        def_MaxUpgradeLvl,
        def_EquipTime
         */

        public ConfigEntry<int> armor, armorPerLevel, baseDurability, durabilityPerLevel, movementSpeedModifier, maxUpgradeLvl;
        public ConfigEntry<float> equipTime;
        public ConfigEntry<bool> destroyBroken, repairable;
        public ConfigEntry<string> damageModPairs;

        /*public SyncedConfigEntry<int> armor, armorPerLevel, baseDurability, durabilityPerLevel, movementSpeedModifier, maxUpgradeLvl;
        public SyncedConfigEntry<float> equipTime;
        public SyncedConfigEntry<bool> destroyBroken, repairable;
        public SyncedConfigEntry<string> damageModPairs;*/

        public int def_Armor, def_ArmorPerLevel = 2, def_BaseDurability = 1000, def_DurabilityPerLevel = 200, def_MovementSpeedModifier = -5, def_MaxUpgradeLvl = 4;
        public float def_EquipTime = 1;
        public bool def_destroyBroken = false, def_repairable = true;
        public string def_damageModPairs;

        public override bool Load()
        {
            if (!base.Load()) return false;

            maxUpgradeLvl =             Sync.SyncConfig(cfg.Bind(configHeader, "Maximum upgrade level",     def_MaxUpgradeLvl, ""));
            armor =                     Sync.SyncConfig(cfg.Bind(configHeader, "Base Armor",                def_Armor, ""));
            armorPerLevel =             Sync.SyncConfig(cfg.Bind(configHeader, "Armor per level",           def_ArmorPerLevel));
            damageModPairs =            Sync.SyncConfig(cfg.Bind(configHeader, "Damage modifiers",          def_damageModPairs, "Damage modifiers are in the format: [DamageType1]:[DamageModifier1];[DamageType2]:[DamageModifier2]; ... Valid damage type names: Blunt, Slash, Pierce, Chop, Pickaxe, Fire, Frost, Lightning, Poison, Spirit, Physical, Elemental ... Valid modifier names: Normal, Resistant, Weak, Immune, Ignore, VeryResistant, VeryWeak"));
            destroyBroken =             Sync.SyncConfig(cfg.Bind(configHeader, "Destroy broken",            def_destroyBroken, ""));
            repairable =                Sync.SyncConfig(cfg.Bind(configHeader, "Repairable",                def_repairable, ""));
            baseDurability =            Sync.SyncConfig(cfg.Bind(configHeader, "Base durability",           def_BaseDurability, "Set to 0 for indestructibility "));
            durabilityPerLevel =        Sync.SyncConfig(cfg.Bind(configHeader, "Durability per level",      def_DurabilityPerLevel, ""));
            movementSpeedModifier =     Sync.SyncConfig(cfg.Bind(configHeader, "Movement speed modifier",   def_MovementSpeedModifier, ""));
            equipTime =                 Sync.SyncConfig(cfg.Bind(configHeader, "Equip time",                def_EquipTime, ""));

            maxUpgradeLvl.SettingChanged            += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_maxQuality =          maxUpgradeLvl.Value; };
            armor.SettingChanged                    += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_armor =               armor.Value; };
            armorPerLevel.SettingChanged            += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_armorPerLevel =       armorPerLevel.Value; };
            damageModPairs.SettingChanged           += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_damageModifiers =     Util.ParseDmgModPairs(damageModPairs.Value); };
            destroyBroken.SettingChanged            += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_destroyBroken =       destroyBroken.Value; };
            repairable.SettingChanged               += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_canBeReparied =       repairable.Value; };
            baseDurability.SettingChanged           += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_maxDurability =       baseDurability.Value; drop.m_itemData.m_shared.m_useDurability = baseDurability.Value != 0; };
            durabilityPerLevel.SettingChanged       += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_durabilityPerLevel =  durabilityPerLevel.Value; };
            movementSpeedModifier.SettingChanged    += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_movementModifier =    movementSpeedModifier.Value; };
            equipTime.SettingChanged                += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_equipDuration =       equipTime.Value; };

            return true;
        }

        public override bool ApplyConfig()
        {
            if (base.ApplyConfig() == false) return false;
            //itemdrop will always be filled in base class ItemConfig
            ItemDrop.ItemData.SharedData stats = drop.m_itemData.m_shared;

            stats.m_armor =                 armor.Value;
            stats.m_armorPerLevel =         armorPerLevel.Value;
            stats.m_damageModifiers =       Util.ParseDmgModPairs(damageModPairs.Value);
            stats.m_maxDurability =         baseDurability.Value;
            stats.m_durabilityPerLevel =    durabilityPerLevel.Value;
            stats.m_destroyBroken =         destroyBroken.Value;
            stats.m_canBeReparied =         repairable.Value;
            stats.m_movementModifier =      movementSpeedModifier.Value / 100f;
            stats.m_equipDuration =         equipTime.Value;
            stats.m_maxQuality =            maxUpgradeLvl.Value;

            drop.m_itemData.m_durability = baseDurability.Value;

            stats.m_useDurability = baseDurability.Value != 0;

            return true;
        }
    }
}
