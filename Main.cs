using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ServerSync;
using BepInEx.Configuration;
using JudesEquipment.Configuration;
using YamlDotNet.Serialization;

namespace JudesEquipment
{
    [BepInDependency("Jotunn", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("BlacksmithTools", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        #region[Bepinex stuff]

        public const string
            MODNAME = "JudesEquipment",
            AUTHOR = "GoldenJude",
            GUID = AUTHOR + "_" + MODNAME,
            VERSION = "2.0.0";

        public static ManualLogSource log;
        internal readonly Harmony harmony;
        public static Assembly assembly;
        public readonly string modFolder;

        #endregion

        public const string bundleName = "judeequipment";
        public const string configName = "JudesEquipment_config.yml";
        public const string localizationFileName = "JudesEquipment_localization.yml";
        public const string setEffectLocalizationToken = "SetEffect";

        public static CustomSyncedValue<string> syncedModConfig = new CustomSyncedValue<string>(Sync.configSync, "JE_config");
        public static CustomSyncedValue<string> syncedLocalization = new CustomSyncedValue<string>(Sync.configSync, "JE_localization");
        public static SyncedConfigEntry<int> lockingConfig;
        public static ConfigEntry<bool> neutralMetals;
        public static ConfigEntry<bool> smoothTextures;
        public static Shader creatureShader;
        public static bool bsmithAvailable = false;
        public static bool hugosCollidersAvaiable = false;

        public static ModConfig modConfig = new ModConfig();
        public static Dictionary<string, Dictionary<string, string>> localization = new Dictionary<string, Dictionary<string, string>>()
        {
            { "English", new Dictionary<string, string>() }
        };

        public static FileSystemWatcher fsw = new FileSystemWatcher()
        {
            Path = Paths.ConfigPath,
            IncludeSubdirectories = true,
            EnableRaisingEvents = true
        };

        public Main()
        {
            log = Logger;
            harmony = new Harmony(GUID);
            assembly = Assembly.GetExecutingAssembly();
            modFolder = Path.GetDirectoryName(assembly.Location);
        }

        public void Start()
        {
            harmony.PatchAll(assembly);
            bsmithAvailable = Util.IsModAvailable("BlacksmithTools", "2.0.0");
            hugosCollidersAvaiable = Util.IsModAvailable("More Player Cloth Colliders", "3.0.0");
            
            if (bsmithAvailable)
            {
                CreateBlacksmithsTooslConfigs();
                ItemManager.InsertBsmithToolsCfgs();
            }

            lockingConfig = Sync.configSync.AddLockingConfigEntry(Config.Bind("Sync", "Sync configs", 1, "1 = enabled, 0 = disabled"));
            neutralMetals = Config.Bind("Appearance", "Neutral metals", false, "Makes all metals a neutral grey");
            smoothTextures = Config.Bind("Appearance", "Smooth textures", false, "Removes pixelization filter on all textures");

            CreateDefaultLocalization();

            syncedModConfig.ValueChanged += () =>
            {
                modConfig = new DeserializerBuilder().Build().Deserialize<ModConfig>(syncedModConfig.Value);
                modConfig.ApplyArmorConfigs();
                modConfig.ApplyRecipeConfigs();
                modConfig.ApplySetEffects();
            };
            syncedLocalization.ValueChanged += () =>
            {
                localization = new DeserializerBuilder().Build().Deserialize<Dictionary<string, Dictionary<string, string>>>(syncedLocalization.Value);
                LocalizationManager.InsertLocalization();
            };

            fsw.Changed += (object sender, FileSystemEventArgs e) =>
            {
                if (!Sync.configSync.IsSourceOfTruth) return;

                if (Path.GetFileName(e.FullPath) == configName)
                {
                    LoadModConfig();
                }
                if(Path.GetFileName(e.FullPath) == localizationFileName)
                {
                    LocalizationManager.LoadLocalization();
                }
            };
        }

        public static void LoadModConfig()
        {
            List<string> files = Directory.GetFiles(Paths.ConfigPath, configName, SearchOption.AllDirectories).ToList();
            if (files.Count == 0)
            {
                File.WriteAllText(Path.Combine(Paths.ConfigPath, configName), new SerializerBuilder().Build().Serialize(modConfig));
                return;
            }

            modConfig = new DeserializerBuilder().Build().Deserialize<ModConfig>(File.ReadAllText(files[0]));
            syncedModConfig.Value = new SerializerBuilder().Build().Serialize(modConfig);
        }

        void CreateDefaultLocalization()
        {
            localization["English"].Add(setEffectLocalizationToken, "Set effect");

            localization["English"].Add("ArmorBarbarianBronzeHelmetJD", "Barbarian's helmet");
            localization["English"].Add("ArmorBarbarianBronzeHelmetJD_description", "Helmet made from a bronze alloy");
            localization["English"].Add("ArmorBarbarianBronzeChestJD", "Barbarian's armor");
            localization["English"].Add("ArmorBarbarianBronzeChestJD_description", "A bronze disc attached to leather straps, a true barbarian hurls himself into battle despite the lack of protection");
            localization["English"].Add("ArmorBarbarianBronzeLegsJD", "Barbarian's boots");
            localization["English"].Add("ArmorBarbarianBronzeLegsJD_description", "Thick hide wrapped around one's waist, fastened with a fashionable bronze belt");
            localization["English"].Add("ArmorBarbarianCapeJD", "Barbarian's fur cape");
            localization["English"].Add("ArmorBarbarianCapeJD_description", "Thick, short cape made from fur. Covers ones back when his drunk raidmates can't.");

            localization["English"].Add("ArmorPlateIronHelmetJD", "Sturdy helmet");
            localization["English"].Add("ArmorPlateIronHelmetJD_description", "A sturdy helmet with a leather neckguard");
            localization["English"].Add("ArmorPlateIronChestJD", "Plate mail");
            localization["English"].Add("ArmorPlateIronChestJD_description", "Thick plates of metal riveted to a leather harness");
            localization["English"].Add("ArmorPlateIronLegsJD", "Plate greaves");
            localization["English"].Add("ArmorPlateIronLegsJD_description", "Reliable greaves and kneeguards");
            localization["English"].Add("ArmorPlateCape", "Boar cape");
            localization["English"].Add("ArmorPlateCape_description", "Reinforced boar hide worn around one's shoulders like a trophy");

            localization["English"].Add("ArmorDragonslayerHelmet", "Horned helm");
            localization["English"].Add("ArmorDragonslayerHelmet_description", "Dragon's tremble in fear when they see the blackened helmet adorned with the horns of their kin");
            localization["English"].Add("ArmorDragonslayerChest", "Dragonslayer's armor");
            localization["English"].Add("ArmorDragonslayerChest_description", "Obsidian layer over silver plates makes for reliable protection");
            localization["English"].Add("ArmorDragonslayerLegs", "Spiked greaves");
            localization["English"].Add("ArmorDragonslayerLegs_description", "Unlucky is he who finds himself in the way of these");

            localization["English"].Add("ArmorWandererHelmet", "Straw hat");
            localization["English"].Add("ArmorWandererHelmet_description", "A reinforced straw hat");
            localization["English"].Add("ArmorWandererChest", "Coat of plates");
            localization["English"].Add("ArmorWandererChest_description", "Small metal plates attached to a leather jerkin, easy to maintain during travels");
            localization["English"].Add("ArmorWandererLegs", "Wanderer's pants");
            localization["English"].Add("ArmorWandererLegs_description", "Durable pants with makeshift protection around the shins");
            localization["English"].Add("ArmorWandererCape", "Straw cape");
            localization["English"].Add("ArmorWandererCape_description", "Cheap to make cape made from straw collected in the plains, protects against the elements but is quick to catch fire");

            localization["English"].Add("ArmorBlackmetalgarbHelmet", "Nomadic helmet");
            localization["English"].Add("ArmorBlackmetalgarbHelmet_description", "Blackmetal helmet with colorful padding fit for a nomad");
            localization["English"].Add("ArmorBlackmetalgarbChest", "Nomadic garb");
            localization["English"].Add("ArmorBlackmetalgarbChest_description", "A nomadic garb adorned with protective elements made from blackmetal, found commonly in the nomad's homeland, the plains");
            localization["English"].Add("ArmorBlackmetalgarbLegs", "Nomadic boots");
            localization["English"].Add("ArmorBlackmetalgarbLegs_description", "Thick leather boots with blackmetal toe guard, helpful when one happens to get stomped on by a Lox");

            localization["English"].Add("ArmorSerpentHelmet", "Finned helm");
            localization["English"].Add("ArmorSerpentHelmet_description", "A thick blackmetal casque adorned by the fins of a mighty serpent. The style is popular with raiding knights of the South.");
            localization["English"].Add("ArmorSerpentChest", "Serpent armor");
            localization["English"].Add("ArmorSerpentChest_description", "Plates of blackmetal overtop a surcoat of sea serpent scales. The perfect garb for spreading Odin's good word.");
            localization["English"].Add("ArmorSerpentLegs", "Serpent Cuisses");
            localization["English"].Add("ArmorSerpentLegs_description", "Blackmetal cuisses, greaves and sabatons. Excellent protection with a slightly fishy smell.");
            localization["English"].Add("ArmorSerpentCape", "Serpent knight's cape");
            localization["English"].Add("ArmorSerpentCape_description", "Heavy dark cape of the Serpent order.");

            localization["English"].Add("ArmorMistlandsHelmet", "Scorched sallet");
            localization["English"].Add("ArmorMistlandsHelmet_description", "Helmet made from a rare material only found within the ashlands");
            localization["English"].Add("ArmorMistlandsChest", "Scorched armor");
            localization["English"].Add("ArmorMistlandsChest_description", "Thick, multi layered gambeson provides protection from the searing heat of flametal, which in turns protects from blows");
            localization["English"].Add("ArmorMistlandsLegs", "Scorched greaves");
            localization["English"].Add("ArmorMistlandsLegs_description", "One need not fear the cold while wearing these");

            localization["English"].Add("BackpackSimple", "Simple backpack");
            localization["English"].Add("BackpackSimple_description", "Leather container attached to a wooden frame");

            localization["English"].Add("BackpackHeavy", "Heavy backpack");
            localization["English"].Add("BackpackHeavy_description", "Large chest hauled on ones shoulders with a canvas bag for additional storage");
        }

        void CreateBlacksmithsTooslConfigs()
        {
            if (!bsmithAvailable) return;


            //blackmetalgarb
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorBlackmetalgarbChest",
                bonesToHide = Util.TorsoUpperArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorBlackmetalgarbLegs",
                bonesToHide = Util.CompleteLegs
            });
            //barbarian legs
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorBarbarianBronzeLegsJD",
                bonesToHide = Util.CompleteLegs
            });

            //ronin armor
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorWandererChest",
                bonesToHide = Util.TorsoUpperArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorWandererLegs",
                bonesToHide = Util.CompleteLegs
            });

            //dragonslayer armor
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorDragonslayerChest",
                bonesToHide = Util.TorsoUpperArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorDragonslayerLegs",
                bonesToHide = Util.CompleteLegs
            });

            //ashlands armor
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorMistlandsChest",
                bonesToHide = Util.TorsoUpperLowerArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorMistlandsLegs",
                bonesToHide = Util.CompleteLegs
            });

            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorSerpentChest",
                bonesToHide = Util.TorsoUpperLowerArms
            });

            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorSerpentLegs",
                bonesToHide = Util.CompleteLegs
            });

            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorKnightChest",
                bonesToHide = Util.TorsoUpperLowerArms
            });

            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorKnightLegs",
                bonesToHide = Util.CompleteLegs
            });
        }
    }
}
