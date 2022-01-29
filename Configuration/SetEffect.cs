using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace JudesEquipment.Configuration
{
    public class SetEffect
    {
        [YamlMember(Alias = "health regen modifier")]
        public int healthRegenModifier = 0;
        [YamlMember(Alias = "stamina regen modifier")]
        public int staminaReregenModifier = 0;
        [YamlMember(Alias = "run stamina drain modifier")]
        public int runStaminaDrainModifier = 0;
        [YamlMember(Alias = "jump stamina drain modifier")]
        public int jumpStaminaDrainModifier = 0;
        [YamlMember(Alias = "carry weight modifier")]
        public int carryWeightModifier = 0;
        [YamlMember(Alias = "skill modifier")]
        public SkillModifier skillModifier = new SkillModifier();
        [YamlMember(Alias = "damage modifiers")]
        public Dictionary<string, string> damageModifiers = new Dictionary<string, string>()
        {
            { HitData.DamageType.Blunt.ToString(), "none" },
            { HitData.DamageType.Slash.ToString(), "none" },
            { HitData.DamageType.Pierce.ToString(), "none" },
            { HitData.DamageType.Chop.ToString(), "none" },
            { HitData.DamageType.Fire.ToString(), "none" },
            { HitData.DamageType.Frost.ToString(), "none" },
            { HitData.DamageType.Lightning.ToString(), "none" },
            { HitData.DamageType.Poison.ToString(), "none" },
            { HitData.DamageType.Spirit.ToString(), "none" }

        };
        /*public Dictionary<string, string> damageModifiers = new Dictionary<string, string>()
        {
            { HitData.DamageType.Physical.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Blunt.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Slash.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Pierce.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Chop.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Fire.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Frost.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Lightning.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Poison.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Spirit.ToString(), HitData.DamageModifier.Normal.ToString() },
            { HitData.DamageType.Elemental.ToString(), HitData.DamageModifier.Normal.ToString() }

        };*/
    }

    public class SkillModifier
    {
        public string skill = "None";
        public int modifier = 0;
    }
}
