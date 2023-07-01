using HappyFarm.UseCases.Sources._1_Entities.Players;

namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Player Get(int id);
        void Set(Player player);
    }
}