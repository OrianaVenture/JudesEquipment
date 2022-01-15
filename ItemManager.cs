using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using JudesEquipment.Configuration;

namespace JudesEquipment
{
    public static class ItemManager
    {
        public static Transform cloneContainer;
        
        public static Transform GetCloneHolder()
        {
            if (cloneContainer == null)
            {
                cloneContainer = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
                UnityEngine.Object.DontDestroyOnLoad(cloneContainer);
                cloneContainer.gameObject.SetActive(false);
                return cloneContainer;
            }
            return cloneContainer;
        }

        public static List<ItemConfig> customItems = new List<ItemConfig>();
        public static List<StatusEffect> customSEs = new List<StatusEffect>();
        public static List<BlacksmithsToolsConfig> bsmithCfgs = new List<BlacksmithsToolsConfig>();

        public static void AddItem(ItemConfig cfg)
        {
            //if (customItems.Find(c => c.configHeader == cfg.configHeader)?.configHeader == cfg.configHeader) Main.log.LogWarning(cfg.configHeader + " already exists in configlist");
            //customItems.Remove(cfg);
            customItems.Add(cfg);
            cfg.Load();
        }

        public static void ApplyConfigs()
        {
            customItems.ForEach(item => item.ApplyConfig());
        }

        public static void AddItemsToODB(ObjectDB odb)
        {
            ApplyConfigs();
            foreach(ItemConfig item in customItems)
            {
                if (item.prefab == null) continue;

                if (!odb.m_itemByHash.ContainsKey(item.prefab.name.GetStableHashCode()))
                {
                    odb.m_itemByHash.Add(item.prefab.name.GetStableHashCode(), item.prefab);
                }

                if (!odb.m_items.Contains(item.prefab))
                {
                    odb.m_items.Add(item.prefab);
                }

                if (ZNetScene.instance != null)
                {
                    if (!ZNetScene.instance.m_prefabs.Contains(item.prefab))
                    {
                        ZNetScene.instance.m_prefabs.Add(item.prefab);
                    }

                    if (!ZNetScene.instance.m_namedPrefabs.ContainsKey(item.prefab.name.GetStableHashCode()))
                    {
                        ZNetScene.instance.m_namedPrefabs.Add(item.prefab.name.GetStableHashCode(), item.prefab);
                    }
                }
            }

            customSEs.ForEach(se => { if (!odb.m_StatusEffects.Contains(se)) odb.m_StatusEffects.Add(se); });
        }

        public static void InsertBsmithToolsCfgs()
        {
            if (Util.IsBsmithAvailable())
            {
                Type type = Type.GetType("BlacksmithTools.BodypartSystem,BlacksmithTools");

                var list = type.GetField("bodypartSettingsAsBones");
                Dictionary<string, List<int>> boneDict = (Dictionary<string, List<int>>)list.GetValue(list);

                foreach (BlacksmithsToolsConfig cfg in bsmithCfgs)
                {
                    if(boneDict.ContainsKey(cfg.itemName))
                    {
                        boneDict[cfg.itemName] = new List<int>(cfg.bonesToHide);
                    }
                    else
                    {
                        boneDict.Add(cfg.itemName, new List<int>(cfg.bonesToHide));
                    }
                }
            }
        }
    }
}
