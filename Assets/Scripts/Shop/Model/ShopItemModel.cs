using System;
using UnityEngine;

namespace Shop.Model
{
    [CreateAssetMenu(fileName = "ShopItemModelAsset", menuName = "Shop Config/Shop Item Model")]
    internal class ShopItemModel : ScriptableObject
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
            var spend = price.Spend();
            if (spend);
            {
                reward.Apply();
            }
        }

        public bool IsAffordable() => price.IsAffordable();

        public void Release()
        {
            price.OnChanged -= OnChangedHandler;
        }
    }
}