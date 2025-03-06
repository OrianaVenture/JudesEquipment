using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Dragonslayer : ArmorSetConfig
    {
        public Dragonslayer()
        {
            setEffect = new SetEffect()
            {
                jumpStaminaDrainModifier = -25,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Jump.ToString(),
                    modifier = 30
                }
            };
            setEffect.damageModifiers[HitData.DamageType.Frost.ToString()] = HitData.DamageModifier.Resistant.ToString();

            int armor = 24;
            int weight = 20;
            int movementModifier = -5;

            ArmorConfig helmet = new ArmorConfig()
            {
                prefabName = "ArmorDragonslayerHelmet",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 20, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "WolfPelt", amount = 10, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Obsidian", amount = 10, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "TrophyHatchling", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            ArmorConfig chest = new ArmorConfig()
            {
                prefabName = "ArmorDragonslayerChest",
                armor = armor,
                weight = weight,
                movementSpeedModifier = movementModifier,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 20, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "WolfPelt", amount = 10, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Obsidian", amount = 10, amountPerLevel = 3
                        }
                    }
                }
            };

            ArmorConfig legs = new ArmorConfig()
            {
                prefabName = "ArmorDragonslayerLegs",
                armor = armor,
                weight = weight,
                movementSpeedModifier = movementModifier,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 20, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "WolfPelt", amount = 10, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Obsidian", amount = 10, amountPerLevel = 3
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
