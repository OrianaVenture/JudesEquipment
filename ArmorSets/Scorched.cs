using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Scorched : JudeArmorSetConfig
    {
        public Scorched()
        {
            setEffect = new SetEffect()
            {
                healthRegenModifier = 10,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Swords.ToString(),
                    modifier = 15
                }
            };
            setEffect.damageModifiers[HitData.DamageType.Fire.ToString()] = HitData.DamageModifier.Resistant.ToString();
            setEffect.damageModifiers[HitData.DamageType.Frost.ToString()] = HitData.DamageModifier.Resistant.ToString();

            int armor = 34;
            int weight = 20;
            int movementModifier = -5;

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorMistlandsHelmet",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "FlametalNew", amount = 20, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 10, amountPerLevel = 3
                        }
                    }
                }
            };

            JudeArmorConfig chest = new JudeArmorConfig()
            {
                prefabName = "ArmorMistlandsChest",
                armor = armor,
                weight = weight,
                movementSpeedModifier = movementModifier,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "FlametalNew", amount = 20, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 10, amountPerLevel = 3
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorMistlandsLegs",
                armor = armor,
                weight = weight,
                movementSpeedModifier = movementModifier,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "FlametalNew", amount = 20, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 10, amountPerLevel = 3
                        }
                    }
                }
            };

            items.Add("helmet", helmet);
            items.Add("chest", chest);
            items.Add("legs", legs);
        }
    }
}
