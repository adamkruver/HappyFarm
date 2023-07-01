using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.General
{
    public class Bootstrap : MonoBehaviour
    {
        private AppBuilder _appBuilder;

        private void Awake()
        {
            if (_appBuilder == null)
                _appBuilder = CreateAppBuilder();

            _appBuilder.Build();
        }

        private AppBuilder CreateAppBuilder()
        {
            GameObject gameObject = new GameObject(nameof(AppBuilder));

            DontDestroyOnLoad(this);
            return gameObject.AddComponent<AppBuilder>();
        }
    }
}