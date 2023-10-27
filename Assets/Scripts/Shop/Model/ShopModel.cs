using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Shop.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shop.Model
{
    [CreateAssetMenu(menuName = "Create ShopModel", fileName = "ShopModel", order = 0)]
    public class ShopModel : ScriptableObject
    {
        private ShopConfig _shopConfig;
        public List<SellableItemConfig> SellableItems { get; private set; }

        public async void Init()
        {
            await InitParamModels();
            LoadItems();
        }

        private async Task InitParamModels()
        {
            var locations = await Addressables.LoadResourceLocationsAsync("ShopModel").Task;
            var paramModels = await Addressables.LoadAssetsAsync<BaseParamModel>(locations, null).Task;

            foreach (var paramModel in paramModels)
            {
                paramModel.Init();
            }
        }

        private async void LoadItems()
        {
            _shopConfig = await Addressables.LoadAssetAsync<ShopConfig>("ShopConfig").Task;

            SellableItems = new List<SellableItemConfig>();
            SellableItems.AddRange(_shopConfig.items);
        }
    }
}