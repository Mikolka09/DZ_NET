using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DZ_C.NET
{

    public enum Suit { Booba = 1, Cross, Peak, Chirva };
    public enum TypeCard { Six = 6, Seven, Eight, Nine, Ten, Jack, Lady, King, Ace };

    class Game
    {
        private List<Player> players;
        private Stack<Card> cards;

        public void Reshuffling()
        {
            cards = new Stack<Card>();
            while (cards.Count != 36)
            {
                Card card = new Card();
                Random rand = new Random();
                int su = rand.Next(1, 5);
                if (su == 1)
                {
                    card.suit = Enum.GetName(typeof(Suit), su);
                    int type = rand.Next(6, 15);
                    if (TypeCard(type))
                    {
                        card.typeCard = Enum.GetName(typeof(TypeCard), type);
                        if (SuitBool(card.suit, card.typeCard))
                            cards.Push(card);
                    }
                }
                else if (su == 2)
                {
                    card.suit = Enum.GetName(typeof(Suit), su);
                    int type = rand.Next(6, 15);
                    if (TypeCard(type))
                    {
                        card.typeCard = Enum.GetName(typeof(TypeCard), type);
                        if (SuitBool(card.suit, card.typeCard))
                            cards.Push(card);
                    }
                }
                else if (su == 3)
                {
                    card.suit = Enum.GetName(typeof(Suit), su);
                    int type = rand.Next(6, 15);
                    if (TypeCard(type))
                    {
                        card.typeCard = Enum.GetName(typeof(TypeCard), type);
                        if (SuitBool(card.suit, card.typeCard))
                            cards.Push(card);
                    }
                }
                else if (su == 4)
                {
                    card.suit = Enum.GetName(typeof(Suit), su);
                    int type = rand.Next(6, 15);
                    if (TypeCard(type))
                    {
                        card.typeCard = Enum.GetName(typeof(TypeCard), type);
                        if (SuitBool(card.suit, card.typeCard))
                            cards.Push(card);
                    }
                }
            }
        }

        public void DistributionOfCards()
        {

        }

        public int Count(string type)
        {
            int count = 0;
            foreach (var item in cards)
            {
                if (item.typeCard == type)
                    count++;
            }
            return count;
        }

        public bool SuitBool(string su, string type)
        {
            foreach (var item in cards)
            {
                if (item.typeCard == type)
                    if (item.suit == su)
                        return false;
            }
            return true;
        }

        public bool TypeCard(int type)
        {
            switch (type)
            {
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    string typeCard = Enum.GetName(typeof(TypeCard), type);
                    if (cards.Count == 0)
                        return true;
                    else if (Count(typeCard) < 5)
                        return true;
                    break;
            }
            return false;
        }

        public void Print()
        {
            foreach (var fore in cards)
            {
                //if (fore.typeCard == NET.TypeCard.Six.ToString())
                Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            }

            //foreach (var fore in cards)
            //{

            //    if (fore.typeCard == NET.TypeCard.Seven.ToString())
            //        Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            //}

            //foreach (var fore in cards)
            //{
            //    if (fore.typeCard == NET.TypeCard.Eight.ToString())
            //        Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            //}

            //foreach (var fore in cards)
            //{
            //    if (fore.typeCard == NET.TypeCard.Nine.ToString())
            //        Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            //}

            //foreach (var fore in cards)
            //{
            //    if (fore.typeCard == NET.TypeCard.Ten.ToString())
            //        Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            //}

            //foreach (var fore in cards)
            //{
            //    if (fore.typeCard == NET.TypeCard.Jack.ToString())
            //        Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            //}

            //foreach (var fore in cards)
            //{
            //    if (fore.typeCard == NET.TypeCard.Lady.ToString())
            //        Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            //}

            //foreach (var fore in cards)
            //{
            //    if (fore.typeCard == NET.TypeCard.King.ToString())
            //        Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            //}

            //foreach (var fore in cards)
            //{
            //    if (fore.typeCard == NET.TypeCard.Ace.ToString())
            //        Console.WriteLine($"{fore.typeCard}-{fore.suit}");
            //}
        }


    }

    class Player
    {
        private Queue<Card> playerCards;

        public void PrintCard()
        {
            foreach (var item in playerCards)
            {
                Console.WriteLine($"{item.typeCard}-{item.suit}");
            }
        }

    }

    class Card
    {
        public string suit;
        public string typeCard;
    }
}
