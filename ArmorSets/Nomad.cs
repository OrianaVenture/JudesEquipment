using System.Collections.Generic;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Nomad : JudeArmorSetConfig
    {
        public Nomad()
        {
            setEffect = new SetEffect()
            {
                runStaminaDrainModifier = -15,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Run.ToString(),
                    modifier = 25
                }
            };
            setEffect.damageModifiers[HitData.DamageType.Frost.ToString().ToString()] = HitData.DamageModifier.Resistant.ToString();

            int armor = 20;
            int weight = 10;

            JudeArmorConfig helmet = new JudeArmorConfig()
            {
                prefabName = "ArmorBlackmetalgarbHelmet",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 5
                        }
                    }
                }
            };

            JudeArmorConfig chest = new JudeArmorConfig()
            {
                prefabName = "ArmorBlackmetalgarbChest",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 5
                        }
                    }
                }
            };

            JudeArmorConfig legs = new JudeArmorConfig()
            {
                prefabName = "ArmorBlackmetalgarbLegs",
                armor = armor,
                weight = weight,
                recipe = new JudeRecipeConfig()
                {
                    station = "forge",
                    requirements = new List<JudeRecipeConfig.RequirementConfig>()
                    {
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "BlackMetal", amount = 15, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new JudeRecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 20, amountPerLevel = 5
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
