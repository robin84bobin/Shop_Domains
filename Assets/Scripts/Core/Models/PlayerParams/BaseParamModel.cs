using UnityEngine;

namespace Core.Models.PlayerParams
{
    /// <summary>
    /// ScriptableObject models used instead of "managers".
    /// Tо prevent singletons using injects into
    /// ISpendable and IReward implementation classes (also ScriptableObject)
    /// via serialized fields in editor
    /// </summary>
    public abstract class BaseParamModel : ScriptableObject
    {
        [SerializeField] protected string parameterName;
        public string ParameterName => parameterName;
        public abstract void Init();
        public abstract void Release();
    }
}