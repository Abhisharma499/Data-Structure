using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.System_Design
{
    public class Card
    {
        public Suit cardSuit { get; set; }

        public uint cardNumber { get; set; }

        public Card(Suit cardSuit, uint cardNumber)
        {
            this.cardSuit = cardSuit;
            this.cardNumber = cardNumber;
        }
    }

    public class DeckOfCards
    {
        List<Card> deck = new List<Card>();

        const int CardsPerSuit = 13;

        const int NumberOfSuits = 4;

        public void FillDeckOfCards()
        {
            for (uint i = 1; i <= CardsPerSuit; i++)
            {
                foreach (var cardSuit in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card((Suit)cardSuit, i));
                }
            }
        }

        public void ShuffleCards()
        {
            for(int i=0;i<= CardsPerSuit * NumberOfSuits-1;i++)
            {
                Random rand = new Random();
                int randomNumber =  rand.Next(0, (CardsPerSuit * NumberOfSuits)-1);
                Card temp = deck[i];
                deck[i] = deck[randomNumber];
                deck[randomNumber] = temp;
            }
        }
    }

    public enum Suit
    {
        SPADE,
        HEART,
        CLUB,
        DIAMOND
    }
}
