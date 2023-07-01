using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;

namespace Sources._3._1_ApplicationServices.Interfaces.Shop
{
    public interface IPatchShopService:IApplicationService
    {
        int GetPatchPrice();
    }
}