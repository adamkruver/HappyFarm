namespace HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces
{
    public interface IDispatcher
    {
        void Dispatch<T>(T @event) where T : IControllerEvent;
    }
}