using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Actions.Hud;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers
{
    public class HudController : AbstractController
    {
        public HudController(
            IDispatcher dispatcher,
            IPresenterFactory presenterFactory,
            IGardenPatchPointerControllable gardenPatchPointerControl
        ) : base(dispatcher)
        {
            IGameplayHudPresenter gameplayHudPresenter = presenterFactory.Create<IGameplayHudPresenter>();

            Register(new ShowHudAction(gameplayHudPresenter, gardenPatchPointerControl));
            Register(new HideHudAction(gameplayHudPresenter, gardenPatchPointerControl));
            Register(new UpdateHudAction(gameplayHudPresenter));
        }
    }
}