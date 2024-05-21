using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class problema4Model : PageModel
    {
        public int[] Numbers { get; set; }
        public int Sum { get; set; }
        public double Mean { get; set; }
        public int[] SortedNumbers { get; set; }
        public int[] Mode { get; set; }
        public double Median { get; set; }

        public void OnPost()
        {
            Random random = new Random();
            Numbers = new int[20];
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = random.Next(0, 101);
            }

            Sum = Numbers.Sum();
            Mean = Numbers.Average();

            var grouped = Numbers.GroupBy(n => n);
            int maxCount = grouped.Max(g => g.Count());
            Mode = grouped.Where(g => g.Count() == maxCount).Select(g => g.Key).ToArray();

            SortedNumbers = (int[])Numbers.Clone();
            Array.Sort(SortedNumbers);

            if (SortedNumbers.Length % 2 == 0)
            {
                Median = (SortedNumbers[SortedNumbers.Length / 2 - 1] + SortedNumbers[SortedNumbers.Length / 2]) / 2.0;
            }
            else
            {
                Median = SortedNumbers[SortedNumbers.Length / 2];
            }
        }

        public void OnGet()
        {
        }
    }
}
