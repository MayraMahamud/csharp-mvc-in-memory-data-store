using exercise.wwwapi.Model;

namespace exercise.wwwapi.Repository
{
    public interface IProductsRepo
    {
       
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product DeleteProduct(string productName);
        Product GetAProduct(string productName);
        Product UpdateProduct(string productName, Product model);
    }
}
