using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new Player[2] {
                new Player() { Name="Kobe"},
                new Player() { Name="James"},
            };
            var cards = GetAllCards();
            Random rand = new Random();
            var starter = rand.Next();
            string lastPlayer = string.Empty;
            while (cards.Values.Any())
            {
                int cur = starter % players.Length;
                var currentPickedCards = players[cur].Pick(cards);
                Console.WriteLine($"{players[cur].Name} pick {string.Join(',', currentPickedCards)}");
                Console.WriteLine(players[cur].ToString());

                lastPlayer = players[cur].Name;
                starter++;
            }
            Console.WriteLine($"{lastPlayer} defeated!");
            Console.ReadKey();
        }


        static Dictionary<int, IList<int>> GetAllCards()
        {
            var data = new Dictionary<int, IList<int>> {
                {1,new List<int>{ 1, 2, 3} },
                {2,new List<int>{ 4, 5, 6, 7, 8 } },
                {3,new List<int>{ 9, 10, 11, 12, 12, 14, 15 } }
            };
            return data;
        }
    }
}
