using HappyFarm.Entities.Sources._1_Entities.Garden;
using UnityEngine;

namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories
{
    public interface IPatchRepository
    {
        Patch[] All { get; }
        public void Set(Patch patch);
        public Patch Get(Vector2Int position);
    }
}