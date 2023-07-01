namespace HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces
{
    public interface IPresenterFactory
    {
        T Create<T>() where T : IPresenter;
    }
}