using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.Controllers.Sources._5_Controllers.Shop.Events;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Shop.Actions
{
    public class HideShopAction : IControllerAction<HideShopEvent>
    {
        private readonly IShopPresenter _presenter;

        public HideShopAction(IShopPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Handle(HideShopEvent @event, IDispatcher dispatcher)
        {
            _presenter.Disable();
        }
    }
}