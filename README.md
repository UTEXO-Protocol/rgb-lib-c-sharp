# rgb-lib-c-sharp

C# bindings for [rgb-lib](https://github.com/UTEXO-Protocol/rgb-lib) - RGB smart contracts library for Bitcoin.

## Installation

```bash
dotnet add package RgbLib
```

Or add to your `.csproj`:

```xml
<PackageReference Include="RgbLib" Version="0.3.0-beta.5" />
```

## Supported Platforms

- Linux x64 (`linux-x64`)
- macOS ARM64 (`osx-arm64`)
- Windows x64 (`win-x64`)

## Usage

```csharp
using RgbLib;

// Generate new keys
var keysJson = RgbLibWallet.GenerateKeys("testnet");
Console.WriteLine($"Keys: {keysJson}");

// Create wallet configuration
var walletData = @"{
    ""data_dir"": ""/tmp/rgb-wallet"",
    ""bitcoin_network"": ""testnet"",
    ""database_type"": ""sqlite"",
    ""max_allocations_per_utxo"": 5,
    ""pubkey"": ""your_pubkey_here"",
    ""mnemonic"": ""your mnemonic words here""
}";

// Create and use wallet
using (var wallet = new RgbLibWallet(walletData))
{
    // Go online
    wallet.GoOnline("ssl://electrum.blockstream.info:60002");
    
    // Get address
    var address = wallet.GetAddress();
    Console.WriteLine($"Address: {address}");
    
    // Get BTC balance
    var balance = wallet.GetBtcBalance();
    Console.WriteLine($"Balance: {balance}");
    
    // List assets
    var assets = wallet.ListAssets();
    Console.WriteLine($"Assets: {assets}");
}
```

## Low-Level API

For more control, use the `NativeMethods` class directly:

```csharp
using RgbLib;

// Direct P/Invoke calls
var result = NativeMethods.rgblib_generate_keys("testnet");
if (result.IsSuccess)
{
    Console.WriteLine(result.GetResult());
}
else
{
    Console.WriteLine($"Error: {result.GetError()}");
}
```

## Building from Source

### Prerequisites

- .NET 8.0 SDK
- Native rgb-lib library (`librgblibcffi.so`, `librgblibcffi.dylib`, or `rgblibcffi.dll`)

### Build

```bash
# Clone repository
git clone https://github.com/UTEXO-Protocol/rgb-lib-c-sharp.git
cd rgb-lib-c-sharp

# Build
dotnet build

# Run tests
dotnet test
```

## Automatic Releases

This repository is automatically updated when a new version of `rgb-lib` is released. The CI/CD pipeline:

1. Detects new `rgb-lib` release
2. Downloads pre-compiled native libraries
3. Builds C# bindings
4. Creates NuGet package
5. Publishes release

## License

MIT License

## Links

- [rgb-lib](https://github.com/UTEXO-Protocol/rgb-lib) - Main Rust library
- [rgb-lib-go](https://github.com/UTEXO-Protocol/rgb-lib-go) - Go bindings
- [rgb-lib-nodejs](https://github.com/UTEXO-Protocol/rgb-lib-nodejs) - Node.js bindings
- [csbindgen](https://github.com/Cysharp/csbindgen) - C# FFI generator
