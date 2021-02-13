using Dapper.Contrib.Extensions;

namespace Model.Entity
{
    [Table("TB_DOMAIN_UNITS")]
    public class Unit
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public long IdGroup { get; set; }
        public long? ReferenceUnit { get; set; }
        public decimal ReferenceValue { get; set; }
    }
}
