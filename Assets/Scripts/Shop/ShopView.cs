using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shop
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Transform contentRoot;
        [SerializeField] private ShopItemWidget shopItemPrefab;

        private List<ISellable> _sellableItems;
        
        public void Start()
        {
            LoadItems();
            ShowItems();
        }

        private async void LoadItems()
        {
            var locations = await Addressables.LoadResourceLocationsAsync("ShopConfig").Task;
            var configs = await Addressables.LoadAssetsAsync<ISellable>(locations,o => { }).Task;
                
            
            int count = 0;
            _sellableItems = new List<ISellable>();
        }

        private void Callback<TObject>(TObject obj)
        {
        }

        private void ShowItems()
        {
        
        }
    }
}
