using System;
using System.Collections.Generic;

namespace Module_4_Task_4_Vasylchenko.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual List<EmployeeProject> EmployeeProject { get; set; } = new List<EmployeeProject>();
    }
}
