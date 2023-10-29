using System;

namespace Core.Models.Spendable
{
    public interface ISpendable
    {
        event Action OnParamValueChanged;
        void Init();
        bool IsAffordable();
        bool Spend();
    }
}