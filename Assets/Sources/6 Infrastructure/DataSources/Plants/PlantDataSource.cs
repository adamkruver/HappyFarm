using System;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.InfrastructureInterfaces.Sources._2_Infrastructure.Interfaces.DataSources.Plants;
using UnityEngine;

namespace HappyFarm.Infrastructure.Sources._6_Infrastructure.DataSources.Plants
{
    public class PlantDataSource : IPlantDataSource
    {
        private readonly string _plantResourcesPath = "PlantData";
        
        private IPlantDto[] _plantDatas;
        
        public PlantDataSource()
        {
            LoadResourcesFromJson();
        }

        public IPlantDto Get(IPlantType plantType)
        {
            return GetByType(plantType.GetType().Name);
        }

        private IPlantDto GetByType(string type)
        {
            foreach (IPlantDto resource in _plantDatas)
                if (resource.Type == type)
                    return resource;

            return default;
        }

        private void LoadResourcesFromJson()
        {
            TextAsset json = Resources.Load<TextAsset>(_plantResourcesPath);
            JsonWrapper<PlantDto> wrapper = JsonUtility.FromJson<JsonWrapper<PlantDto>>(json.text);
            _plantDatas = wrapper.Collection;
        }
    }
}