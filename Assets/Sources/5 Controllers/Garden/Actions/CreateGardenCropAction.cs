using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Garden.Actions
{
    public class CreateGardenCropAction : IControllerAction<CreateGardenCropEvent>
    {
        private readonly IGardenPresenter _gardenPresenter;
        private readonly ICropGardenService _cropGardenService;

        public CreateGardenCropAction(
            IGardenPresenter gardenPresenter, 
            ICropGardenService cropGardenService
        )
        {
            _gardenPresenter = gardenPresenter;
            _cropGardenService = cropGardenService;
        }

        public void Handle(CreateGardenCropEvent @event, IDispatcher dispatcher)
        {
            _cropGardenService.Create(@event.PlantType, @event.Position);
            _gardenPresenter.Update();
        }
    }
}