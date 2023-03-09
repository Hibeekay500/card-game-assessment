public enum Suit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public enum Rank
{
    Ace = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}

public class Pack
{
    private List<Card> _cards;

    public Pack()
    {
        _cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }

    public static void ShuffleCardPack(int typeOfShuffle)
    {
        Random random = new Random();
        switch (typeOfShuffle)
        {
            case 1: // Fisher-Yates Shuffle
                for (int i = _cards.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    Card temp = _cards[j];
                    _cards[j] = _cards[i];
                    _cards[i] = temp;
                }
                break;
            case 2: // Riffle Shuffle
                // TODO: implement Riffle Shuffle
                break;
            case 3: // No Shuffle
                // do nothing
                break;
            default:
                throw new ArgumentException("Invalid type of shuffle");
        }
    }

    public static Card DealCard()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("The pack is empty");
        }
        Card card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }

    public static List<Card> DealCard(int amount)
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < amount; i++)
        {
            cards.Add(DealCard());
        }
        return cards;
    }
}
class Testing
{
    static void Main(string[] args)
    {
        // Create a new pack of cards
        Pack pack = new Pack();

        // Shuffle the pack of cards using different algorithms
        Pack.ShuffleCardPack(1); // Fisher-Yates Shuffle
        Pack.ShuffleCardPack(2); // Riffle Shuffle
        Pack.ShuffleCardPack(3); // No Shuffle

        // Deal a single card from the pack and print it
        Card card = Pack.DealCard();
        Console.WriteLine($"Dealt card: {card}");

        // Deal 5 cards from the pack and print them
        List<Card> cards = Pack.DealCard(5);
        Console.WriteLine("Dealt cards:");
        foreach (Card c in cards)
        {
            Console.WriteLine(c);
        }
    }
}
