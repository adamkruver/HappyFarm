using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories
{
    public class BuyPatchGardenViewActionFactory : IGardenViewActionFactory
    {
        private readonly IDispatcher _dispatcher;

        public BuyPatchGardenViewActionFactory(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public BuyPatchGardenViewAction Create()
        {
            return new BuyPatchGardenViewAction(_dispatcher);
        }
    }
}