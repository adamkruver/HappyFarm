using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.UseCases.Sources._4_Controllers
{
    public interface IController
    {
        void Handle<T>(T @event) where T : IControllerEvent;
    }
}