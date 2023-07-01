namespace HappyFarm.UseCases.Sources._1_Entities.Players
{
    public class Money
    {
        private int _value;

        public Money(int value)
        {
            _value = value;
        }

        public int Value => _value;

        public void Pay(int bill)
        {
            _value -= bill;
        }

        public void Add(int money)
        {
            _value += money;
        }
    }
}