using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Actions
{
    public interface IControllerAction
    {
    }

    public interface IControllerAction<T> : IControllerAction where T : IControllerEvent
    {
        void Handle(T @event, IDispatcher dispatcher);
    }
}