using System;
using Core;
using Core.Common;
using Core.PlayerParams;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(menuName = "Create LocationModel", fileName = "LocationModelAsset", order = 0)]
    public class LocationModel : StringParamModel
    {
        [SerializeField] private string defaultLocation = String.Empty;
        
        private ReactiveParameter<string> _currentLocation;
        
        public override void Init()
        {
            _currentLocation = new ReactiveParameter<string>(defaultLocation);
            _currentLocation.OnValueChange += OnValueChanged;
        }

        public override void Release()
        {
            _currentLocation.OnValueChange -= OnValueChanged;
        }

        public override string GetValueText() => _currentLocation.Value;

        public void ResetValue()
        {
            _currentLocation.SetDefaultValue(defaultLocation);
        }

        public override bool CheckValueToSpend(string value)
        {
            return true;
        }

        public override void AddValue(string value)
        {
            _currentLocation.Value = value;
        }

        public override void Spend(string value)
        {
            ResetValue();
        }
    }
}