using UnityEngine;

namespace Core.Models.Reward
{
    internal sealed class NumericalFixedReward : NumericalReward
    {
        [SerializeField] private float _value;
        protected override float ValueToReward => _value;
    }
}