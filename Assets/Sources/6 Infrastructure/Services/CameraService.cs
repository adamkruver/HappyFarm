using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.Services;
using UnityEngine;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.Repositories.Services
{
    public class CameraService : ICameraService
    {
        private Camera _camera;

        public Camera Camera => _camera ??= Camera.main;
    }
}