namespace ContosoPizza.Models;

public class Pizza
{
    private List<string> _toppings = new List<string>();
    public enum LocalityChosen { East, West, North, South };
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
    public List<string> Toppings{  get { return _toppings; }
    set { _toppings = value; }}
    public LocalityChosen DistributionLocality{ get; set; }
  
}