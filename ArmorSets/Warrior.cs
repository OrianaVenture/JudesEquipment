using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Warrior : ArmorSetConfig
    {
        public Warrior()
        {
            setEffect = new SetEffect()
            {
                healthRegenModifier = 10,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Polearms.ToString(),
                    modifier = 15
                }
            };
            setEffect.damageModifiers[HitData.DamageType.Slash.ToString()] = HitData.DamageModifier.Resistant.ToString();

            int armor = 6;
            int weight = 15;
            int movementModifier = -5;

            ArmorConfig helmet = new ArmorConfig()
            {
                prefabName = "ArmorWarriorHelmet",
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
                            item = "DeerHide", amount = 3, amountPerLevel = 1
                        }
                    }
                }
            };

            ArmorConfig chest = new ArmorConfig()
            {
                prefabName = "ArmorWarriorChest",
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
                            item = "Bronze", amount = 5, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 3, amountPerLevel = 1
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Stone", amount = 20, amountPerLevel = 0
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Raspberry", amount = 20, amountPerLevel  = 0
                        }
                    }
                }
            };

            ArmorConfig legs = new ArmorConfig()
            {
                prefabName = "ArmorWarriorLegs",
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
                            item = "Bronze", amount = 5, amountPerLevel = 3
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "DeerHide", amount = 3, amountPerLevel = 1
                        }
                    }
                }
            };

            items.Add("helmet", helmet);
            items.Add("chest", chest);
            items.Add("legs", legs);
        }
    }
}
