using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using JudesEquipment.Configuration;
using ServerSync;

namespace JudesEquipment
{
    //dont like having all the content defitinots in main, so here it goes
    [HarmonyPatch]
    public static class ContentDispenser
    {
        /*
            Armor config header format - ARMOR NAME (Barbarian Armor) - piece (Helmet, Chest, Legs, Cape, Utility etc..)
        */
        public static void DoOwnThing()
        {
            AssetBundle bundle = Util.LoadBundle(Main.bundle1Name);

            #region ITEMS

            //BARBARIAN ARMOR
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorBarbarianBronzeHelmetJD", bundle),

                configHeader = "Barbarian Armor - Helmet",

                def_MovementSpeedModifier = 0,

                def_Weight = 3,
                def_Armor = 8,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1000,
                def_DurabilityPerLevel = 200
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorBarbarianBronzeChestJD", bundle),

                configHeader = "Barbarian Armor - Chest",

                def_Weight = 10,
                def_Armor = 8,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1000,
                def_DurabilityPerLevel = 200
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorBarbarianBronzeLegsJD", bundle),

                configHeader = "Barbarian Armor - Legs",

                def_Weight = 10,
                def_Armor = 8,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1000,
                def_DurabilityPerLevel = 200
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorBarbarianCapeJD", bundle),

                configHeader = "Barbarian Armor - Cape",

                def_MovementSpeedModifier = 0,

                def_Weight = 4,
                def_Armor = 1,
                def_ArmorPerLevel = 1,
                def_BaseDurability = 400,
                def_DurabilityPerLevel = 50
            });

            //PLATE ARMOR
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorPlateIronHelmetJD", bundle),

                configHeader = "Plate Armor - Helmet",

                def_MovementSpeedModifier = 0,

                def_Weight = 3,
                def_Armor = 14,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1200,
                def_DurabilityPerLevel = 200
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorPlateIronChestJD", bundle),

                configHeader = "Plate Armor - Chest",

                def_Weight = 15,
                def_Armor = 14,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1200,
                def_DurabilityPerLevel = 200
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorPlateIronLegsJD", bundle),

                configHeader = "Plate Armor - Legs",

