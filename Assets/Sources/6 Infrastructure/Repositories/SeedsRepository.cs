using System.Collections.Generic;
using HappyFarm.Entities.Sources._1_Entities.Plants;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using UnityEngine;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.Repositories
{
    public class SeedsRepository : ISeedsRepository
    {
        private readonly List<Seeds> _seeds = new List<Seeds>();

        public Seeds Get(IPlantType plantType)
        {
            return GetByType(plantType) 
                   ?? new Seeds(plantType, 0);
        }

        public void Set(IPlantType plantType, int count)
        {
            _seeds.Remove(GetByType(plantType));
            _seeds.Add(new Seeds(plantType, count));
        }

        private Seeds GetByType(IPlantType plantType)
        {
            foreach (Seeds seeds in _seeds)
                if (seeds.PlantType.GetType() == plantType.GetType())
                    return seeds;

            return default;
        }
    }
}