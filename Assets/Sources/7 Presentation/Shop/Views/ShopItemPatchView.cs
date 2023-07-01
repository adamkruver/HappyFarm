using HappyFarm.Presentation.Sources._7_Presentation.Views;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HappyFarm.Presentation.Sources._7_Presentation.Shop.Views
{
    public class ShopItemPatchView : View
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private Button _buyButton;

        public void SetTitle(string title) => 
            _title.text = title;

        public void SetPrice(string price) => 
            _price.text = price;

        public void AddBuyButtonClickListener(UnityAction callback) => 
            _buyButton.onClick.AddListener(callback);

        public void RemoveBuyButtonClickListener(UnityAction callback) => 
            _buyButton.onClick.RemoveListener(callback);
    }
}