using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR10_C121_SavolaynenDmitriy_Wpf
{
    public class ToyInfo
    {
        public string Name { get; set; }
        public string FactoryName { get; set; }
        public string Age { get; set; }
        public decimal Price { get; set; }
        public string Discount { get; set; }
        public string ProductionDate { get; set; }
        public bool OnStock { get; set; }

        public ToyInfo(string name, string factoryname, string age, decimal price, string discount, string productiondate, bool onstock)
        {
            this.Name = name;
            this.FactoryName = factoryname;
            this.Age = age;
            this.Price = price;
            this.Discount = discount;
            this.ProductionDate = productiondate;
            this.OnStock = onstock;
        }

    }
}
