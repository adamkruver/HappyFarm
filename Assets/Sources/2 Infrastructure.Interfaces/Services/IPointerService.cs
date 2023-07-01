using UnityEngine;

namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services
{
    public interface IPointerService
    {
        public Vector3? WorldPoint { get; }
        public Vector3? ScreenPoint { get; }
    }
}