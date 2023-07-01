using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Actions.Hud
{
    public class ShowHudAction : IControllerAction<ShowHudEvent>
    {
        private readonly IGameplayHudPresenter _gameplayHudPresenter;
        private readonly IGardenPatchPointerControllable _gardenPatchPointerControl;

        public ShowHudAction(IGameplayHudPresenter gameplayHudPresenter,
            IGardenPatchPointerControllable gardenPatchPointerControl)
        {
            _gameplayHudPresenter = gameplayHudPresenter;
            _gardenPatchPointerControl = gardenPatchPointerControl;
        }

        public void Handle(ShowHudEvent @event, IDispatcher dispatcher)
        {
            _gameplayHudPresenter.Enable();
            _gardenPatchPointerControl.Enable();
            dispatcher.Dispatch(new EnableGardenActionsEvent());
        }
    }
}