using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Barbarian : JudeArmorSetConfig
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

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorBarbarianBronzeHelmetJD",
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
                            item = "DeerHide", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            JudeArmorConfig chest = new JudeArmorConfig()
            {
                prefabName = "ArmorBarbarianBronzeChestJD",
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
                            item = "DeerHide", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorBarbarianBronzeLegsJD",
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
                            item = "DeerHide", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            JudeArmorConfig cape = new JudeArmorConfig()
            {
                prefabName = "ArmorBarbarianCapeJD",
                armor = 4,
                weight = 6,
                movementSpeedModifier = -3,
                countsTowardsSetBonus = false,
                recipe = new JudeRecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 8, amountPerLevel = 4
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Bronze", amount = 1, amountPerLevel = 1
                        },
                        new JudeRecipeConfig.RequirementConfig()
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
