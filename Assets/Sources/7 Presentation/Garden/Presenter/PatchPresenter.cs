using System.Collections.Generic;
using System.Linq;
using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Presenter
{
    public class PatchPresenter : IPresenter
    {
        private readonly Tilemap _patchTilemap;
        private readonly Patch _patch;
        private readonly TileFactory _tileFactory;

        public PatchPresenter(Tilemap patchTilemap, Patch patch, TileFactory tileFactory)
        {
            _patchTilemap = patchTilemap;
            _patch = patch;
            _tileFactory = tileFactory;
        }

        public void Enable()
        {
            Tile tile = _tileFactory.CreatePatch();
            _patchTilemap.SetTile((Vector3Int)_patch.Position, tile);
        }

        public void Update()
        {
        }

        public void Disable()
        {
            _patchTilemap.SetTile((Vector3Int)_patch.Position, null);
        }

        public bool HasEqualPatch(IEnumerable<Patch> patches)
        {
            return patches.FirstOrDefault(patch => patch.Position == _patch.Position) != null;
        }
    }
}