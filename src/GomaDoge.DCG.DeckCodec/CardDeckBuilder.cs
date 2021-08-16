using System.Collections.Generic;
using System.Linq;

namespace GomaDoge.DCG.DeckCodec
{
  public class CardDeckBuilder
  {
    private string _name;
    private string _language;
    private List<Card> _digiEggs;
    private List<Card> _mainDeck;
    private List<Card> _sideboard;

    public CardDeckBuilder()
    {
      ClearCards();
    }

    public CardDeckBuilder(CardDeck preset)
    {
      ClearCards(preset.Name, preset.Language);

      _digiEggs = new List<Card>();
      foreach (var card in preset.DigiEggs)
      {
        _digiEggs.Add(new Card(card));
      }

      _mainDeck = new List<Card>();
      foreach (var card in preset.Deck)
      {
        _mainDeck.Add(new Card(card));
      }

      _sideboard = new List<Card>();
      foreach (var card in preset.Sideboard)
      {
        _sideboard.Add(new Card(card));
      }
    }

    public CardDeck Build() => new()
    {
      Name = _name,
      Language = _language,
      DigiEggs = _digiEggs,
      Deck = _mainDeck,
      Sideboard = _sideboard
    };

    public void ClearCards(string name = "New Deck", string language = "en")
    {
      _name = name;
      _language = language;
      _digiEggs = new List<Card>();
      _mainDeck = new List<Card>();
      _sideboard = new List<Card>();
    }

    public CardDeckBuilder WithName(string name)
    {
      _name = name;

      return this;
    }

    public CardDeckBuilder WithLanguage(string language)
    {
      _language = language;

      return this;
    }

    public CardDeckBuilder WithDigiEggCard(string number, int count = 1, int parallelID = 0)
    {
      if (_digiEggs.Any(c => c.Number == number && c.ParallelID == parallelID))
      {
        var card = _digiEggs.Where(c => c.Number == number && c.ParallelID == parallelID).First();
        card.Count = count;
        card.ParallelID = parallelID;
      }
      else
      {
        _digiEggs.Add(new Card{Number = number, Count = count, ParallelID = parallelID});
      }

      return this;
    }

    public CardDeckBuilder WithDeckCard(string number, int count = 1, int parallelID = 0)
    {
      if (_mainDeck.Any(c => c.Number == number && c.ParallelID == parallelID))
      {
        var card = _mainDeck.Where(c => c.Number == number && c.ParallelID == parallelID).First();
        card.Count = count;
        card.ParallelID = parallelID;
      }
      else
      {
        _mainDeck.Add(new Card{Number = number, Count = count, ParallelID = parallelID});
      }

      return this;
    }

    public CardDeckBuilder WithSideboardCard(string number, int count = 1, int parallelID = 0)
    {
      if (_sideboard.Any(c => c.Number == number && c.ParallelID == parallelID))
      {
        var card = _sideboard.Where(c => c.Number == number && c.ParallelID == parallelID).First();
        card.Count = count;
        card.ParallelID = parallelID;
      }
      else
      {
        _sideboard.Add(new Card{Number = number, Count = count, ParallelID = parallelID});
      }

      return this;
    }
  }
}