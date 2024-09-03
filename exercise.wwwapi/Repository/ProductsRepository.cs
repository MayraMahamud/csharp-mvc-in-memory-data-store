using exercise.wwwapi.Model;
using exercise.wwwapi.Data;

namespace exercise.wwwapi.Repository
{
    public class ProductsRepository : IProductsRepo
    {
        private DataContext _db;
        public ProductsRepository(DataContext db)
        {
            _db = db;   
            
        }
        public Product AddProduct(Product product)
        {

            _db.Products.Add(product);
            _db.SaveChanges();
            return product;

        }

        public Product DeleteProduct(string productName)
        {
            var product = _db.Products.FirstOrDefault(p => p.Name == productName);

            _db.Products.Remove(product);
                _db.SaveChanges();
            
            
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
           
        }

        public Product GetAProduct(string productName)
        {
            var product = _db.Products.FirstOrDefault(p => p.Name == productName);
            return product;

        }

       
        public Product UpdateProduct(string productName, Product model)
        {
            var product = _db.Products.FirstOrDefault(p => p.Name == productName);
           
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Category = model.Category;
                _db.SaveChanges();
            }
            return product;

        }

      


    }


}


