using System;
using UnityEngine;

namespace Shop.Configs
{
    [CreateAssetMenu(fileName = "ShopItemModelAsset", menuName = "Shop Config/Shop Item Model")]
    public class ShopItemModel : ScriptableObject
    {
        [SerializeField] public string title;
        [SerializeField] ShopPriceModel price;
        [SerializeField] ShopRewardModel reward;

        public event Action OnChanged;

        public void Init()
        {
            price.Init();
            price.OnChanged += OnChangedHandler;
        }

        private void OnChangedHandler()
        {
            OnChanged?.Invoke();
        }

        public void Buy()
        {
            price.Spend();
            //reward.Apply();
        }

        public bool IsAffordable() => price.IsAffordable();
    }
}