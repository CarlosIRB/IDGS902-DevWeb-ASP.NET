using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class SumaNumerosModel : PageModel
    {
        //Propiedades
        [BindProperty]
        public string num1 { get; set; } = "";
        [BindProperty]
        public string num2 { get; set; } = "";
        public double suma = 0;

        public void OnPost()
        {
            //Obtenemos los valores de los campos num1 y num2
            double numero1 = double.Parse(num1);
            double numero2 = double.Parse(num2);

            //Realizamos la suma
            suma = numero1 + numero2;

            ModelState.Clear();
        }
    }
}
