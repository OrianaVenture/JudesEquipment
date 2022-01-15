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
    public class BackpackConfig : ArmorConfig
    {
        public ConfigEntry<int> carryWeightBonus;

        public int def_carryWeightBonus;

        public SE_Stats seStats;

        public override bool Load()
        {
            if (!base.Load()) return false;

            carryWeightBonus = Sync.SyncConfig(cfg.Bind(configHeader, "Carry weight bonus", def_carryWeightBonus, ""));

            carryWeightBonus.SettingChanged += (object sender, EventArgs e) => { if (seStats != null) seStats.m_addMaxCarryWeight = carryWeightBonus.Value; };

            return true;
        }

        public override bool ApplyConfig()
        {
            if (!base.ApplyConfig()) return false;

            if(seStats == null)
            {
                seStats = ScriptableObject.CreateInstance<SE_Stats>();
            }

            seStats.name = configHeader + "_SE";
            seStats.m_name = configHeader + "_SE";
            seStats.m_addMaxCarryWeight = carryWeightBonus.Value;
            seStats.m_icon = drop.m_itemData.m_shared.m_icons[0];
            drop.m_itemData.m_shared.m_equipStatusEffect = seStats;

            if(ItemManager.customSEs.Find(se => se.name == seStats.name) == null) ItemManager.customSEs.Add(seStats);

            return true;
        }
    }
}
