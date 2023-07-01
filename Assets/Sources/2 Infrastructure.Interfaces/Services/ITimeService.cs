using System;

namespace HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services
{
    public interface ITimeService
    {
        event Action<float> Updated;
        
        float Current { get; }
        void Update(float deltaTime);
    }
}