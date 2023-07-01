using HappyFarm.Entities.Sources._1_Entities.Garden;
using UnityEngine;

namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories
{
    public interface ICropRepository
    {
        public Crop[] All { get; }
        public void Set(Crop crop);
        public Crop Get(Vector2Int position);
        public void Remove(Vector2Int position);
    }
}