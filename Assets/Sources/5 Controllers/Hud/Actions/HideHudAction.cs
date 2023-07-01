using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Actions.Hud
{
    public class HideHudAction : IControllerAction<HideHudEvent>
    {
        private readonly IGameplayHudPresenter _gameplayHudPresenter;
        private readonly IGardenPatchPointerControllable _gardenPatchPointerControl;

        public HideHudAction(IGameplayHudPresenter gameplayHudPresenter,
            IGardenPatchPointerControllable gardenPatchPointerControl)
        {
            _gameplayHudPresenter = gameplayHudPresenter;
            _gardenPatchPointerControl = gardenPatchPointerControl;
        }

        public void Handle(HideHudEvent @event, IDispatcher dispatcher)
        {
            _gameplayHudPresenter.Disable();
            _gardenPatchPointerControl.Disable();
            dispatcher.Dispatch(new DisableGardenActionsEvent());
        }
    }
}