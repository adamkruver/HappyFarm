namespace HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player
{
    public interface IProgressPlayerService : IApplicationService
    {
        int CurrentLevel { get; }
        float CurrentProgress { get; }

        void Add(int experience);
    }
}