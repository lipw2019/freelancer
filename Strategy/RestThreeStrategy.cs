using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Strategy
{
    /// <summary>
    /// 当只剩下三行:全取，取数量最少的行
    /// </summary>
    public class RestThreeStrategy : StrategyBase
    {
        public override IEnumerable<int> Exec(Dictionary<int, IList<int>> cards)
        {
            var anyLineRemainOneCards = cards.Any(x => x.Value.Count() == 1);
            var minQtyRowNo = cards.OrderBy(x => x.Value.Count()).FirstOrDefault().Key;
            var maxQtyRowNo = cards.OrderByDescending(x => x.Value.Count()).FirstOrDefault().Key;
            var qtyLgtOneRowNo = cards.FirstOrDefault(x => x.Value.Count() > 1).Key;
            if (anyLineRemainOneCards)
            {
                Random rand = new Random();
                return Pick(cards, new Random().Next(1, cards[qtyLgtOneRowNo].Count()), qtyLgtOneRowNo);
            }
            else
            {
                return Pick(cards, cards[minQtyRowNo].Count, minQtyRowNo);
            }
        }

    }
}
