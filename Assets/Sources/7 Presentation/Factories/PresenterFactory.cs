using System;
using System.Collections.Generic;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Presenter;
using HappyFarm.Presentation.Sources._7_Presentation.Hud.Presenters;
using HappyFarm.Presentation.Sources._7_Presentation.Hud.Views;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Presenters;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Views;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using Sources._3._1_ApplicationServices.Interfaces.Shop;

namespace HappyFarm.Presentation.Sources._7_Presentation.Factories
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly Dictionary<Type, Func<IPresenter>> _factories;

        public PresenterFactory(
            IDispatcher dispatcher,
            ViewFactory viewFactory,
            IMoneyPlayerService moneyPlayerService,
            IPlantsShopService plantsShopService,
            IPatchGardenService patchGardenService,
            IProgressPlayerService progressPlayerService,
            ICropGardenService cropGardenService,
            IGardenActionService gardenActionService,
            ShopItemPresenterFactory shopItemPresenterFactory,
            ShopItemPatchPresenterFactory shopItemPatchPresenterFactory,
            PatchPresenterFactory patchPresenterFactory,
            CropPresenterFactory cropPresenterFactory,
            GardenViewActionFactoryProvider gardenViewActionFactoryProvider
        )
        {
            _factories = new Dictionary<Type, Func<IPresenter>>()
            {
                [typeof(IGameplayHudPresenter)] = () =>
                    new GameplayHudPresenter(
                        dispatcher,
                        progressPlayerService,
                        gardenActionService,
                        gardenViewActionFactoryProvider,
                        viewFactory.Create<GameplayHudView>(),
                        moneyPlayerService
                    ),

                [typeof(IShopPresenter)] = () =>
                    new ShopPresenter(
                        dispatcher,
                        plantsShopService,
                        viewFactory.Create<ShopView>(),
                        shopItemPresenterFactory,
                        shopItemPatchPresenterFactory
                    ),

                [typeof(IGardenPresenter)] = () =>
                    new GardenPresenter(
                        patchGardenService,
                        cropGardenService,
                        patchPresenterFactory,
                        cropPresenterFactory
                    ),
            };
        }

        public T Create<T>() where T : IPresenter
        {
            return (T)_factories[typeof(T)].Invoke();
        }
    }
}