using UnityEngine;

namespace HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces
{
    public interface IView
    {
        void SetParent(RectTransform parent);
        void Show();
        void Hide();
    }
}