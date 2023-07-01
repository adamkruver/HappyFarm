using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using UnityEngine;

namespace HappyFarm.UseCases.Sources._3_UseCases.Garden.Patchs
{
    public class ExistsCardenPatchQuery
    {
        private readonly IPatchRepository _patchRepository;

        public ExistsCardenPatchQuery(IPatchRepository patchRepository)
        {
            _patchRepository = patchRepository;
        }

        public bool Execute(Vector2Int position)
        {
            return _patchRepository.Get(position) != null;
        }
    }
}