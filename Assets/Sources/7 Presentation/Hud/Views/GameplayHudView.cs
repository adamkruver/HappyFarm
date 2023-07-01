using HappyFarm.Presentation.Sources._7_Presentation.Views;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HappyFarm.Presentation.Sources._7_Presentation.Hud.Views
{
    [RequireComponent(typeof(ViewFadeAnimation))]
    public class GameplayHudView : View
    {
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _collectButton;
        [SerializeField] private TextMeshProUGUI _money;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private Slider _progress;

        public void SetMoney(string money) =>
            _money.text = money;

        public void SetLevel(string level) =>
            _level.text = level;

        public void SetProgress(float progress) =>
            _progress.value = progress;

        public void AddShopButtonClickListener(UnityAction callback) =>
            _shopButton.onClick.AddListener(callback);

        public void RemoveShopButtonClickListener(UnityAction callback) =>
            _shopButton.onClick.RemoveListener(callback);
        
        public void AddCollectButtonClickListener(UnityAction callback) =>
            _collectButton.onClick.AddListener(callback);

        public void RemoveCollectButtonClickListener(UnityAction callback) =>
            _collectButton.onClick.RemoveListener(callback);
    }
}