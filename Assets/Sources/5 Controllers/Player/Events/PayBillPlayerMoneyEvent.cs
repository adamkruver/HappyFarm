using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Player.Events
{
    public class PayBillPlayerMoneyEvent : IControllerEvent
    {
        public PayBillPlayerMoneyEvent(int bill)
        {
            Bill = bill;
        }

        public int Bill { get; }
    }
}