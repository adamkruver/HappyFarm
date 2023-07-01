using HappyFarm.Entities.Sources._1_Entities.Garden;
using UnityEngine;

namespace HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden
{
    public interface IPatchGardenService : IApplicationService
    {
        void Buy(Vector2Int position);
        Patch[] GetAll();
    }
}