using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudesEquipment.Configuration;

namespace JudesEquipment
{
    public static class LocalizationManager
    {
        public static Localization localizationInstance;

        public static List<LocalizationConfig> localizationCfgs = new List<LocalizationConfig>();
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

        public static void AddLocalizationCfg(LocalizationConfig cfg)
        {
            localizationCfgs.Add(cfg);
            cfg.Load();
        }

        public static void InsertLocalization()
        {
            if (LocalizationManager.localizationInstance == null) return;

            for (int i = 0; i < localizationCfgs.Count; i++)
            {
                localizationCfgs[i].ApplyConfig();
            }
        }
    }
}
