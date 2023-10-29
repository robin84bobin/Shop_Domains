using Core.Models;
using Core.PlayerParams;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.View
{
    public class PlayerStringParamWidget : PlayerParamWidget
    {
        [FormerlySerializedAs("paramManager")] [SerializeField] private StringParamModel paramModel;

        protected override void Start()
        {
            base.Start();
            paramModel.OnValueChange += OnValueChangeHandler;
        }

        public override void Init()
        {
            UpdateValue();
        }

        private void OnValueChangeHandler(string oldValue, string newValue) => UpdateValue();
        private void UpdateValue() => value.text = paramModel.GetValueText();

        protected override void OnDestroy()
        {
            base.OnDestroy();
            paramModel.OnValueChange -= OnValueChangeHandler;
        }

        protected override void CheatButtonClickHandler()
        {
            paramModel.ResetValue();
        }
    }
}