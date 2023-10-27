using System;
using Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Health
{
    [Serializable]
    public class FixedHealthSpendable : ISpendable
    {
        [FormerlySerializedAs("healthManager")] [SerializeField] private HealthModel healthModel;
        [SerializeField] private int value;
        public void Sell()
        {
            healthModel.Spend(value);
        }
    }
}