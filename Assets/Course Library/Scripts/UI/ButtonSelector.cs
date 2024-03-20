using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Course_Library.Scripts.UI
{
    public class ButtonSelector : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private float selectScale = 1.075f;
        [SerializeField] private float DeselectScale = 1.0f;
        [SerializeField] private float duration = 0.075f;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            eventData.selectedObject = gameObject;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            eventData.selectedObject = null;
        }

        public void OnSelect(BaseEventData eventData)
        {
            transform.DOScale(selectScale, duration).SetEase(Ease.InOutQuad);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            transform.DOScale(DeselectScale, duration);
        }
    }
}
