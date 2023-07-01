using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Player.Money.Presenter
{
    public class MoneyNotifierPresenter : IMoneyNotifierPresenter
    {
        private Color _positiveColor = Color.green;
        private Color _negativeColor = Color.red;
        
        private MoneyNotifierView _view;
        
        public MoneyNotifierPresenter(float price, Vector2 position, ViewFactory viewFactory)
        {
            _view = viewFactory.Create<MoneyNotifierView>();
            
            int money = (int)price;
            Color color = money >= 0 ? _positiveColor : _negativeColor;
            
            _view.SetStartPosition(position);
            _view.SetValue(money.ToString());
            _view.SetColor(color);
        }

        public void Enable()
        {
            _view.Show();
        }

        public void Update()
        {
        }

        public void Disable()
        {
            _view.Hide();
        }
    }
}