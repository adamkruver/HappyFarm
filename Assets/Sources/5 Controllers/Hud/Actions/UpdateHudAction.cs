using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Actions.Hud
{
    public class UpdateHudAction : IControllerAction<UpdateHudEvent>
    {
        private readonly IGameplayHudPresenter _presenter;

        public UpdateHudAction(IGameplayHudPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Handle(UpdateHudEvent @event, IDispatcher dispatcher)
        {
            _presenter.Update();
        }
    }
}