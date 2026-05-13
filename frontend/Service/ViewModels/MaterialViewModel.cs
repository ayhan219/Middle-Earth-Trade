using System;

namespace MiddleEarthTrader.Web.ViewModels
{
    public class MaterialViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nation { get; set; } 
        public string MaterialType { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public int TotalStock { get; set; }
        public int AvailableStock { get; set; }
        public string NationName { get; set; }
        public decimal PriceChangePercentage =>
            BasePrice == 0 ? 0 : ((CurrentPrice - BasePrice) / BasePrice) * 100;
        
    }
}