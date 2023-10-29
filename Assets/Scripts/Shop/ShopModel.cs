using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.PlayerParams;
using Shop.Model;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shop
{
    [CreateAssetMenu(menuName = "Create ShopModel", fileName = "ShopModel", order = 0)]
    internal class ShopModel : ScriptableObject
    {
        public IEnumerable<ShopItemModel> SellableItems => _sellableItems;
        private IList<ShopItemModel> _sellableItems;
        
        private IList<BaseParamModel> _paramModels;

        public async Task Init()
        {
            await InitParamModels();
            await InitSellableItems();
        }

        private async Task InitParamModels()
        {
            var locations = await Addressables.LoadResourceLocationsAsync("GameParamModel").Task;
            _paramModels = await Addressables.LoadAssetsAsync<BaseParamModel>(locations, null).Task;
            _paramModels.ForEach(i => i.Init());
        }

        private async Task InitSellableItems()
        {
            var locations = await Addressables.LoadResourceLocationsAsync("ShopItem").Task;
            _sellableItems = await Addressables.LoadAssetsAsync<ShopItemModel>(locations, null).Task;
            _sellableItems.ForEach(i => i.Init());
        }

        public void Release()
        {
            _paramModels.ForEach(i => i.Release());
            _sellableItems.ForEach(i => i.Release());
        }
    }
}