using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using UnityEngine;

namespace HappyFarm.Controllers.Sources._5_Controllers.Garden.Events
{
    public class CollectCropEvent : IControllerEvent
    {
        public Vector2Int Position { get; }

        public CollectCropEvent(Vector2Int position)
        {
            Position = position;
        }
    }
}