using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BepInEx.Configuration;
using JudesEquipment.Configuration;
using YamlDotNet.Serialization;
using Jotunn.Utils;
using Jotunn.Entities;
using Jotunn.Managers;

namespace JudesEquipment
{
    [BepInDependency(Jotunn.Main.ModGuid)]
    [BepInDependency("com.ValheimModding.YamlDotNetDetector")]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    [BepInDependency("BlacksmithTools", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        public const string
            MODNAME = "JudesEquipment",
            AUTHOR = "GoldenJude",
            GUID = AUTHOR + "_" + MODNAME,
            VERSION = "3.0.0";

        private static string ConfigFileName = GUID + ".cfg";
        private static string ConfigFileFullPath = BepInEx.Paths.ConfigPath + Path.DirectorySeparatorChar + ConfigFileName;

        public static ManualLogSource log;
        internal readonly Harmony harmony;
        public static Assembly assembly;

        public const string bundleName = "judeequipment";
        public const string itemConfigName = GUID + "_ItemConfig.yml";
        public const string localizationconfigName = GUID + "_Localization.yml";
        public const string colorConfigName = GUID + "_Colors.yml";

        public static ConfigEntry<bool> neutralMetals;
        public static ConfigEntry<bool> smoothTextures;

        private readonly ConfigurationManagerAttributes AdminConfig = new ConfigurationManagerAttributes { IsAdminOnly = true };
        private readonly ConfigurationManagerAttributes ClientConfig = new ConfigurationManagerAttributes { IsAdminOnly = false };

        private void AddConfig<T>(string key, string section, string description, bool synced, T value, ref ConfigEntry<T> configEntry)
        {
            string extendedDescription = GetExtendedDescription(description, synced);
            configEntry = Config.Bind(section, key, value,
                new ConfigDescription(extendedDescription, null, synced ? AdminConfig : ClientConfig));
        }

        public string GetExtendedDescription(string description, bool synchronizedSetting)
        {
            return description + (synchronizedSetting ? " [Synced with Server]" : " [Not Synced with Server]");
        }

        public static Shader creatureShader;
        public static bool bsmithAvailable = false;
        public static bool hugosCollidersAvaiable = false;

        public static JudeItemConfig ModConfig = new JudeItemConfig();

        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        public static FileSystemWatcher fsw = new FileSystemWatcher()
        {
            Path = BepInEx.Paths.ConfigPath,
            IncludeSubdirectories = true,
            EnableRaisingEvents = true
        };

        public Main()
        {
            log = Logger;
            harmony = new Harmony(GUID);
            assembly = Assembly.GetExecutingAssembly();
        }

        public void Start()
        {
            harmony.PatchAll(assembly);
            bsmithAvailable = Util.IsModAvailable("BlacksmithTools", "3.0.0");
            hugosCollidersAvaiable = Util.IsModAvailable("More Player Cloth Colliders", "3.0.0");

            if (bsmithAvailable)
            {
                CreateBlacksmithsTooslConfigs();
                ItemManager.InsertBsmithToolsCfgs();
            }

            AddConfig("Appearance", "Neutral metals",
                "Makes all metals a neutral grey",
                true, false, ref neutralMetals);
            AddConfig("Appearance", "Smooth textures",
                "Removes pixelization filter on all textures, overrides color config",
                true, false, ref smoothTextures);

            string localizedJson = AssetUtils.LoadTextFromResources("Localization.English.json", Assembly.GetExecutingAssembly());
            Localization.AddJsonFile("English", localizedJson);

            ItemManager.AddItems();
            LoadColorConfig();
            SetupWatcher();
        }

        private void OnDestroy()
        {
            Config.Save();
        }

        private void SetupWatcher()
        {
            _lastReloadTime = DateTime.Now;
            FileSystemWatcher watcher = new(BepInEx.Paths.ConfigPath, ConfigFileName);
            // Due to limitations of technology this can trigger twice in a row
            watcher.Changed += ReadConfigValues;
            watcher.Created += ReadConfigValues;
            watcher.Renamed += ReadConfigValues;
            watcher.IncludeSubdirectories = true;
            watcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
            watcher.EnableRaisingEvents = true;
        }

        private DateTime _lastReloadTime;
        private const long RELOAD_DELAY = 10000000; // One second

        private void ReadConfigValues(object sender, FileSystemEventArgs e)
        {
            var now = DateTime.Now;
            var time = now.Ticks - _lastReloadTime.Ticks;
            if (!File.Exists(ConfigFileFullPath) || time < RELOAD_DELAY) return;

            try
            {
                Jotunn.Logger.LogInfo("Attempting to reload configuration...");
                Config.Reload();
            }
            catch
            {
                Jotunn.Logger.LogError($"There was an issue loading {ConfigFileName}");
                return;
            }

            _lastReloadTime = now;
            // TODO: add back
            //modConfig.ApplyArmorConfigs();
            //modConfig.ApplyRecipeConfigs();
            //modConfig.ApplySetEffects();
        }

        public static void LoadColorConfig()
        {
            List<string> list = Directory.GetFiles(
                BepInEx.Paths.ConfigPath, colorConfigName, SearchOption.AllDirectories).ToList<string>();

            if (list.Count == 0)
            {
                File.WriteAllText(Path.Combine(BepInEx.Paths.ConfigPath, colorConfigName),
                    new SerializerBuilder().Build().Serialize(ItemManager.colorConfig));
            }
            else
            {
                var loadedColorConfig = new Dictionary<string, Dictionary<string, string>>();
                try
                {
                    loadedColorConfig = new DeserializerBuilder().Build()
                        .Deserialize<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(list[0]));
                    ItemManager.colorConfig = loadedColorConfig;
                }
                catch (Exception ex)
                {
                    Main.log.LogWarning("An error occured when loading " + colorConfigName + ", will use default values");
                    Main.log.LogWarning(ex.Message);
                    Main.log.LogWarning(ex.StackTrace);
                }
            }
        }

        public static void CreateBlacksmithsTooslConfigs()
        {
            if (!bsmithAvailable) return;

            //nobruh armor
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorNobleChest",
                bonesToHide = Util.TorsoUpperLowerArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorNobleLegs",
                bonesToHide = Util.CompleteLegs
            });

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

            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorWarriorLegs",
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
        }
    }
}
