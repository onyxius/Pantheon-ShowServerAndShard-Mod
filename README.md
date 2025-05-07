<<<<<<< HEAD
<<<<<<< HEAD
# ShowServerAndShard

A Pantheon: Rise of the Fallen mod that displays the currently selected server name below the compass UI element.

## Features

- Shows the currently selected server name in a clear, visible location
- Updates automatically when:
  - A server is pre-selected
  - A user manually selects a server
  - The server list is refreshed
- Displays in yellow text for good visibility
- Positioned below the compass for easy reference

## Technical Details

### How It Works

The mod uses Harmony patches to hook into several game events:

1. `UIRealmListItem.OnSelected` - Triggered when a user selects a server
2. `UIRealmListItem.Select` - Triggered when a server is programmatically selected
3. `UIRealmListItem.Init` - Triggered when server list items are initialized
4. `UIWindowPanel.Start` - Used to create the text display when the compass panel loads

### Implementation

- Uses TextMeshPro for text rendering
- Maintains both pre-selected and actively selected server names
- Automatically updates the display when server selection changes
- Handles both manual and automatic server selection events

### Requirements

- MelonLoader
- Pantheon: Rise of the Fallen

## Installation

1. Ensure MelonLoader is installed
2. Place the `ShowServerAndShard.dll` in your `Mods` folder
3. Launch the game

## Usage

The mod works automatically - no configuration needed. The server name will be displayed below the compass as soon as you enter the server selection screen.

## Version History

### 1.0.0
- Initial release
- Basic server name display functionality
- Automatic updates on server selection
=======
=======
>>>>>>> f70f24938c83148f5d709bd8b99ab22887e94e36
<p align="center" width="100%">
  This mod is for Pantheon: Rise of the Fallen.  It's a simple mod that displays the server and shard the player is logged into and is anchored to the bottom of the compass.
</p>
<p align="center" width="100%">
    <img width="33%" src="https://github.com/user-attachments/assets/f147c80b-3d95-45ea-9315-2734b7d23813"> 
</p>
<p align="center" width="100%">
You can get more info on modding Pantheon by joining the Mods of Pantheon discord group https://discord.gg/h96Tuk5h
</p>
<<<<<<< HEAD
>>>>>>> f70f24938c83148f5d709bd8b99ab22887e94e36
=======
>>>>>>> f70f24938c83148f5d709bd8b99ab22887e94e36
