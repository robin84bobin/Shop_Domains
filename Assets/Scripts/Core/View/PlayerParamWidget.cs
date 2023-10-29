using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.View
{
    public abstract class PlayerParamWidget : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI title;
        [SerializeField] protected TextMeshProUGUI value;
        [SerializeField] private Button cheatButton;

        protected virtual void Start()
        {
            cheatButton.onClick.AddListener(CheatButtonClickHandler);
        }

        protected abstract void CheatButtonClickHandler();

        public abstract void Init();

        public virtual void Release()
        {
            cheatButton.onClick.RemoveListener(CheatButtonClickHandler);
        }
    }
}