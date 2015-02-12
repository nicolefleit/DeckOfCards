using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            deck1.Shuffle();
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine("{0, -19}", deck1.DealCard());
                if ((i + 1) % 4 == 0)
                    Console.WriteLine();
            }
            Console.ReadLine();

        }
    }


    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
	//     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
	//     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
	//     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
	//         discard pile	
    // 
    // A deck knows the following information about itself:
	//     int CardsRemaining -- number of cards left in the deck
	//     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played
    public class Deck
    {
        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }
        public int CardsRemaining;

        public const int numberOfCards = 52;
        public Random ranNum;

        public Deck()
        {
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();
            
            for (int y = 1; y <= 4; y++)
            {
                for (int i = 2; i <= 14; i++)
                {
                    this.DeckOfCards.Add(new Card((Rank)i, (Suit)y));
                }
            }

        }
        public void Shuffle()
        {
            ranNum = new Random();
            List<Card> tempList = new List<Card>();

            //while the deck of cards is greater than 0 while shuffling
            while(this.DeckOfCards.Count > 0)
            {
                //choose a random card
                int index = ranNum.Next(DeckOfCards.Count());

                //add the random card to the temperary list
                tempList.Add(DeckOfCards[index]);

                //remove the card from the deck of cards
                this.DeckOfCards.RemoveAt(index);

            }
            //once the deck of cards is empty it is the same deck
            this.DeckOfCards = tempList;
            
            //for (int i = 0; i < DeckOfCards.Count; i++)
            //{
            //    int second = ranNum.Next(numberOfCards);
            //    Card temp = DeckOfCards[i];
            //    DeckOfCards[i] = DeckOfCards[second];
            //    DeckOfCards[second] = temp;

            //}

        }

        public List<Card> Deal(int numberOfCards)
        {
            List<Card> cardsToDeal = new List<Card>();
            for (int i = 0; i < numberOfCards; i++)
            {
                Card drawn = this.DeckOfCards.Last();
                //Add cards to list
                cardsToDeal.Add(drawn);
               //remove cards
                this.DeckOfCards.Remove(drawn);
            }
            return cardsToDeal;
        }
        public void Discard (Card card)
        {
            this.DiscardedCards.Add(card);
        }
        public void Discard (List<Card> card)
        {
            foreach (var item in card)
            {
                this.DiscardedCards.Add(item);
            }
        }
        public Card DealCard()
        {
            if (CardsRemaining < DeckOfCards.Count)
            {
                return DeckOfCards[CardsRemaining++];
            }
            else
            {
                return null;
            }
        }
        
    }

    
    // What makes a card?
	//     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"
    public class Card
    {
        public Rank Rank { get; set; }
        private Suit Suit { get; set; }

        public Card(Rank cardRank, Suit cardSuit)
        {
            this.Rank = cardRank;
            this.Suit = cardSuit;
        }
        public string CardStirng()
        {
            return this.Rank + "of" + this.Suit;
        }


    }
    public enum Suit
    {
        Hearts = 1,
        Diamonds,
        Clubs,
        Spades
    }
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Jack,
        Queen,
        King,
        Ace
    }
}
