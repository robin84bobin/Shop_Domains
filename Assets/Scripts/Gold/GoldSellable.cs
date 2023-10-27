using System;
using Core;

namespace Gold
{
    [Serializable]
    public class GoldSellable : ISellable
    {
        public void Sell()
        {
            GoldManager.Instance.Sell();
        }
    }
}