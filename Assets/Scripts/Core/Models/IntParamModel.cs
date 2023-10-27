using UnityEngine;

namespace Core.Models
{
    public class IntParamModel : BaseParamModel
    {
        [SerializeField] protected int defaultValue = 0;
        [SerializeField] protected int maxValue = 100;
        [SerializeField] protected int minValue = 0;
        
        public event ValueChangeDelegate<int> OnValueChange = delegate { };
        protected ReactiveParameter<int> Parameter { get; set; }

        public override void Init()
        {
            Parameter = new ReactiveParameter<int>(defaultValue);
            Parameter.OnValueChange += OnValueChanged;
        }

        public override void Release()
        {
            Parameter.OnValueChange -= OnValueChanged;
        }

        private void OnValueChanged(int oldValue, int newValue)
        {
            OnValueChange?.Invoke(oldValue, newValue);
        }

        public void Spend(int value)
        {
            if (value == 0)
                return;
            
            int newValue = Parameter.Value - value;
            Parameter.Value = newValue >= minValue ? newValue : minValue;
            
        }

        public void AddValue(int value)
        {
            if (value == 0)
                return;
            
            int newValue = Parameter.Value + value;
            Parameter.Value = maxValue >= newValue ? newValue : maxValue;
        }
    }
}