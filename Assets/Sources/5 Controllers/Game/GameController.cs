using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Controllers.Sources._5_Controllers.Game.Actions;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Game
{
    public class GameController : AbstractController
    {
        private readonly IGardenPatchPointerService _gardenPatchPointerService;

        public GameController(
            IDispatcher dispatcher, 
            ITimeService timeService,
            IGardenPatchPointerService gardenPatchPointerService
        ) : base(dispatcher)
        {
            Register(new StartGameAction(timeService, gardenPatchPointerService));
            Register(new EndGameAction(timeService, gardenPatchPointerService));
        }
    }
}