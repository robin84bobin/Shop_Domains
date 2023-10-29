using System;
using Core.PlayerParams;
using UnityEngine;

namespace Core.Models.Spendable
{
    //todo remove unused?
    public class StringSpendable : ISpendable
    {
        [SerializeField] protected StringParamModel ParamModel;
        [SerializeField] protected string Value;
        public event Action OnChanged;
        
        public void Init()
        {
            ParamModel.OnValueChange += OnValueChangeHandler;
        }

        private void OnValueChangeHandler(string oldvalue, string newvalue)
        {
            OnChanged?.Invoke();
        }

        public bool IsAffordable()
        {
            return ParamModel.CheckValueToSpend(Value);
        }

        public void Spend()
        {
            ParamModel.Spend(Value);
        }
    }
}