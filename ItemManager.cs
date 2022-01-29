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

        public static List<PrefabConfig> prefabs = new List<PrefabConfig>();
        public static List<StatusEffect> customSEs = new List<StatusEffect>();
        public static List<BlacksmithsToolsConfig> bsmithCfgs = new List<BlacksmithsToolsConfig>();

        public static void AddItemsToDBs(ObjectDB odb)
        {
            LoadPrefabsFromBundle();
            foreach(PrefabConfig prefab in prefabs)
            {
                if (prefab.GetPrefab() == null) continue;

                if (!odb.m_itemByHash.ContainsKey(prefab.GetPrefab().name.GetStableHashCode()))
                {
                    odb.m_itemByHash.Add(prefab.GetPrefab().name.GetStableHashCode(), prefab.GetPrefab());
                }

                if (!odb.m_items.Contains(prefab.GetPrefab()))
                {
                    odb.m_items.Add(prefab.GetPrefab());
                }

                if (ZNetScene.instance != null)
                {
                    if (!ZNetScene.instance.m_prefabs.Contains(prefab.GetPrefab()))
                    {
                        ZNetScene.instance.m_prefabs.Add(prefab.GetPrefab());
                    }

                    if (!ZNetScene.instance.m_namedPrefabs.ContainsKey(prefab.GetPrefab().name.GetStableHashCode()))
                    {
                        ZNetScene.instance.m_namedPrefabs.Add(prefab.GetPrefab().name.GetStableHashCode(), prefab.GetPrefab());
                    }
                }
            }

            customSEs.ForEach(se => { if (!odb.m_StatusEffects.Contains(se)) odb.m_StatusEffects.Add(se); });
        }

        public static void InsertBsmithToolsCfgs()
        {
            if (Main.bsmithAvailable)
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

        static void LoadPrefabsFromBundle()
        {
            AssetBundle bundle = Util.LoadBundle(Main.bundleName);

            ItemManager.prefabs.Clear();
            allPrefabs.ForEach(_prefab => ItemManager.prefabs.Add(new PrefabConfig()
            {
                prefab = bundle.LoadAsset<GameObject>(_prefab)
            }));
            bundle.Unload(false);
        }

        public static readonly List<string> allPrefabs = new List<string>()
        {
            "ArmorBarbarianBronzeHelmetJD",
            "ArmorBarbarianBronzeChestJD",
            "ArmorBarbarianBronzeLegsJD",
            "ArmorBarbarianCapeJD",

            "ArmorPlateIronHelmetJD",
            "ArmorPlateIronChestJD",
            "ArmorPlateIronLegsJD",
            "ArmorPlateCape",

            "ArmorDragonslayerHelmet",
            "ArmorDragonslayerChest",
            "ArmorDragonslayerLegs",

            "ArmorWandererHelmet",
            "ArmorWandererChest",
            "ArmorWandererLegs",
            "ArmorWandererCape",

            "ArmorBlackmetalgarbHelmet",
            "ArmorBlackmetalgarbChest",
            "ArmorBlackmetalgarbLegs",

            "ArmorSerpentHelmet",
            "ArmorSerpentChest",
            "ArmorSerpentLegs",
            "ArmorSerpentCape",

            "ArmorMistlandsHelmet",
            "ArmorMistlandsChest",
            "ArmorMistlandsLegs", 

            "BackpackSimple",
            "BackpackHeavy"
        };
    }
}
