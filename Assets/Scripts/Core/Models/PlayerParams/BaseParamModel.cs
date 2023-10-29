using UnityEngine;

namespace Core.Models.PlayerParams
{
    public abstract class BaseParamModel : ScriptableObject
    {
        public abstract void Init();
        public abstract void Release();
        public abstract string GetValueText();
    }
}