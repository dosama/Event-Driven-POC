using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Models;
using CarService.Service;

namespace CarService.Commands
{
    public class RentCarCommand: UndoableCommand
    {
   
            private IRentCarService _rentCarService;
            private RentModel _rentModel;
          
            public RentCarCommand(IServiceProvider serviceProvider, RentModel rentModel)
            {
                _rentCarService = (IRentCarService)serviceProvider.GetService(typeof(IRentCarService));
                _rentModel = rentModel;
            }

            public override void Execute()
            {
                _rentCarService.RentCar(_rentModel);
            }

            public override void Undo()
            {
                _rentCarService.CancelRentCar(_rentModel.TransactionId);
            }
        
    }
}
