using Core.Models;
using Core.Models.PlayerParams;
using UnityEngine;

namespace Core.View
{
    public class PlayerIntParamWidget : PlayerParamWidget
    {
        [SerializeField] private IntParamModel paramModel;
        
        protected override void Start()
        {
            base.Start();
            paramModel.OnValueChange += ValueChangeHandler;
        }

        public override void Init()
        {
            UpdateValue();    
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            paramModel.OnValueChange -= ValueChangeHandler;
        }

        private void ValueChangeHandler(int oldValue, int newValue)
        {
           UpdateValue();
        }

        private void UpdateValue()
        {
            value.text = paramModel.GetValueText();
        }

        protected override void CheatButtonClickHandler()
        {
            paramModel.AddValue(1);
        }
    }
}