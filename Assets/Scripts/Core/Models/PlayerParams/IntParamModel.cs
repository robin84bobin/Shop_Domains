using UnityEngine;

namespace Core.Models.PlayerParams
{
    public class NumericalParamModel : TypedParamModel<float>
    {
        [SerializeField] protected int maxValue = 100;
        [SerializeField] protected int minValue = 0;

        public float Value => Parameter.Value;

        public bool CheckValueToSpend(float spendValue)
        {
            var newValue = Parameter.Value - spendValue;
            return newValue >= minValue;
        }
        
        public void Spend(float value)
        {
            if (value == 0)
                return;
            
            float newValue = Parameter.Value - value;
            Parameter.Value = newValue >= minValue ? newValue : minValue;
        }

        public void AddValue(float value)
        {
            if (value == 0)
                return;
            
            float newValue = Parameter.Value + value;
            Parameter.Value = maxValue >= newValue ? newValue : maxValue;
        }

        public string GetValueText() => $"{Parameter.Value:0}";
    }
}