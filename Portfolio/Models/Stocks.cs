using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Stocks
    {
        [Key]
        public string StockId { get; set; }
        public StockName StockName { get; set; }
        public int StockCount { get; set; }       
    }
}
