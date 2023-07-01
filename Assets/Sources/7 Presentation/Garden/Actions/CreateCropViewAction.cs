using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions
{
    public class CreateCropViewAction : IGardenViewAction
    {
        private readonly IDispatcher _dispatcher;
        private readonly IPlantType _plantType;

        public CreateCropViewAction(IDispatcher dispatcher, IPlantType plantType)
        {
            _dispatcher = dispatcher;
            _plantType = plantType;
        }

        public void Execute(Vector2Int position)
        {
            _dispatcher.Dispatch(new CreateGardenCropEvent(_plantType, position));
        }
    }
}