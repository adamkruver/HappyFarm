using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Garden.Actions
{
    public class UpdateGardenAction : IControllerAction<UpdateGardenEvent>
    {
        private readonly IGardenPresenter _gardenPresenter;

        public UpdateGardenAction(IGardenPresenter gardenPresenter)
        {
            _gardenPresenter = gardenPresenter;
        }

        public void Handle(UpdateGardenEvent @event, IDispatcher dispatcher)
        {
            _gardenPresenter.Update();
        }
    }
}