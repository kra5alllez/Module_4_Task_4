using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Module_4_Task_4_Vasylchenko
{
    public class LazyLoadingSamples
    {
        private readonly ApplicationContext _context;

        public LazyLoadingSamples(ApplicationContext context)
        {
            _context = context;
        }

        public async Task LoadCategoriesProductsAndSupply()
        {

            var data = await _context.Clients
                .SelectMany(x => x.Projects.Select(v => new { PName = v.Name, EmloyeeId = v.EmployeeProject.Select(p => p.EmployeeId)})).ToListAsync();

            //foreach (var supply in data)
            //{
            //    Console.WriteLine($"CID: {supply.ClientId}. PN: {supply.Projec.}");
            //}
        }
    }
}
