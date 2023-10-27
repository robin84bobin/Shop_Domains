using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.PlayerParams;
using Shop.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shop.Model
{
    [CreateAssetMenu(menuName = "Create ShopModel", fileName = "ShopModel", order = 0)]
    public class ShopModel : ScriptableObject
    {
        private ShopConfig _shopConfig;
        private IList<BaseParamModel> _paramModels;
        public List<ShopItemModel> SellableItems { get; private set; }

        public async Task Init()
        {
            await InitParamModels();
            await InitSellableItems();
        }

        public void Release()
        {
            foreach (var paramModel in _paramModels)
            {
                paramModel.Release();
            }
        }

        private async Task InitParamModels()
        {
            var locations = await Addressables.LoadResourceLocationsAsync("ParamsModel").Task;
            _paramModels = await Addressables.LoadAssetsAsync<BaseParamModel>(locations, null).Task;

            foreach (var paramModel in _paramModels)
            {
                paramModel.Init();
            }
        }

        private async Task InitSellableItems()
        {
            _shopConfig = await Addressables.LoadAssetAsync<ShopConfig>("ShopConfig").Task;

            SellableItems = new List<ShopItemModel>();
            foreach (var shopItemModel in _shopConfig.items)
            {
                shopItemModel.Init();
                SellableItems.Add(shopItemModel);
            }
        }
    }
}