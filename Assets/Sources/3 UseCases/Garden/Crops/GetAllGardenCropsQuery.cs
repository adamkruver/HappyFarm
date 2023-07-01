using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;

namespace HappyFarm.UseCases.Sources._3_UseCases.Garden.Crops
{
    public class GetAllGardenCropsQuery
    {
        private readonly ICropRepository _cropRepository;

        public GetAllGardenCropsQuery(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }

        public Crop[] Execute()
        {
            return _cropRepository.All;
        }
    }
}