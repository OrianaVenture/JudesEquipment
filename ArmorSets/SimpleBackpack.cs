using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class SimpleBackpack : ArmorSetConfig
    {
        public SimpleBackpack()
        {
            setEffect = new SetEffect()
            {
                carryWeightModifier = 100
            };

            ArmorConfig bag = new ArmorConfig()
            {
                prefabName = "BackpackSimple",
                armor = 0,
                weight = 15,
                movementSpeedModifier = -5,
                baseDurability = 10,
                durabilityPerLevel = 10,
                recipe = new RecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Wood", amount = 20, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 5, amountPerLevel = 2
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LeatherScraps", amount = 10, amountPerLevel = 5
                        }
                    }
                }
            };

            items.Add("backpack", bag);
        }
    }
}
