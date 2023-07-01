using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;

namespace HappyFarm.UseCases.Sources._3_UseCases.Garden.Patchs
{
    public class GetAllPatchesQuery
    {
        private readonly IPatchRepository _patchRepository;

        public GetAllPatchesQuery(IPatchRepository patchRepository)
        {
            _patchRepository = patchRepository;
        }

        public Patch[] Execute()
        {
            return _patchRepository.All;
        }
    }
}