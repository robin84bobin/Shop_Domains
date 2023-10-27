using System;
using Core;

namespace Health
{
    [Serializable]
    public class HealthSellable : ISellable
    {
        public int value;
        public void Sell()
        {
            throw new System.NotImplementedException();
        }
    }
}