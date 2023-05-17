using Microsoft.AspNetCore.Mvc;
using La_Mia_Pizzeria.Models;
using La_Mia_Pizzeria.Database;

namespace La_Mia_Pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> pizze = db.Pizze.ToList();

                return View(pizze);
            }


               
        }

        public IActionResult PizzaDetails(int Id)
        {

            using (PizzaContext db = new PizzaContext())
            {

                PizzaModel? pizza = db.Pizze.Where( pizze => pizze.Id == Id).FirstOrDefault();

                if (pizza != null)
                {


                    return View(pizza);
                }else
                {
                    return NotFound($"Nessuna pizza trovata con l'Id {Id}");
                }
            }
        }
    }
}
