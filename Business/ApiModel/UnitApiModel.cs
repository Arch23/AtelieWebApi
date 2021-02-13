using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ApiModel
{
    public class UnitApiModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public long IdGroup { get; set; }
        public long? ReferenceUnit { get; set; }
        public decimal ReferenceValue { get; set; }
    }
}
