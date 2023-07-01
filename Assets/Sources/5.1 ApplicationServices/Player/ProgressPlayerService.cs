using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.UseCases.Sources._3_UseCases.Players.Progress;

namespace HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Player
{
    public class ProgressPlayerService : IProgressPlayerService
    {
        private readonly GetPlayerLevelQuery _getPlayerLevelQuery;
        private readonly GetPlayerProgressQuery _getPlayerProgressQuery;
        private readonly AddPlayerExperienceCommand _addPlayerExperienceCommand;
        private IProgressPlayerService _progressPlayerServiceImplementation;

        public ProgressPlayerService(
            GetPlayerLevelQuery getPlayerLevelQuery,
            GetPlayerProgressQuery getPlayerProgressQuery,
            AddPlayerExperienceCommand addPlayerExperienceCommand
        )
        {
            _getPlayerLevelQuery = getPlayerLevelQuery;
            _getPlayerProgressQuery = getPlayerProgressQuery;
            _addPlayerExperienceCommand = addPlayerExperienceCommand;
        }

        public int CurrentLevel => _getPlayerLevelQuery.Execute();
        public float CurrentProgress => _getPlayerProgressQuery.Execute();
        
        public void Add(int experience)
        {
            _addPlayerExperienceCommand.Execute(experience);
        }
    }
}