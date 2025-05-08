<p align="center" width="100%">
    <img width="33%" src="https://github.com/user-attachments/assets/f147c80b-3d95-45ea-9315-2734b7d23813"> 
</p>

## ShowServerAndShard

A Pantheon: Rise of the Fallen mod that displays the currently selected server name below the compass UI element.

## Features

- **Displays Server Name:** Shows the currently selected server name in a clear, visible location.
- **Automatic Updates:** Updates when:
  - A server is pre-selected
  - A user manually selects a server
  - The server list is refreshed
- **Easy to Read:** Uses yellow TextMeshPro text for high visibility.
- **Smart Positioning:** Positioned below the compass for easy reference.

## Installation

### Manual Method

1. **Install MelonLoader** (if you haven't already).
2. **Download** `ShowServerAndShard.dll` from the [Releases](https://github.com/onyxius/ShowServerAndShard/releases) page.
3. **Place** `ShowServerAndShard.dll` in your game's `Mods` folder:
   ```
   <Pantheon Game Directory>/Mods/
   ```

### Automatic Method

For easy management and automatic updates of all available Pantheon mods, use the [ModsOfPantheonClient](https://github.com/ModsOfPantheon/ModsOfPantheonClient).

## Usage

- Launch the game.
- The server name will be displayed below the compass as soon as you enter the server selection screen.
- No configuration or setup is required.

## Technical Details

- **Harmony Patches:** Hooks into several game events:
  1. `UIRealmListItem.OnSelected` - Triggered when a user selects a server
  2. `UIRealmListItem.Select` - Triggered when a server is programmatically selected
  3. `UIRealmListItem.Init` - Triggered when server list items are initialized
  4. `UIWindowPanel.Start` - Used to create the text display when the compass panel loads
- **Text Rendering:** Uses TextMeshPro for crisp, modern text.
- **State Tracking:** Maintains both pre-selected and actively selected server names.
- **Automatic Updates:** Updates the display when server selection changes, handling both manual and automatic events.

## Version History

### 1.0.1
- Initial release
- Basic server name display functionality
- Automatic updates on server selection

## Community & Resources

- [Mods of Pantheon Discord](https://discord.gg/h96Tuk5h) – Get help, share mods, and join the community.
- [ModsOfPantheonClient](https://github.com/ModsOfPantheon/ModsOfPantheonClient) – Tool for downloading and deploying mods.

---

*This mod is not affiliated with or endorsed by Visionary Realms or Pantheon: Rise of the Fallen.*
