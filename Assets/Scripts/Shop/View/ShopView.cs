using System.Collections.Generic;
using Shop.Configs;
using Shop.Model;
using UnityEngine;

namespace Shop.View
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private ShopModel model;
        [SerializeField] private Transform contentRoot;
        [SerializeField] private ShopItemWidget shopItemPrefab;

        private List<SellableItemConfig> _sellableItems;
        
        public void Start()
        {
            model.Init();
            ShowItems();
        }

        private void ShowItems()
        {
            foreach (var sellableItem in model.SellableItems)
            {
                var widget = Instantiate(shopItemPrefab, contentRoot);
                widget.Setup(sellableItem);
            }
        }
    }
}
