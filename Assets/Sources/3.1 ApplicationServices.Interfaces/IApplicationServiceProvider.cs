namespace HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces
{
    public interface IApplicationServiceProvider
    {
        T Get<T>() where T : IApplicationService;
    }
}