using System.ComponentModel.DataAnnotations;

namespace CRUDMVCs.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Salary")]
        public decimal Salary { get; set; }
    }
}