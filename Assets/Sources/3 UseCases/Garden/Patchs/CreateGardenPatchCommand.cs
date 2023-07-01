using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using HappyFarm.UseCases.Sources._3_UseCases.Exceptions;
using UnityEngine;

namespace HappyFarm.UseCases.Sources._3_UseCases.Garden.Patchs
{
    public class CreateGardenPatchCommand
    {
        private readonly IPatchRepository _patchRepository;

        public CreateGardenPatchCommand(IPatchRepository patchRepository)
        {
            _patchRepository = patchRepository;
        }

        public void Execute(Vector2Int position)
        {
            Patch patch = _patchRepository.Get(position);

            if (patch != null)
                throw new AlreadyExistsGardenPatchException();

            patch = new Patch(position);
            
            _patchRepository.Set(patch);
        }
    }
}