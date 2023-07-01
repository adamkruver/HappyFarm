using System;
using UnityEngine;

namespace HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden
{
    public interface IGardenPatchPointerService : IApplicationService
    {
        event Action<Vector2Int> PositionChanged;
        event Action<Vector2Int> Selected;
        
        void Update(float deltaTime);
    }
}