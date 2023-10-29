using System;
using Core.Models.Spendable;
using UnityEngine;

namespace Shop.Model
{
    [CreateAssetMenu(menuName = "Create ShopPriceModel", fileName = "ShopPriceModelAsset", order = 0)]
    internal class ShopPriceModel : ScriptableObject
    {
        [SerializeReference] private ISpendable _spendable;

        public void Init()
        {
            _spendable.Init();
            _spendable.OnChanged += OnChangedHandler;
        }

        private void OnChangedHandler()
        {
            OnChanged?.Invoke();
        }

        public event Action OnChanged;
        public void Spend() => _spendable.Spend();
        public bool IsAffordable() => _spendable.IsAffordable();
    }
}