using System.Collections.Generic;
using System.Linq;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Shop.Events;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Shop.Views;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using Sources._3._1_ApplicationServices.Interfaces.Shop;

namespace HappyFarm.Presentation.Sources._7_Presentation.Shop.Presenters
{
    public class ShopPresenter : IShopPresenter
    {
        private readonly IDispatcher _dispatcher;
        private readonly ShopView _view;

        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        public ShopPresenter(
            IDispatcher dispatcher,
            IPlantsShopService plantsShopService,
            ShopView view,
            ShopItemPresenterFactory shopItemPresenterFactory,
            ShopItemPatchPresenterFactory shopItemPatchPresenterFactory
        )
        {
            _dispatcher = dispatcher;
            _view = view;

            CreatePatchPresenter(shopItemPatchPresenterFactory);
            CreatePlantPresenters(shopItemPresenterFactory, plantsShopService.GetAvalilableTypes());
        }

        public void Enable()
        {
            _view.Show();

            foreach (IPresenter presenter in _presenters)
                presenter.Enable();

            _view.AddCloseButtonClickListener(OnCloseButtonClicked);
        }

        public void Disable()
        {
            _view.Hide();

            foreach (IPresenter presenter in _presenters)
                presenter.Disable();

            _view.RemoveCloseButtonClickListener(OnCloseButtonClicked);
        }

        public void Update()
        {
            foreach (IPresenter presenter in _presenters)
                presenter.Update();
        }

        private void CreatePatchPresenter(ShopItemPatchPresenterFactory shopItemPatchPresenterFactory)
        {
            ShopItemPatchPresenter presenter = shopItemPatchPresenterFactory.Create();
            _presenters.Add(presenter);
            _view.AddItem(presenter.View);
        }

        private void CreatePlantPresenters(ShopItemPresenterFactory shopItemPresenterFactory, IPlantType[] plantTypes)
        {
            foreach (IPlantType plantType in plantTypes.OrderBy(plantType => plantType.RequiredLevel))
            {
                ShopItemPresenter presenter = shopItemPresenterFactory.Create(plantType);
                _presenters.Add(presenter);
                _view.AddItem(presenter.View);
            }
        }

        private void OnCloseButtonClicked()
        {
            _dispatcher.Dispatch(new HideShopEvent());
            _dispatcher.Dispatch(new ShowHudEvent());
        }
    }
}