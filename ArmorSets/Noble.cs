using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Noble : JudeArmorSetConfig
    {
        public Noble()
        {
            setEffect = new SetEffect()
            {
                staminaReregenModifier = 5,
                healthRegenModifier = 5,
                runStaminaDrainModifier = -5
            };

            int armor = 1;
            int weight = 5;

            string craftingStation = "piece_workbench";

            string recipeItem1 = "LeatherScraps";
            int recipeItem1Amount = 5;
            int recipeItem1AmountPerLevel = 1;

            string recipeItem2 = "DeerHide";
            int recipeItem2Amount = 2;
            int recipeItem2AmountPerLevel = 1;

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorNobleHelmet",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = craftingStation,
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = recipeItem1, amount = recipeItem1Amount, amountPerLevel = recipeItem1AmountPerLevel
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = recipeItem2, amount = recipeItem2Amount, amountPerLevel = recipeItem2AmountPerLevel
                        }
                    }
                }
            };

            JudeArmorConfig chest = new JudeArmorConfig()
            {
                prefabName = "ArmorNobleChest",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = craftingStation,
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = recipeItem1, amount = recipeItem1Amount, amountPerLevel = recipeItem1AmountPerLevel
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = recipeItem2, amount = recipeItem2Amount, amountPerLevel = recipeItem2AmountPerLevel
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorNobleLegs",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = craftingStation,
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = recipeItem1, amount = recipeItem1Amount, amountPerLevel = recipeItem1AmountPerLevel
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = recipeItem2, amount = recipeItem2Amount, amountPerLevel = recipeItem2AmountPerLevel
                        }
                    }
                }
            };

            JudeArmorConfig cape = new JudeArmorConfig()
            {
                prefabName = "ArmorNobleCape",
                armor = 1,
                weight = 1,
                countsTowardsSetBonus = false,
                recipe = new JudeRecipeConfig()
                {
                    station = craftingStation,
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = recipeItem1, amount = recipeItem1Amount, amountPerLevel = recipeItem1AmountPerLevel
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
