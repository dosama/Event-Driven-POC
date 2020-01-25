using System;
using System.Collections.Generic;

namespace CarService.Data
{
    public partial class Rents
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public decimal RentPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Staus { get; set; }
        public string CarNumber { get; set; }
    }
}
