using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices;
using HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Garden;
using HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Garden.Actions;
using HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Player;
using HappyFarm.Controllers.Sources._5_Controllers;
using HappyFarm.Controllers.Sources._5_Controllers.Game;
using HappyFarm.Controllers.Sources._5_Controllers.Game.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Player;
using HappyFarm.Controllers.Sources._5_Controllers.Shop;
using HappyFarm.Infrastructure.Sources._6_Infrastructure;
using HappyFarm.Infrastructure.Sources._6_Infrastructure.DataSources.Plants;
using HappyFarm.Infrastructure.Sources._6_Infrastructure.EventDispatcher;
using HappyFarm.Infrastructure.Sources._6_Infrastructure.Repositories;
using HappyFarm.Infrastructure.Sources._6_Infrastructure.Repositories.Services;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Player.Money.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Factories;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._3_UseCases.Garden.Crops;
using HappyFarm.UseCases.Sources._3_UseCases.Garden.Patchs;
using HappyFarm.UseCases.Sources._3_UseCases.Plants;
using HappyFarm.UseCases.Sources._3_UseCases.Players.Money;
using HappyFarm.UseCases.Sources._3_UseCases.Players.Progress;
using HappyFarm.UseCases.Sources._3_UseCases.Shop.Items;
using Sources._3._1_ApplicationServices.Interfaces.Shop;
using Sources._5._1_ApplicationServices.Shop;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.General
{
    public class AppBuilder : MonoBehaviour
    {
        private Dispatcher _dispatcher;
        private ITimeService _timeService;

        private void Awake()
        {
            _dispatcher = new Dispatcher();
            _timeService = new TimeService();

            // Infrastructure Services

            ICurrentPlayerService currentPlayerService = new CurrentPlayerService();
            ICameraService cameraService = new CameraService();
            IPointerService pointerService = new PointerService(cameraService);

            // Data Sources

            IPlantTypesDataSource plantTypesDataSource = new PlantTypesDataSource();
            IPlantDataSource plantDataSource = new PlantDataSource();

            //Factories

            SpriteFactory spriteFactory = new SpriteFactory();
            GardenGridFactory gardenGridFactory = new GardenGridFactory();
            TileFactory tileFactory = new TileFactory();

            //Repositories

            ISeedsRepository seedsRepository = new SeedsRepository();
            IPatchRepository patchRepository = new PatchRepository();
            ICropRepository cropRepository = new CropRepository();

            // UseCases

            GetPlayerLevelQuery getPlayerLevelQuery = new GetPlayerLevelQuery(currentPlayerService);
            GetPlayerProgressQuery getPlayerProgressQuery = new GetPlayerProgressQuery(currentPlayerService);
            GetAvailablePlantTypesQuery getAvailablePlantTypesQuery =
                new GetAvailablePlantTypesQuery(plantTypesDataSource);
            GetPlantTypePriceQuery getPlantTypePriceQuery = new GetPlantTypePriceQuery(plantDataSource);
            GetAvailableSeedsCountQuery getAvailableSeedsCountQuery = new GetAvailableSeedsCountQuery(seedsRepository);
            GetMoneyBalanceQuery getMoneyBalanceQuery = new GetMoneyBalanceQuery(currentPlayerService);
            BuySeedsCommand buySeedsCommand =
                new BuySeedsCommand(seedsRepository);
            PayCommand payCommand = new PayCommand(currentPlayerService);
            CreateGardenPatchCommand createGardenPatchCommand = new CreateGardenPatchCommand(patchRepository);
            CreateGardenCropCommand createGardenCropCommand =
                new CreateGardenCropCommand(cropRepository, patchRepository, _timeService);
            GetAllPatchesQuery getAllPatchesQuery = new GetAllPatchesQuery(patchRepository);
            GetGardenCropQuery getGardenCropQuery = new GetGardenCropQuery(cropRepository);
            GetAllGardenCropsQuery getAllGardenCropsQuery = new GetAllGardenCropsQuery(cropRepository);
            AddMoneyCommand addMoneyCommand = new AddMoneyCommand(currentPlayerService);
            RemoveGardenCropCommand removeGardenCropCommand = new RemoveGardenCropCommand(cropRepository);
            AddPlayerExperienceCommand addPlayerExperienceCommand =
                new AddPlayerExperienceCommand(currentPlayerService);

            //

            IGardenGrid gardenGrid = gardenGridFactory.Create();

            //ApplicationServices

            ApplicationServiceProvider applicationServiceProvider = new ApplicationServiceProvider();

            GardenActionService gardenActionService = new GardenActionService();

            PlantsShopService plantsShopService = new PlantsShopService(
                _dispatcher,
                applicationServiceProvider,
                getAvailablePlantTypesQuery,
                getPlantTypePriceQuery);

            SeedsShopService seedsShopService = new SeedsShopService(
                _dispatcher,
                applicationServiceProvider,
                buySeedsCommand);

            MoneyPlayerService moneyPlayerService = new MoneyPlayerService(
                _dispatcher,
                applicationServiceProvider,
                getMoneyBalanceQuery,
                payCommand,
                addMoneyCommand
            );

            GardenPatchPointerService gardenPatchPointerService =
                new GardenPatchPointerService(pointerService, gardenGrid);

            SeedsPlayerService seedsPlayerService = new SeedsPlayerService(getAvailableSeedsCountQuery);
            ProgressPlayerService progressPlayerService =
                new ProgressPlayerService(getPlayerLevelQuery, getPlayerProgressQuery, addPlayerExperienceCommand);
            PatchGardenService patchGardenService = new PatchGardenService(applicationServiceProvider,
                createGardenPatchCommand, getAllPatchesQuery);

            CropGardenService cropGardenService =
                new CropGardenService(
                    applicationServiceProvider,
                    _timeService,
                    plantDataSource,
                    createGardenCropCommand,
                    getAllGardenCropsQuery,
                    getGardenCropQuery,
                    removeGardenCropCommand
                );
            
            PatchShopService patchShopService = new PatchShopService(getAllPatchesQuery);

            applicationServiceProvider.Register<IPlantsShopService>(plantsShopService);
            applicationServiceProvider.Register<ISeedsShopService>(seedsShopService);
            applicationServiceProvider.Register<IMoneyPlayerService>(moneyPlayerService);
            applicationServiceProvider.Register<IGardenPatchPointerService>(gardenPatchPointerService);
            applicationServiceProvider.Register<IGardenActionService>(gardenActionService);
            applicationServiceProvider.Register<IProgressPlayerService>(progressPlayerService);
            applicationServiceProvider.Register<IPatchGardenService>(patchGardenService);
            applicationServiceProvider.Register<ICropGardenService>(cropGardenService);
            applicationServiceProvider.Register<IPatchShopService>(patchShopService);

            // ViewActions

            BuyPatchGardenViewAction buyPatchGardenViewAction = new BuyPatchGardenViewAction(_dispatcher);

            //Presentation Factories

            GardenViewActionFactoryProvider gardenViewActionFactoryProvider =
                new GardenViewActionFactoryProvider(_dispatcher);

            ViewFactory viewFactory = new ViewFactory();

            CropPresenterFactory cropPresenterFactory =
                new CropPresenterFactory(gardenGrid, plantDataSource, _timeService, tileFactory);

            PatchPresenterFactory patchPresenterFactory = new PatchPresenterFactory(gardenGrid, tileFactory);

            ShopItemPatchPresenterFactory shopItemPatchPresenterFactory =
                new ShopItemPatchPresenterFactory(
                    _dispatcher,
                    gardenActionService,
                    patchShopService,
                    viewFactory,
                    buyPatchGardenViewAction
                );

            ShopItemPresenterFactory shopItemPresenterFactory =
                new ShopItemPresenterFactory(
                    _dispatcher,
                    progressPlayerService,
                    gardenActionService,
                    gardenViewActionFactoryProvider,
                    viewFactory,
                    spriteFactory,
                    plantDataSource
                );

            PresenterFactory presenterFactory =
                new PresenterFactory(
                    _dispatcher,
                    viewFactory,
                    moneyPlayerService,
                    plantsShopService,
                    patchGardenService,
                    progressPlayerService,
                    cropGardenService,
                    gardenActionService,
                    shopItemPresenterFactory,
                    shopItemPatchPresenterFactory,
                    patchPresenterFactory,
                    cropPresenterFactory,
                    gardenViewActionFactoryProvider
                );

            MoneyNotifierPresenterFactory moneyNotifierPresenterFactory =
                new MoneyNotifierPresenterFactory(viewFactory);

            // Controllers

            HudController hudController = new HudController(_dispatcher, presenterFactory, gardenPatchPointerService);
            _dispatcher.RegisterController(hudController);

            ShopController shopController = new ShopController(_dispatcher, presenterFactory);
            _dispatcher.RegisterController(shopController);

            GameController gameController = new GameController(_dispatcher, _timeService, gardenPatchPointerService);
            _dispatcher.RegisterController(gameController);

            GardenController gardenController =
                new GardenController(
                    _dispatcher,
                    gardenPatchPointerService,
                    gardenActionService,
                    patchGardenService,
                    cropGardenService,
                    presenterFactory
                );

            PlayerController playerController =
                new PlayerController(_dispatcher, pointerService, progressPlayerService, moneyNotifierPresenterFactory);
            _dispatcher.RegisterController(playerController);

            _dispatcher.RegisterController(gardenController);
        }

        public void Build()
        {
            _dispatcher.Dispatch(new StartGameEvent());
        }

        private void Update()
        {
            _timeService.Update(Time.deltaTime);
        }
    }
}