namespace HappyFarm.Entities.Sources._1_Entities.Garden
{
    public class Duration
    {
        public Duration(float grow, float harvest)
        {
            Grow = grow;
            Harvest = harvest;
        }

        public float Harvest { get; }
        public float Grow { get; }
    }
}