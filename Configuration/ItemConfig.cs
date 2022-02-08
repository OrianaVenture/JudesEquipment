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
    public class ItemConfig
    {
        [YamlMember(Alias = "barbarian's armor")]
        public Barbarian barbarian = new Barbarian();

        [YamlMember(Alias = "warrior's armor")]
        public Warrior warrior = new Warrior();

        [YamlMember(Alias = "plate armor")]
        public Plate plate = new Plate();

        [YamlMember(Alias = "dragonslayer's armor")]
        public Dragonslayer dragonslayer = new Dragonslayer();

        [YamlMember(Alias = "wanderer's armor")]
        public Wanderer wanderer = new Wanderer();

        [YamlMember(Alias = "nomad's armor")]
        public Nomad nomad = new Nomad();

        [YamlMember(Alias = "serpent armor")]
        public Serpent serpent = new Serpent();

        [YamlMember(Alias = "scorched armor")]
        public Scorched scorched = new Scorched();

        [YamlMember(Alias = "simple backpack")]
        public SimpleBackpack simpleBackpack = new SimpleBackpack();

        [YamlMember(Alias = "heavy backpack")]
        public HeavyBackpack heavyBackpack = new HeavyBackpack();

        [YamlIgnore]
        private List<ArmorSetConfig> Sets => new List<ArmorSetConfig>()
        {
            barbarian,
            warrior,
            plate,
            dragonslayer,
            wanderer,
            nomad,
            serpent,
            scorched,
            simpleBackpack,
            heavyBackpack
        };

        public void ApplyArmorConfigs()
        {
            Sets.ForEach(set => set.ApplyArmorConfigs());
        }

        public void ApplyRecipeConfigs()
        {
            Sets.ForEach(set => set.ApplyRecipeConfigs());
        }

        public void ApplySetEffects()
        {
            Sets.ForEach(set => set.ApplySetConfig(set.items.Values.First().prefabName));
        }
    }
}
