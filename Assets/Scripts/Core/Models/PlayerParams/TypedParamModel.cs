namespace Core.Models.PlayerParams
{
    public abstract class TypedParamModel<T> : BaseParamModel
    {
        public event ValueChangeDelegate<T> OnValueChange;
        protected void OnValueChanged(T oldValue, T newValue)
        {
            OnValueChange?.Invoke(oldValue, newValue);
        }

        public abstract void AddValue(T value);
        public abstract void Spend(T value);
        public abstract bool CheckValueToSpend(T value);
    }
}