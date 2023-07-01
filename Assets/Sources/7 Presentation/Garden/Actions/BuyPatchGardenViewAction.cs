﻿using HappyFarm.Controllers.Sources._5_Controllers.Garden.Events;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Actions
{
    public class BuyPatchGardenViewAction : IGardenViewAction
    {
        private readonly IDispatcher _dispatcher;

        public BuyPatchGardenViewAction(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Execute(Vector2Int position)
        {
            _dispatcher.Dispatch(new BuyGardenPatchEvent(position));
        }
    }
}