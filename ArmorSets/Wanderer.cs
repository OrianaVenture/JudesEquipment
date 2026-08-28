using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Wanderer : JudeArmorSetConfig
    {
        public Wanderer()
        {
            setEffect = new SetEffect()
            {
                staminaReregenModifier = 15,
                carryWeightModifier = 50,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Swords.ToString(),
                    modifier = 15
                }
            };

            int armor = 22;
            int weight = 10;
            int movementModifier = -3;

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorWandererHelmet",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Flax", amount = 15, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Iron", amount = 10, amountPerLevel = 3
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
                prefabName = "ArmorWandererChest",
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
                            item = "Iron", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 10
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorWandererLegs",
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
                            item = "Iron", amount = 10, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 10
                        }
                    }
                }
            };

            JudeArmorConfig cape = new JudeArmorConfig()
            {
                prefabName = "ArmorWandererCape",
                armor = 2,
                weight = 5,
                countsTowardsSetBonus = false,
                recipe = new JudeRecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Flax", amount = 15, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Iron", amount = 10, amountPerLevel = 3
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
            items.Add("cape", cape);
        }
    }
}
