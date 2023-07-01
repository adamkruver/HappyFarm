using System.Collections.Generic;
using System.Linq;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.Entities.Sources._0_Utils.Extensions;
using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.Presentation.Sources._7_Presentation.Garden.Factories;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Presenter
{
    public class GardenPresenter : IGardenPresenter
    {
        private readonly IPatchGardenService _patchGardenService;
        private readonly ICropGardenService _cropGardenService;
        private readonly PatchPresenterFactory _patchPresenterFactory;
        private readonly CropPresenterFactory _cropPresenterFactory;

        private readonly List<PatchPresenter> _patchPresenters = new List<PatchPresenter>();
        private readonly List<CropPresenter> _cropPresenters = new List<CropPresenter>();
        
        private List<Patch> _patches = new List<Patch>();
        private List<Crop> _crops = new List<Crop>();

        public GardenPresenter(
            IPatchGardenService patchGardenService,
            ICropGardenService cropGardenService,
            PatchPresenterFactory patchPresenterFactory,
            CropPresenterFactory cropPresenterFactory
        )
        {
            _patchGardenService = patchGardenService;
            _cropGardenService = cropGardenService;
            _patchPresenterFactory = patchPresenterFactory;
            _cropPresenterFactory = cropPresenterFactory;
        }

        public void Enable()
        {
        }

        public void Update()
        {
            UpdatePatches();
            UpdateCrops();
        }

        public void Disable()
        {
        }

        private void UpdatePatches()
        {
            Patch[] patches = _patchGardenService.GetAll();

            var diffPatches = _patches
                .Diff(patches, (item1, item2) => item1.Position == item2.Position);

            var addedPatches = patches.Intersect(diffPatches);
            var removedPatches = _patches.Intersect(diffPatches);

            var removedPatchPresenters =
                _patchPresenters.Where(presenter => presenter.HasEqualPatch(removedPatches)).ToList();

            foreach (PatchPresenter presenter in removedPatchPresenters)
            {
                presenter.Disable();
                _patchPresenters.Remove(presenter);
            }

            _patches = patches.ToList();

            foreach (Patch patch in addedPatches)
            {
                PatchPresenter presenter = _patchPresenterFactory.Create(patch);
                presenter.Enable();
                _patchPresenters.Add(presenter);
            }
        }
        
        private void UpdateCrops()
        {
            Crop[] crops = _cropGardenService.GetAll();

            var diffCrops = _crops
                .Diff(crops, (item1, item2) => item1.Position == item2.Position);

            var addedCrops = crops.Intersect(diffCrops);
            var removedCrops = _crops.Intersect(diffCrops);

            var removedCropPresenters =
                _cropPresenters.Where(presenter => presenter.HasEqualCrop(removedCrops)).ToList();

            foreach (CropPresenter presenter in removedCropPresenters)
            {
                presenter.Destroy();
                _cropPresenters.Remove(presenter);
            }

            _crops = crops.ToList();

            foreach (Crop crop in addedCrops)
            {
                CropPresenter presenter = _cropPresenterFactory.Create(crop);
                presenter.Enable();
                _cropPresenters.Add(presenter);
            }
        }
    }
}