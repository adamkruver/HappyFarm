using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Game.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Game.Actions
{
    public class StartGameAction : IControllerAction<StartGameEvent>
    {
        private readonly ITimeService _timeService;
        private readonly IGardenPatchPointerService _gardenPatchPointerService;

        public StartGameAction(
            ITimeService timeService,
            IGardenPatchPointerService gardenPatchPointerService
        )
        {
            _timeService = timeService;
            _gardenPatchPointerService = gardenPatchPointerService;
        }

        public void Handle(StartGameEvent @event, IDispatcher dispatcher)
        {
            _timeService.Updated += _gardenPatchPointerService.Update;
            dispatcher.Dispatch(new ShowHudEvent());
            dispatcher.Dispatch(new EnableGardenEvent());
        }
    }
}