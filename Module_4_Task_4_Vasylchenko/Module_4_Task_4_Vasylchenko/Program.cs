using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Module_4_Task_4_Vasylchenko
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).LoadCategoriesProductsAndSupply();
            }

            Console.ReadKey();
        }
    }
}
