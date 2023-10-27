using UnityEngine;

namespace Core.Models.Spendable
{
    public class IntFixedSpendable : IntSpendable
    {
        [SerializeField] private int _fixedValue;
        protected override int ValueToSpend => _fixedValue;
    }
}