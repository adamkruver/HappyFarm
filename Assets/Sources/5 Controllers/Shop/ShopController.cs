using HappyFarm.Controllers.Sources._5_Controllers.Shop.Actions;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Shop
{
    public class ShopController : AbstractController
    {
        public ShopController(
            IDispatcher dispatcher,
            IPresenterFactory presenterFactory
        ) : base(dispatcher)
        {
            IShopPresenter presenter = presenterFactory.Create<IShopPresenter>();

            Register(new ShowShopAction(presenter));
            Register(new HideShopAction(presenter));
            Register(new UpdateShopAction(presenter));
        }
    }
}