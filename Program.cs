using LinqToDB;
using LinqToDB.Data;
using static LinqToDB.Reflection.Methods.LinqToDB;

namespace ORM
{
    internal class Program
    {
        private static DbContext _db = new DbContext();

        static void Main(string[] args)
        {
            InsertInto();
            SelectFromTables();
            SelectWhithFilter();            
        }
        static void SelectFromTables()
        {
            int id = 17;
            var customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"{customer.Id}, {customer.LastName}, {customer.FirstName}, {customer.Age}");
            var products = _db.Products.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"{products.Id}, {products.Name}, {products.Description}, {products.Price}");
            var order = _db.Orders.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"{order.Id}, {order.CustomerId}, {order.ProductId}, {order.Quantity}");
        }
        static void InsertInto()
        {
            var cstm = new CustomersModel()
            {
                Id = 18,
                FirstName = "fedor",
                LastName = "prokofiev",
                Age = 35,
            };
            _db.Insert(cstm);
            var prdct = new ProductsModel()
            {
                Id = 18,
                Name = "NewGame",
                Description = "This is new game",
                StockQuantity = 1,
                Price = 10
            };
            _db.Insert(prdct);
            var order = new OrdersModel()
            {
                Id = 18,
                CustomerId = 17,
                ProductId = 1,
                Quantity = 1,

            };
            _db.Insert(order);
        }

        public static void SelectWhithFilter()
        {
            var select = from o in _db.Orders
                         join c in _db.Customers
                         on o.CustomerId equals c.Id
                         join p in _db.Products
                         on o.ProductId equals p.Id
                         where p.Id == 1
                         where c.Age > 30
                         select new { o.CustomerId, c.FirstName, c.LastName, o.ProductId, p.Name, p.StockQuantity, p.Price };
            foreach (var item in select)
            {
                Console.WriteLine($"Customer ID: {item.CustomerId}, Customer First/Last Name {item.FirstName} {item.LastName}," +
                    $"\nProduct Id: {item.ProductId}, product name {item.Name} " +
                    $"Product stock {item.StockQuantity}, product price {item.Price}");
            }
        }
    }
}

