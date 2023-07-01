using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Controllers.Sources._5_Controllers.Events;
using HappyFarm.Controllers.Sources._5_Controllers.Player.Events;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._3_UseCases.Players.Money;

namespace HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Player
{
    public class MoneyPlayerService : IMoneyPlayerService
    {
        private readonly IDispatcher _dispatcher;
        private readonly IApplicationServiceProvider _applicationServiceProvider;
        private readonly GetMoneyBalanceQuery _getMoneyBalanceQuery;
        private readonly PayCommand _payCommand;
        private readonly AddMoneyCommand _addMoneyCommand;

        public MoneyPlayerService(
            IDispatcher dispatcher,
            IApplicationServiceProvider applicationServiceProvider,
            GetMoneyBalanceQuery getMoneyBalanceQuery,
            PayCommand payCommand,
            AddMoneyCommand addMoneyCommand
        )
        {
            _dispatcher = dispatcher;
            _applicationServiceProvider = applicationServiceProvider;
            _getMoneyBalanceQuery = getMoneyBalanceQuery;
            _payCommand = payCommand;
            _addMoneyCommand = addMoneyCommand;
        }

        public void Add(int money)
        {
            _addMoneyCommand.Execute(money);
            _dispatcher.Dispatch(new UpdateHudEvent());
            _dispatcher.Dispatch(new AddPlayerMoneyEvent(money));
        }

        public void Pay(int bill)
        {
            _payCommand.Execute(bill);
            _dispatcher.Dispatch(new UpdateHudEvent());
            _dispatcher.Dispatch(new PayBillPlayerMoneyEvent(bill));
        }

        public int GetBalance()
        {
            return _getMoneyBalanceQuery.Execute();
        }
        
    }
}