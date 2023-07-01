using UnityEngine.Tilemaps;

namespace HappyFarm.PresentationInterfaces.Sources._4_Pesentation.Interfaces
{
    public interface IGardenGrid
    {
        Tilemap Background { get; }
        Tilemap Patches { get; }
        Tilemap Crops { get; }
    }
}