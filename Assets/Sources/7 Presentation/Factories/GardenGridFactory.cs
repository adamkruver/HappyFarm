using HappyFarm.Entities.Sources._0_Utils;
using HappyFarm.Presentation.Sources._7_Presentation.Garden;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Factories
{
    public class GardenGridFactory
    {
        public IGardenGrid Create()
        {
            return Object.Instantiate(Resources.Load<GardenGrid>(Environment.GardenPath + nameof(GardenGrid)));
        }
    }
}