using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;

namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants
{
    public interface IPlantDataSource
    {
        IPlantDto Get(IPlantType plantType);
    }
}