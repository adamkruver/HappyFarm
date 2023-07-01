using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._1_Entities.Players;

namespace HappyFarm.UseCases.Sources._3_UseCases.Players.Progress
{
    public class GetPlayerLevelQuery
    {
        private readonly ICurrentPlayerService _currentPlayerService;

        public GetPlayerLevelQuery(ICurrentPlayerService currentPlayerService)
        {
            _currentPlayerService = currentPlayerService;
        }

        public int Execute()
        {
            Player player = _currentPlayerService.CurrentPlayer;
            
            return player.Progress.Level;
        }
    }
}