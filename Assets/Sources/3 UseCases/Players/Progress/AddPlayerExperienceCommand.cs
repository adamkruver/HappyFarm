using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.UseCases.Sources._3_UseCases.Players.Progress
{
    public class AddPlayerExperienceCommand
    {
        private readonly ICurrentPlayerService _currentPlayerService;

        public AddPlayerExperienceCommand(ICurrentPlayerService currentPlayerService)
        {
            _currentPlayerService = currentPlayerService;
        }

        public void Execute(int experience)
        {
            _currentPlayerService.CurrentPlayer.Progress.Add(experience);
        }
    }
}