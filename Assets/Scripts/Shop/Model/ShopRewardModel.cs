﻿using Core.Models.Reward;
using UnityEngine;

namespace Shop.Model
{
    [CreateAssetMenu(menuName = "Create ShopRewardModel", fileName = "ShopRewardModelAsset", order = 0)]
    internal class ShopRewardModel : ScriptableObject
    {
        [SerializeReference] private IReward _reward;

        public void Apply()
        {
            _reward.Apply();
        }
        
    }
}