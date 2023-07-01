using HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HappyFarm.Presentation.Sources._7_Presentation.Garden
{
    public class GardenGrid : MonoBehaviour, IGardenGrid
    {
        [field: SerializeField] public Tilemap Background { get; private set; }
        [field: SerializeField] public Tilemap Patches { get; private set; }
        [field: SerializeField] public Tilemap Crops { get; private set; }
    }
}