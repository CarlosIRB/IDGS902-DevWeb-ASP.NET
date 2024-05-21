using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class programa2Model : PageModel
    {
        //Propiedades
        [BindProperty]
        public string input { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";

        public string mensaje_cifrado = "";
        public string mensaje_cifrado_latin = "";
        public string mensaje_decodificado = "";

        public void OnPost()
        {
            //Obtenemos los valores de los campos
            double numero = double.Parse(n);

            //codificar con el cifrado cesar para el siguiente array de caracteres que incluye letras con tilde y la letra ñ, mayusculas y minusculas
            char[] chars = [ ' ', 'a', 'á', 'b', 'c', 'd', 'e', 'é', 'f', 'g', 'h', 'i', 'í', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'ó', 'p', 'q', 'r', 's', 't', 'u', 'ú', 'ü', 'v', 'w', 'x', 'y', 'z', 'A', 'Á', 'B', 'C', 'D', 'E', 'É', 'F', 'G', 'H', 'I', 'Í', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'Ó', 'P', 'Q', 'R', 'S', 'T', 'U', 'Ú', 'Ü', 'V', 'W', 'X', 'Y', 'Z' ];
            //crear un array solo con caracteres latinos [A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, X, Y, Z] 
            char[] chars_latin = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z'];
            //Realizamos la condicion del cifrado cesar
            string mensaje = input;
            for (int i = 0; i < mensaje.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    
                    if (mensaje[i] == chars[j])
                    {
                        mensaje_cifrado += chars[(j + (int)numero) % chars.Length];
                        break;
                    }
                }
            }
            //cesar con el array de caracteres latinos
            try
            {
                string result = "";
                int num = chars_latin.Length;
                int shift = (int)numero;

                foreach (char c in input.ToUpper())
                {
                    if (c == ' ')
                    {
                        result += c;
                    }
                    else
                    {
                        int index = Array.IndexOf(chars_latin, c);
                        if (index == -1)
                        {
                            throw new ArgumentException("Character not in chars_latin array");
                        }
                        int newIndex = (index + shift) % num;
                        result += chars_latin[newIndex];
                    }
                }

                mensaje_cifrado_latin = result;
            }
            catch (Exception e)
            {
                mensaje_cifrado_latin = "El mensaje tiene caracteres no compatibles con el cifrado cesar original";
            }

            //decodificar haciendo el proceso inverso del cifrado cesar
            for (int i = 0; i < mensaje_cifrado.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    if (mensaje_cifrado[i] == chars[j])
                    {
                        //asegurarse de que siempre se realice la operacion modulo con un numero positivo
                        int ajustedNumero = (int)numero % chars.Length;
                        mensaje_decodificado += chars[(j - ajustedNumero + chars.Length) % chars.Length];
                        break;
                    }
                }
            }



            ModelState.Clear();
        }
    }
}
