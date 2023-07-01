using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;
using HappyFarm.Entities.Sources._1_Entities.Plants.PlantTypes;
using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;
using HappyFarm.UseCases.Sources._3_UseCases.Plants;
using HappyFarm.UseCases.Sources._3_UseCases.Shop.Items;
using Sources._3._1_ApplicationServices.Interfaces.Shop;

namespace Sources._5._1_ApplicationServices.Shop
{
    public class PlantsShopService : IPlantsShopService
    {
        private readonly IDispatcher _dispatcher;
        private readonly IApplicationServiceProvider _applicationServiceProvider;
        private readonly GetAvailablePlantTypesQuery _getAvailablePlantTypesQuery;
        private readonly GetPlantTypePriceQuery _getPlantTypePriceQuery;

        public PlantsShopService(
            IDispatcher dispatcher,
            IApplicationServiceProvider applicationServiceProvider,
            GetAvailablePlantTypesQuery getAvailablePlantTypesQuery,
            GetPlantTypePriceQuery getPlantTypePriceQuery
        )
        {
            _dispatcher = dispatcher;
            _applicationServiceProvider = applicationServiceProvider;
            _getAvailablePlantTypesQuery = getAvailablePlantTypesQuery;
            _getPlantTypePriceQuery = getPlantTypePriceQuery;
        }

        public IPlantType[] GetAvalilableTypes()
        {
            return _getAvailablePlantTypesQuery.Execute();
        }

        public int GetPrice(IPlantType plantType)
        {
            return _getPlantTypePriceQuery.Execute(plantType);
        }
    }
}