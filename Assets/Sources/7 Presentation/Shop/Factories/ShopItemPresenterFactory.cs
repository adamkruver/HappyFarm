using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;
using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Presenters;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Views;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._3_UseCases.Plants;
using Sources._3._1_ApplicationServices.Interfaces.Shop;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Shop.Factories
{
    public class ShopItemPresenterFactory
    {
        private readonly IDispatcher _dispatcher;
        private readonly IProgressPlayerService _progressPlayerService;
        private readonly IGardenActionService _gardenActionService;
        private readonly GardenViewActionFactoryProvider _gardenViewActionFactoryProvider;
        private readonly ViewFactory _viewFactory;
        private readonly SpriteFactory _spriteFactory;
        private readonly IPlantDataSource _plantDataSource;
        private readonly GetAvailableSeedsCountQuery _getAvailableSeedsCountQuery;

        public ShopItemPresenterFactory(
            IDispatcher dispatcher,
            IProgressPlayerService progressPlayerService,
            IGardenActionService gardenActionService,
            GardenViewActionFactoryProvider gardenViewActionFactoryProvider,
            ViewFactory viewFactory,
            SpriteFactory spriteFactory,
            IPlantDataSource plantDataSource
        )
        {
            _dispatcher = dispatcher;
            _progressPlayerService = progressPlayerService;
            _gardenActionService = gardenActionService;
            _gardenViewActionFactoryProvider = gardenViewActionFactoryProvider;
            _viewFactory = viewFactory;
            _spriteFactory = spriteFactory;
            _plantDataSource = plantDataSource;
        }

        public ShopItemPresenter Create(IPlantType plantType)
        {
            IPlantDto plantDto = _plantDataSource.Get(plantType);
            Sprite icon = _spriteFactory.Load(plantDto.IconPath);
            ShopItemView view = _viewFactory.Create<ShopItemView>();
            string title = plantDto.Title;
            int price = plantDto.Price;

            return new ShopItemPresenter(
                _dispatcher,
                _progressPlayerService,
                _gardenActionService,
                _gardenViewActionFactoryProvider,
                view,
                plantType,
                title,
                icon,
                price
            );
        }
    }
}