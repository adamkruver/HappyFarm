using HappyFarm.Entities.Sources._1_Entities.Plants;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using HappyFarm.UseCases.Sources._3_UseCases.Players.Money;
using UnityEngine;

namespace HappyFarm.UseCases.Sources._3_UseCases.Shop.Items
{
    public class BuySeedsCommand
    {
        private readonly ISeedsRepository _seedsRepository;

        public BuySeedsCommand(
            ISeedsRepository seedsRepository
        )
        {
            _seedsRepository = seedsRepository;
        }

        public void Execute(IPlantType plantType)
        {
            int seedsCount = _seedsRepository.Get(plantType).Count;
            seedsCount ++;
            
            _seedsRepository.Set(plantType, seedsCount);
        }
    }
}