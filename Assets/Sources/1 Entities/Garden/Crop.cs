using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using UnityEngine;

namespace HappyFarm.Entities.Sources._1_Entities.Garden
{
    public class Crop
    {
        public Crop(IPlantType plantType, float createdAt, Vector2Int position)
        {
            PlantType = plantType;
            CreatedAt = createdAt;
            Position = position;
        }

        public IPlantType PlantType { get; }
        public float CreatedAt { get; }
        public Vector2Int Position { get; }
    }
}