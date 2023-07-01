namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants
{
    public interface IPlantDto
    {
        float GrowTime { get; }
        float HarvestTime { get; }
        string Title { get; }
        string Type { get; }
        int Price { get; }
        int AdditionalCost { get; }
        int Experience { get; }
        string IconPath { get; }
        string[] GrowSpritePaths { get; }
        string HarvestSpritePath { get; }
        string RottenSpritePath { get; }
    }
}