using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Shop.Events;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Hud.Views;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Presentation.Sources._7_Presentation.Hud.Presenters
{
    public class GameplayHudPresenter : IGameplayHudPresenter
    {
        private readonly IDispatcher _dispatcher;
        private readonly IProgressPlayerService _progressPlayerService;
        private readonly IGardenActionService _gardenActionService;
        private readonly CollectCropViewAction _collectCropViewAction;
        private readonly GameplayHudView _view;
        private readonly IMoneyPlayerService _moneyPlayerService;

        public GameplayHudPresenter(
            IDispatcher dispatcher,
            IProgressPlayerService progressPlayerService,
            IGardenActionService gardenActionService,
            GardenViewActionFactoryProvider gardenViewActionFactoryProvider,
            GameplayHudView view,
            IMoneyPlayerService moneyPlayerService
        )
        {
            _dispatcher = dispatcher;
            _progressPlayerService = progressPlayerService;
            _gardenActionService = gardenActionService;
            _collectCropViewAction = gardenViewActionFactoryProvider.Get<CollectCropViewActionFactory>().Create();
            _view = view;
            _moneyPlayerService = moneyPlayerService;
        }

        public void Enable()
        {
            Update();

            _view.Show();
            _view.AddShopButtonClickListener(OnShopButtonClicked);
            _view.AddCollectButtonClickListener(OnCollectButtonClicked);
        }

        public void Disable()
        {
            _view.Hide();
            _view.RemoveShopButtonClickListener(OnShopButtonClicked);
            _view.RemoveCollectButtonClickListener(OnCollectButtonClicked);
        }

        public void Update()
        {
            _view.SetLevel(_progressPlayerService.CurrentLevel.ToString());
            _view.SetMoney(_moneyPlayerService.GetBalance().ToString());
            _view.SetProgress(_progressPlayerService.CurrentProgress);
        }

        private void OnShopButtonClicked()
        {
            _dispatcher.Dispatch(new HideHudEvent());
            _dispatcher.Dispatch(new ShowShopEvent());
        }

        private void OnCollectButtonClicked()
        {
            _gardenActionService.SetAction(_collectCropViewAction);
        }
    }
}