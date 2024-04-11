using LinqToDB.Mapping;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace ORM
{
    [Table("customers")]
    public class CustomersModel
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]

        public string LastName { get; set; }

        [Column("age")]
        public int Age { get; set; }
    }
}
