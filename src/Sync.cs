﻿using ServerSync;
using BepInEx.Configuration;

namespace JudesEquipment
{
    public static class Sync
    {
        public static ConfigSync configSync = new ConfigSync(Main.GUID) 
        { 
            DisplayName = "Jude's Equipment",
            CurrentVersion = Main.VERSION,
            MinimumRequiredVersion = Main.VERSION
        };

        public static ConfigEntry<T> SyncConfig<T>(ConfigEntry<T> entry)
        {
            SyncedConfigEntry<T> syncedConfig = configSync.AddConfigEntry(entry);
            syncedConfig.SynchronizedConfig = true;
            return entry;
        }
    }
}
