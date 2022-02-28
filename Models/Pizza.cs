using System.ComponentModel.DataAnnotations;
namespace ContosoPizza.Models;

public class Pizza
{
    private List<string> _toppings = new List<string>();
    public enum LocalityChosen { East, West, North, South };
    public int Id { get; set; }
    public string Name { get; set; }
    [Range(typeof(bool), "true", "true", ErrorMessage="Value for this field must be provided.")]
    public bool IsGlutenFree { get; set; }
    [Required, MinLength(1)]
    public List<string> Toppings{  get { return _toppings; }
    set { _toppings = value; }}
    [EnumDataType(typeof(LocalityChosen))]
    public LocalityChosen DistributionLocality{ get; set; }
  
}