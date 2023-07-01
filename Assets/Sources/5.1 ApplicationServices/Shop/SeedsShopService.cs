using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Controllers.Sources._5_Controllers.Shop.Events;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._3_UseCases.Shop.Items;
using Sources._3._1_ApplicationServices.Interfaces.Shop;

namespace Sources._5._1_ApplicationServices.Shop
{
    public class SeedsShopService : ISeedsShopService
    {
        private readonly IDispatcher _dispatcher;
        private readonly IApplicationServiceProvider _applicationServiceProvider;
        private readonly BuySeedsCommand _buySeedsCommand;

        private IMoneyPlayerService _moneyPlayerService;
        private IPlantsShopService _plantsShopService;

        public SeedsShopService(
            IDispatcher dispatcher,
            IApplicationServiceProvider applicationServiceProvider,
            BuySeedsCommand buySeedsCommand
        )
        {
            _dispatcher = dispatcher;
            _applicationServiceProvider = applicationServiceProvider;
            _buySeedsCommand = buySeedsCommand;
        }

        private IMoneyPlayerService MoneyPlayerService => _moneyPlayerService
            ??= _applicationServiceProvider.Get<IMoneyPlayerService>();

        private IPlantsShopService PlantsShopService => _plantsShopService
            ??= _applicationServiceProvider.Get<IPlantsShopService>();

        public void Buy(IPlantType plantType)
        {
            int bill = PlantsShopService.GetPrice(plantType);
            MoneyPlayerService.Pay(bill);
            _buySeedsCommand.Execute(plantType);
            _dispatcher.Dispatch(new UpdateShopEvent());
        }

        public void Buy(IPlantType plantType, int count)
        {
            if (count <= 0)
                return;

            for (int i = 0; i < count; i++)
                Buy(plantType);
        }
    }
}