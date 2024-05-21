using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace RazorPages.Pages
{
    public class problema3Model : PageModel
    {
        [BindProperty]
        public double A { get; set; }

        [BindProperty]
        public double B { get; set; }

        [BindProperty]
        public double X { get; set; }

        [BindProperty]
        public double Y { get; set; }

        [BindProperty]
        public int N { get; set; }

        public string ResultDirect { get; set; }
        public List<string> ResultStepByStep { get; set; }

        public void OnPost()
        {
            ResultDirect = EvaluateDirect(A, B, X, Y, N);
            ResultStepByStep = ExpandBinomialStepByStep(A, B, X, Y, N);
        }

        private string EvaluateDirect(double a, double b, double x, double y, int n)
        {
            double result = Math.Pow(a * x + b * y, n);
            return result.ToString("G");
        }

        private List<string> ExpandBinomialStepByStep(double a, double b, double x, double y, int n)
        {
            List<string> steps = new List<string>();
            double cumulativeResult = 0;

            for (int k = 0; k <= n; k++)
            {
                double coefficient = BinomialCoefficient(n, k);
                double termA = Math.Pow(a * x, n - k);
                double termB = Math.Pow(b * y, k);
                double term = coefficient * termA * termB;

                cumulativeResult += term;
                steps.Add($"{term.ToString("G")} (sum: {cumulativeResult.ToString("G")})");
            }

            return steps;
        }

        private double BinomialCoefficient(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private double Factorial(int number)
        {
            if (number == 0)
                return 1;
            double result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
