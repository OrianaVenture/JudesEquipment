using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Barbarian : ArmorSetConfig
    {
        public Barbarian()
        {
            setEffect = new SetEffect()
            {
                staminaReregenModifier = 25,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Axes.ToString(),
                    modifier = 25
                }
            };

            int armor = 4;
            int weight = 10;

            ArmorConfig helmet = new ArmorConfig()
            {
                prefabName = "ArmorBarbarianBronzeHelmetJD",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Bronze", amount = 5, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            ArmorConfig chest = new ArmorConfig()
            {
                prefabName = "ArmorBarbarianBronzeChestJD",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Bronze", amount = 5, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            ArmorConfig legs = new ArmorConfig()
            {
                prefabName = "ArmorBarbarianBronzeLegsJD",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Bronze", amount = 5, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            ArmorConfig cape = new ArmorConfig()
            {
                prefabName = "ArmorBarbarianCapeJD",
                armor = 4,
                weight = 6,
                movementSpeedModifier = -3,
                countsTowardsSetBonus = false,
                recipe = new RecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 8, amountPerLevel = 4
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Bronze", amount = 1, amountPerLevel = 1
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "BoneFragments", amount = 5, amountPerLevel = 3
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
