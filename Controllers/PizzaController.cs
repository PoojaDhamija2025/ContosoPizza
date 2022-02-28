using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet]
public ActionResult<List<Pizza>> GetAll()
{
    try{
    List<Pizza> sortedPizzas;
    List<Pizza> defaultPizzas=PizzaService.GetAll();
    string sortVal =Request.Query["sortByName"];
    sortedPizzas = defaultPizzas;
     if(sortVal!=null)
     {    
            sortVal=sortVal.ToLower();
            if(sortVal=="ascending")
            {
                sortedPizzas = defaultPizzas.OrderBy(o => o.Name).ToList();            
            }
            if(sortVal=="descending")
            {
                sortedPizzas = defaultPizzas.OrderByDescending(o => o.Name).ToList();
            }
     }
    string filterVal = Request.Query["filterByGlutenContent"];
    List<Pizza> filteredPizzas;
    filteredPizzas= sortedPizzas;
    if(filterVal!=null)
     {
        if(Convert.ToBoolean(filterVal))
        {
            filteredPizzas = sortedPizzas.Where(o => o.IsGlutenFree).ToList();
        }
        else
        {
            filteredPizzas = sortedPizzas.Where(o => !o.IsGlutenFree).ToList();
        }
     }
    return filteredPizzas;
    }
    catch (Exception)
       {
        return StatusCode(444, "Invalid Request. API supports two query parameters filterByGlutenContent and sortByName. Valid values for filterByGlutenContent are True or False, whereas sortByName accepts Ascending and Descending.");
       }
}

    // GET by Id action
    [HttpGet("{id}")]
public ActionResult<Pizza> Get(int id)
{
    var pizza = PizzaService.Get(id);

    if(pizza == null)
    throw new FileNotFoundException();
       // return NotFound();

    return pizza;
}

    // POST action
    [HttpPost]
public IActionResult Create(Pizza pizza)
{    
       
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    
}

    // PUT action
    [HttpPut("{id}")]
public IActionResult Update(int id, Pizza pizza)
{
    if (id != pizza.Id)
        return BadRequest();
           
    var existingPizza = PizzaService.Get(id);
    if(existingPizza is null)
        return NotFound();
   
    PizzaService.Update(pizza);           
   
    return NoContent();
}

    // DELETE action
    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var pizza = PizzaService.Get(id);
   
    if (pizza is null)
        return NotFound();
       
    PizzaService.Delete(id);
   
    return NoContent();
}


}