using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._1_Entities.Players;
using HappyFarm.UseCases.Sources._3_UseCases.Exceptions;

namespace HappyFarm.UseCases.Sources._3_UseCases.Players.Money
{
    public class AddMoneyCommand
    {
        private readonly ICurrentPlayerService _currentPlayerService;

        public AddMoneyCommand(ICurrentPlayerService currentPlayerService)
        {
            _currentPlayerService = currentPlayerService;
        }

        public void Execute(int money)
        {
            if (money < 0)
                throw new InvalidPayBillException();

            Player player = _currentPlayerService.CurrentPlayer;

            player.Money.Add(money);
        }
    }
}