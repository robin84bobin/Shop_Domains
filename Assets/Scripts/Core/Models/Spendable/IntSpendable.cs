using System;
using Core.Models.PlayerParams;
using UnityEngine;

namespace Core.Models.Spendable
{
    public abstract class IntSpendable : ISpendable
    {
        [SerializeField] protected IntParamModel ParamModel;
        public event Action OnChanged;
        
        protected abstract int ValueToSpend { get; }
        
        public void Init()
        {
            ParamModel.OnValueChange += OnValueChangeHandler;
        }

        private void OnValueChangeHandler(int oldvalue, int newvalue)
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