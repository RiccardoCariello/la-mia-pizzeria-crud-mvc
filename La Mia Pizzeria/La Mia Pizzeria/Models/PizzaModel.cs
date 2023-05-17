﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace La_Mia_Pizzeria.Models
{
    public class PizzaModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        
        [Column(TypeName = "text")]
        public string Description { get; set; }
       
        [MaxLength(300)]
        public string ImgSource { get; set; }
        
        float Price { get; set; }

        public PizzaModel(string name, string description , string imgSource, float price)
        {
            Name = name;
            Description = description;
            ImgSource = imgSource;
            Price = price;
        }


    }
}
