using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using JudesEquipment.Configuration;
using YamlDotNet.Serialization;

namespace JudesEquipment
{
    public static class LocalizationManager
    {
        public static Localization localizationInstance;

        public static readonly List<string> languages = new List<string>()
        {
            "English",
            "Swedish",
            "French",
            "Italian",
            "German",
            "Spanish",
            "Russian",
            "Romanian",
            "Bulgarian",
            "Macedonian",
            "Finnish",
            "Danish",
            "Norwegian",
            "Icelandic",
            "Turkish",
            "Lithuanian",
            "Czech",
            "Hungarian",
            "Slovak",
            "Polish",
            "Dutch",
            "Portuguese_European",
            "Portuguese_Brazilian",
            "Chinese",
            "Japanese",
            "Korean",
            "Hindi",
            "Thai",
            "Abenaki",
            "Croatian",
            "Georgian",
            "Greek",
            "Serbian",
            "Ukrainian"
        };

        public static void LoadLocalization()
        {
            var files = Directory.GetFiles(Paths.ConfigPath, Main.localizationFileName, SearchOption.AllDirectories).ToList();

            if(files.Count == 0)
            {
                File.WriteAllText(Path.Combine(Paths.ConfigPath, Main.localizationFileName), new SerializerBuilder().Build().Serialize(Main.localization));
                return;
            }

            try
            {
                var d = new DeserializerBuilder().Build();
                var loadedLocalization = new Dictionary<string, Dictionary<string, string>>();
                loadedLocalization = d.Deserialize<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(files[0]));

                Main.localization.Clear();
                Main.localization = loadedLocalization;
                Main.syncedLocalization.Value = new SerializerBuilder().Build().Serialize(loadedLocalization);
            }
            catch (Exception e)
            {
                Main.log.LogError(e.Message);
                Main.log.LogError(e.StackTrace);
            }
        }

        public static void InsertLocalization()
        {
            if (LocalizationManager.localizationInstance == null) return;

            string language = localizationInstance.GetSelectedLanguage();
            if (!Main.localization.ContainsKey(language)) return;
            foreach (KeyValuePair<string, string> localization in Main.localization[language])
            {
                localizationInstance.m_translations.Remove(localization.Key);
                localizationInstance.m_translations.Add(localization.Key, localization.Value);
            }
        }
    }
}
