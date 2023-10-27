using System;
using Core;

namespace Location
{
    [Serializable]
    public class LocationSellable : ISellable
    {
        public string name;
        public void Sell()
        {
            throw new System.NotImplementedException();
        }
    }
}