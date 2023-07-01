using System.Collections.Generic;
using System.Linq;
using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using UnityEngine;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.Repositories
{
    public class CropRepository : ICropRepository
    {
        private readonly List<Crop> _crops = new List<Crop>();

        public void Set(Crop crop)
        {
            Remove(crop.Position);
            _crops.Add(crop);
        }

        public Crop Get(Vector2Int position)
        {
            return _crops.FirstOrDefault(crop => crop.Position == position);
        }

        public void Remove(Vector2Int position)
        {
            _crops.Remove(Get(position));
            
            Debug.Log("Removed");
        }

        public Crop[] All => _crops.ToArray();
    }
}