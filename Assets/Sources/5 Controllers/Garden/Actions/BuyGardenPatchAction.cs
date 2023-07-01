using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Shop.Events;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Garden.Actions
{
    public class BuyGardenPatchAction : IControllerAction<BuyGardenPatchEvent>
    {
        private readonly IPatchGardenService _patchGardenService;

        public BuyGardenPatchAction(
            IPatchGardenService patchGardenService
        )
        {
            _patchGardenService = patchGardenService;
        }

        public void Handle(BuyGardenPatchEvent @event, IDispatcher dispatcher)
        {
            _patchGardenService.Buy(@event.Position);
            dispatcher.Dispatch(new UpdateGardenEvent());
            dispatcher.Dispatch(new UpdateShopEvent());
        }
    }
}