using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Controllers.Sources._5_Controllers.Player.Actions;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Player
{
    public class PlayerController : AbstractController
    {
        public PlayerController(
            IDispatcher dispatcher,
            IPointerService pointerService,
            IProgressPlayerService progressPlayerService,
            IMoneyNotifierPresenterFactory moneyNotifierPresenterFactory
            ) : base(dispatcher)
        {
            Register(new PayBillPlayerMoneyAction(pointerService, moneyNotifierPresenterFactory));
            Register(new AddPlayerMoneyAction(pointerService, moneyNotifierPresenterFactory));
            Register(new AddPlayerExperienceAction(progressPlayerService));
        }
    }
}