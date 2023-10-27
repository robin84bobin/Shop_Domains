using UnityEngine;

namespace Core.Models.PlayerParams
{
    public class IntParamModel : TypedParamModel<int>
    {
        [SerializeField] protected int defaultValue = 0;
        [SerializeField] protected int maxValue = 100;
        [SerializeField] protected int minValue = 0;

        public int Value => Parameter.Value;
        private ReactiveParameter<int> Parameter { get; set; }

        public override void Init()
        {
            Parameter = new ReactiveParameter<int>(defaultValue);
            Parameter.OnValueChange += OnValueChanged;
        }

        public override void Release()
        {
            Parameter.OnValueChange -= OnValueChanged;
        }

        public override bool CheckValueToSpend(int spendValue)
        {
            var newValue = Parameter.Value - spendValue;
            return newValue >= minValue;
        }
        
        public override void Spend(int value)
        {
            if (value == 0)
                return;
            
            int newValue = Parameter.Value - value;
            Parameter.Value = newValue >= minValue ? newValue : minValue;
        }

        public override void AddValue(int value)
        {
            if (value == 0)
                return;
            
            int newValue = Parameter.Value + value;
            Parameter.Value = maxValue >= newValue ? newValue : maxValue;
        }

        public override string GetValueText() => Parameter.Value.ToString();
    }
}