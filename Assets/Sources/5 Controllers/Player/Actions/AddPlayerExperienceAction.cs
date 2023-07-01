using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Player.Events;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Player.Actions
{
    public class AddPlayerExperienceAction : IControllerAction<AddPlayerExperienceEvent>
    {
        private readonly IProgressPlayerService _progressPlayerService;

        public AddPlayerExperienceAction(IProgressPlayerService progressPlayerService)
        {
            _progressPlayerService = progressPlayerService;
        }

        public void Handle(AddPlayerExperienceEvent @event, IDispatcher dispatcher)
        {
            _progressPlayerService.Add(@event.Experience);
            dispatcher.Dispatch(new UpdateHudEvent());
        }
    }
}