using System.Collections.Generic;
using HappyFarm.Entities.Sources._0_Utils;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.Repositories.Services
{
    public class PointerService : IPointerService
    {
        private readonly ICameraService _cameraService;
        private readonly int _layerMask;

        public PointerService(ICameraService cameraService)
        {
            _cameraService = cameraService;
            _layerMask = LayerMask.NameToLayer(Environment.UILayerName);
        }

        public Vector3? WorldPoint => 
            PointerIsOverUI()
                ? null
                : _cameraService.Camera.ScreenToWorldPoint(PointerPosition);
        
        public Vector3? ScreenPoint => 
            PointerIsOverUI()
                ? PointerPosition
                : null;
        
        private EventSystem EventSystem => EventSystem.current;
        private Vector3 PointerPosition => Input.mousePosition;

        private bool PointerIsOverUI()
        {
            GameObject hitObject = UIRaycast(ScreenPositionToPointerData(PointerPosition));
            return hitObject != null && hitObject.layer == _layerMask;
        }

        private GameObject UIRaycast (PointerEventData pointerEventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.RaycastAll(pointerEventData, results);

            return results.Count < 1 
                ? null 
                : results[0].gameObject;
        }

        private PointerEventData ScreenPositionToPointerData (Vector2 screenPosition) =>
            new PointerEventData(EventSystem)
            {
                position = screenPosition
            };
    }
}