using System;
using System.Collections.Generic;
using System.Linq;
using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.Presentation.Sources._7_Presentation.Factories;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden.Presenter
{
    public class CropPresenter : IPresenter
    {
        private readonly Tilemap _cropTilemap;
        private readonly Crop _crop;
        private readonly IPlantDto _plantDto;
        private readonly ITimeService _timeService;
        private readonly TileFactory _tileFactory;

        private string _currentTilePath;
        private bool _isGrowing;

        public CropPresenter(
            Tilemap cropTilemap,
            Crop crop,
            IPlantDto plantDto,
            ITimeService timeService,
            TileFactory tileFactory)
        {
            _cropTilemap = cropTilemap;
            _crop = crop;
            _plantDto = plantDto;
            _timeService = timeService;
            _tileFactory = tileFactory;
        }

        public void Enable()
        {
            if (_isGrowing)
                return;

            _isGrowing = true;
            _timeService.Updated += OnUpdate;
            OnUpdate(0);
        }

        public void Update()
        {
        }

        public void Disable()
        {
            if (_isGrowing == false)
                return;

            _isGrowing = false;
            _timeService.Updated -= OnUpdate;
        }

        public bool HasEqualCrop(IEnumerable<Crop> crops)
        {
            return crops.FirstOrDefault(crop => crop.Position == _crop.Position) != null;
        }

        public void Destroy()
        {
            _cropTilemap.SetTile((Vector3Int)_crop.Position, null);
            Disable();
        }

        private void OnUpdate(float deltaTime)
        {
            if (_isGrowing == false)
                return;

            string tilePath;
            float plantingTime = _timeService.Current - _crop.CreatedAt;

            if (plantingTime < _plantDto.GrowTime)
            {
                float growSpriteDuration = _plantDto.GrowTime / _plantDto.GrowSpritePaths.Length;
                int growSpriteIndex = (int)(plantingTime / growSpriteDuration);

                tilePath = _plantDto.GrowSpritePaths[growSpriteIndex];
            }
            else if (plantingTime < _plantDto.HarvestTime + _plantDto.GrowTime)
            {
                tilePath = _plantDto.HarvestSpritePath;
            }
            else
            {
                tilePath = _plantDto.RottenSpritePath;
                Disable();
            }

            if (tilePath == _currentTilePath)
                return;

            SetTileByPath(tilePath);
        }

        private void SetTileByPath(string path)
        {
            Tile tile = _tileFactory.Create(path);
            _cropTilemap.SetTile((Vector3Int)_crop.Position, tile);
        }
    }
}