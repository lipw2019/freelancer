using CardGame.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class StrategyFactory
    {
        private static Dictionary<int, StrategyBase> _strategy = new Dictionary<int, StrategyBase>()
        {
            { 1,new RestOneStrategy()},
            { 2,new RestTwoStrategy()},
            { 3,new RestThreeStrategy()}
        };
        public static StrategyBase CreateStrategy(int name)
        {
            if (_strategy.TryGetValue(name, out StrategyBase result))
                return result;
            else
                return null;
        }
    }
}
