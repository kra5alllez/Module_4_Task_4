using System.Collections.Generic;

namespace Module_4_Task_4_Vasylchenko.Entities
{
    public class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
