using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeManagement.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserRoleId { get; set; }
        public bool? Status { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
