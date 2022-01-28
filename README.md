## Notes
**Do not install my Barbarian armor and Plate armor mods from nexusmods, they are included in this mod**  

Blacksmith's tools is not a hard dependency, the mod will work without it. You'll just run into armors clipping with player body.  
The mod makes no use of blacksmith's tool's bone reoder, you may disable it if you wish.  
In case of questions you may find me on the [Modding discord server](https://discord.gg/MXqWrn532w)

## Features

#### Barbarian's armor and cape
- crafted at a lvl 1 forge using bronze and deer hide, cape at a workbench using deer hide and bone fragments
- alternative to vanilla bronze armor

#### Plate armor
- crafted at a lvl 1 forge using iron and deer hide
- alternative to vanilla iron armor

#### Dragonslayer's armor
- crafted at a lvl 1 forge using silver, wolf hides, obsidian and drake trophies
- mountain tier armor

#### Nomad's armor
- crafted at a lvl 1 forge using blackmetal, lox hide and linen
- light armor, trades defense for mobility (slightly less defense than padded but does not slow the wearer down)

#### Wanderer's armor and cape
- crafted at a lvl 1 forge using iron, linen threads, flax and deer hide, cape at a workbench using flax and linen  
- mostly an alternative to padded armor
- cape provides a mostly inexpensive means to gain frost resistance

#### Mistlands armor
- crafted at a lvl 1 forge using flametal, linen threads and lox pelts  
- completely new flametal armor  
- provides constant frost resistance  

#### Simple backpack
- crafted at a lvl 1 workbench using wood, deer hide and leather scraps
- increases the wearer's carrying capacity

## Installation
Place the JudesEquipment.dll into your Bepinex/plugins folder.

## Configuration
After launching the game the mod will generate configuration files for items, recipes and localization

## Screenshots  

![Barbarian's armor](https://cdn.discordapp.com/attachments/889777555194912798/901127852618035341/barbv2.png)  
![Plate armor](https://cdn.discordapp.com/attachments/889777555194912798/901127892140978266/platev2.png)  
![Dragonslayer's armor](https://cdn.discordapp.com/attachments/889777555194912798/901127826428796938/dragonslayer.png)  
![Nomad's armor](https://cdn.discordapp.com/attachments/889777555194912798/901127888592584734/nomadgarb.png)  
![Wanderer's armor](https://cdn.discordapp.com/attachments/889777555194912798/901127896784048189/wanderer.png)  
![Mistlands armor](https://cdn.discordapp.com/attachments/830502805869559848/892789090154606682/20210929153749_1.jpg)  

## Changelog  
- **1.4.0**  
Added Dragonslayer's armor  
- **1.3.0**  
Added [blaxxun's server sync](https://github.com/blaxxun-boop/ServerSync)  
All item stats, recipes and translations should sync on connect  
Recipes and translation should sync prefectly fine while server is live when using ConfigWatcher  
Item stats also sync live but changes are only applied to items created after applying config change, changes will only take effect for already existing items after player relog  
Please let me know if there's an issue with syncing configs  
Recipes should no longer appear several times in crafting window   
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

Mistlands armor:
- ArmorMistlandsHelmet
- ArmorMistlandsChest
- ArmorMistlandsLegs  

Simple backpack:
- BackpackSimple  
