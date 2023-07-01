using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;

namespace HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Garden.Actions
{
    public class GardenActionService : IGardenActionService
    {
        private IGardenViewAction _gardenAction;

        public void Execute(Vector2Int position)
        {
            Debug.Log($"X: {position.x} Y: {position.y} ------------");
            _gardenAction?.Execute(position);
        }

        public void SetAction(IGardenViewAction gardenAction) =>
            _gardenAction = gardenAction;
    }
}