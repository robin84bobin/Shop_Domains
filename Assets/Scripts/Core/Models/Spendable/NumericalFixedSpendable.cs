using UnityEngine;

namespace Core.Models.Spendable
{
    internal class NumericalFixedSpendable : NumericalSpendable
    {
        [SerializeField] private int _fixedValue;
        protected override float ValueToSpend => _fixedValue;
    }
}