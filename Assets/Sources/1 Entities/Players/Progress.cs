namespace HappyFarm.UseCases.Sources._1_Entities.Players
{
    public class Progress
    {
        private readonly ExperienceService _experienceService = new ExperienceService();

        private int _experience;

        public Progress(int experience)
        {
            _experience = experience;
        }

        public int Level => _experienceService.CalculateLevel(_experience);
        public float Experience => _experienceService.CalculateNextLevelValueNormalized(_experience);

        public void Add(int experience)
        {
            _experience += experience;
        }
    }
}