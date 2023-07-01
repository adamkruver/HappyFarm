using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Garden.Actions
{
    public class DisableGardenActionsAction : IControllerAction<DisableGardenActionsEvent>
    {
        private readonly IGardenPatchPointerService _gardenPatchPointerService;
        private readonly IGardenActionService _gardenActionService;

        public DisableGardenActionsAction(
            IGardenPatchPointerService gardenPatchPointerService,
            IGardenActionService gardenActionService)
        {
            _gardenPatchPointerService = gardenPatchPointerService;
            _gardenActionService = gardenActionService;
        }

        public void Handle(DisableGardenActionsEvent @event, IDispatcher dispatcher)
        {
            _gardenPatchPointerService.Selected -= _gardenActionService.Execute;
        }
    }
}