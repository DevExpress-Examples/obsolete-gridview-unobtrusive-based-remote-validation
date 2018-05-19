using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

public class Product {
    public int ProductID { get; set; }
    [Required(ErrorMessage = "Product Name is required")]
    [Remote("CheckIfExists", "Home", AdditionalFields = "OriginalProductName", ErrorMessage = "The name you specified already exists. Please specify a different name.")]
    public string ProductName { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsOnOrder { get; set; }
}