using System.Collections.Generic;
using Core.View;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shop.View
{
    internal class ShopView : MonoBehaviour
    {
        [SerializeField] private ShopModel model;
        [SerializeField] private List<PlayerParamWidget> playerParamWidgets;
        [SerializeField] private Transform contentRoot;
        [SerializeField] private AssetReference shopItemAssetRef;

        private List<ShopItemWidget> _itemWidgets;

        public async void Start()
        {
            await model.Init();
            InitPlayerParamsWidgets();
            ShowSellableItems();
        }

        private void InitPlayerParamsWidgets()
        {
            foreach (var paramWidget in playerParamWidgets)
            {
                paramWidget.Init();
            }
        }

        private async void ShowSellableItems()
        {
            _itemWidgets = new List<ShopItemWidget>();
            
            foreach (var sellableItem in model.SellableItems)
            {
                var gameObj = await Addressables.InstantiateAsync(shopItemAssetRef, contentRoot).Task;
                var shopItemWidget = gameObj.GetComponent<ShopItemWidget>();
                shopItemWidget.Setup(sellableItem);
                _itemWidgets.Add(shopItemWidget);
            }
        }

        private void OnDestroy()
        {
            model.Release();
            playerParamWidgets.ForEach(i => i.Release());
            _itemWidgets.ForEach(i => i.Release());
        }
    }
}
