using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;

namespace Sources._3._1_ApplicationServices.Interfaces.Shop
{
    public interface ISeedsShopService : IApplicationService
    {
        void Buy(IPlantType plantType);
        void Buy(IPlantType plantType, int count);
    }
}