using UnityEngine;

namespace Core.Models.Spendable
{
    public class NumericalFixedSpendable : NumericalSpendable
    {
        [SerializeField] private int _fixedValue;
        protected override float ValueToSpend => _fixedValue;
    }
}