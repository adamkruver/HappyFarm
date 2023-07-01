using System;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Garden
{
    public class GardenPatchPointerService : IGardenPatchPointerService, IGardenPatchPointerControllable
    {
        private readonly IPointerService _pointerService;
        private readonly IGardenGrid _gardenGrid;

        private Vector3Int _currentPosition;

        private bool _isEnabled;
        private bool _isClicked;

        public GardenPatchPointerService(IPointerService pointerService, IGardenGrid gardenGrid)
        {
            _pointerService = pointerService;
            _gardenGrid = gardenGrid;
        }

        public event Action<Vector2Int> PositionChanged;
        public event Action<Vector2Int> Selected;

        private Tilemap Tilemap => _gardenGrid.Background;

        public void Enable() =>
            _isEnabled = true;

        public void Disable() =>
            _isEnabled = false;

        public void Update(float deltaTime)
        {
            if (_isEnabled == false)
                return;

            Vector3? pointerPosition = _pointerService.WorldPoint;

            if (pointerPosition == null)
                return;

            Vector3Int tilePosition = Tilemap.WorldToCell((Vector3)pointerPosition);

            Vector2Int currentPosition = new Vector2Int(tilePosition.x, tilePosition.y);

            if (_currentPosition != tilePosition)
            {
                _currentPosition = tilePosition;
                _isClicked = false;
                PositionChanged?.Invoke(currentPosition);
            }

            if (Input.GetMouseButton(0))
            {
                if (_isClicked)
                    return;
                
                _isClicked = true;
                Selected?.Invoke(currentPosition);
            }
            else
            {
                _isClicked = false;
            }
        }
    }
}