using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Shop.Events;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Enums;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Views;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Shop.Presenters
{
    public class ShopItemPresenter : IPresenter
    {
        private readonly IDispatcher _dispatcher;
        private readonly IProgressPlayerService _progressPlayerService;
        private readonly IGardenActionService _gardenActionService;
        private readonly CreateCropViewAction _createCropViewAction;
        private readonly ShopItemView _view;
        private readonly IPlantType _plantType;

        public ShopItemPresenter(
            IDispatcher dispatcher,
            IProgressPlayerService progressPlayerService,
            IGardenActionService gardenActionService,
            GardenViewActionFactoryProvider gardenViewActionFactoryProvider,
            ShopItemView view,
            IPlantType plantType,
            string title,
            Sprite icon,
            int price
        )
        {
            _createCropViewAction =
                gardenViewActionFactoryProvider.Get<CreateCropViewActionFactory>().Create(plantType);
            _dispatcher = dispatcher;
            _progressPlayerService = progressPlayerService;
            _gardenActionService = gardenActionService;
            _view = view;
            _plantType = plantType;

            _view.SetTitle(title);
            _view.SetIcon(icon);
            _view.SetPrice(price.ToString());

            Update();
        }

        public IView View => _view;

        private ContentStatus ContentStatus => _progressPlayerService.CurrentLevel < _plantType.RequiredLevel
            ? ContentStatus.Locked
            : ContentStatus.Opened;

        public void Enable()
        {
            Update();
            _view.AddBuyButtonClickListener(OnBuyButtonClicked);
            _view.Show();
        }

        public void Update()
        {
            _view.SetStatus(ContentStatus);
        }

        public void Disable()
        {
            _view.Hide();
            _view.RemoveBuyButtonClickListener(OnBuyButtonClicked);
        }

        private void OnBuyButtonClicked()
        {
            if (ContentStatus != ContentStatus.Opened)
                return;

            _gardenActionService.SetAction(_createCropViewAction);
            _dispatcher.Dispatch(new HideShopEvent());
            _dispatcher.Dispatch(new ShowHudEvent());
        }
    }
}