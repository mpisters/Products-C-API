namespace Products.Core.Models;

public class Product
{
  
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<Review> Reviews { get; set; }  // A list of reviews for the product

}