using HappyFarm.UseCases.Sources._1_Entities.Players;

namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces
{
    public interface ICurrentPlayerService
    {
        Player CurrentPlayer { get; }
    }
}