namespace HappyFarm.UseCases.Sources._1_Entities.Players
{
    public class ExperienceService
    {
        public int CalculateLevel(int experience)
        {
            return experience / 100 + 1;
        }

        public float CalculateNextLevelValueNormalized(int experience)
        {
            return (experience % 100f) / 100f;
        }
    }
}