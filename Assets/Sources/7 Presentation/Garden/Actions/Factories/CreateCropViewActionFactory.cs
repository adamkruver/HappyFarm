using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories
{
    public class CreateCropViewActionFactory : IGardenViewActionFactory
    {
        private readonly IDispatcher _dispatcher;

        public CreateCropViewActionFactory(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public CreateCropViewAction Create(IPlantType plantType)
        {
            return new CreateCropViewAction(_dispatcher, plantType);
        }
    }
}