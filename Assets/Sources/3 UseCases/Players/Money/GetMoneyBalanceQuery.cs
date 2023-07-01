using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._1_Entities.Players;

namespace HappyFarm.UseCases.Sources._3_UseCases.Players.Money
{
    public class GetMoneyBalanceQuery
    {
        private readonly ICurrentPlayerService _currentPlayerService;

        public GetMoneyBalanceQuery(ICurrentPlayerService currentPlayerService)
        {
            _currentPlayerService = currentPlayerService;
        }

        public int Execute()
        {
            Player player = _currentPlayerService.CurrentPlayer;
            
            return player.Money.Value;
        }
    }
}