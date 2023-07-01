using HappyFarm.Presentation.Sources._7_Presentation.Views;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HappyFarm.Presentation.Sources._7_Presentation.Hud.Views
{
    public class GameplayHudAvailableSeedsItemView : View
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private Button _button;

        public void SetIcon(Sprite icon) => 
            _icon.sprite = icon;

        public void SetCount(string count) => 
            _count.text = count;

        public void AddClickListener(UnityAction callback) => 
            _button.onClick.AddListener(callback);

        public void RemoveClickListener(UnityAction callback) => 
            _button.onClick.RemoveListener(callback);
    }
}