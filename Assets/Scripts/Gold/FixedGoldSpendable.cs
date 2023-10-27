using System;
using Core;
using UnityEngine;

namespace Gold
{
    [Serializable]
    public class FixedGoldSpendable : ISpendable
    {
        [SerializeField] private GoldModel goldModel;
        [SerializeField] private int goldValue;
        
        public void Sell()
        {
            goldModel.Spend(goldValue);
        }
    }
}