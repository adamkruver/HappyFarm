using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.DataSources.Plants
{
    public class PlantTypesDataSource : IPlantTypesDataSource
    {
        public IPlantType[] GetPlantTypes()
        {
            return new IPlantType[]
            {
                new Pumkin(),
                new Egglant(),
                new Watermelon(),
                new Beet()
            };
        }
    }
}