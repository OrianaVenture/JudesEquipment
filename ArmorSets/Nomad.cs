using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Nomad : ArmorSetConfig
    {
        public Nomad()
        {
            setEffect = new SetEffect()
            {
                staminaReregenModifier = 15,
                carryWeightModifier = 20,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Ride.ToString(),
                    modifier = 30
                }
            };
            setEffect.damageModifiers[HitData.DamageType.Frost.ToString().ToString()] = HitData.DamageModifier.Resistant.ToString();

            int armor = 20;
            int weight = 10;

            ArmorConfig helmet = new ArmorConfig()
            {
                prefabName = "ArmorBlackmetalgarbHelmet",
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
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 5
                        }
                    }
                }
            };

            ArmorConfig chest = new ArmorConfig()
            {
                prefabName = "ArmorBlackmetalgarbChest",
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
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 5
                        }
                    }
                }
            };

            ArmorConfig legs = new ArmorConfig()
            {
                prefabName = "ArmorBlackmetalgarbLegs",
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
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 5
                        }
                    }
                }
            };

            pieces.Add("helmet", helmet);
            pieces.Add("chest", chest);
            pieces.Add("legs", legs);
        }
    }
}
