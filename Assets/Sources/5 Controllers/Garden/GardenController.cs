using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Garden.Actions;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Garden
{
    public class GardenController : AbstractController
    {
        public GardenController(
            IDispatcher dispatcher,
            IGardenPatchPointerService gardenPatchPointerService,
            IGardenActionService gardenActionService,
            IPatchGardenService patchGardenService,
            ICropGardenService cropGardenService,
            IPresenterFactory presenterFactory
        ) : base(dispatcher)
        {
            IGardenPresenter gardenPresenter = presenterFactory.Create<IGardenPresenter>();

            Register(new EnableGardenAction(gardenPresenter));
            Register(new DisableGardenAction(gardenPresenter));
            Register(new UpdateGardenAction(gardenPresenter));
            Register(new EnableGardenActionsAction(gardenPatchPointerService, gardenActionService));
            Register(new DisableGardenActionsAction(gardenPatchPointerService, gardenActionService));
            Register(new BuyGardenPatchAction(patchGardenService));
            Register(new CollectCropAction(gardenPresenter, cropGardenService));
            Register(new CreateGardenCropAction(gardenPresenter, cropGardenService));
        }
    }
}