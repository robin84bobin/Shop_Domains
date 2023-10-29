namespace Core.Common
{
    public sealed class ReactiveParameter<T> 
    {
        public event ValueChangeDelegate<T> OnValueChange = delegate { };

        public ReactiveParameter(T defaultValue = default(T))
        {
            SetDefaultValue(defaultValue);
        }

        public void SetDefaultValue(T defaultValue)
        {
            _defaultValue = defaultValue;
            _value = _defaultValue;
        }

        private T _defaultValue = default(T);
        private T _value = default(T);
        
        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;

                if (_value != null && _value.Equals(value))
                    return;

                _value = value;
                OnValueChange.Invoke(oldValue, _value);
            }
        }
    }


    public delegate void ValueChangeDelegate<T>(T oldValue, T newValue);
}