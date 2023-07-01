using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._1_Entities.Players;
using HappyFarm.UseCases.Sources._3_UseCases.Exceptions;

namespace HappyFarm.UseCases.Sources._3_UseCases.Players.Money
{
    public class PayCommand
    {
        private readonly ICurrentPlayerService _currentPlayerService;

        public PayCommand(
            ICurrentPlayerService currentPlayerService
        )
        {
            _currentPlayerService = currentPlayerService;
        }

        public void Execute(int bill)
        {
            if (bill < 0)
                throw new InvalidPayBillException();
            
            Player player = _currentPlayerService.CurrentPlayer;

            var money = player.Money;
            
            if (bill > money.Value)
                throw new NotEnoughMoneyException();

            money.Pay(bill);
        }
    }
}