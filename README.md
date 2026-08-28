# Jude's Equipment

This mod is brought to you by GoldenJude, now maintained with the help of VentureValheim. Please direct all comments and issues to OrianaVenture on discord or at [Venture Gaming](https://discord.gg/tAd5hapt88). To make a report on github please do so under the specified project fork.

## Notes

Blacksmith's tools is not a hard dependency, the mod will work without it. You'll just run into armors clipping with player body.
The mod makes no use of blacksmith's tool's bone reoder, you may disable it if you wish.

Using [Hugo's more and modified cloth colliders](https://valheim.thunderstore.io/package/HugotheDwarf/More_and_Modified_Player_Cloth_Colliders/) improves some armor's cloth physics

## Features

#### Noble's garb
- crafted at a workbench using deer hides and leather scraps
- scraps/leather tier set

#### Barbarian's armor and cape
- crafted at a forge using bronze and deer hide, cape at a workbench using deer hide and bone fragments
- light black forest tier armor set

#### Warrior's armor
- crafted at a forge using bronze and deer hide, chest additionally required stone and raspberries
- black forest tier armor set

#### Plate armor
- crafted at a forge using iron and deer hide
- swamp tier armor set

#### Dragonslayer's armor
- crafted at a forge using silver, wolf hides, obsidian and drake trophies
- mountain tier armor

#### Nomad's armor
- crafted at a forge using blackmetal, lox hide and linen
- light plains tier armor set

#### Wanderer's armor and cape
- crafted at a forge using iron, linen threads, flax and deer hide, cape at a workbench using flax and linen
- plains tier armor set

#### Serpent armor and cape
- crafted at a forge using blackmetal, silver, lox pelts, serpent scales and serpent trophies, cape at a workbench using silver and linen
- legs have cloth physics if using HugoTheDwarf's ``More and Modified Player Cloth Colliders`` mod

#### Scorched armor
- crafted at a forge using flametal, linen threads and lox pelts
- ashlands tier armor 

#### Simple backpack
- crafted at a workbench using wood, deer hide and leather scraps
- increases the wearer's maximum carry weight

#### Heavy backpack
- crafted at a workbench using iron nails, wood, deer hide and leather scraps
- increases the wearer's maximum carry weight

## Installation

This mod needs to be on both the client and server; the mod will enforce installation. Players without the mod will NOT be able to connect to the server. Must install all dependencies for the mod to load. (Jotunn, Yaml.NET)

## Configuration

Not currently supported. USe another mod like [RecipeManager](https://thunderstore.io/c/valheim/p/MidnightMods/RecipeManager/) to change these items! Prefab IDs are listed below.

Each armor piece's metallic color can be adjusted in ``JudesEquipment_Colors.yml`` to fit custom materials, this config is not synced

## Screenshots

![Noble's armor](https://i.imgur.com/27fNBDK.png)
![Barbarian's armor](https://i.imgur.com/DFJndwi.png)
![Warrior's armor](https://i.imgur.com/FoGXfvB.png)
![Plate armor](https://i.imgur.com/JWWaUo0.png)
![Dragonslayer's armor](https://i.imgur.com/Fnuibrp.png)
![Nomad's armor](https://i.imgur.com/ZIolSid.png)
![Wanderer's armor](https://i.imgur.com/9Np33y7.png)
![Serpent armor](https://i.imgur.com/R4cwT8l.png)
![Scorched armor](https://i.imgur.com/2pUbuUI.jpg)

## Item IDs

Noble's armor:
- ArmorNobleHelmet
- ArmorNobleChest
- ArmorNobleLegs
- ArmorNobleCape

Barbarian's armor:
- ArmorBarbarianBronzeHelmetJD
- ArmorBarbarianBronzeChestJD
- ArmorBarbarianBronzeLegsJD
- ArmorBarbarianCapeJD

Warrior's armor:
- ArmorWarriorHelmet
- ArmorWarriorChest
- ArmorWarriorLegs

Plate armor:
- ArmorPlateIronHelmetJD
- ArmorPlateIronChestJD
- ArmorPlateIronLegsJD
- ArmorPlateCape

Dragonslayer's armor:
- ArmorDragonslayerHelmet
- ArmorDragonslayerChest
- ArmorDragonslayerLegs

Nomad's armor:
- ArmorBlackmetalgarbHelmet
- ArmorBlackmetalgarbChest
- ArmorBlackmetalgarbLegs

Wanderer's armor:
- ArmorWandererHelmet
- ArmorWandererChest
- ArmorWandererLegs
- ArmorWandererCape

Serpent armor:
- ArmorSerpentHelemt
- ArmorSerpentChest
- ArmorSerpentLegs
- ArmorSerpentCape

Scorched armor:
- ArmorMistlandsHelmet
- ArmorMistlandsChest
- ArmorMistlandsLegs

Simple backpack:
- BackpackSimple

Heavy backpack:
- BackpackHeavy