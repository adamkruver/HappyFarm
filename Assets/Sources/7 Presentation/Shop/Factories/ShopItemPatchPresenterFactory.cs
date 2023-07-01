using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Presenters;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Views;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using Sources._3._1_ApplicationServices.Interfaces.Shop;

namespace HappyFarm.Presentation.Sources._7_Presentation.Shop.Factories
{
    public class ShopItemPatchPresenterFactory
    {
        private readonly IDispatcher _dispatcher;
        private readonly IGardenActionService _gardenActionService;
        private readonly IPatchShopService _patchShopService;
        private readonly ViewFactory _viewFactory;
        private readonly BuyPatchGardenViewAction _buyPatchGardenViewAction;

        public ShopItemPatchPresenterFactory(
            IDispatcher dispatcher,
            IGardenActionService gardenActionService,
            IPatchShopService patchShopService,
            ViewFactory viewFactory,
            BuyPatchGardenViewAction buyPatchGardenViewAction
        )
        {
            _dispatcher = dispatcher;
            _gardenActionService = gardenActionService;
            _patchShopService = patchShopService;
            _viewFactory = viewFactory;
            _buyPatchGardenViewAction = buyPatchGardenViewAction;
        }

        public ShopItemPatchPresenter Create()
        {
            return new ShopItemPatchPresenter(
                _dispatcher,
                _viewFactory.Create<ShopItemPatchView>(),
                _gardenActionService,
                _patchShopService,
                _buyPatchGardenViewAction
            );
        }
    }
}