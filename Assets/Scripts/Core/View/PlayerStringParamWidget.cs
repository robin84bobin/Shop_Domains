using Core.Models.PlayerParams;
using UnityEngine;

namespace Core.View
{
    public class PlayerStringParamWidget : PlayerParamWidget
    {
        [SerializeField] private StringParamModel paramModel;

        protected override void Start()
        {
            base.Start();
            paramModel.OnValueChange += OnValueChangeHandler;
        }

        public override void Init()
        {
            title.text = paramModel.ParameterName;
            UpdateValue();
        }

        private void OnValueChangeHandler(string oldValue, string newValue) => UpdateValue();

        private void UpdateValue() => value.text = paramModel.GetValueText();

        protected override void CheatButtonClickHandler()
        {
            paramModel.ResetValue();
        }

        public override void Release()
        {
            base.Release();
            paramModel.OnValueChange -= OnValueChangeHandler;
        }
    }
}