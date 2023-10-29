using System.Collections.Generic;
using Core.View;
using Shop.Model;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;

namespace Shop.View
{
    public class ShopView : MonoBehaviour
    {
        [FormerlySerializedAs("manager")] [SerializeField] private ShopModel model;
        [SerializeField] private PlayerParamWidget[] playerParamWidgets;
        [SerializeField] private Transform contentRoot;
        [SerializeField] private AssetReference shopItemAssetRef;

        private List<ShopItemModel> _sellableItems;
        
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
            foreach (var sellableItem in model.SellableItems)
            {
                var gameObj = await Addressables.InstantiateAsync(shopItemAssetRef, contentRoot).Task;
                var shopItemWidget = gameObj.GetComponent<ShopItemWidget>();
                shopItemWidget.Setup(sellableItem);
            }
        }

        private void OnDestroy()
        {
            model.Release();
        }
    }
}
