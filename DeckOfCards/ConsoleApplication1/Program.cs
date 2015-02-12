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

        public class Deck
        {
            private Card[] deck;
            private int currentCard;
            private const int numberOfCards = 52;
            private Random ranNum;

            public Deck()
            {
                string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Jack", "Quees", "King" };
                string[] suits = { "Hearts", "Spades", "Diamonds", "Clubs" };

                deck = new Card[numberOfCards];
                ranNum = new Random();
                for (int i = 0; i < deck.Length; i++)
                {
                    deck[i] = new Card(faces[i % 11], suits[i / 13]);
                }
            }
           public void Shuffle()
            {
                currentCard = 0;
                for (int i = 0; i < deck.Length; i++)
                {
                    int second = ranNum.Next(numberOfCards);
                    Card temp = deck[i];
                    deck[i] = deck[second];
                    deck[second] = temp;

                }

            }
            public Card DealCard()
           {
                if(currentCard < deck.Length)
                {
                    return deck[currentCard++];
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
            private string face;
            private string suit;

            public Card(string cardFace, string cardSuit)
            {
                face = cardFace;
                suit = cardSuit;
            }
            public override string ToString()
            {
                return face + "of" + suit;
            }


        }
    }
}