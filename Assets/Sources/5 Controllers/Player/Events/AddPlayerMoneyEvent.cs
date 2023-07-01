using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Player.Events
{
    public class AddPlayerMoneyEvent : IControllerEvent
    {
        public AddPlayerMoneyEvent(int money)
        {
            Money = money;
        }

        public int Money { get; }
    }
}