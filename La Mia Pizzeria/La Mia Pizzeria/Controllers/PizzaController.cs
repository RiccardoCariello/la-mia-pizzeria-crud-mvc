using Microsoft.AspNetCore.Mvc;
using La_Mia_Pizzeria.Models;
using La_Mia_Pizzeria.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

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
        
        
        
        //[Authorize(Roles = "ADMIN,USER")]
        [HttpGet]
        public IActionResult PizzaDetails(int Id)
        {

            using (PizzaContext db = new PizzaContext())
            {

                PizzaModel? pizza = db.Pizze.Where(pizze => pizze.Id == Id).FirstOrDefault();

                if (pizza != null)
                {


                    return View(pizza);
                } else
                {
                    return NotFound($"Nessuna pizza trovata con l'Id {Id}");
                }
            }
        }



        //[Authorize(Roles = "ADMIN,USER")]
        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaModel newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel pizzaToCreate = new PizzaModel(newPizza.Name, newPizza.Description, newPizza.ImgSource, newPizza.Price);

                db.Pizze.Add(pizzaToCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }



        [Authorize(Roles = "ADMIN")]
        [HttpGet] public IActionResult Update(int id) {


            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDaModificare = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDaModificare != null)
                {   //se l'oggetto non è nullo significa che il progrtmma ha correttamente trovato l'articolo che vogliamo modificare, quindi ci ritornerà
                    //la view passando come modello la pizza trovata
                    return View("Update", pizzaDaModificare);
                }
                else
                {
                    return NotFound();
                }

            }

        }



        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaModel pizzaModificata)
        {

            if (!ModelState.IsValid)
            {
                return View("Update", pizzaModificata);
            }

            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDaModificare = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaDaModificare != null)
                {
                    pizzaDaModificare.Name = pizzaModificata.Name;
                    pizzaDaModificare.Description = pizzaModificata.Description;
                    pizzaDaModificare.ImgSource = pizzaModificata.ImgSource;
                    pizzaDaModificare.Price = pizzaModificata.Price;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("L'articolo da modificare non esiste!");
                }
            }
        }



        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDaCancellare = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                if(pizzaDaCancellare != null)
                {
                    db.Remove(pizzaDaCancellare);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Non ho trovato la pizza che vorresti cancellare.");
                }
            }

        }

    }
}
