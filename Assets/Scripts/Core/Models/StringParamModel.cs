using System;
using UnityEngine;

namespace Core.Models
{
    public class StringParamModel : BaseParamModel
    {
        [SerializeField] protected string defaultValue = String.Empty;
        protected ReactiveParameter<string> Parameter;
        public event ValueChangeDelegate<string> OnValueChange = delegate { };
        public override void Init()
        {
            Parameter = new ReactiveParameter<string>(defaultValue);
            Parameter.OnValueChange += OnValueChangeHandler;
        }

        public override void Release()
        {
            Parameter.OnValueChange -= OnValueChangeHandler;
        }

        private void OnValueChangeHandler(string oldValue, string newValue)
        {
            OnValueChange?.Invoke(oldValue, newValue);
        }

        public void ResetValue()
        {
            Parameter.SetDefaultValue(defaultValue);
        }

    }
}