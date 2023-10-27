using UnityEngine;

namespace Core.Models.Spendable
{
    public class IntPercentSpendable : IntSpendable
    {
        [SerializeField] private int _percentValue;
        protected override int ValueToSpend => (int) (ParamModel.Value * _percentValue * 0.01f);
    }
}