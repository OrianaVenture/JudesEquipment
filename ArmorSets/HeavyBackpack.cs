using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class HeavyBackpack : ArmorSetConfig
    {
        public HeavyBackpack()
        {
            setEffect = new SetEffect()
            {
                carryWeightModifier = 200
            };

            ArmorConfig bag = new ArmorConfig()
            {
                prefabName = "BackpackHeavy",
                armor = 0,
                weight = 30,
                movementSpeedModifier = -5,
                baseDurability = 100,
                durabilityPerLevel = 100,
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
                            item = "DeerHide", amount = 5, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "IronNails", amount = 10, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Iron", amount = 2, amountPerLevel = 1
                        }
                    }
                }
            };

            items.Add("backpack", bag);
        }
    }
}
