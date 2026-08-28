using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class HeavyBackpack : JudeArmorSetConfig
    {
        public HeavyBackpack()
        {
            setEffect = new SetEffect()
            {
                carryWeightModifier = 200
            };

            JudeArmorConfig bag = new JudeArmorConfig()
            {
                prefabName = "BackpackHeavy",
                armor = 0,
                weight = 30,
                movementSpeedModifier = -5,
                baseDurability = 100,
                durabilityPerLevel = 100,
                recipe = new JudeRecipeConfig()
                {
                    station = "piece_workbench",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "Wood", amount = 20, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 5, amountPerLevel = 3
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "IronNails", amount = 10, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
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
