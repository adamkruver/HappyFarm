using System.Collections.Generic;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class ListView : MonoBehaviour
    {
        private readonly List<IView> _views = new List<IView>();

        private RectTransform _rectTransform;

        private void Awake() =>
            _rectTransform = GetComponent<RectTransform>();

        public void Add(IView view)
        {
            _views.Add(view);
            SetViewsParent(view, _rectTransform);
        }

        public void AddRange(IEnumerable<IView> views)
        {
            foreach (IView view in views)
                Add(view);
        }

        public void Clear()
        {
            foreach (IView view in _views)
                SetViewsParent(view, null);

            _views.Clear();
        }

        private void SetViewsParent(IView view, RectTransform parent)
        {
            view.SetParent(parent);
        }
    }
}