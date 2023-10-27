using System.Collections.Generic;
using Core;
using Shop.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shop
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Transform contentRoot;
        [SerializeField] private ShopItemWidget shopItemPrefab;

        private List<SellableItemConfig> _sellableItems;
        
        public void Start()
        {
            LoadItems();
            ShowItems();
        }

        private async void LoadItems()
        {
            var locations = await Addressables.LoadResourceLocationsAsync("ShopConfig").Task;
            var configs = await Addressables.LoadAssetsAsync<ShopConfig>(locations,o => { }).Task;

            _sellableItems = new List<SellableItemConfig>();
            foreach (var shopConfig in configs)
            {
                _sellableItems.AddRange(shopConfig.items);
            }


            foreach (var sellableItem in _sellableItems)
            {
                sellableItem.Sell();
            }
            
            int count = 0;
            
        }


        private void ShowItems()
        {
        
        }
    }
}