                def_Weight = 15,
                def_Armor = 14,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1200,
                def_DurabilityPerLevel = 200
            });

            //DRAGONSLAYER IRON
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorDragonslayerHelmet", bundle),

                configHeader = "Dragonslayer Armor - Helmet",

                def_Weight = 5,
                def_Armor = 25,
                def_MovementSpeedModifier = 0
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorDragonslayerChest", bundle),

                configHeader = "Dragonslayer Armor - Chest",

                def_Weight = 20,
                def_Armor = 25,
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorDragonslayerLegs", bundle),

                configHeader = "Dragonslayer Armor - Legs",

                def_Weight = 20,
                def_Armor = 25
            });

            //BLACKMETAL GARB
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorBlackmetalgarbHelmet", bundle),

                configHeader = "Nomad Armor - Helmet",

                def_MovementSpeedModifier = 0,

                def_Weight = 3,
                def_Armor = 20,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1000,
                def_DurabilityPerLevel = 200
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorBlackmetalgarbChest", bundle),

                configHeader = "Nomad Armor - Chest",

                def_MovementSpeedModifier = 0,

                def_Weight = 6,
                def_Armor = 20,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1000,
                def_DurabilityPerLevel = 200
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorBlackmetalgarbLegs", bundle),

                configHeader = "Nomad Armor - Legs",

                def_MovementSpeedModifier = 0,

                def_Weight = 6,
                def_Armor = 20,
                def_ArmorPerLevel = 2,
                def_BaseDurability = 1000,
                def_DurabilityPerLevel = 200
            });

            //WANDERER ARMOR
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorWandererHelmet", bundle),

                configHeader = "Wanderer Armor - Helmet",

                def_Weight = 3,
                def_Armor = 26,
                def_MovementSpeedModifier = 0
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorWandererChest", bundle),

                configHeader = "Wanderer Armor - Chest",

                def_Weight = 10,
                def_Armor = 26
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorWandererLegs", bundle),

                configHeader = "Wanderer Armor - Legs",

                def_Weight = 10,
                def_Armor = 26
            });
            ItemManager.AddItem(new CapeConfig()
            {
                configHeader = "Wanderer Armor - Cape",

                prefabToClone = "CapeLox",
                prefabNameOverride = "ArmorWandererCape",
                materialOverride = bundle.LoadAsset<Material>("roninCapeMat"),
                iconOverride = bundle.LoadAsset<Sprite>("capeicon"),

                def_Weight = 3,
                def_Armor = 1,
                def_ArmorPerLevel = 1,
                def_damageModPairs = "Fire:Weak;Frost:Resistant",
                def_MovementSpeedModifier = 0,
                def_BaseDurability = 300,
                def_DurabilityPerLevel = 100
            });

            //MISTLANDS ARMOR
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorMistlandsHelmet", bundle),

                configHeader = "Mistlands Armor - Helmet",

                def_Weight = 10,
                def_Armor = 32,
                def_damageModPairs = "Frost:Resistant",
                def_MovementSpeedModifier = 0
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorMistlandsChest", bundle),

                configHeader = "Mistlands Armor - Chest",

                def_Weight = 10,
                def_Armor = 32,
                def_damageModPairs = "Frost:Resistant"
            });
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = Util.PullGoFromAB("ArmorMistlandsLegs", bundle),

                configHeader = "Mistlands Armor - Legs",

                def_Weight = 10,
                def_Armor = 32,
                def_damageModPairs = "Frost:Resistant"
            });



            //BACKPACK
            ItemManager.AddItem(new BackpackConfig()
            {
                prefab = Util.PullGoFromAB("BackpackSimple", bundle),

                configHeader = "Simple backpack",

                def_carryWeightBonus = 100,

                def_Weight = 5,
                def_Armor = 0,
                def_ArmorPerLevel = 0,
                def_BaseDurability = 50,
                def_DurabilityPerLevel = 25,

                def_destroyBroken = true
            });

            AssetBundle crusaderbundle = Util.LoadBundle("crusader");
            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = crusaderbundle.LoadAsset<GameObject>("ArmorCrusaderHelmet"),

                configHeader = "Crusader Armor",

                def_Armor = 10
            });

            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = crusaderbundle.LoadAsset<GameObject>("ArmorCrusaderChest"),

                configHeader = "Crusader Armor",

                def_Armor = 10
            });

            ItemManager.AddItem(new ArmorConfig()
            {
                prefab = crusaderbundle.LoadAsset<GameObject>("ArmorCrusaderLegs"),

                configHeader = "Crusader Armor",

                def_Armor = 10
            });

            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorCrusaderChest",
                bonesToHide = Util.TorsoUpperLowerArms
            });

            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorCrusaderLegs",
                bonesToHide = Util.CompleteLegs
            });

            #endregion

            #region RECIPES

            //BARBARIAN ARMOR
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Barbarian Armor - Helmet",

                outputPrefabName = "ArmorBarbarianBronzeHelmetJD",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Bronze;5;3",
                def_itemRequirement2 = "DeerHide;2;0",
                def_itemRequirement3 = "",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Barbarian Armor - Chest",

                outputPrefabName = "ArmorBarbarianBronzeChestJD",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Bronze;5;3",
                def_itemRequirement2 = "DeerHide;2;0",
                def_itemRequirement3 = "",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Barbarian Armor - Legs",

                outputPrefabName = "ArmorBarbarianBronzeLegsJD",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Bronze;5;3",
                def_itemRequirement2 = "DeerHide;2;0",
                def_itemRequirement3 = "",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Barbarian Armor - Cape",

                outputPrefabName = "ArmorBarbarianCapeJD",
                def_craftingStation = "piece_workbench",
                def_minStationLvl = 1,

                def_itemRequirement1 = "DeerHide;4;4",
                def_itemRequirement2 = "BoneFragments;5;5",
                def_itemRequirement3 = "",
                def_itemRequirement4 = ""
            });

            //PLATE ARMOR
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Plate Armor - Helmet",

                outputPrefabName = "ArmorPlateIronHelmetJD",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Iron;20;5",
                def_itemRequirement2 = "DeerHide;2;0",
                def_itemRequirement3 = "",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Plate Armor - Chest",

                outputPrefabName = "ArmorPlateIronChestJD",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Iron;20;5",
                def_itemRequirement2 = "DeerHide;2;0",
                def_itemRequirement3 = "",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Plate Armor - Legs",

                outputPrefabName = "ArmorPlateIronLegsJD",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Iron;20;5",
                def_itemRequirement2 = "DeerHide;2;0",
                def_itemRequirement3 = "",
                def_itemRequirement4 = ""
            });

            //DRAGONSLAYER ARMOR
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Dragonslayer Armor - Helmet",

                outputPrefabName = "ArmorDragonslayerHelmet",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Silver;20;5",
                def_itemRequirement2 = "WolfPelt;10;5",
                def_itemRequirement3 = "Obsidian;10;5",
                def_itemRequirement4 = "TrophyHatchling;2;0"
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Dragonslayer Armor - Chest",

                outputPrefabName = "ArmorDragonslayerChest",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Silver;15;5",
                def_itemRequirement2 = "WolfPelt;10;5",
                def_itemRequirement3 = "Obsidian;10;5",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Dragonslayer Armor - Legs",

                outputPrefabName = "ArmorDragonslayerLegs",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Silver;15;5",
                def_itemRequirement2 = "WolfPelt;10;5",
                def_itemRequirement3 = "Obsidian;10;5",
                def_itemRequirement4 = ""
            });

            //NOMAD ARMOR
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Nomad Armor - Helmet",

                outputPrefabName = "ArmorBlackmetalgarbHelmet",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "BlackMetal;20;5",
                def_itemRequirement2 = "LoxPelt;10;5",
                def_itemRequirement3 = "LinenThread;20;5",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Nomad Armor - Chest",
                outputPrefabName = "ArmorBlackmetalgarbChest",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "BlackMetal;20;5",
                def_itemRequirement2 = "LoxPelt;10;5",
                def_itemRequirement3 = "LinenThread;20;5",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Nomad Armor - Legs",

                outputPrefabName = "ArmorBlackmetalgarbLegs",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "BlackMetal;20;5",
                def_itemRequirement2 = "LoxPelt;10;5",
                def_itemRequirement3 = "LinenThread;20;5",
                def_itemRequirement4 = ""
            });

            //WANDERER ARMOR
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Wanderer Armor - Helmet",

                outputPrefabName = "ArmorWandererHelmet",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Flax;15;5",
                def_itemRequirement2 = "Iron;10;5",
                def_itemRequirement3 = "LinenThread;10;0",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Wanderer Armor - Chest",

                outputPrefabName = "ArmorWandererChest",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Iron;10;5",
                def_itemRequirement2 = "LinenThread;10;2",
                def_itemRequirement3 = "DeerHide;10;2",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Wanderer Armor - Legs",

                outputPrefabName = "ArmorWandererLegs",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Iron;10;5",
                def_itemRequirement2 = "LinenThread;10;2",
                def_itemRequirement3 = "DeerHide;10;2",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Wanderer Armor - Cape",

                outputPrefabName = "ArmorWandererCape",
                def_craftingStation = "piece_workbench",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Flax;10;5",
                def_itemRequirement2 = "LinenThread;5;1",
                def_itemRequirement3 = "",
                def_itemRequirement4 = ""
            });
            
            //MISTLANDS ARMOR
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Mistlands Armor - Helmet",

                outputPrefabName = "ArmorMistlandsHelmet",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Flametal;15;5",
                def_itemRequirement2 = "LoxPelt;10;5",
                def_itemRequirement3 = "LinenThread;10;0",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Mistlands Armor - Chest",

                outputPrefabName = "ArmorMistlandsChest",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Flametal;15;5",
                def_itemRequirement2 = "LoxPelt;10;5",
                def_itemRequirement3 = "LinenThread;10;0",
                def_itemRequirement4 = ""
            });
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Mistlands Armor - Legs",

                outputPrefabName = "ArmorMistlandsLegs",
                def_craftingStation = "forge",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Flametal;15;5",
                def_itemRequirement2 = "LoxPelt;10;5",
                def_itemRequirement3 = "LinenThread;10;0",
                def_itemRequirement4 = ""
            });



            //SIMPLE BACKPACK
            RecipeManager.AddRecipe(new RecipeConfig()
            {
                configHeader = "Simple backpack",

                outputPrefabName = "BackpackSimple",
                def_craftingStation = "piece_workbench",
                def_minStationLvl = 1,

                def_itemRequirement1 = "Wood;20;5",
                def_itemRequirement2 = "DeerHide;5;2",
                def_itemRequirement3 = "LeatherScraps;10;5",
                def_itemRequirement4 = ""
            });

            #endregion

            #region LOCALIZATION

            //BARBARIAN ARMOR
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBarbarianBronzeHelmetJD",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Barbarian's helmet" },
                    { @"Czech", @"Barbarova přilba" },
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBarbarianBronzeHelmetJD_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Helmet made of a bronze alloy" },
                    { @"Czech", @"Přilba z bronzové slitiny" },
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBarbarianBronzeChestJD",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Barbarian's armor" },
                    { @"Czech", @"Barbarova zbroj" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBarbarianBronzeChestJD_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"A bronze disc attached to leather straps, a true barbarian hurls himself into battle despite the lack of protection" },
                    { @"Czech", @"Bronzový disk připevněny ke koženým popruhům, pravý barabr se vrhá do boje i přes nedostatek ochrany" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBarbarianBronzeLegsJD",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Barbarian's belt" },
                    { @"Czech", @"Barbarův opasek" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBarbarianBronzeLegsJD_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Thick hide wrapped around one's waist, fastened with a fashionable bronze belt" },
                    { @"Czech", @"Tlustá kožešina ovázaná kolem pasu a upevněna pohledným bronzovým popruhem" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBarbarianCapeJD",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Barbarian's fur cape" },
                    { @"Czech", @"Barbarův kožešinový plášť" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBarbarianCapeJD_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Thick but short cape made of fur. Covers ones back when his drunk raidmates can't." },
                    { @"Czech", @"Tlustý, ale krátký plášť z kožešiny, chrání záda, když opilý spolunájezdníci nemohou" }
                }
            });

            //NOMAD ARMOR
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBlackmetalgarbHelmet",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Nomadic helmet" },
                    { @"Czech", @"Nomádská přilba" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBlackmetalgarbHelmet_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Helmet made of blackmetal with colorful padding fit for a nomad" },
                    { @"Czech", @"Přilba z černokovu s barevným polstrováním sedící na nomáda" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBlackmetalgarbChest",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Nomadic garb" },
                    { @"Czech", @"Nomádský oděv" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBlackmetalgarbChest_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"A nomadic garb adorned with protective elements made of blackmetal, found commonly in the nomad's homeland, the plains" },
                    { @"Czech", @"Nomádský oděv ověšený ochranou z černokovu, jenž je v nomádím domově, pláních, hojno" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBlackmetalgarbLegs",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Nomadic boots" },
                    { @"Czech", @"Nomádská obuv" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorBlackmetalgarbLegs_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Thick leather boots with blackmetal toe guard, helpful when one happens to get stomped on by a Lox" },
                    { @"Czech", @"Silné kožené boty s černokovovou špičkou, užitečné když se stane, že na vlastníka dupne lox" }
                }
            });

            //PLATE ARMOR
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorPlateIronHelmetJD",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Sturdy helmet" },
                    { @"Czech", @"Pevná přilba" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorPlateIronHelmetJD_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"A sturdy helmet with a leather neckguard" },
                    { @"Czech", @"Odolná helma s koženou ochranou krku" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorPlateIronChestJD",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Plate mail" },
                    { @"Czech", @"Plátová zbroj" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorPlateIronChestJD_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Thick plates of metal riveted to a leather harness" },
                    { @"Czech", @"Silné kovové pláty přinýtované ke koženému postroji" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorPlateIronLegsJD",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Plate greaves" },
                    { @"Czech", @"Plátové holenice" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorPlateIronLegsJD_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Reliable greaves and kneeguards" },
                    { @"Czech", @"Spolehlivé holenice s chráničy kolen" }
                }
            });

            //DRAGONSLAYER ARMOR
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorDragonslayerHelmet",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Dragonslayer's helm" },
                    { @"Czech", @"Drakobijcova přilba" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorDragonslayerHelmet_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Dragon's tremble in fear when they see the blackened helmet adorned with the horns of their kin" },
                    { @"Czech", @"Draci se klepou strachy když vidí tu začerněno přilbu ozdobenou rohy jejich vlastních" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorDragonslayerChest",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Dragonslayer's armor" },
                    { @"Czech", @"Drakobijcova zbroj" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorDragonslayerChest_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Obsidian layer over silver plates provides reliable protection" },
                    { @"Czech", @"Obsidiánová vrstva na stříbrných plátech poskytuje spolehlivou ochranu" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorDragonslayerLegs",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Spiked greaves" },
                    { @"Czech", @"Špičaté holenice" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorDragonslayerLegs_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Unlucky is he who finds himself in the way of these" },
                    { @"Czech", @"Kdokoliv se ocitne v jejich cestě bude mít špatný den" }
                }
            });

            //WANDERER ARMOR
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorWandererHelmet",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Wanderer's straw hat" },
                    { @"Czech", @"Tulákův slamník" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorWandererHelmet_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"A reinforced straw hat" },
                    { @"Czech", @"Vyztužený slamník" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorWandererChest",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Wanderer's coat of plates" },
                    { @"Czech", @"Tulákova plátová vesta" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorWandererChest_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Small metal plates attached to a leather jerkin, easy to maintain during travels" },
                    { @"Czech", @"Malé kovové pláty přišité na koženou vestu, lehké na údržbu při cestách" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorWandererLegs",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Wanderer's pants" },
                    { @"Czech", @"Tulákovy kalhoty" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorWandererLegs_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Durable pants with makeshift protection around the shins" },
                    { @"Czech", @"Odolné kalhoty s provizorní ochranou okolo holení" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorWandererCape",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Straw cape" },
                    { @"Czech", @"Slaměný plášť" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorWandererCape_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Cheap to make cape made from straw collected in the plains, protects against the elements but is quick to catch fire" },
                    { @"Czech", @"Levný na vytvoření plášť ze slámy posbírané v pláních, ochrání proti živlům ale lehce lehne popelem" }
                }
            });

            //MISTLANDS ARMOR
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorMistlandsHelmet",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Mistlands helmet" },
                    { @"Czech", @"Mlhokrajná prilba" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorMistlandsHelmet_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Helmet made from a rare material only found within the mistlands" },
                    { @"Czech", @"Helma ukována ze vzácného materiálu nalezitelného pouze v mlžných krajích" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorMistlandsChest",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Mistlands armor" },
                    { @"Czech", @"Mlhokrajná zbroj" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorMistlandsChest_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Thick, multi layered gambeson provides protection from the searing heat of flametal, which in turns protects from blows" },
                    { @"Czech", @"Tlustá vícevrstvá přošívanice chrání před žhavým plamenokovem, který zase chrání před údery" }
                }
            });

            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorMistlandsLegs",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Mistlands greaves" },
                    { @"Czech", @"Mlhokrajné holenice" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "ArmorMistlandsLegs_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"One need not fear the cold while wearing these" },
                    { @"Czech", @"Při nošení těchto holenic nachlazení určite nehrozí" }
                }
            });

            //simple backpack
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "BackpackSimple",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Simple backpack" },
                    { @"Czech", @"Prostý batoh" }
                }
            });
            LocalizationManager.AddLocalizationCfg(new LocalizationConfig()
            {
                token = "BackpackSimple_description",
                translationDefaults = new Dictionary<string, string>()
                {
                    { @"English", @"Leather container attached to a wooden frame" },
                    { @"Czech", @"Kožená nádoba přivázaná k dřevěnému rámu" }
                }
            });

            #endregion

            #region BSMITHTOOLS

            //blackmetalgarb
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorBlackmetalgarbChest",
                bonesToHide = Util.TorsoUpperLowerArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorBlackmetalgarbLegs",
                bonesToHide = Util.CompleteLegs
            });
            //barbarian legs
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorBarbarianBronzeLegsJD",
                bonesToHide = Util.CompleteLegs
            });
            //ronin armor
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorWandererChest",
                bonesToHide = Util.TorsoUpperArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorWandererLegs",
                bonesToHide = Util.CompleteLegs
            });
            //ronin armor
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorMistlandsChest",
                bonesToHide = Util.TorsoUpperLowerArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorMistlandsLegs",
                bonesToHide = Util.CompleteLegs
            });

            //skyrim iron

            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorDragonslayerChest",
                bonesToHide = Util.TorsoUpperArms
            });
            ItemManager.bsmithCfgs.Add(new BlacksmithsToolsConfig()
            {
                itemName = "ArmorDragonslayerLegs",
                bonesToHide = Util.CompleteLegs
            });

            #endregion

            //item config applying
            ItemManager.InsertBsmithToolsCfgs();

            bundle.Unload(false);
        }
    }
}
