using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;
using ServerSync;

namespace JudesEquipment.Configuration
{
    public class LocalizationConfig
    {
        ConfigFile cfg;
        public Dictionary<string, ConfigEntry<string>> translationPerLanguage = new Dictionary<string, ConfigEntry<string>>();
        public Dictionary<string, string> translationDefaults = new Dictionary<string, string>();

        public string token;

        public bool Load()
        {
            cfg = Main.localizationCfgFile;

            foreach (string language in LocalizationManager.languages)
            {
                if (translationPerLanguage.ContainsKey(language))
                {
                    translationPerLanguage[language] = Sync.SyncConfig(cfg.Bind(language, token, translationDefaults.ContainsKey(language)? translationDefaults[language] : "", ""));
                    translationPerLanguage[language].SettingChanged += (object sender, EventArgs e) => { ApplyConfig(); };
                }
                else
                {
                    translationPerLanguage.Add(language, Sync.SyncConfig(cfg.Bind(language, token, translationDefaults.ContainsKey(language) ? translationDefaults[language] : "", "")));
                    translationPerLanguage[language].SettingChanged += (object sender, EventArgs e) => { ApplyConfig(); };
                }
            }

            return true;
        }

        public bool ApplyConfig()
        {
            if (LocalizationManager.localizationInstance == null) return false;

            Localization loc = LocalizationManager.localizationInstance;

            if (string.IsNullOrEmpty(translationPerLanguage[loc.GetSelectedLanguage()].Value.Trim()))
            {
                loc.m_translations.Remove(token);
                loc.m_translations.Add(token, translationPerLanguage["English"].Value);
            }
            else
            {
                loc.m_translations.Remove(token);
                loc.m_translations.Add(token, translationPerLanguage[loc.GetSelectedLanguage()].Value);
            }

            return true;
        }
    }
}
