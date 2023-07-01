using System.Collections;
using HappyFarm.Entities.Sources._0_Utils;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    public class ViewFadeAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _mainPanel;
        
        private float _fadeSeconds = Environment.UIFadeSpeedInSeconds;
        private Coroutine _fadeJob;
        private CanvasGroup _canvasGroup; 
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
            Hide();
        }

        public void Show()
        {
            StartFade(1);
        }

        public void Hide()
        {
            StartFade(0);
        }

        private void StartFade(float targetAlpha)
        {
            StopFade();

            gameObject.SetActive(true);
            
            _fadeJob = StartCoroutine(FadeCoroutine(targetAlpha));
        }

        private void StopFade()
        {
            if (_fadeJob != null)
                StopCoroutine(_fadeJob);

            if (_canvasGroup.alpha == 0)
                gameObject.SetActive(false);
        }

        private IEnumerator FadeCoroutine(float targetAlpha)
        {
            float timeScale = 1 / _fadeSeconds;
            float alpha = _canvasGroup.alpha;

            SetAlpha(alpha);

            while (Mathf.Abs(alpha - targetAlpha) > 0.01f)
            {
                alpha = Mathf.LerpAngle(alpha, targetAlpha, Time.deltaTime * timeScale);

                SetAlpha(alpha);

                yield return null;
            }

            SetAlpha(targetAlpha);
            StopFade();
        }

        private void SetAlpha(float alpha)
        {
            _canvasGroup.alpha = Mathf.Pow(alpha, 3);

            if (_mainPanel != null)
                _mainPanel.localScale = Vector3.one * alpha;
        }
    }
}