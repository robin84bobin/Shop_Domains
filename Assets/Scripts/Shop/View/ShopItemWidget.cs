using System;
using Shop.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.View
{
    public class ShopItemWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI value;
        [SerializeField] private Button sellButton;

        private void Start()
        {
            sellButton.onClick.AddListener(OnSellClickHandler);
        }        
        
        private void OnDestroy()
        {
            sellButton.onClick.RemoveListener(OnSellClickHandler);
        }

        private void OnSellClickHandler()
        {
            throw new NotImplementedException();
        }

        public void Setup(SellableItemConfig sellableItem)
        {
            Debug.Log(sellableItem.title);
        }
    }
}
