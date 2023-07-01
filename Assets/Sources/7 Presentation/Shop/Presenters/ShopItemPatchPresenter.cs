using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Shop.Events;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Views;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using Sources._3._1_ApplicationServices.Interfaces.Shop;

namespace HappyFarm.Presentation.Sources._7_Presentation.Shop.Presenters
{
    public class ShopItemPatchPresenter : IPresenter
    {
        private readonly IDispatcher _dispatcher;
        private readonly ShopItemPatchView _view;
        private readonly IGardenActionService _gardenActionService;
        private readonly IPatchShopService _patchShopService;
        private readonly BuyPatchGardenViewAction _buyPatchGardenViewAction;

        public ShopItemPatchPresenter(
            IDispatcher dispatcher,
            ShopItemPatchView view,
            IGardenActionService gardenActionService,
            IPatchShopService patchShopService,
            BuyPatchGardenViewAction buyPatchGardenViewAction
        )
        {
            _dispatcher = dispatcher;
            _view = view;
            _gardenActionService = gardenActionService;
            _patchShopService = patchShopService;
            _buyPatchGardenViewAction = buyPatchGardenViewAction;
            _view.SetTitle("Patch");
            
            Update();
        }

        public IView View => _view;
        
        public void Enable()
        {
            _view.Show();
            _view.AddBuyButtonClickListener(OnBuyButtonClicked);
        }

        public void Update()
        {
            _view.SetPrice(_patchShopService.GetPatchPrice().ToString());
        }

        public void Disable()
        {
            _view.Hide();
            _view.RemoveBuyButtonClickListener(OnBuyButtonClicked);
        }

        private void OnBuyButtonClicked()
        {
            _gardenActionService.SetAction(_buyPatchGardenViewAction);
            _dispatcher.Dispatch(new HideShopEvent());
            _dispatcher.Dispatch(new ShowHudEvent());
        }
    }
}