using System.Collections.Generic;
using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using UnityEngine;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.Repositories
{
    public class PatchRepository : IPatchRepository
    {
        private readonly List<Patch> _patches = new List<Patch>();
        
        public void Set(Patch patch)
        {
            Patch currentPatch = GetByPosition(patch.Position);
            _patches.Remove(currentPatch);
            _patches.Add(patch);
        }

        public Patch[] All => _patches.ToArray();

        public Patch Get(Vector2Int position)
        {
            return GetByPosition(position);
        }

        private Patch GetByPosition(Vector2Int position)
        {
            foreach (Patch patch in _patches)
                if (patch.Position == position)
                    return patch;

            return default;
        }
    }
}