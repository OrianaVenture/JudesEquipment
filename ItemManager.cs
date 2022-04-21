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
        public static Dictionary<string, Dictionary<string, string>> colorConfig = new Dictionary<string, Dictionary<string, string>>
		{
			{ "ArmorBarbarianBronzeHelmetJD", new Dictionary<string, string> { { "Color 1", "#FF892A" }, { "Color 2", "#FFFFFF" } } },
			{ "ArmorBarbarianBronzeChestJD", new Dictionary<string, string> { { "Color 1", "#FF892A" }, { "Color 2", "#FFFFFF" } } },
			{ "ArmorBarbarianBronzeLegsJD", new Dictionary<string, string> { { "Color 1", "#FF892A" }, { "Color 2", "#FFFFFF" } } },

			{ "ArmorWarriorHelmet", new Dictionary<string, string> { { "Color 1", "#FF892A" } } }, 
			{ "ArmorWarriorChest", new Dictionary<string, string> { { "Color 1", "#FF892A" } } },

			{ "ArmorPlateIronHelmetJD", new Dictionary<string, string> { { "Color 1", "#FFFFFF" } } },
			{ "ArmorPlateIronChestJD", new Dictionary<string, string> { { "Color 1", "#FFFFFF" } } },
			{ "ArmorPlateIronLegsJD", new Dictionary<string, string> { { "Color 1", "#FFFFFF" } } },

			{ "ArmorDragonslayerHelmet", new Dictionary<string, string> { { "Color 1", "#373737" } } },
			{ "ArmorDragonslayerChest", new Dictionary<string, string> { { "Color 1", "#373737" } } },
			{ "ArmorDragonslayerLegs", new Dictionary<string, string> { { "Color 1", "#373737" } } },

			{ "ArmorWandererChest", new Dictionary<string, string> { { "Color 1", "#FFFFFF" } } },
			{ "ArmorWandererLegs", new Dictionary<string, string> { { "Color 1", "#FFFFFF" } } },

			{ "ArmorBlackmetalgarbHelmet", new Dictionary<string, string> { { "Color 1", "#264C35" } } },
			{ "ArmorBlackmetalgarbChest", new Dictionary<string, string> { { "Color 1", "#264C35" } } },
			{ "ArmorBlackmetalgarbLegs", new Dictionary<string, string> { { "Color 1", "#264C35" } } },

			{ "ArmorSerpentHelmet", new Dictionary<string, string> { { "Color 1", "#264C35" }, { "Color 2", "#FFFFFF" } } },
			{ "ArmorSerpentChest", new Dictionary<string, string> { { "Color 1", "#264C35" }, { "Color 2", "#FFFFFF" } } },
			{ "ArmorSerpentLegs", new Dictionary<string, string> { { "Color 1", "#264C35" }, { "Color 2", "#FFFFFF" } } },

			{ "ArmorMistlandsHelmet", new Dictionary<string, string> { { "Color 1", "#545454" }, { "Emission color", "#BF3000" } } },
			{ "ArmorMistlandsChest", new Dictionary<string, string> { { "Color 1", "#545454" }, { "Emission color", "#BF3000" } } },
			{ "ArmorMistlandsLegs", new Dictionary<string, string> { { "Color 1", "#545454" }, { "Emission color", "#BF3000" } } }
        };

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
            "ArmorNobleHelmet",
            "ArmorNobleChest",
            "ArmorNobleLegs",
            "ArmorNobleCape",

            "ArmorBarbarianBronzeHelmetJD",
            "ArmorBarbarianBronzeChestJD",
            "ArmorBarbarianBronzeLegsJD",
            "ArmorBarbarianCapeJD",

            "ArmorWarriorHelmet",
            "ArmorWarriorChest",
            "ArmorWarriorLegs",

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
