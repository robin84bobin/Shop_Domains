using UnityEngine;

namespace Core.Models.Spendable
{
    public class NumericalPercentSpendable : NumericalSpendable
    {
        [SerializeField] private int _percentValue;
        protected override float ValueToSpend => ParamModel.Value * _percentValue * 0.01f;
    }
}