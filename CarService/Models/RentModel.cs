using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class RentModel
    {
            public int Id { get; set; }
            public string TransactionId { get; set; }
            public decimal RentPrice { get; set; }
            public DateTime CreatedDate { get; set; }
            public string Staus { get; set; }
            public string CarNumber { get; set; }
        
    }
}
