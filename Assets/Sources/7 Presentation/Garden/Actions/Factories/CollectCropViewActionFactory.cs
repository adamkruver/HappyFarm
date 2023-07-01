using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories
{
    public class CollectCropViewActionFactory : IGardenViewActionFactory
    {
        private readonly IDispatcher _dispatcher;

        public CollectCropViewActionFactory(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public CollectCropViewAction Create()
        {
            return new CollectCropViewAction(_dispatcher);
        }
    }
}