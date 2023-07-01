using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;

namespace HappyFarm.UseCases.Sources._3_UseCases.Shop.Items
{
    public class GetPlantTypePriceQuery
    {
        private readonly IPlantDataSource _plantDataSource;

        public GetPlantTypePriceQuery(IPlantDataSource plantDataSource)
        {
            _plantDataSource = plantDataSource;
        }

        public int Execute(IPlantType plantType)
        {
            IPlantDto plantDto = _plantDataSource.Get(plantType);

            return plantDto.Price;
        }
    }
}