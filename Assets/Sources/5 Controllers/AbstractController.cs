using System.Collections.Generic;
using HappyFarm.Controllers.Sources._5_Controllers.Actions;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._4_Controllers;

namespace HappyFarm.Controllers.Sources._5_Controllers
{
    public class AbstractController : IController
    {
        private readonly List<IControllerAction> _actions = new List<IControllerAction>();

        public AbstractController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        protected IDispatcher Dispatcher { get; }

        public void Handle<T>(T @event) where T: IControllerEvent
        {
            var action = GetAction(@event);
            
            if(action == null)
                return;
            
            action.Handle(@event, Dispatcher);
        }
        
        protected void Register(IControllerAction action)
        {
            if (_actions.Contains(action))
                return;

            _actions.Add(action);
        }

        private IControllerAction<T> GetAction<T>(T @event) where T : IControllerEvent
        {
            foreach (var action in _actions)
                if(action is IControllerAction<T> concreteAction)
                    return concreteAction;
            
            return null;
        }
    }
}