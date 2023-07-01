using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._1_Entities.Players;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure
{
    public class CurrentPlayerService : ICurrentPlayerService
    {
        public Player CurrentPlayer { get; } = new Player(1, 100, 1000);
    }
}