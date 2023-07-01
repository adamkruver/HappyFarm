using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Player.Money.Presenter;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Player.Money.Factories
{
    public class MoneyNotifierPresenterFactory: IMoneyNotifierPresenterFactory
    {
        private readonly ViewFactory _viewFactory;

        public MoneyNotifierPresenterFactory(ViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public IMoneyNotifierPresenter Create(int value, Vector2 position)
        {
            return new MoneyNotifierPresenter(value, position, _viewFactory);
        }
    }
}