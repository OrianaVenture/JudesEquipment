using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudesEquipment.Configuration;

namespace JudesEquipment.ArmorSets
{
    public class Scorched : ArmorSetConfig
    {
        public Scorched()
        {
            setEffect = new SetEffect()
            {
                healthRegenModifier = 10,
                skillModifier = new SkillModifier()
                {
                    skill = Skills.SkillType.Swords.ToString(),
                    modifier = 15
                }
            };
            setEffect.damageModifiers[HitData.DamageType.Fire.ToString()] = HitData.DamageModifier.Resistant.ToString();
            setEffect.damageModifiers[HitData.DamageType.Frost.ToString()] = HitData.DamageModifier.Resistant.ToString();

            int armor = 34;
            int weight = 20;
            int movementModifier = -5;

            ArmorConfig helmet = new ArmorConfig()
            {
                prefabName = "ArmorMistlandsHelmet",
                armor = armor,
                weight = weight,
                recipe = new RecipeConfig()
                {
                    station = "forge",
                    requirements = new List<RecipeConfig.RequirementConfig>()
                    {
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "Flametal", amount = 20, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 10, amountPerLevel = 3
                        }
                    }
                }
            };

            ArmorConfig chest = new ArmorConfig()
            {
                prefabName = "ArmorMistlandsChest",
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
                            item = "Flametal", amount = 20, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 10, amountPerLevel = 3
                        }
                    }
                }
            };

            ArmorConfig legs = new ArmorConfig()
            {
                prefabName = "ArmorMistlandsLegs",
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
                            item = "Flametal", amount = 20, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LoxPelt", amount = 10, amountPerLevel = 5
                        },
                        new RecipeConfig.RequirementConfig()
                        {
                            item = "LinenThread", amount = 10, amountPerLevel = 3
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
