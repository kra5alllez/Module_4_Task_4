using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module_4_Task_4_Vasylchenko.Entities;

namespace Module_4_Task_4_Vasylchenko
{
    public class LazyLoadingSamples
    {
        private readonly ApplicationContext _context;

        public LazyLoadingSamples(ApplicationContext context)
        {
            _context = context;
        }

        public async Task TaskOne()
        {
            var data = await _context.Clients.
                Select(c => new { cn = c.FirstName, pn = c.Projects.
                SelectMany(p => p.EmployeeProject.
                Select(e => new { ProjectName = p.Name, EmployeeID = e.EmployeeId }))}).ToListAsync();

            foreach (var client in data)
            {
                Console.WriteLine($"NameClient: {client.cn}. {string.Join(",", string.Join(",", client.pn))}");
            }
        }
        public async Task TaskTwo()
        {
            var data = await _context.Employees.
                Select(e => SqlServerDbFunctionsExtensions.
                DateDiffDay(null, e.HiredDate, DateTime.Now)).
                OrderBy(e => e).ToListAsync();

            foreach (var dif in data)
            {
                Console.WriteLine($"DataDifference: {dif}");
            }
        }

        public async Task TaskThree()
        {
            var employee = await _context.Employees.FirstOrDefaultAsync();
            var office = await _context.Offices.FirstOrDefaultAsync();

            if (employee != null)
            {
                employee.LastName = "Poo";
                employee.DateOfBirth = new DateTime(1999, 05, 05);
            }

            if (office != null)
            {
                office.Location = "Warshawa";
            }

            await _context.SaveChangesAsync();
        }

        public async Task TaskFour()
        {
            var office = await _context.Offices.FirstOrDefaultAsync(o => o.Location == "Italia");
            var project = await _context.Projects.FirstOrDefaultAsync(o => o.Name == "Project2");

            var employee = new Employee { FirstName = "Ivan", 
                LastName = "Ivan", 
                DateOfBirth = new DateTime(2000, 08, 04), 
                HiredDate = new DateTime(2020, 08, 04), 
                OfficeId = office.Id, 
                Title = new Title { Name = "ivanko" },
                EmployeeProject = new List<EmployeeProject>() { new EmployeeProject { ProjectId = project.Id, Rate = 23, StartedDate = new DateTime(2020, 08, 05) } }
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task TaskFive()
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.FirstName == "Ivan");
            _context.EmployeeProject.RemoveRange(employee.EmployeeProject);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task TaskSix()
        {
            var group = await _context.Employees.Where(t => !EF.Functions.Like(t.Title.Name, "%a%")).
                GroupBy(g => g.Title.Name).
                Select(s => new
                {
                    s.Key,
                    Count = s.Count()
                }).ToListAsync();

            foreach (var dif in group)
            {
                Console.WriteLine($"{dif.Key} : {dif.Count}");
            }
        }
    }
}
