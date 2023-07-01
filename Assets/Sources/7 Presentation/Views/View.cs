using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Views
{
    [RequireComponent(typeof(ViewFadeAnimation))]
    [RequireComponent(typeof(RectTransform))]
    public abstract class View : MonoBehaviour, IView
    {
        private ViewFadeAnimation _animation;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _animation = GetComponent<ViewFadeAnimation>();
            _rectTransform = GetComponent<RectTransform>();

            OnAwake();
        }

        public void SetParent(RectTransform parent)
        {
            _rectTransform.parent = parent;
            _rectTransform.localScale = Vector3.one;
        }

        public void Show() =>
            _animation.Show();

        public void Hide() =>
            _animation.Hide();

        protected virtual void OnAwake()
        {
        }
    }
}