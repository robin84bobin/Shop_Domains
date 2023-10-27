using Core;
using Core.Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shop.View
{
    public class PlayerIntParamWidget : PlayerParamWidget
    {
        [SerializeField] private IntParamModel paramModel;

        
        protected override void Start()
        {
            base.Start();
            paramModel.OnValueChange += UpdateValue;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            paramModel.OnValueChange -= UpdateValue;
        }

        private void UpdateValue(int oldValue, int newValue)
        {
            value.text = newValue.ToString();
        }

        protected override void CheatButtonClickHandler()
        {
            paramModel.AddValue(1);
        }
    }
}