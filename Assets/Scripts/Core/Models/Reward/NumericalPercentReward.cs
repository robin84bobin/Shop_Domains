using UnityEngine;

namespace Core.Models.Reward
{
    internal sealed class NumericalPercentReward : NumericalReward
    {
        [SerializeField] private float _percentValue;
        protected override float ValueToReward => ParamModel.Value * _percentValue * 0.01f;
    }
}