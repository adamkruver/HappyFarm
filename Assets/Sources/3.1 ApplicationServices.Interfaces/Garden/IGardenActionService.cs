using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;

namespace HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden
{
    public interface IGardenActionService : IApplicationService
    {
        void Execute(Vector2Int position);
        void SetAction(IGardenViewAction gardenAction);
    }
}