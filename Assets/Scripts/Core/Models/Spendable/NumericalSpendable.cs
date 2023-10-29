using System;
using Core.PlayerParams;
using UnityEngine;

namespace Core.Models.Spendable
{
    public abstract class NumericalSpendable : ISpendable
    {
        [SerializeField] protected NumericalParamModel ParamModel;
        public event Action OnChanged;
        
        protected abstract float ValueToSpend { get; }
        
        public void Init()
        {
            ParamModel.OnValueChange += OnValueChangeHandler;
        }

        private void OnValueChangeHandler(float oldvalue, float newvalue)
        {
            OnChanged?.Invoke();
        }

        public bool IsAffordable()
        {
            return ParamModel.CheckValueToSpend(ValueToSpend);
        }

        public virtual void Spend()
        {
            ParamModel.Spend(ValueToSpend);
        }
    }
}