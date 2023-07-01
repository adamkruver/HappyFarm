using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._1_Entities.Players;

namespace HappyFarm.UseCases.Sources._3_UseCases.Players.Progress
{
    public class GetPlayerProgressQuery
    {
        private readonly ICurrentPlayerService _currentPlayerService;

        public GetPlayerProgressQuery(ICurrentPlayerService currentPlayerService)
        {
            _currentPlayerService = currentPlayerService;
        }

        public float Execute()
        {
            Player player = _currentPlayerService.CurrentPlayer;

            return player.Progress.Experience;
        }
    }
}