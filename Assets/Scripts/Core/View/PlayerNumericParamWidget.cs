using Core.PlayerParams;
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
            UpdateValue();    
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            paramModel.OnValueChange -= ValueChangeHandler;
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
    }
}