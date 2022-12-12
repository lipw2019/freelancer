using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Strategy
{
    /// <summary>
    /// 鉴于时间关系，此Demo未考虑所有可能的情况，但为了便于以后增加新的游戏策略,
    /// 这里采用了策略模式和工厂模式方便后续扩展
    /// </summary>
    public abstract class StrategyBase
    {
        public abstract IEnumerable<int> Exec(Dictionary<int, IList<int>> cards);
        public IList<int> Pick(Dictionary<int, IList<int>> cards, int takeQty, int row)
        {
            IList<int> picks = new List<int>();
            if (cards[row].Count == takeQty)
            {
                picks = cards[row];
                cards.Remove(row);
            }
            else
            {
                picks = cards[row].Take(takeQty).ToList();
                cards[row] = cards[row].Skip(takeQty).ToList();
            }
            return picks;
        }
    }
}
