using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Strategy
{

    /// <summary>
    /// 当只剩下一行
    /// 此时有两种情况： 卡片数大于1的情况，此时取剩下一张可以赢
    /// 只剩一张的情况，只能直接取，然后输
    /// </summary>
    public class RestOneStrategy : StrategyBase
    {
        public override IEnumerable<int> Exec(Dictionary<int, IList<int>> cards)
        {
            return cards.Values.Count() > 1 ? Pick(cards, cards.Values.Count() - 1, cards.Keys.FirstOrDefault())
                : Pick(cards, 1, cards.Keys.FirstOrDefault());
        }
    }
}
