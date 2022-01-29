## Notes
**Do not install my Barbarian armor and Plate armor mods from nexusmods, they are included in this mod**  

Blacksmith's tools is not a hard dependency, the mod will work without it. You'll just run into armors clipping with player body.  
The mod makes no use of blacksmith's tool's bone reoder, you may disable it if you wish.  
Use the mod on a server to sync configs.  
In case of questions you may find me on the [Modding discord server](https://discord.gg/MXqWrn532w)

## Features

#### Barbarian's armor and cape
- crafted at a forge using bronze and deer hide, cape at a workbench using deer hide and bone fragments
- light black forest tier armor set

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
Modifiers for health regen, stamina regen and jump and sprint stamina drain are in percentages therefore ``health regen modifier: 25`` will increase health regen by 25%  
Valid values for damage modifiers are: ``Ignore, Immune, Normal, Resistant, VeryResistant, VeryWeak, Weak``  
List for Valheim's vanilla skill list: ``None, All, Axes, Blocking, Bows, Clubs, Jump, Knives, Pickaxes, Polearms, Ride, Run, Sneak, Spears, Swim, Swords, Unarmed, WoodCutting``  
Names for crafting stations and items can be found on the Valheim wiki under ``Internal ID``

## Screenshots  

![Barbarian's armor](https://cdn.discordapp.com/attachments/889777555194912798/919176996771221534/barbarmor200.png)  
![Plate armor](https://cdn.discordapp.com/attachments/889777555194912798/901127892140978266/platev2.png)  
![Dragonslayer's armor](https://cdn.discordapp.com/attachments/889777555194912798/901127826428796938/dragonslayer.png)  
![Nomad's armor](https://cdn.discordapp.com/attachments/889777555194912798/936890070789677106/nomad200.png)  
![Wanderer's armor](https://cdn.discordapp.com/attachments/889777555194912798/901127896784048189/wanderer.png)  
![Serpent armor](https://cdn.discordapp.com/attachments/889777555194912798/936555888087535647/serpent.png)
![Scorched armor](https://cdn.discordapp.com/attachments/830502805869559848/892789090154606682/20210929153749_1.jpg)  

## Changelog  
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

Barbarian armor:  
- ArmorBarbarianBronzeHelmetJD  
- ArmorBarbarianBronzeChestJD  
- ArmorBarbarianBronzeLegsJD  
- ArmorBarbarianCapeJD  
  
Plate armor:  
- ArmorPlateIronHelmetJD  
- ArmorPlateIronChestJD  
- ArmorPlateIronLegsJD  
- ArmorPlateCape

Dragonslayer armor:  
- ArmorDragonslayerHelmet  
- ArmorDragonslayerChest  
- ArmorDragonslayerLegs  

Nomad armor:
- ArmorBlackmetalgarbHelmet  
- ArmorBlackmetalgarbChest  
- ArmorBlackmetalgarbLegs  

Wanderer armor:
- ArmorWandererHelmet
- ArmorWandererChest
- ArmorWandererLegs
- ArmorWandererCape

Serpetn armor:
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
