using System;
using Core.Common;
using UnityEngine;

namespace Core.PlayerParams
{
    public abstract class StringParamModel : TypedParamModel<string>
    {
        [SerializeField] protected string defaultValue = String.Empty;
        private ReactiveParameter<string> _parameter;
        
        public override void Init()
        {
            _parameter = new ReactiveParameter<string>(defaultValue);
            _parameter.OnValueChange += OnValueChanged;
        }

        public override void Release()
        {
            _parameter.OnValueChange -= OnValueChanged;
        }

        public override string GetValueText() => _parameter.Value;

        public void ResetValue()
        {
            _parameter.SetDefaultValue(defaultValue);
        }
    }
}