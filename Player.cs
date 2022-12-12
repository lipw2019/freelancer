using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<int> PickedCards { get; set; } = new List<int>();
        public IEnumerable<int> Pick(Dictionary<int, IList<int>> data)
        {
            int lineCount = data.Keys.Count();
            var strategy = StrategyFactory.CreateStrategy(lineCount);
            var cards = strategy.Exec(data);
            PickedCards.AddRange(cards);
            return cards;
        }

        public override string ToString()
        {
            return $"{Name} has cards: {string.Join(',', PickedCards)}";
        }
    }
}
