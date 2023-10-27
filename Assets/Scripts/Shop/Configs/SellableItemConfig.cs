using Core;
using UnityEngine;

namespace Shop.Configs
{
    [CreateAssetMenu(fileName = "SellableItemConfig", menuName = "Shop Config/Sellable Item Config")]
    public class SellableItemConfig : ScriptableObject
    {
        [SerializeField] public string title;
        [SerializeReference] ISpendable _price;
        [SerializeReference] IReward _reward;

        public void Sell()
        {
            _price.Sell();
            _reward.Apply();
        }
    }
}