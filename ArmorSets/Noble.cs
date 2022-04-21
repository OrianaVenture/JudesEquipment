using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Noble : ArmorSetConfig
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

            ArmorConfig helmet = new ArmorConfig()
            {
                prefabName = "ArmorNobleHelmet",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = craftingStation,
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = recipeItem1, amount = recipeItem1Amount, amountPerLevel = recipeItem1AmountPerLevel
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = recipeItem2, amount = recipeItem2Amount, amountPerLevel = recipeItem2AmountPerLevel
                        }
                    }
                }
            };

            ArmorConfig chest = new ArmorConfig()
            {
                prefabName = "ArmorNobleChest",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = craftingStation,
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = recipeItem1, amount = recipeItem1Amount, amountPerLevel = recipeItem1AmountPerLevel
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = recipeItem2, amount = recipeItem2Amount, amountPerLevel = recipeItem2AmountPerLevel
                        }
                    }
                }
            };

            ArmorConfig legs = new ArmorConfig()
            {
                prefabName = "ArmorNobleLegs",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = craftingStation,
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = recipeItem1, amount = recipeItem1Amount, amountPerLevel = recipeItem1AmountPerLevel
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = recipeItem2, amount = recipeItem2Amount, amountPerLevel = recipeItem2AmountPerLevel
                        }
                    }
                }
            };

            ArmorConfig cape = new ArmorConfig()
            {
                prefabName = "ArmorNobleCape",
                armor = 1,
                weight = 1,
                countsTowardsSetBonus = false,
                recipe = new RecipeConfig()
                {
                    station = craftingStation,
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
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
