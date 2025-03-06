using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Plate : ArmorSetConfig
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

            ArmorConfig helmet = new ArmorConfig()
            {
                prefabName = "ArmorPlateIronHelmetJD",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Iron", amount = 20, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 5, amountPerLevel = 1
                        }
                    }
                }
            };

            ArmorConfig chest = new ArmorConfig()
            {
                prefabName = "ArmorPlateIronChestJD",
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
                            item = "Iron", amount = 25, amountPerLevel = 8
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 5, amountPerLevel = 1
                        }
                    }
                }
            };

            ArmorConfig legs = new ArmorConfig()
            {
                prefabName = "ArmorPlateIronLegsJD",
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
                            item = "Iron", amount = 25, amountPerLevel = 8
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 5, amountPerLevel = 1
                        }
                    }
                }
            };

            ArmorConfig cape = new ArmorConfig()
            {
                prefabName = "ArmorPlateCape",
                armor = 4,
                weight = 8,
                movementSpeedModifier = -3,
                countsTowardsSetBonus = false,
                recipe = new RecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "TrophyBoar", amount = 3, amountPerLevel = 1
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Iron", amount = 2, amountPerLevel = 1
                        },
                        new RecipeConfig.RequirementConfig()
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
