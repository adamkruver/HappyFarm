using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.UseCases.Sources._3_UseCases.Exceptions;
using UnityEngine;

namespace HappyFarm.UseCases.Sources._3_UseCases.Garden.Crops
{
    public class CreateGardenCropCommand
    {
        private readonly ICropRepository _cropRepository;
        private readonly IPatchRepository _patchRepository;
        private readonly ITimeService _timeService;

        public CreateGardenCropCommand(
            ICropRepository cropRepository, 
            IPatchRepository patchRepository,
            ITimeService timeService
            )
        {
            _cropRepository = cropRepository;
            _patchRepository = patchRepository;
            _timeService = timeService;
        }

        public void Execute(IPlantType plantType, Vector2Int position)
        {
            if (HasMissingGardenPatch(position))
                throw new MissingGardenPatchException();

            if (ExistsGardenCrop(position))
                throw new AlreadyExistsGardenCropException();

            float createdAt = _timeService.Current;
            Crop crop = new Crop(plantType, createdAt, position);

            _cropRepository.Set(crop);
        }

        private bool HasMissingGardenPatch(Vector2Int position)
        {
            return _patchRepository.Get(position) == null;
        }

        private bool ExistsGardenCrop(Vector2Int position)
        {
            return _cropRepository.Get(position) != null;
        }
    }
}