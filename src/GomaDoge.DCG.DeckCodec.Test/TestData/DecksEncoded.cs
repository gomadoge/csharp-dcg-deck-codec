namespace GomaDoge.DCG.DeckCodec.Test.TestData
{
  public class DecksEncoded
  {
    private static readonly CardDeck s_deckST1 = new CardDeckBuilder()
        .WithName("Starter Deck, Gaia Red [ST-1]")
        .WithLanguage("en")
        .WithDigiEggCard("ST1-01", 4)
        .WithDeckCard("ST1-02", 4)
        .WithDeckCard("ST1-03", 4)
        .WithDeckCard("ST1-04", 4)
        .WithDeckCard("ST1-05", 4)
        .WithDeckCard("ST1-06", 4)
        .WithDeckCard("ST1-07", 2)
        .WithDeckCard("ST1-08", 4)
        .WithDeckCard("ST1-09", 4)
        .WithDeckCard("ST1-10", 2)
        .WithDeckCard("ST1-11", 2)
        .WithDeckCard("ST1-12", 4)
        .WithDeckCard("ST1-13", 4)
        .WithDeckCard("ST1-14", 4)
        .WithDeckCard("ST1-15", 2)
        .WithDeckCard("ST1-16", 2)
        .Build();

    private static readonly CardDeck s_deckST2 = new CardDeckBuilder()
        .WithName("Starter Deck, Cocytus Blue [ST-2]")
        .WithLanguage("en")
        .WithDigiEggCard("ST2-01", 4)
        .WithDeckCard("ST2-02", 4)
        .WithDeckCard("ST2-03", 4)
        .WithDeckCard("ST2-04", 4)
        .WithDeckCard("ST2-05", 4)
        .WithDeckCard("ST2-06", 2)
        .WithDeckCard("ST2-07", 4)
        .WithDeckCard("ST2-08", 4)
        .WithDeckCard("ST2-09", 4)
        .WithDeckCard("ST2-10", 2)
        .WithDeckCard("ST2-11", 2)
        .WithDeckCard("ST2-12", 4)
        .WithDeckCard("ST2-13", 4)
        .WithDeckCard("ST2-14", 2)
        .WithDeckCard("ST2-15", 4)
        .WithDeckCard("ST2-16", 2)
        .Build();

    private static readonly CardDeck s_deckST3 = new CardDeckBuilder()
        .WithName("Starter Deck, Heaven's Yellow [ST-3]")
        .WithLanguage("en")
        .WithDigiEggCard("ST3-01", 4)
        .WithDeckCard("ST3-02", 4)
        .WithDeckCard("ST3-03", 4)
        .WithDeckCard("ST3-04", 4)
        .WithDeckCard("ST3-05", 2)
        .WithDeckCard("ST3-06", 4)
        .WithDeckCard("ST3-07", 4)
        .WithDeckCard("ST3-08", 4)
        .WithDeckCard("ST3-09", 4)
        .WithDeckCard("ST3-10", 2)
        .WithDeckCard("ST3-11", 2)
        .WithDeckCard("ST3-12", 4)
        .WithDeckCard("ST3-13", 4)
        .WithDeckCard("ST3-14", 2)
        .WithDeckCard("ST3-15", 4)
        .WithDeckCard("ST3-16", 2)
        .Build();

    private static readonly CardDeck s_deckST4 = new CardDeckBuilder()
        .WithName("Starter Deck, Giga Green [ST-4]")
        .WithLanguage("en")
        .WithDigiEggCard("ST4-01", 4)
        .WithDeckCard("ST4-02", 4)
        .WithDeckCard("ST4-03", 4)
        .WithDeckCard("ST4-04", 4)
        .WithDeckCard("ST4-05", 4)
        .WithDeckCard("ST4-06", 4)
        .WithDeckCard("ST4-07", 4)
        .WithDeckCard("ST4-08", 2)
        .WithDeckCard("ST4-09", 4)
        .WithDeckCard("ST4-10", 4)
        .WithDeckCard("ST4-11", 2)
        .WithDeckCard("ST4-12", 2)
        .WithDeckCard("ST4-13", 2)
        .WithDeckCard("ST4-14", 4)
        .WithDeckCard("ST4-15", 4)
        .WithDeckCard("ST4-16", 2)
        .Build();

    private static readonly CardDeck s_deckST5 = new CardDeckBuilder()
        .WithName("Starter Deck, Machine Black [ST-5]")
        .WithLanguage("en")
        .WithDigiEggCard("ST5-01", 4)
        .WithDeckCard("ST5-02", 4)
        .WithDeckCard("ST5-03", 4)
        .WithDeckCard("ST5-04", 4)
        .WithDeckCard("ST5-05", 4)
        .WithDeckCard("ST5-06", 4)
        .WithDeckCard("ST5-07", 4)
        .WithDeckCard("ST5-08", 2)
        .WithDeckCard("ST5-09", 4)
        .WithDeckCard("ST5-10", 4)
        .WithDeckCard("ST5-11", 2)
        .WithDeckCard("ST5-12", 2)
        .WithDeckCard("ST5-13", 2)
        .WithDeckCard("ST5-14", 4)
        .WithDeckCard("ST5-15", 4)
        .WithDeckCard("ST5-16", 2)
        .Build();

    private static readonly CardDeck s_deckST6 = new CardDeckBuilder()
        .WithName("Starter Deck, Venomous Violet [ST-6]")
        .WithLanguage("en")
        .WithDigiEggCard("ST6-01", 4)
        .WithDeckCard("ST6-02", 4)
        .WithDeckCard("ST6-03", 4)
        .WithDeckCard("ST6-04", 4)
        .WithDeckCard("ST6-05", 4)
        .WithDeckCard("ST6-06", 4)
        .WithDeckCard("ST6-07", 4)
        .WithDeckCard("ST6-08", 2)
        .WithDeckCard("ST6-09", 4)
        .WithDeckCard("ST6-10", 4)
        .WithDeckCard("ST6-11", 2)
        .WithDeckCard("ST6-12", 2)
        .WithDeckCard("ST6-13", 2)
        .WithDeckCard("ST6-14", 4)
        .WithDeckCard("ST6-15", 4)
        .WithDeckCard("ST6-16", 2)
        .Build();

    public static (string, CardDeck) StarterDecks(string name, int version)
    {
      return name switch
      {
        "ST1" => version switch
        {
          0 => ("DCGAREdU1QxIEHBU1QxIE_CwcHBwUHBwUFBwcHBQUFTdGFydGVyIERlY2ssIEdhaWEgUmVkIFtTVC0xXQ", s_deckST1),
          1 => ("DCGETsdnJ0BQQMBnJ0BTwMCAwEDAQMBAwEBAQMBAwEBAQEBAwEDAQMBAQEBAVN0YXJ0ZXIgRGVjaywgR2FpYSBSZWQgW1NULTFd", s_deckST1),
          2 => ("DCGITsdAJydAUEDAZydAU8DAgMBAwEDAQMBAQEDAQMBAQEBAQMBAwEDAQEBAQFTdGFydGVyIERlY2ssIEdhaWEgUmVkIFtTVC0xXQ", s_deckST1),
          3 => ("DCGOTsdAJydAUEDAZydAU8DAgMBAwEDAQMBAQEDAQMBAQEBAQMBAwEDAQEBAQFTdGFydGVyIERlY2ssIEdhaWEgUmVkIFtTVC0xXQ", s_deckST1),
          _ => ("", null),
        },
        "ST2" => version switch
        {
          0 => ("DCGARMhU1QyIEHBU1QyIE_CwcHBQcHBwUFBwcFBwUFTdGFydGVyIERlY2ssIENvY3l0dXMgQmx1ZSBbU1QtMl0", s_deckST2),
          1 => ("DCGET0hnJ0CQQMBnJ0CTwMCAwEDAQMBAQEDAQMBAwEBAQEBAwEDAQEBAwEBAVN0YXJ0ZXIgRGVjaywgQ29jeXR1cyBCbHVlIFtTVC0yXQ", s_deckST2),
          2 => ("DCGIT0hAJydAkEDAZydAk8DAgMBAwEDAQEBAwEDAQMBAQEBAQMBAwEBAQMBAQFTdGFydGVyIERlY2ssIENvY3l0dXMgQmx1ZSBbU1QtMl0", s_deckST2),
          3 => ("DCGOT0hAJydAkEDAZydAk8DAgMBAwEDAQEBAwEDAQMBAQEBAQMBAwEBAQMBAQFTdGFydGVyIERlY2ssIENvY3l0dXMgQmx1ZSBbU1QtMl0", s_deckST2),
          _ => ("", null),
        },
        "ST3" => version switch
        {
          0 => ("DCGARUkU1QzIEHBU1QzIE_CwcFBwcHBwUFBwcFBwUFTdGFydGVyIERlY2ssIEhlYXZlbidzIFllbGxvdyBbU1QtM10", s_deckST3),
          1 => ("DCGET8knJ0DQQMBnJ0DTwMCAwEDAQEBAwEDAQMBAwEBAQEBAwEDAQEBAwEBAVN0YXJ0ZXIgRGVjaywgSGVhdmVuJ3MgWWVsbG93IFtTVC0zXQ", s_deckST3),
          2 => ("DCGIT8kAJydA0EDAZydA08DAgMBAwEBAQMBAwEDAQMBAQEBAQMBAwEBAQMBAQFTdGFydGVyIERlY2ssIEhlYXZlbidzIFllbGxvdyBbU1QtM10", s_deckST3),
          3 => ("DCGOT8kAJydA0EDAZydA08DAgMBAwEBAQMBAwEDAQMBAQEBAQMBAwEBAQMBAQFTdGFydGVyIERlY2ssIEhlYXZlbidzIFllbGxvdyBbU1QtM10", s_deckST3),
          _ => ("", null),
        },
        "ST4" => version switch
        {
          0 => ("DCGARcfU1Q0IEHBU1Q0IE_CwcHBwcFBwcFBQUHBwUFTdGFydGVyIERlY2ssIEdpZ2EgR3JlZW4gW1NULTRd", s_deckST4),
          1 => ("DCGEUEfnJ0EQQMBnJ0ETwMCAwEDAQMBAwEDAQEBAwEDAQEBAQEBAQMBAwEBAVN0YXJ0ZXIgRGVjaywgR2lnYSBHcmVlbiBbU1QtNF0", s_deckST4),
          2 => ("DCGIUEfAJydBEEDAZydBE8DAgMBAwEDAQMBAwEBAQMBAwEBAQEBAQEDAQMBAQFTdGFydGVyIERlY2ssIEdpZ2EgR3JlZW4gW1NULTRd", s_deckST4),
          3 => ("DCGOUEfAJydBEEDAZydBE8DAgMBAwEDAQMBAwEBAQMBAwEBAQEBAQEDAQMBAQFTdGFydGVyIERlY2ssIEdpZ2EgR3JlZW4gW1NULTRd", s_deckST4),
          _ => ("", null),
        },
        "ST5" => version switch
        {
          0 => ("DCGARkiU1Q1IEHBU1Q1IE_CwcHBwcFBwcFBQUHBwUFTdGFydGVyIERlY2ssIE1hY2hpbmUgQmxhY2sgW1NULTVd", s_deckST5),
          1 => ("DCGEUMinJ0FQQMBnJ0FTwMCAwEDAQMBAwEDAQEBAwEDAQEBAQEBAQMBAwEBAVN0YXJ0ZXIgRGVjaywgTWFjaGluZSBCbGFjayBbU1QtNV0", s_deckST5),
          2 => ("DCGIUMiAJydBUEDAZydBU8DAgMBAwEDAQMBAwEBAQMBAwEBAQEBAQEDAQMBAQFTdGFydGVyIERlY2ssIE1hY2hpbmUgQmxhY2sgW1NULTVd", s_deckST5),
          3 => ("DCGOUMiAJydBUEDAZydBU8DAgMBAwEDAQMBAwEBAQMBAwEBAQEBAQEDAQMBAQFTdGFydGVyIERlY2ssIE1hY2hpbmUgQmxhY2sgW1NULTVd", s_deckST5),
          _ => ("", null),
        },
        "ST6" => version switch
        {
          0 => ("DCGARskU1Q2IEHBU1Q2IE_CwcHBwcFBwcFBQUHBwUFTdGFydGVyIERlY2ssIFZlbm9tb3VzIFZpb2xldCBbU1QtNl0", s_deckST6),
          1 => ("DCGEUUknJ0GQQMBnJ0GTwMCAwEDAQMBAwEDAQEBAwEDAQEBAQEBAQMBAwEBAVN0YXJ0ZXIgRGVjaywgVmVub21vdXMgVmlvbGV0IFtTVC02XQ", s_deckST6),
          2 => ("DCGIUUkAJydBkEDAZydBk8DAgMBAwEDAQMBAwEBAQMBAwEBAQEBAQEDAQMBAQFTdGFydGVyIERlY2ssIFZlbm9tb3VzIFZpb2xldCBbU1QtNl0", s_deckST6),
          3 => ("DCGOUUkAJydBkEDAZydBk8DAgMBAwEDAQMBAwEBAQMBAwEBAQEBAQEDAQMBAQFTdGFydGVyIERlY2ssIFZlbm9tb3VzIFZpb2xldCBbU1QtNl0", s_deckST6),
          _ => ("", null),
        },
        _ => ("", null),
      };
    }
  }
}
