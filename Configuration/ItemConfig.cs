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
    public class ItemConfig
    {
        /*public ConfigEntry<int> weight, maxStackSize;
        public ConfigEntry<bool> teleportable;*/

        ConfigEntry<int> weight;
        ConfigEntry<bool> teleportable;

        public ConfigFile cfg;
        public string configHeader;

        public int def_Weight; /*, def_maxStackSize = 1;*/
        public bool def_teleportable = true;


        //globals or wahtever
        public GameObject prefab;
        public ItemDrop drop;

        //when using a cloned item as a base
        public string prefabToClone;
        public string prefabNameOverride = string.Empty;
        public Sprite iconOverride;

        public virtual bool Load()
        {
            cfg = Main.itemCfgFile;
            weight =        Sync.SyncConfig(cfg.Bind(configHeader, "Weight",            def_Weight, ""));
            //maxStackSize =  Sync.SyncConfig(cfg.Bind(configHeader, "Max stack size",    def_maxStackSize, "dunno"));
            teleportable =  Sync.SyncConfig(cfg.Bind(configHeader, "Teleportable",      def_teleportable, ""));

            weight.SettingChanged += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_weight = weight.Value; };
            teleportable.SettingChanged += (object sender, EventArgs e) => { if (drop != null) drop.m_itemData.m_shared.m_teleportable = teleportable.Value; };

            return true;
        }

        public virtual bool ApplyConfig()
        {
            if(prefab == null)
            {
                GameObject toClone = ObjectDB.instance?.m_items.Find(odbItem => odbItem.name == prefabToClone);
                if (toClone == null) { /*Main.log.LogMessage("could not find " + prefabToClone + " in odb yet"); */ return false; }
                prefab = UnityEngine.Object.Instantiate(toClone, ItemManager.GetCloneHolder());

                drop = prefab.GetComponentInChildren<ItemDrop>(true);

                drop.m_itemData.m_shared.m_damageModifiers?.Clear();
                drop.m_itemData.m_shared.m_setStatusEffect = null;
                drop.m_itemData.m_shared.m_equipStatusEffect = null;
            }

            //set item base stats
            drop = prefab.GetComponentInChildren<ItemDrop>(true);
            ItemDrop.ItemData.SharedData stats = drop.m_itemData.m_shared;

            stats.m_weight = weight.Value;
            stats.m_teleportable = teleportable.Value;
            stats.m_maxStackSize = 1;

            prefab.layer = 12;

            //override stuff
            if (!string.IsNullOrEmpty(prefabNameOverride.Trim())) prefab.name = prefabNameOverride;
            if (iconOverride != null) drop.m_itemData.m_shared.m_icons[0] = iconOverride;

            //localization
            string nameToken = "$" + prefab.name;
            string descriptionToken = "$" + prefab.name + "_description";

            stats.m_name = nameToken;
            stats.m_description = descriptionToken;

            return true;
        }
    }
}
