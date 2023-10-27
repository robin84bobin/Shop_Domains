using Core.Models;
using UnityEngine;

namespace Shop.View
{
    public class PlayerStringParamWidget : PlayerParamWidget
    {
        [SerializeField] private StringParamModel paramModel;
        protected override void Start()
        {
            base.Start();
            paramModel.OnValueChange += UpdateValue;
        }

        private void UpdateValue(string oldValue, string newValue)
        {
            value.text = newValue;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            paramModel.OnValueChange -= UpdateValue;
        }

        protected override void CheatButtonClickHandler()
        {
            paramModel.ResetValue();
        }
    }
}