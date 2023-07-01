using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using UnityEngine;

namespace HappyFarm.Controllers.Sources._5_Controllers.Garden.Events
{
    public class BuyGardenPatchEvent : IControllerEvent
    {
        public Vector2Int Position { get; }

        public BuyGardenPatchEvent(Vector2Int position)
        {
            Position = position;
        }
    }
}