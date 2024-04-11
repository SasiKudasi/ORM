using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace ORM
{
    [Table("orders")]
    public class OrdersModel
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }
        [Column("customerid")]
        [ForeignKey("fk_customerid")]
        public int CustomerId { get; set; }
        [Column("productid")]
        [ForeignKey("fk_productid")]
        public int ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        [Association(ThisKey = nameof(OrdersModel.ProductId), OtherKey = nameof(ProductsModel.Id))]
        public IEnumerable<ProductsModel> Product { get; set; } = new List<ProductsModel>();
        [Association(ThisKey = nameof(OrdersModel.CustomerId), OtherKey = nameof(CustomersModel.Id))]
        public IEnumerable<CustomersModel> Customers { get; set; } = new List<CustomersModel>();
    }
}
