using Core.Models.PlayerParams;
using UnityEngine;

namespace Core.Models.Reward
{
    internal abstract class NumericalReward : IReward
    {
        [SerializeField] protected NumericalParamModel ParamModel;
        protected abstract float ValueToReward { get; }

        public void Apply()
        {
            ParamModel.AddValue(ValueToReward);
        }
    }
}