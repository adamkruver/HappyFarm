
using HappyFarm.Entities.Sources._0_Utils;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HappyFarm.Presentation.Sources._7_Presentation.Factories
{
    public class TileFactory
    {
        private readonly static string _patch = "Patch";
        
        public Tile CreatePatch()
        {
            return Resources.Load<Tile>(Environment.GardenPath + _patch);
        }
        
        public Tile Create(string path)
        {
            return Resources.Load<Tile>(path);
        }
    }
}