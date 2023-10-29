using System;
using Core.Models.PlayerParams;
using UnityEngine;

namespace Core.Models.Spendable
{
    internal abstract class NumericalSpendable : ISpendable
    {
        [SerializeField] protected NumericalParamModel ParamModel;
        public event Action OnParamValueChanged;
        
        protected abstract float ValueToSpend { get; }
        
        public void Init()
        {
            ParamModel.OnValueChange += OnValueChangeHandler;
        }

        private void OnValueChangeHandler(float oldvalue, float newvalue)
        {
            OnParamValueChanged?.Invoke();
        }

        public bool IsAffordable()
        {
            return ParamModel.CheckValueToSpend(ValueToSpend);
        }

        public bool Spend()
        {
            if (!IsAffordable())
                return false;
            
            ParamModel.Spend(ValueToSpend);
            return true;
        }
    }
}