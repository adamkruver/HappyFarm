namespace HappyFarm.UseCases.Sources._1_Entities.Players
{
    public class Player
    {
        public Player(int id, int money, int experience)
        {
            ID = id;
            Money = new Money(money);
            Progress = new Progress(experience);
        }
        
        public int ID { get; }
        public Money Money { get; }
        public Progress Progress { get; }
    }
}