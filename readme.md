# TorrentSearchNet

**A small library that helps with finding torrents for legal file sharing.**  
Supports searching and file inspection through multiple torrent APIs.

NuGet: [TorrentSearchNet on nuget.org](https://www.nuget.org/packages/TorrentSearchNet)

---

## 📦 Installation

Install via NuGet:

```bash
dotnet add package TorrentSearchNet
```

---

## 🚀 Quick Start

Search for torrents:

```csharp
using TorrentSearchNet;

SearchResult result = await TorrentFinder.SearchAsync("ubuntu", Category.AppOther);

foreach (TorrentFileInfo file in result.Files)
{
    Console.WriteLine(file); // see output example below for what this outputs
    Console.WriteLine(file.GetMagnetLink()); // see output example below
}
```
## 📤 Output Example

```text
Ubuntu 22.04 ISO | AppOther | 3,155 MB | Seeders: 195 | Leechers: 12 | Added: 2024-06-01 | By: linuxfan
magnet:?xt=urn:btih:ABC123...&dn=Ubuntu+22.04+ISO&tr=...
```
---

### Get the files contained in a torrent:

```csharp
ContainedFilesResult contents = await TorrentFinder.GetContainedFilesAsync("36418511");

foreach (ContainedFilesInfo file in contents.Files)
{
    Console.WriteLine($"{file.Name} - {file.Size} bytes");
}
```

### 🔗 Generate a Magnet Link

You can easily get a magnet link from a `TorrentFileInfo`:

```csharp
TorrentFileInfo file = ...;
MagnetLink magnet = file.GetMagnetLink();
Console.WriteLine(magnet); // prints the full magnet URI
```

---

## ⚙️ Configuration

### 🔌 Adding Custom Providers

You can add your own implementations of `ITorrentApi` using:

```csharp
TorrentFinder.AddTorrentApi(new MyCustomApi());
```

By default, the library uses a built-in provider called `PhpApi`, which targets the PirateBay-like API structure. Adding your own `ITorrentApi` allows you to extend or replace the default behavior, e.g., to support private trackers or alternative backends.

---

### 🌐 Setting the PhpApi Base URL

The default base URL for the `PhpApi` is:

```csharp
PhpApiSettings.Url = "https://apibay.org";
```

You can override it to point to any other compatible API:

```csharp
PhpApiSettings.Url = "https://thepiratebay.cloud";
```

---

### 📡 Magnet Link Trackers

By default, generated magnet links include public trackers. You can view and modify them using:

```csharp
MagnetLinkSettings.PublicTrackers.Add("udp://your.custom.tracker:1337/announce");
MagnetLinkSettings.PublicTrackers.RemoveAt(0); // if you want to remove defaults
```

---

## 📄 Models

### TorrentFileInfo

- `.Name` — Display name of the torrent
- `.InfoHash` — The info hash used in the magnet link
- `.Size` — Size in bytes
- `.Seeders`, `.Leechers` — Stats
- `.Category` — Enum-based category
- `.GetMagnetLink()` — Returns a `MagnetLink` instance

### ContainedFilesInfo

- `.Name` — File name inside the torrent
- `.Size` — File size in bytes

---

## 🧪 Testing

You can run your own unit tests using MSTest or another compatible test framework. The library is designed to be testable, with mockable APIs via `ITorrentApi`.

---

## ⚖️ Legal Disclaimer

Torrenting and peer-to-peer file sharing are not inherently illegal. This library is intended **solely** for legal use cases, such as downloading or distributing open-source software, public domain content, or other freely licensed material.

Illegal activity, such as sharing or downloading copyrighted material without proper authorization, **is illegal** and may result in legal consequences depending on your jurisdiction.

> The developer of this library does **not condone**, support, or take responsibility for the misuse of this library in any unlawful manner. Use responsibly.

---

## 📚 License

MIT License
