using HappyFarm.Entities.Sources._0_Utils;
using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Factories
{
    public class ViewFactory
    {
        public T Create<T>() where T : MonoBehaviour, IView
        {
            T view = Object.Instantiate(Resources.Load<T>($"{Environment.ViewPath}{typeof(T).Name}"));
            view.gameObject.SetActive(false);

            return view;
        }
    }
}