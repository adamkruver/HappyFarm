using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;

namespace HappyFarm.Entities.Sources._1_Entities.Plants
{
    public class Seeds
    {
        public Seeds(IPlantType plantType, int count)
        {
            PlantType = plantType;
            Count = count;
        }

        public IPlantType PlantType { get; }
        public int Count { get; }
    }
}