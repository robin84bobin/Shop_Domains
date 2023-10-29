using Shop.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.View
{
    internal class ShopItemWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private Button sellButton;
        private ShopItemModel _shopItemModel;

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
            _shopItemModel.Buy();
            UpdateView();
        }

        public void Setup(ShopItemModel shopItem)
        {
            _shopItemModel = shopItem;
            _shopItemModel.OnChanged += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            title.text = _shopItemModel.title;
            var affordable = _shopItemModel.IsAffordable();
            sellButton.interactable = affordable;
        }

        public void Release()
        {
            _shopItemModel.OnChanged -= UpdateView;
        }
    }
}
