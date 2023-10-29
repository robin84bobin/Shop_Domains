using System;
using Core.Common;
using UnityEngine;

namespace Core.PlayerParams
{
    public class NumericalParamModel : TypedParamModel<float>
    {
        [SerializeField] protected int defaultValue = 0;
        [SerializeField] protected int maxValue = 100;
        [SerializeField] protected int minValue = 0;

        public float Value => Parameter.Value;
        private ReactiveParameter<float> Parameter { get; set; }

        public override void Init()
        {
            Parameter = new ReactiveParameter<float>(defaultValue);
            Parameter.OnValueChange += OnValueChanged;
        }

        public override void Release()
        {
            Parameter.OnValueChange -= OnValueChanged;
        }

        public override bool CheckValueToSpend(float spendValue)
        {
            var newValue = Parameter.Value - spendValue;
            return newValue >= minValue;
        }
        
        public override void Spend(float value)
        {
            if (value == 0)
                return;
            
            float newValue = Parameter.Value - value;
            Parameter.Value = newValue >= minValue ? newValue : minValue;
        }

        public override void AddValue(float value)
        {
            if (value == 0)
                return;
            
            float newValue = Parameter.Value + value;
            Parameter.Value = maxValue >= newValue ? newValue : maxValue;
        }

        public override string GetValueText() => $"{Parameter.Value:0}";
    }
}