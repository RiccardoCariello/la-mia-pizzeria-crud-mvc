using System.ComponentModel.DataAnnotations;

namespace La_Mia_Pizzeria.Models
{
    public class CathegoryModel
    {
       
        public int Id { get; set; }


        

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<PizzaModel> pizzaModels { get; set; }

        public CathegoryModel() { }

        public CathegoryModel(string name, string? description)
        {
            Name = name;

            Description = description;

            pizzaModels = new List<PizzaModel>(); 


        }



    }
}
