using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Warrior : JudeArmorSetConfig
    {
        public Warrior()
        {
            setEffect = new SetEffect()
            {
                healthRegenModifier = 10,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Polearms.ToString(),
                    modifier = 15
                }
            };
            setEffect.damageModifiers[HitData.DamageType.Slash.ToString()] = HitData.DamageModifier.Resistant.ToString();

            int armor = 6;
            int weight = 15;
            int movementModifier = -5;

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorWarriorHelmet",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Bronze", amount = 5, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 3, amountPerLevel = 1
                        }
                    }
                }
            };

            JudeArmorConfig chest = new JudeArmorConfig()
            {
                prefabName = "ArmorWarriorChest",
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
                            item = "Bronze", amount = 5, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 3, amountPerLevel = 1
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Stone", amount = 20, amountPerLevel = 0
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Raspberry", amount = 20, amountPerLevel  = 0
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorWarriorLegs",
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
                            item = "Bronze", amount = 5, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 3, amountPerLevel = 1
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
