using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ApiModel
{
    public class MaterialApiModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? IdBrand { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public long IdUnit { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime AlterTime { get; set; }
    }
}
