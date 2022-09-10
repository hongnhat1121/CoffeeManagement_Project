using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeManagement.DAL.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Identification { get; set; }
        public string Description { get; set; }

        public virtual User EmployeeNavigation { get; set; }
    }
}