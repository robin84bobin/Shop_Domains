using UnityEngine;

namespace Core.Models
{
    public abstract class BaseParamModel : ScriptableObject
    {
        public abstract void Init();
        public abstract void Release();
    }
}