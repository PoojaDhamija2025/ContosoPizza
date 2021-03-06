using ContosoPizza.Models;
using System.Linq.Expressions;


namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 5;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "zClassic Italian", IsGlutenFree = false, Toppings={"Sausage","Extra cheese"},DistributionLocality=Pizza.LocalityChosen.East },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true , Toppings={"Bacon","Extra cheese"},DistributionLocality=Pizza.LocalityChosen.West },
            new Pizza { Id = 3, Name = "Peppe Paneer", IsGlutenFree = false, Toppings={"Paneer","Extra cheese"},DistributionLocality=Pizza.LocalityChosen.East},
            new Pizza { Id = 4, Name = "Chicken", IsGlutenFree = true,Toppings={"Corn","Extra cheese"},DistributionLocality=Pizza.LocalityChosen.West }
            
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
    public static void Sort()
    {
        var sorted = Pizzas.OrderBy(x => x.Name);
        return;
    }
    
}