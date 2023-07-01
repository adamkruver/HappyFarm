using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;

namespace HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player
{
    public interface ISeedsPlayerService
    {
        int GetAvailableCount(IPlantType plantType);
    }
}