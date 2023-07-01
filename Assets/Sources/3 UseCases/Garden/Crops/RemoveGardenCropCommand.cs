using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories;
using UnityEngine;

namespace HappyFarm.UseCases.Sources._3_UseCases.Garden.Crops
{
    public class RemoveGardenCropCommand
    {
        private readonly ICropRepository _cropRepository;

        public RemoveGardenCropCommand(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }

        public void Execute(Vector2Int position)
        {
            _cropRepository.Remove(position);
        }
    }
}