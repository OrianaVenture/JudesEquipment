using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Plate : JudeArmorSetConfig
    {
        public Plate()
        {
            setEffect = new SetEffect()
            {
                healthRegenModifier = 10,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Blocking.ToString(),
                    modifier = 20
                }
            };

            int armor = 18;
            int weight = 20;
            int movementModifier = -5;

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorPlateIronHelmetJD",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Iron", amount = 20, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 5, amountPerLevel = 1
                        }
                    }
                }
            };

            JudeArmorConfig chest = new JudeArmorConfig()
            {
                prefabName = "ArmorPlateIronChestJD",
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
                            item = "Iron", amount = 25, amountPerLevel = 8
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 5, amountPerLevel = 1
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorPlateIronLegsJD",
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
                            item = "Iron", amount = 25, amountPerLevel = 8
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 5, amountPerLevel = 1
                        }
                    }
                }
            };

            JudeArmorConfig cape = new JudeArmorConfig()
            {
                prefabName = "ArmorPlateCape",
                armor = 4,
                weight = 8,
                movementSpeedModifier = -3,
                countsTowardsSetBonus = false,
                recipe = new JudeRecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "TrophyBoar", amount = 3, amountPerLevel = 1
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Iron", amount = 2, amountPerLevel = 1
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LeatherScraps", amount = 10, amountPerLevel = 5
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
