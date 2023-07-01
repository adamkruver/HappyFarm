using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Exceptions;
using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.UseCases.Sources._3_UseCases.Exceptions;
using HappyFarm.UseCases.Sources._3_UseCases.Garden.Crops;
using UnityEngine;

namespace HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Garden
{
    public class CropGardenService : ICropGardenService
    {
        private readonly IApplicationServiceProvider _applicationServiceProvider;
        private readonly ITimeService _timeService;
        private readonly IPlantDataSource _plantDataSource;
        private readonly CreateGardenCropCommand _createGardenCropCommand;
        private readonly GetAllGardenCropsQuery _getAllGardenCropsQuery;
        private readonly GetGardenCropQuery _getGardenCropQuery;
        private readonly RemoveGardenCropCommand _removeGardenCropCommand;

        public CropGardenService(
            IApplicationServiceProvider applicationServiceProvider,
            ITimeService timeService,
            IPlantDataSource plantDataSource,
            CreateGardenCropCommand createGardenCropCommand,
            GetAllGardenCropsQuery getAllGardenCropsQuery,
            GetGardenCropQuery getGardenCropQuery,
            RemoveGardenCropCommand removeGardenCropCommand
        )
        {
            _applicationServiceProvider = applicationServiceProvider;
            _timeService = timeService;
            _plantDataSource = plantDataSource;
            _createGardenCropCommand = createGardenCropCommand;
            _getAllGardenCropsQuery = getAllGardenCropsQuery;
            _getGardenCropQuery = getGardenCropQuery;
            _removeGardenCropCommand = removeGardenCropCommand;
        }

        private IMoneyPlayerService MoneyPlayerService => _applicationServiceProvider.Get<IMoneyPlayerService>();

        private IProgressPlayerService ProgressPlayerService =>
            _applicationServiceProvider.Get<IProgressPlayerService>();

        public void Create(IPlantType plantType, Vector2Int position)
        {
            IPlantDto plantDto = _plantDataSource.Get(plantType);

            if (MoneyPlayerService.GetBalance() < plantDto.Price)
                throw new NotEnoughMoneyException();

            _createGardenCropCommand.Execute(plantType, position);
            MoneyPlayerService.Pay(plantDto.Price);
        }

        public Crop Get(Vector2Int position)
        {
            return _getGardenCropQuery.Execute(position);
        }

        public Crop[] GetAll()
        {
            return _getAllGardenCropsQuery.Execute();
        }

        public void Collect(Vector2Int position)
        {
            Crop crop = Get(position);
            IPlantDto plantDto = _plantDataSource.Get(crop.PlantType);

            if (CanHarvest(crop))
            {
                MoneyPlayerService.Add(plantDto.Price + plantDto.AdditionalCost);
                ProgressPlayerService.Add(plantDto.Experience);
            }
            else if (CanClean(crop))
            {
            }
            else
            {
                MoneyPlayerService.Add(Mathf.Max(plantDto.Price/2, 1));
            }
            _removeGardenCropCommand.Execute(crop.Position);
        }

        private bool CanClean(Crop crop)
        {
            IPlantDto plantDto = _plantDataSource.Get(crop.PlantType);
            float time = _timeService.Current - crop.CreatedAt;

            return time >= plantDto.GrowTime + plantDto.HarvestTime;
        }

        private bool CanHarvest(Crop crop)
        {
            IPlantDto plantDto = _plantDataSource.Get(crop.PlantType);
            float time = _timeService.Current - crop.CreatedAt;

            return time >= plantDto.GrowTime && time < plantDto.GrowTime + plantDto.HarvestTime;
        }
    }
}