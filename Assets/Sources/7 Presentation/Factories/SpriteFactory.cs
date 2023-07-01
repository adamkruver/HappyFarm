using UnityEngine;

namespace HappyFarm.Presentation.Sources._7_Presentation.Factories
{
    public class SpriteFactory
    {
        public Sprite Load(string path)
        {
            return Resources.Load<Sprite>(path);
        }
    }
}