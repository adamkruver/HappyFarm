using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Garden;
using HappyFarm.ApplicationServices.Interfaces.Sources._3._1_ApplicationServices.Interfaces.Player;
using HappyFarm.Entities.Sources._1_Entities.Garden;
using HappyFarm.UseCases.Sources._3_UseCases.Exceptions;
using HappyFarm.UseCases.Sources._3_UseCases.Garden.Patchs;
using Sources._3._1_ApplicationServices.Interfaces.Shop;
using UnityEngine;

namespace HappyFarm.ApplicationServices.Sources._5._1_ApplicationServices.Garden
{
    public class PatchGardenService : IPatchGardenService
    {
        private readonly IApplicationServiceProvider _applicationServiceProvider;
        private readonly CreateGardenPatchCommand _createGardenPatchCommand;
        private readonly GetAllPatchesQuery _getAllPatchesQuery;

        public PatchGardenService(
            IApplicationServiceProvider applicationServiceProvider,
            CreateGardenPatchCommand createGardenPatchCommand,
            GetAllPatchesQuery getAllPatchesQuery
        )
        {
            _applicationServiceProvider = applicationServiceProvider;
            _createGardenPatchCommand = createGardenPatchCommand;
            _getAllPatchesQuery = getAllPatchesQuery;
        }

        private IMoneyPlayerService MoneyPlayerService => _applicationServiceProvider.Get<IMoneyPlayerService>();
        private IPatchShopService PatchShopService => _applicationServiceProvider.Get<IPatchShopService>();

        public void Buy(Vector2Int position)
        {
            int patchPrice = PatchShopService.GetPatchPrice(); 
            
            if (MoneyPlayerService.GetBalance() < patchPrice)
                throw new NotEnoughMoneyException();
                
            _createGardenPatchCommand.Execute(position);
            MoneyPlayerService.Pay(patchPrice);
        }

        public Patch[] GetAll()
        {
            return _getAllPatchesQuery.Execute();
        }
    }
}