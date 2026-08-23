# ClassicUs.Reactor

Networking framework for **Classic Us** (Among Us) BepInEx IL2CPP mods.

## Features
- **Automatic handshake** — broadcasts your mod list to all players when joining a lobby
- **Lobby tracker** — knows which players have Reactor and which mods they're running
- **Version check** — detects version mismatches across players
- **Unmodded lobby detection** — fires an event if the host doesn't have Reactor
- **Optional kick enforcement** — off by default, so host-only mods can let vanilla clients join

## Usage

```csharp
// In your BepInEx plugin Load():
ReactorAPI.Register("YourModName", "1.0.0");

// Events
ReactorAPI.OnPlayerModded += (playerId, mods) => { };
ReactorAPI.OnLobbyFullyModded += () => { };
ReactorAPI.OnJoiningUnmoddedLobby += () => { };
ReactorAPI.OnModVersionMismatch += (playerId, mod, localVer, remoteVer) => { };

// Queries
bool ok = ReactorAPI.IsCompatibleToPlay();
List<byte> unmodded = ReactorAPI.GetUnmoddedPlayers();
```

## Config (`BepInEx/config/classicus.reactor.cfg`)

- `Handshake.EnforceCompatibility` (`false` by default) — when `true`, the host
  kicks players who never send a Reactor handshake (vanilla clients) or whose
  mod set mismatches, after the handshake grace period. Leave `false` for
  **host-only** mods so unmodded/vanilla clients can join a modded lobby.

## Requirements
- BepInEx IL2CPP for Classic Us
- `ClassicUs.Reactor.dll` installed in `BepInEx/plugins/`
