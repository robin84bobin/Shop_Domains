using UnityEngine;

namespace Core.PlayerParams
{
    public abstract class BaseParamModel : ScriptableObject
    {
        public abstract void Init();
        public abstract void Release();
        public abstract string GetValueText();
    }
}