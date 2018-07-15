using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using eShop.Domain;

namespace eShop.DataAccess.Dapper
{
   public class ProductRepository: DapperRepository<Product> 
   {
       private const string InsertSql = @"insert into [Product] ([Id], [Description], [Price])
 values (@Id, @Description, @Price)";

        public ProductRepository() : base("Product")
        {
        }

        public override ICollection<Product> GetAll()
        {
            return base.GetAllDefault();
        }

        protected override void Insert(Product product, IDbConnection connection)
        {
            connection.Execute(InsertSql, product);
        }

        protected override void Update(Product product, IDbConnection connection)
        {
            var sql = @"Update Product 
                Set Name = @Name
                Where Id = @Id";
            var parameters = new[]
            {
                new {Id = product.Id, FirstName = product.Name}
            };
            connection.Execute(sql, parameters);
        }

       public override void ExecuteProcedure(Product product)
       {
           using (IDbConnection cn = Connection)
           {
               cn.Open();
               cn.Query("CreatePromo", new {Percent = 10}, 
                   commandType: CommandType.StoredProcedure);
           }
       }
    }
}
