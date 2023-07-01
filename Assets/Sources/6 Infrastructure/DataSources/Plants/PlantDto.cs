using System;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;
using UnityEngine;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.DataSources.Plants
{
    [Serializable]
    public class PlantDto : IPlantDto
    {
        [SerializeField] private string _title;
        [SerializeField] private string _type;
        [SerializeField] private float _harvestTime;
        [SerializeField] private float _growTime;
        [SerializeField] private int _price;
        [SerializeField] private int _additionalCost;
        [SerializeField] private int _experience;
        [SerializeField] private string _iconPath;
        [SerializeField] private string[] _growSprites;
        [SerializeField] private string _harvestSprite;
        [SerializeField] private string _rottenSprite;

        public float GrowTime => _growTime;
        public float HarvestTime => _harvestTime;
        public string Type => _type;
        public string Title => _type;
        public int Price => _price;
        public int AdditionalCost => _additionalCost;
        public int Experience => _experience;
        public string IconPath => _iconPath;
        public string[] GrowSpritePaths => _growSprites;
        public string HarvestSpritePath => _harvestSprite;
        public string RottenSpritePath => _rottenSprite;
    }
}