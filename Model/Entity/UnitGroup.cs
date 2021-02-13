using Dapper.Contrib.Extensions;

namespace Model.Entity
{
    [Table("TB_DOMAIN_UNITS_GROUP")]
    public class UnitGroup
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
