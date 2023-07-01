using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Presenter;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Factories
{
    public class PatchPresenterFactory
    {
        private readonly IGardenGrid _gardenGrid;
        private readonly TileFactory _tileFactory;

        public PatchPresenterFactory(
            IGardenGrid gardenGrid, 
            TileFactory tileFactory
        )
        {
            _gardenGrid = gardenGrid;
            _tileFactory = tileFactory;
        }

        public PatchPresenter Create(Patch patch)
        {
            return new PatchPresenter(_gardenGrid.Patches, patch, _tileFactory);
        }
    }
}