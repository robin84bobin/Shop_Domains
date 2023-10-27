using Core;
using UnityEngine;

namespace Shop.Configs
{
    [CreateAssetMenu(fileName = "SellableItemConfig", menuName = "Shop Config/Sellable Item Config")]
    public class SellableItemConfig : ScriptableObject
    {
        [SerializeReference] ISellable _sellable;
        [SerializeReference] IReward _reward;

        public void Sell()
        {
            _sellable.Sell();
            _reward.Apply();
        }
    }
}