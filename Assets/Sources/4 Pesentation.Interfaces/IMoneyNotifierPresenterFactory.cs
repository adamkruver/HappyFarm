using UnityEngine;

namespace HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces
{
    public interface IMoneyNotifierPresenterFactory
    {
        IMoneyNotifierPresenter Create(int price, Vector2 position);
    }
}