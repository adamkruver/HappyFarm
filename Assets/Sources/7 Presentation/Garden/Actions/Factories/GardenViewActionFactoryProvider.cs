using System;
using System.Collections.Generic;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions.Factories
{
    public class GardenViewActionFactoryProvider
    {
        private readonly Dictionary<Type, IGardenViewActionFactory> _actions; 

        public GardenViewActionFactoryProvider(IDispatcher dispatcher)
        {
            _actions = new Dictionary<Type, IGardenViewActionFactory>()
            {
                [typeof(BuyPatchGardenViewActionFactory)] = new BuyPatchGardenViewActionFactory(dispatcher),
                [typeof(CreateCropViewActionFactory)] = new CreateCropViewActionFactory(dispatcher),
                [typeof(CollectCropViewActionFactory)] = new CollectCropViewActionFactory(dispatcher),
            };
        }


        public T Get<T>() where T : IGardenViewActionFactory
        {
            return (T)_actions[typeof(T)];
        }
    }
}