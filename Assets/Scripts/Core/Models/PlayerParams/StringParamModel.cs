
namespace Core.Models.PlayerParams
{
    public abstract class StringParamModel : TypedParamModel<string>
    {
        public string GetValueText() => Parameter.Value;
       
        public void SetValue(string value)
        {
            Parameter.Value = value;
        }
        
        public void ResetValue()
        {
            Parameter.SetDefaultValue(defaultValue);
        }
    }
}