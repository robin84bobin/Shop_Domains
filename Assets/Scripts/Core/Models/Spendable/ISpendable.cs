using System;

namespace Core.Models.Spendable
{
    public interface ISpendable
    {
        event Action OnChanged;
        void Init();
        bool IsAffordable();
        void Spend();
    }
}