using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Dragonslayer : JudeArmorSetConfig
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

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorDragonslayerHelmet",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 20, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "WolfPelt", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Obsidian", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "TrophyHatchling", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            JudeArmorConfig chest = new JudeArmorConfig()
            {
                prefabName = "ArmorDragonslayerChest",
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
                            item = "Silver", amount = 20, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "WolfPelt", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Obsidian", amount = 10, amountPerLevel = 3
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorDragonslayerLegs",
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
                            item = "Silver", amount = 20, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "WolfPelt", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
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
