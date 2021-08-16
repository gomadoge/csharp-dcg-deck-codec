# C# DCG deck codec

A C# implementation of the [DCG deck codec](https://github.com/niamu/digimon-card-game). The reference implementation is written by [niamu](https://github.com/niamu).

# Prerequisites

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

# Usage

This repository contains a CLI to decode and encode deck codecs. It is located at ``src/GomaDoge.DCG.DeckCodec.CLI``. If you want to use it in your own code simply add a reference to ``src/GomaDoge.DCG.DeckCodec``. In the future, a NuGet package will be provided.

## Decode

### Command Line

```shell
dotnet run --project src/GomaDoge.DCG.DeckCodec.CLI decode DCGAREdU1QxIEHBU1QxIE_CwcHBwUHBwUFBwcHBQUFTdGFydGVyIERlY2ssIEdhaWEgUmVkIFtTVC0xXQ
```

```json
{
  "deck/name": "Starter Deck, Gaia Red [ST-1]",
  "deck/language": "en",
  "deck/digi-eggs": [
    {
      "card/number": "ST1-01",
      "card/count": 4
    }
  ],
  "deck/deck": [
    {
      "card/number": "ST1-02",
      "card/count": 4
    },
    {
      "card/number": "ST1-03",
      "card/count": 4
    },
    {
      "card/number": "ST1-04",
      "card/count": 4
    },
    {
      "card/number": "ST1-05",
      "card/count": 4
    },
    {
      "card/number": "ST1-06",
      "card/count": 4
    },
    {
      "card/number": "ST1-07",
      "card/count": 2
    },
    {
      "card/number": "ST1-08",
      "card/count": 4
    },
    {
      "card/number": "ST1-09",
      "card/count": 4
    },
    {
      "card/number": "ST1-10",
      "card/count": 2
    },
    {
      "card/number": "ST1-11",
      "card/count": 2
    },
    {
      "card/number": "ST1-12",
      "card/count": 4
    },
    {
      "card/number": "ST1-13",
      "card/count": 4
    },
    {
      "card/number": "ST1-14",
      "card/count": 4
    },
    {
      "card/number": "ST1-15",
      "card/count": 2
    },
    {
      "card/number": "ST1-16",
      "card/count": 2
    }
  ]
}
```

### Code

```csharp
using GomaDoge.DCG.DeckCodec;

public static CardDeck DecodeDeck(string deckCodec)
{
  // deckCodec must start with 'DCG'
  return DeckCodec.Decode(deckCodec);
}
```

## Encode

### Command Line

```shell
dotnet run --project src/GomaDoge.DCG.DeckCodec.CLI encode '{"deck/name":"Starter Deck, Gaia Red [ST-1]","deck/language":"en","deck/digi-eggs":[{"card/number":"ST1-01","card/count":4}],"deck/deck":[{"card/number":"ST1-02","card/count":4},{"card/number":"ST1-03","card/count":4},{"card/number":"ST1-04","card/count":4},{"card/number":"ST1-05","card/count":4},{"card/number":"ST1-06","card/count":4},{"card/number":"ST1-07","card/count":2},{"card/number":"ST1-08","card/count":4},{"card/number":"ST1-09","card/count":4},{"card/number":"ST1-10","card/count":2},{"card/number":"ST1-11","card/count":2},{"card/number":"ST1-12","card/count":4},{"card/number":"ST1-13","card/count":4},{"card/number":"ST1-14","card/count":4},{"card/number":"ST1-15","card/count":2},{"card/number":"ST1-16","card/count":2}]}'
```

```shell
Not supported yet
```

### Code

```csharp
using GomaDoge.DCG.DeckCodec;

public static string EncodeDeck(string deckJSON)
{
  // Not supported yet
  return DeckCodec.Encode(deckJSON);
}
```

# Test

```shell
dotnet test
```

# Deploy

You can create a single file application using the ``dotnet publish`` command.
For example, the following line creates a single file executable for ``linux-x86``.
See also the [official documentation](https://github.com/dotnet/designs/blob/main/accepted/2020/single-file/design.md).

```shell
dotnet publish -r linux-x64 --self-contained false /p:PublishSingleFile=true src/GomaDoge.DCG.DeckCodec.CLI
```

Note that by specifying ``--self-contained false`` the .NET runtime is not bundled with the application which also means that you need to install it on your target host.
You can omit the option if you want to but this leads to very big executable files.
