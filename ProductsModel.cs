using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;
using LinqToDB.Mapping;

namespace ORM
{
    [Table("products")]
    public class ProductsModel
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("stockquantity")]
        public int StockQuantity { get; set; }
        [Column("price")]
        public int Price { get; set; }
    }
}
