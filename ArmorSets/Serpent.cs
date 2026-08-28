using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Serpent : JudeArmorSetConfig
    {
        public Serpent()
        {
            setEffect = new SetEffect()
            {
                staminaReregenModifier = 15,
                healthRegenModifier = 15,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Swim.ToString(),
                    modifier = 30
                }
            };

            int armor = 30;
            int weight = 20;
            int movementModifier = -5;

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorSerpentHelmet",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 2
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "TrophySerpent", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            JudeArmorConfig chest = new JudeArmorConfig()
            {
                prefabName = "ArmorSerpentChest",
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
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 5, amountPerLevel = 2
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "SerpentScale", amount = 5, amountPerLevel = 2
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorSerpentLegs",
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
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 5, amountPerLevel = 2
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "SerpentScale", amount = 5, amountPerLevel = 2
                        }
                    }
                }
            };

            JudeArmorConfig cape = new JudeArmorConfig()
            {
                prefabName = "ArmorSerpentCape",
                armor = 3,
                weight = 6,
                recipe = new JudeRecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 5, amountPerLevel = 1
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 5
                        }
                    }
                }
            };
            cape.damageModifiers[HitData.DamageType.Frost.ToString()] = HitData.DamageModifier.Resistant.ToString();

            items.Add("helmet", helmet);
            items.Add("chest", chest);
            items.Add("legs", legs);
            items.Add("cape", cape);
        }
    }
}
