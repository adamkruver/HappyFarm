using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.UseCases.Sources._3_UseCases.Plants;

namespace HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Player
{
    public class SeedsPlayerService : ISeedsPlayerService
    {
        private readonly GetAvailableSeedsCountQuery _getAvailableSeedsCountQuery;

        public SeedsPlayerService(GetAvailableSeedsCountQuery getAvailableSeedsCountQuery)
        {
            _getAvailableSeedsCountQuery = getAvailableSeedsCountQuery;
        }

        public int GetAvailableCount(IPlantType plantType)
        {
            return _getAvailableSeedsCountQuery.Execute(plantType);
        }
    }
}