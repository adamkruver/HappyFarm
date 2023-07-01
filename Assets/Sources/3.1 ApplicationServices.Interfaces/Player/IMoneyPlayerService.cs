namespace HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player
{
    public interface IMoneyPlayerService : IApplicationService
    {
        void Add(int money);
        void Pay(int bill);
        int GetBalance();
    }
}