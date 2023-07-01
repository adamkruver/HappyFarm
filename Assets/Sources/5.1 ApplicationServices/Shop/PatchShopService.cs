using HappyFarm.UseCases.Sources._3_UseCases.Garden.Patchs;
using Sources._3._1_ApplicationServices.Interfaces.Shop;

namespace Sources._5._1_ApplicationServices.Shop
{
    public class PatchShopService : IPatchShopService
    {
        private readonly GetAllPatchesQuery _getAllPatchesQuery;

        public PatchShopService(GetAllPatchesQuery getAllPatchesQuery)
        {
            _getAllPatchesQuery = getAllPatchesQuery;
        }

        public int GetPatchPrice()
        {
            return 1 + _getAllPatchesQuery.Execute().Length;
        }
    }
}