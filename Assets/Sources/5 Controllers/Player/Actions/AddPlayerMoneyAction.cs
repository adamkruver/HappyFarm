using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.Controllers.Sources._5_Controllers.Player.Events;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using UnityEngine;

namespace HappyFarm.Controllers.Sources._5_Controllers.Player.Actions
{
    public class AddPlayerMoneyAction : IControllerAction<AddPlayerMoneyEvent>
    {
        private readonly IPointerService _pointerService;
        private readonly IMoneyNotifierPresenterFactory _moneyNotifierPresenterFactory;

        public AddPlayerMoneyAction(
            IPointerService pointerService,
            IMoneyNotifierPresenterFactory moneyNotifierPresenterFactory
        )
        {
            _pointerService = pointerService;
            _moneyNotifierPresenterFactory = moneyNotifierPresenterFactory;
        }

        public void Handle(AddPlayerMoneyEvent @event, IDispatcher dispatcher)
        {
            if (_pointerService.WorldPoint is Vector3 spawnPosition)
            {
                IMoneyNotifierPresenter presenter = _moneyNotifierPresenterFactory.Create(@event.Money, spawnPosition);
                presenter.Enable();
            }
        }
    }
}