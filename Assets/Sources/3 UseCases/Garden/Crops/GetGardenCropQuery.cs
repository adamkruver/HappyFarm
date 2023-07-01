using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using HappyFarm.UseCases.Sources._3_UseCases.Exceptions;
using UnityEngine;

namespace HappyFarm.UseCases.Sources._3_UseCases.Garden.Crops
{
    public class GetGardenCropQuery
    {
        private readonly ICropRepository _cropRepository;

        public GetGardenCropQuery(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }

        public Crop Execute(Vector2Int position)
        {
            return _cropRepository.Get(position) ?? throw new MissingGardenCropException();
        }
    }
}