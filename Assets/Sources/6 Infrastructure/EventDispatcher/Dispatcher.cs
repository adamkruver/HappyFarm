using System.Collections.Generic;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._4_Controllers;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.EventDispatcher
{
    public class Dispatcher : IDispatcher
    {
        private readonly List<IController> _controllers = new List<IController>();

        public Dispatcher RegisterController(IController controller)
        {
            if (_controllers.Contains(controller))
                return this;

            _controllers.Add(controller);

            return this;
        }

        public void Dispatch<T>(T @event) where T : IControllerEvent
        {
            foreach (IController controller in _controllers)
            {
                controller.Handle(@event);
            }
        }
    }
}