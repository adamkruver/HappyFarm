using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using UnityEngine;

namespace HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden
{
    public interface ICropGardenService : IApplicationService
    {
        void Create(IPlantType plantType, Vector2Int position);
        Crop Get(Vector2Int position);
        Crop[] GetAll();
        void Collect(Vector2Int position);
    }
}