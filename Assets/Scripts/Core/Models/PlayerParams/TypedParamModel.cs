using Core.Common;
using UnityEngine;

namespace Core.Models.PlayerParams
{
    public abstract class TypedParamModel<T> : BaseParamModel
    {
        [SerializeField] protected T defaultValue;
        protected ReactiveParameter<T> Parameter;
        
        public override void Init()
        {
            Parameter = new ReactiveParameter<T>(defaultValue);
            Parameter.OnValueChange += OnValueChanged;
        }

        public event ValueChangeDelegate<T> OnValueChange;

        private void OnValueChanged(T oldValue, T newValue)
        {
            OnValueChange?.Invoke(oldValue, newValue);
        }

        public override void Release()
        {
            Parameter.OnValueChange -= OnValueChanged;
        }
    }
}