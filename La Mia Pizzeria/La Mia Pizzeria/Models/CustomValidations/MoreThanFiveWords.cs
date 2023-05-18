using System.ComponentModel.DataAnnotations;

namespace La_Mia_Pizzeria.Models.CustomValidations
{
    public class MoreThanFiveWords : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int flag= 0;
           
            string fieldValue = (string)value;
            if(fieldValue == null) 
            {
                return new ValidationResult("Il campo non può essere nullo.");
            }
            else
            {
                do
                {
                    if (fieldValue.Trim().IndexOf(" ") == -1)
                    {
                        break;
                    }
                    else
                    {
                        flag++;
                    }

                    if(flag >= 4)
                    {
                        break;
                    }
                } while (fieldValue.Trim().IndexOf(" ") == -1);

            }
            if(flag >= 4 )
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Il campo deve contenere almeno 5 parole.");

            }

        }
    }
}
