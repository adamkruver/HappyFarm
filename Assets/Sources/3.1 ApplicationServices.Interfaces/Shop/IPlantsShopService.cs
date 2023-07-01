using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;

namespace Sources._3._1_ApplicationServices.Interfaces.Shop
{
    public interface IPlantsShopService : IApplicationService
    {
        IPlantType[] GetAvalilableTypes();
        int GetPrice(IPlantType plantType);
    }
}