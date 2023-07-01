using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;

namespace HappyFarm.UseCases.Sources._3_UseCases.Plants
{
    public class GetAvailablePlantTypesQuery
    {
        private readonly IPlantTypesDataSource _plantTypesDataSource;

        public GetAvailablePlantTypesQuery(IPlantTypesDataSource plantTypesDataSource)
        {
            _plantTypesDataSource = plantTypesDataSource;
        }

        public IPlantType[] Execute()
        {
            return _plantTypesDataSource.GetPlantTypes();
        }
    }
}