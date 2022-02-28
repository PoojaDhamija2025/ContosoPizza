using System.ComponentModel.DataAnnotations;
namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    [Display(Name = "Is Gluten Free")]
    [Range(typeof(bool), "true", "true", ErrorMessage="Invalid Schema. The field 'IsGlutenFree' must be checked.")]
    public bool IsGlutenFree { get; set; }
  
}