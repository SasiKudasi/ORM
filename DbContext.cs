using LinqToDB.Data;
using LinqToDB;
namespace ORM
{
    public class DbContext : DataConnection
    {
        public DbContext()
            : base("PostgreSQL", @"Server=localhost;Port=5432;Database=Shop;User Id=myuser;Password=mypassword;Pooling=true;")
        {
        }
        public ITable<CustomersModel> Customers => this.GetTable<CustomersModel>();
        public ITable<OrdersModel> Orders => this.GetTable<OrdersModel>();
        public ITable<ProductsModel> Products => this.GetTable<ProductsModel>();
    }
}
