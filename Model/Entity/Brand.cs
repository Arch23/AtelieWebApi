using Dapper.Contrib.Extensions;

namespace Model.Entity
{
    [Table("TB_DOMAIN_BRANDS")]
    public class Brand
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
