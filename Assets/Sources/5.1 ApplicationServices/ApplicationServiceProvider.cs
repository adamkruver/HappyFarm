using System;
using System.Collections.Generic;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;

namespace HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices
{
    public class ApplicationServiceProvider : IApplicationServiceProvider
    {
        private Dictionary<Type, IApplicationService> _services = new Dictionary<Type, IApplicationService>();

        public void Register<T>(IApplicationService service) where T : IApplicationService
        {
            Type type = typeof(T);
            _services[type] = service;
        }        
        
        public T Get<T>() where T : IApplicationService
        {
            Type type = typeof(T);
            return (T)_services[type];
        }
    }
}