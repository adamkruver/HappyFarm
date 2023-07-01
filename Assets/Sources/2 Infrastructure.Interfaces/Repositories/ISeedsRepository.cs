using HappyFarm.Entities.Sources._1_Entities.Plants;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;

namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories
{
    public interface ISeedsRepository
    {
        Seeds Get(IPlantType plantType);
        void Set(IPlantType plantType, int count);
    }
}