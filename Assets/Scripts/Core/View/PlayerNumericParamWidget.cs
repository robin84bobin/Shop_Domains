using Core.Models.PlayerParams;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.View
{
    public class PlayerNumericParamWidget : PlayerParamWidget
    {
        [FormerlySerializedAs("paramManager")] [SerializeField] private NumericalParamModel paramModel;
        
        protected override void Start()
        {
            base.Start();
            paramModel.OnValueChange += ValueChangeHandler;
        }

        public override void Init()
        {
            title.text = paramModel.ParameterName;
            UpdateValue();    
        }

        private void ValueChangeHandler(float oldValue, float newValue)
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

        public override void Release()
        {
            base.Release();
            paramModel.OnValueChange -= ValueChangeHandler;
        }
    }
}