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
using YamlDotNet.Serialization;
using Tomlyn;

namespace JudesEquipment
{
 /*
 TODO:
 -serversync x
 -touch up nomad and barbarian

 */
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        #region[Bepinex stuff]

        public const string
            MODNAME = "JudesEquipment",
            AUTHOR = "GoldenJude",
            GUID = AUTHOR + "_" + MODNAME,
            VERSION = "1.4.0.1";

        public static ManualLogSource log;
        internal readonly Harmony harmony;
        public static Assembly assembly;
        public readonly string modFolder;

        #endregion

        public static readonly string bundle1Name = "judeequipment";

        public static ConfigFile itemCfgFile;
        public static ConfigFile recipeCfgFile;
        public static ConfigFile localizationCfgFile;
        public static ConfigFile mainCfgFile;

        public SyncedConfigEntry<int> lockingConfig;
        public ConfigEntry<bool> testEntry;

        public static AssetBundle bundle;

        string helloDecompilerUser;

        public Main()
        {
            log = Logger;
            harmony = new Harmony(GUID);
            assembly = Assembly.GetExecutingAssembly();
            modFolder = Path.GetDirectoryName(assembly.Location);

            helloDecompilerUser = "https://cdn.discordapp.com/attachments/535168232596963338/899392804747358208/yuyuspin.mp4";
        }

        public void Start()
        {
            harmony.PatchAll(assembly);

            itemCfgFile =           new ConfigFile(Utility.CombinePaths(Paths.ConfigPath, AUTHOR + "_" + MODNAME + "_ItemConfig"          + ".cfg"), true);
            recipeCfgFile =         new ConfigFile(Utility.CombinePaths(Paths.ConfigPath, AUTHOR + "_" + MODNAME + "_RecipeConfig"        + ".cfg"), true);
            localizationCfgFile =   new ConfigFile(Utility.CombinePaths(Paths.ConfigPath, AUTHOR + "_" + MODNAME + "_LocalizationConfig"  + ".cfg"), true);
            mainCfgFile = Config;

            lockingConfig = Sync.configSync.AddLockingConfigEntry(mainCfgFile.Bind("Sync", "Sync configs", 1, "1 = enabled, 0 = disabled"));

            ContentDispenser.DoOwnThing();

            helloDecompilerUser = helloDecompilerUser.Trim();
        }
    }
}
