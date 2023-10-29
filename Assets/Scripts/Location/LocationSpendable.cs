using System;
using Core.Models.Reward;
using Core.Models.Spendable;
using UnityEngine;

namespace Location
{
    internal class LocationReward : IReward
    {
        [SerializeField] LocationModel _locationModel;
        [SerializeField] string _locationName;
        
        public void Apply()
        {
            _locationModel.SetValue(_locationName);
        }
    }

    internal class LocationSpendable : ISpendable
    {
        [Header("!Note: Drops location to default")]
        [SerializeField] LocationModel _locationModel;
        
        public event Action OnParamValueChanged;

        public void Init()
        {
            _locationModel.OnValueChange += OnValueChangeHandler;
        }

        private void OnValueChangeHandler(string oldvalue, string newvalue)
        {
            OnParamValueChanged?.Invoke();
        }

        public bool IsAffordable()
        {
            return true;
        }

        public bool Spend()
        {
            _locationModel.ResetValue();
            return true;
        }
    }
}