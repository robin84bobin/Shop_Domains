using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.View
{
    public abstract class PlayerParamWidget : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI value;
        [SerializeField] private Button cheatButton;

        protected virtual void Start()
        {
            cheatButton.onClick.AddListener(CheatButtonClickHandler);
        }

        protected virtual void OnDestroy()
        {
            cheatButton.onClick.RemoveListener(CheatButtonClickHandler);
        }

        protected abstract void CheatButtonClickHandler();
    }
}