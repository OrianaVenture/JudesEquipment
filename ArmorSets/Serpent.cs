using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Serpent : ArmorSetConfig
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

            ArmorConfig helmet = new ArmorConfig()
            {
                prefabName = "ArmorSerpentHelmet",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 10, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 2
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "TrophySerpent", amount = 2, amountPerLevel = 0
                        }
                    }
                }
            };

            ArmorConfig chest = new ArmorConfig()
            {
                prefabName = "ArmorSerpentChest",
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
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 10, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 5, amountPerLevel = 2
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "SerpentScale", amount = 5, amountPerLevel = 2
                        }
                    }
                }
            };

            ArmorConfig legs = new ArmorConfig()
            {
                prefabName = "ArmorSerpentLegs",
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
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 10, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 5, amountPerLevel = 2
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "SerpentScale", amount = 5, amountPerLevel = 2
                        }
                    }
                }
            };

            ArmorConfig cape = new ArmorConfig()
            {
                prefabName = "ArmorSerpentCape",
                armor = 3,
                weight = 6,
                recipe = new RecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Silver", amount = 5, amountPerLevel = 1
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 5
                        }
                    }
                }
            };
            cape.damageModifiers[HitData.DamageType.Frost.ToString()] = HitData.DamageModifier.Resistant.ToString();

            pieces.Add("helmet", helmet);
            pieces.Add("chest", chest);
            pieces.Add("legs", legs);
            pieces.Add("cape", cape);
        }
    }
}
