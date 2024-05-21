using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class programa1Model : PageModel
    {
        //Propiedades
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";

        public string estado = "";

        public void OnPost()
        {
            //Obtenemos los valores de los campos
            double numero1 = double.Parse(peso);
            double numero2 = double.Parse(altura);

            //Realizamos la condicion del imc
            double imc = numero1 / (numero2 * numero2);
            
            if(imc< 18)
            {
                estado = "1";
            }
            else if(imc >= 18 && imc < 25)
            {
                estado = "2";
            }
            else if (imc >= 25 && imc < 27)
            {
                estado = "3";
            }
            else if (imc >= 27 && imc < 30)
            {
                estado = "4";
            }
            else if (imc >= 30 && imc < 40)
            {
                estado = "5";
            }
            else if (imc >= 40)
            {
                estado = "6";
            }   

            ModelState.Clear();
        }
    }
}
