using System;
using System.Collections.Generic;
using System.IO;
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
        private List<Player> players = new List<Player>();
        private Stack<Card> cards = new Stack<Card>();

        public void DrawGame()
        {
            Console.SetCursorPosition(4, 0);
            Console.WriteLine("ИГРА \"ПЬЯНИЦА\"");
            Console.WriteLine("--------------------------");
        }

        public void Reshuffling()
        {
            while (cards.Count != 36)
            {
                Card card = new Card();
                Random rand = new Random();
                int su = rand.Next(1, 5);

                switch (su)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        card.suit = Enum.GetName(typeof(Suit), su);
                        int type = rand.Next(6, 15);
                        if (TypeCardBool(type))
                        {
                            card.typeCard = Enum.GetName(typeof(TypeCard), type);
                            if (SuitBool(card.suit, card.typeCard))
                                cards.Push(card);
                        }
                        break;
                    default:
                        Console.WriteLine("ОШИБКА ВВОДА!!!");
                        break;
                }
            }
        }

        public void DistributionOfCards()
        {
            int i = 0;
            while (cards.Count != 0)
            {
                if (i > players.Count - 1)
                    i = 0;
                players[i].playerCards.Enqueue(cards.Pop());
                i++;
            }
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

        public bool TypeCardBool(int type)
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
                default:
                    Console.WriteLine("ОШИБКА ВВОДА!!!");
                    break;
            }
            return false;
        }

        public void CreateListPlayers()
        {

            bool close = true;
            int num = 1;
            while (close)
            {
                Console.Clear();
                DrawGame();
                Console.WriteLine("Создание списков Игроков");
                Console.WriteLine("-------------------------");
                Console.WriteLine();
                Player player = new Player();
                Console.WriteLine($"Игрок номер - {num}:");
                Console.WriteLine("-------------------------");
                Console.WriteLine();
                Console.WriteLine("Введите имя Игрока:");
                player.name = Console.ReadLine();
                player.playerCards = new Queue<Card>();
                players.Add(player);
                if (players.Count() < 2)
                {
                    Console.Clear();
                    DrawGame();
                    Console.WriteLine("Создание списков Игроков");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine();
                    Player player2 = new Player();
                    num++;
                    Console.WriteLine($"Игрок номер - {num}:");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Введите имя Игрока:");
                    player2.name = Console.ReadLine();
                    player2.playerCards = new Queue<Card>();
                    players.Add(player2);
                }
                Console.WriteLine();
                Console.WriteLine("--------------------");
                Console.WriteLine("Добавить еще Игрока?\n" +
                                      "1 - ДА     2 - НЕТ");
                int vib = int.Parse(Console.ReadLine());
                switch (vib)
                {
                    case 1: close = true; num++; break;
                    case 2: close = false; break;
                    default: Console.WriteLine("ОШИБКА ВВОДА!!!"); break;
                }
            }
        }

        public int intEnum(string st)
        {
            switch (st)
            {
                case "Six":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(0);

                case "Seven":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(1);

                case "Eight":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(2);

                case "Nine":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(3);

                case "Ten":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(4);

                case "Jack":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(5);

                case "Lady":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(6);

                case "King":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(7);

                case "Ace":
                    return (int)Enum.GetValues(typeof(TypeCard)).GetValue(8);
            }
            return 0;
        }

        public void PrintPlayers()
        {
            int numb = 1;
            int xn = 0, yn = 6, xc = 40, yc = 6;
            while (numb != players.Count + 1)
            {
                if (numb % 2 != 0)
                {
                    if (numb > 2)
                        yn = yn + 4;
                    Console.SetCursorPosition(xn, yn);
                    Console.WriteLine($"Игрок номер - {numb} ({players[numb - 1].name})");
                    Console.SetCursorPosition(xn, yn + 1);
                    Console.WriteLine("-------------------------");
                    Console.SetCursorPosition(xn, yn + 2);
                    Console.WriteLine($"Карта: {players[numb - 1].playerCards.Peek()}");

                }
                else
                {
                    if (numb > 2)
                        yc = yc + 4;
                    Console.SetCursorPosition(xc, yc);
                    Console.WriteLine($"Игрок номер - {numb} ({players[numb - 1].name})");
                    Console.SetCursorPosition(xc, yc + 1);
                    Console.WriteLine("-------------------------");
                    Console.SetCursorPosition(xc, yc + 2);
                    Console.WriteLine($"Карта: {players[numb - 1].playerCards.Peek()}");
                }

                Console.WriteLine();
                numb++;
            }
        }
        public void PrintCards()
        {
            int numb = 1;
            int xn = 0, yn = 15, xc = 50, yc = 15;
            while (numb != players.Count + 1)
            {
                if (numb % 2 != 0)
                {
                    if (numb > 2)
                        yn = yn + (36 / players.Count) + 6;
                    Console.SetCursorPosition(xn, yn);
                    Console.WriteLine($"Количество оставшихся карт {players[numb - 1].name} - {players[numb - 1].playerCards.Count}");
                    Console.SetCursorPosition(xn, yn + 1);
                    Console.WriteLine("------------------------------------");
                    Console.SetCursorPosition(xn, yn + 2);
                    players[numb - 1].PrintCard(xn, yn);
                }
                else
                {
                    if (numb > 2)
                        yc = yc + (36 / players.Count) + 6;
                    Console.SetCursorPosition(xc, yc);
                    Console.WriteLine($"Количество оставшихся карт {players[numb - 1].name} - {players[numb - 1].playerCards.Count}");
                    Console.SetCursorPosition(xc, yc + 1);
                    Console.WriteLine("------------------------------------");
                    Console.SetCursorPosition(xc, yc + 2);
                    players[numb - 1].PrintCard(xc, yc);
                }
                numb++;
            }
        }

        public void StartGame()
        {
            Console.Clear();
            DrawGame();
            Console.WriteLine();
            Console.WriteLine("\tИГРА НАЧАЛАСЬ!");
            Thread.Sleep(2000);
            bool endGame = true;
            int step = 1;
            string vin = "";
            while (endGame)
            {
                Console.Clear();
                DrawGame();
                Console.WriteLine();
                Console.WriteLine($"Этап Игры номер - {step}");
                Console.WriteLine("----------------------");
                Console.WriteLine();
                PrintPlayers();
                Card[] arrCards = new Card[players.Count];
                for (int i = 0; i < arrCards.Length; i++)
                {
                    arrCards[i] = players[i].playerCards.Dequeue();
                }

                int max = intEnum(arrCards[0].typeCard);
                int imax = 0;
                for (int i = 0; i < arrCards.Length; i++)
                {
                    if (intEnum(arrCards[i].typeCard) > max)
                    {
                        max = intEnum(arrCards[i].typeCard);
                        imax = i;
                    }
                }
                int maxCount = 0;
                for (int i = 0; i < arrCards.Length; i++)
                {
                    if (intEnum(arrCards[i].typeCard) == max)
                        maxCount++;
                }

                if (maxCount == 1)
                    Console.Write($"Больше Карта у - {players[imax].name}, он забирает карты!");
                else
                {
                    for (int i = 0; i < arrCards.Length; i++)
                    {
                        if (intEnum(arrCards[i].typeCard) == max)
                        {
                            imax = i;
                            break;
                        }
                    }
                    Console.Write($"Больше Карта у - {players[imax].name}, он забирает карты!");
                }
                for (int i = arrCards.Length - 1; i >= 0; i--)
                {
                    players[imax].playerCards.Enqueue(arrCards[i]);
                }
                if (players.Count == 1)
                {
                    vin = players[0].name;
                    endGame = false;
                }
                else
                {
                    int it = players.Count - 1;
                    while (it != -1)
                    {
                        if (players[it].playerCards.Count == 0)
                        {
                            players.RemoveAt(it);
                            it++;
                        }

                        it--;
                    }
                    endGame = true;
                }
                step++;
                PrintCards();
                Console.WriteLine();
                Console.WriteLine("Для следующего хода нажмите ЛЮБУЮ клавишу!!!");
                Console.ReadKey();
            }
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.WriteLine($"ПОБЕДИТЕЛЬ - {vin}, количество ходов - {step}!!!");
            Thread.Sleep(2500);
        }
    }

    class Player
    {
        public string name;
        public Queue<Card> playerCards;

        public void PrintCard(int x, int y)
        {
            foreach (var item in playerCards)
            {
                Console.SetCursorPosition(x, y + 2);
                Console.WriteLine($"{item.typeCard}-{item.suit}");
                y++;
            }
        }

        public override string ToString()
        {
            foreach (var item in playerCards)
            {
                return $"{item.typeCard}-{item.suit}";
            }
            return "";
        }
    }

    class Card
    {
        public string suit;
        public string typeCard;

        public override string ToString()
        {
            return $"{typeCard}-{suit}";
        }
    }
}
