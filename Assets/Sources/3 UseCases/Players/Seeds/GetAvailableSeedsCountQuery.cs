using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;

namespace HappyFarm.UseCases.Sources._3_UseCases.Plants
{
    public class GetAvailableSeedsCountQuery
    {
        private readonly ISeedsRepository _seedsRepository;

        public GetAvailableSeedsCountQuery(ISeedsRepository seedsRepository)
        {
            _seedsRepository = seedsRepository;
        }

        public int Execute(IPlantType plantType)
        {
            return _seedsRepository.Get(plantType).Count;
        }
    }
}