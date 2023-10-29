using System;
using Core.Models.Spendable;
using UnityEngine;
using UnityEngine.Serialization;

namespace Location
{
    [Serializable]
    public class LocationSpendable : ISpendable
    {
        [FormerlySerializedAs("locationManager")]
        [Header("!Note: Drops location to default")]
        [SerializeField] LocationModel locationModel;
        
        public event Action OnChanged;

        public void Init()
        {
            locationModel.OnValueChange += OnValueChangeHandler;
        }

        private void OnValueChangeHandler(string oldvalue, string newvalue)
        {
            OnChanged?.Invoke();
        }

        public bool IsAffordable()
        {
            return true;
        }

        public void Spend()
        {
            locationModel.ResetValue();
        }
    }
}