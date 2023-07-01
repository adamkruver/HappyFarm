using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Presenter;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Factories
{
    public class CropPresenterFactory
    {
        private readonly IGardenGrid _gardenGrid;
        private readonly IPlantDataSource _dataSource;
        private readonly ITimeService _timeService;
        private readonly TileFactory _tileFactory;

        public CropPresenterFactory(
            IGardenGrid gardenGrid,
            IPlantDataSource dataSource,
            ITimeService timeService,
            TileFactory tileFactory
        )
        {
            _gardenGrid = gardenGrid;
            _dataSource = dataSource;
            _timeService = timeService;
            _tileFactory = tileFactory;
        }

        public CropPresenter Create(Crop crop)
        {
            return new CropPresenter(
                _gardenGrid.Crops,
                crop,
                _dataSource.Get(crop.PlantType),
                _timeService,
                _tileFactory
            );
        }
    }
}