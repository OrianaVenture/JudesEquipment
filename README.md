## Notes
**Do not install my Barbarian armor and Plate armor mods from nexusmods, they are included in this mod**  

Blacksmith's tools is not a hard dependency, the mod will work without it. You'll just run into armors clipping with player body.  
The mod makes no use of blacksmith's tool's bone reoder, you may disable it if you wish.  
Use the mod on a server to sync configs.  
Using [Hugo's more and modified cloth colliders](https://valheim.thunderstore.io/package/HugotheDwarf/More_and_Modified_Player_Cloth_Colliders/) improves some armor's cloth physics  
In case of questions you may find me on the [Odin Plus discord server](https://discord.gg/Pb6bVMnFb2)

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
Place the JudesEquipment.dll into your Bepinex/plugins folder.

## Configuration
After launching the game the mod will generate configuration files for items, recipes and localization  

Item stats and recipes can be edited in ``GoldenJude_JudesEquipment_ItemConfig.yml``  
Localization can be edited in ``GoldenJude_JudesEquipment_Localization.yml``  
Armor metal colors and emission can be edited in ``GoldenJude_JudesEquipment_Colors.yml`` using hex color codes  
  
Modifiers for health regen, stamina regen and jump and sprint stamina drain are in percentages therefore ``health regen modifier: 25`` will increase health regen by 25%  
Valid values for damage modifiers are: ``Ignore, Immune, Normal, Resistant, VeryResistant, VeryWeak, Weak``  
List for Valheim's vanilla skill list: ``None, All, Axes, Blocking, Bows, Crossbows, Clubs, Jump, Knives, Pickaxes, Polearms, Ride, Run, Sneak, Spears, Swim, Swords, Unarmed, WoodCutting, ElementalMagic, BloodMagic, Fishing``  
Names for crafting stations and items can be found on the Valheim wiki under ``Internal ID``  

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

## Changelog  
- **2.2.3 (i guess)**
Updated ServerSync  
Recompiled for new latest Valheim update  
- **2.2.1**  
Updated ServerSync to 1.13  
- **2.2.1**  
Updated ServerSync to 1.12  
- **2.2.1**  
Updated ServerSync  
- **2.2.0**  
Added Noble's armor  
- **2.1.1**  
Reupload with correct mod icon  
- **2.1.0**  
Added Warrior's armor  
Added ``JudesEquipment_Colors.yml`` config for changing the metallic color of armor parts  
- **2.0.3**  
Probably fixed the odd bug with chaos armor losing it's blacksmith's tools configs
- **2.0.2**  
Made localization fall back to English again
- **2.0.1**  
Fixed configs not applying item weight   
- **2.0.0**  
Added Serpent armor set  
Added Heavy backpack  
Added Boar cape to the Plate armor set  
Tweaked most of the existing armor meshes and textures  
**New configuration:**
  - item and recipe configs are now in the ``JudesEquipment_config.yml`` file
  - localization is in the ``JudesEquipment_localization.yml`` file
  - added set bonuses to item config
  - no longer syncing the entirety of the known universe    
- **1.4.0**  
Added Dragonslayer's armor  
- **1.3.0**  
Added [blaxxun's server sync](https://github.com/blaxxun-boop/ServerSync)  
All item stats, recipes and translations sync on connect
- **1.2.1**  
Fixed OpenDatabase incompatibiity  
- **1.2.0**  
Added Mistlands armor  
Adjusted Wanderer's helmet weight to match vanilla padded helmet  
- **1.1.2**  
Fixed localization not falling back to English    
- **1.1.1**  
Added Vulkan support  
- **1.1.0**  
Added Wanderer's armor  
Added damage modifiers to armor configs  
- **1.0.2**  
Fixed some localization errors  
- **1.0.1**  
Fixed incorrect section names for the simple backpack and nomad chest armor in item config  
Added missing blacksmiths tools configuration for barbarian's legs  
- **1.0.0**  
Initial upload  

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