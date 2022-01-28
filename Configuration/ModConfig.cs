using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BepInEx;
using YamlDotNet.Serialization;
using JudesEquipment.ArmorSets;

namespace JudesEquipment.Configuration
{
    public class ModConfig
    {
        [YamlMember(Alias = "armor sets")]
        public Dictionary<string, ArmorSetConfig> armorSets = new Dictionary<string, ArmorSetConfig>()
        {
            { "barbarian's armor", new Barbarian() },
            { "plate armor", new Plate() },
            { "dragonslayer's armor", new Dragonslayer() },
            { "wanderer's armor", new Wanderer() },
            { "nomad's armor", new Nomad() },
            { "serpent armor", new Serpent() },
            { "scorched armor", new Scorched() },
            { "simple backpack", new SimpleBackpack() },
            { "heavy backpack", new HeavyBackpack() }
        };

        public void ApplyArmorConfigs()
        {
            armorSets.Values.ToList().ForEach(set => set.ApplyArmorConfigs());
        }

        public void ApplyRecipeConfigs()
        {
            armorSets.Values.ToList().ForEach(set => set.ApplyRecipeConfigs());
        }

        public void ApplySetEffects()
        {
            armorSets.Values.ToList().ForEach(set => set.ApplySetConfig(set.pieces.Values.First().prefabName));
        }
    }
}
