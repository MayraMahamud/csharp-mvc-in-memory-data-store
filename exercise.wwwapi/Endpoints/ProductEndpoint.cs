using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Model;
using exercise.wwwapi.ViewModels;



namespace exercise.wwwapi.Endpoints
{
    public static class ProductEndpoint
    {
        public static void ConfigureProductEndpoint(this WebApplication app)
        {
            var product= app.MapGroup("product");
            product.MapGet("/", GetAllProducts);
            product.MapPost("/{name}", AddProduct);
            product.MapDelete("/{name}", DeleteProduct);
            product.MapGet("/{name}", GetAProduct);
            product.MapPut("/{name}", UpdateProduct);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetAllProducts(IProductsRepo repository)
        {
            if (repository.GetAllProducts() == null)
            {
                TypedResults.NotFound();
            }

            return TypedResults.Ok(repository.GetAllProducts());

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public static IResult AddProduct(IProductsRepo repository, Product model)
        {
            if ( string.IsNullOrEmpty(model.Name))
            {
                TypedResults.BadRequest();

            }

            var result = repository.AddProduct(model);


            return TypedResults.Created("", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static IResult DeleteProduct(IProductsRepo repository, string name)
        {
            if (string.IsNullOrEmpty(name)) 
            {
                TypedResults.NotFound();
            }
            var result = repository.DeleteProduct(name);


            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static IResult GetAProduct(IProductsRepo repository, string name)
        {
            if (repository.GetAProduct(name) == null)
            {
                TypedResults.NotFound();



            }

            var result = repository.GetAProduct(name);


            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public static IResult UpdateProduct(IProductsRepo repository, string name, PostProduct model)
        {
            Product P = new Product(); 
            P.Name = model.Name;
            P.Price = model.Price;  
            P.Category = model.Category;    
          

            if (repository.UpdateProduct(name, P) == null)
            {
                TypedResults.BadRequest();
            }  
            var result = repository.UpdateProduct(name, P);
            return TypedResults.Ok(result); 
            //return TypedResults.Created($"https://localhost:7068/products/{result.Name}", result);
        }
    }
}
