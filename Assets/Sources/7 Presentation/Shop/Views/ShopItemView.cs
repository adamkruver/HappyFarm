using DG.Tweening;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Enums;
using HappyFarm.Presentation.Sources._7_Presentation.Views;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HappyFarm.Presentation.Sources._7_Presentation.Shop.Views
{
    public class ShopItemView : View
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private Button _buyButton;

        [SerializeField] private Image _lockedPanel;
        [SerializeField] private Image _buyButtonCoin;
        [SerializeField] private Image _buyButtonLock;

        public void SetIcon(Sprite icon) =>
            _icon.sprite = icon;

        public void SetTitle(string title) =>
            _title.text = title;

        public void SetPrice(string price) =>
            _price.text = price;

        public void AddBuyButtonClickListener(UnityAction callback) =>
            _buyButton.onClick.AddListener(callback);

        public void RemoveBuyButtonClickListener(UnityAction callback) =>
            _buyButton.onClick.RemoveListener(callback);

        public void SetStatus(ContentStatus status)
        {
            switch (status)
            {
                case ContentStatus.Opened:
                    OpenContent();
                    break;

                case ContentStatus.Locked:
                    LockContent();
                    break;
            }
        }

        private void LockContent()
        {
            _buyButtonCoin.gameObject.SetActive(false);
            _buyButtonLock.gameObject.SetActive(true);
            _lockedPanel.gameObject.SetActive(true);
        }

        private void OpenContent()
        {
            _buyButtonCoin.gameObject.SetActive(true);
            _buyButtonLock.gameObject.SetActive(false);
            _lockedPanel.gameObject.SetActive(false);
        }
    }
}