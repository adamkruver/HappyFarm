using DG.Tweening;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using TMPro;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Player.Money
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasGroup))]
    public class MoneyNotifierView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI _value;

        private Vector2 _startPosition;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void SetParent(RectTransform parent)
        {
        }

        public void Show()
        {
            gameObject.SetActive(true);

            _rectTransform.anchoredPosition = _startPosition;
            Vector2 endPosition = _startPosition + Vector2.up;

            DOTween.Sequence()
                .Append(_rectTransform.DOMove(endPosition, 1f));
            
            Invoke(nameof(Hide), 1.3f); // TODO: Refactor this
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetStartPosition(Vector2 startPosition)
        {
            _startPosition = startPosition;
        }

        public void SetValue(string value)
        {
            _value.text = value;
        }

        public void SetColor(Color color)
        {
            _value.color = color;
        }
    }
}