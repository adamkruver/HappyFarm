using HappyFarm.Presentation.Sources._7_Presentation.Views;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HappyFarm.Presentation.Sources._7_Presentation.Shop.Views
{
    public class ShopView : View
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private ListView _itemsView;

        public void AddItem(IView view) =>
            _itemsView.Add(view);

        public void AddCloseButtonClickListener(UnityAction callback) =>
            _closeButton.onClick.AddListener(callback);

        public void RemoveCloseButtonClickListener(UnityAction callback) =>
            _closeButton.onClick.RemoveListener(callback);
    }
}