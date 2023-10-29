using Core.Common;

namespace Core.Models.PlayerParams
{
    public abstract class TypedParamModel<T> : BaseParamModel
    {
        public event ValueChangeDelegate<T> OnValueChange;
        protected void OnValueChanged(T oldValue, T newValue)
        {
            OnValueChange?.Invoke(oldValue, newValue);
        }

       
    }
}