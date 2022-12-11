using System;
using System.ComponentModel.DataAnnotations;

namespace TestProject.WebAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailId { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpenses { get; set; }
    }
}
