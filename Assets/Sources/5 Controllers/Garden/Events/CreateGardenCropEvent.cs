using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using UnityEngine;

namespace HappyFarm.Controllers.Sources._5_Controllers.Garden.Events
{
    public class CreateGardenCropEvent : IControllerEvent
    {
        public CreateGardenCropEvent(IPlantType plantType, Vector2Int position)
        {
            PlantType = plantType;
            Position = position;
        }

        public IPlantType PlantType { get; }
        public Vector2Int Position { get; }
    }
}