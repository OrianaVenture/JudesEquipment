using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class SimpleBackpack : JudeArmorSetConfig
    {
        public SimpleBackpack()
        {
            setEffect = new SetEffect()
            {
                carryWeightModifier = 100
            };

            JudeArmorConfig bag = new JudeArmorConfig()
            {
                prefabName = "BackpackSimple",
                armor = 0,
                weight = 15,
                movementSpeedModifier = -5,
                baseDurability = 10,
                durabilityPerLevel = 10,
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
                            item = "DeerHide", amount = 5, amountPerLevel = 2
                        },
                        new JudeRecipeConfig.RequirementConfig()
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
