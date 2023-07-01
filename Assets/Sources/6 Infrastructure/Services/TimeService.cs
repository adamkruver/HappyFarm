using System;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.Repositories.Services
{
    public class TimeService : ITimeService
    {
        public event Action<float> Updated;
        
        public float Current { get; private set; } = 0;

        public void Update(float deltaTime)
        {
            Current += deltaTime;
            
            Updated?.Invoke(deltaTime);
        }
    }
}