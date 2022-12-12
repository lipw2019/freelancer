using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Strategy
{
    /// <summary>
    /// 当只剩下两行
    /// 此时有两种情况：每行卡片都大于1，保留两行最安全
    /// 有一行卡片等于1，把数量大于1的那一行取光就可以赢
    /// </summary>
    public class RestTwoStrategy : StrategyBase
    {
        public override IEnumerable<int> Exec(Dictionary<int, IList<int>> cards)
        {
            var qtyLgtOneList = cards.Where(x => x.Value.Count() > 1);
            var minQtyRowNo = cards.OrderBy(x => x.Value.Count()).FirstOrDefault().Key;
            var maxQtyRowNo = cards.OrderByDescending(x => x.Value.Count()).FirstOrDefault().Key;
            var qtyLgtOneRowNo = cards.FirstOrDefault(x => x.Value.Count() > 1).Key;
            if (qtyLgtOneList.Count() > 1)
            {
                return Pick(cards, new Random().Next(1, cards[qtyLgtOneRowNo].Count()), qtyLgtOneRowNo);
            }
            else
            {
                return Pick(cards, cards[maxQtyRowNo].Count, maxQtyRowNo);
            }
        }

    }
}
