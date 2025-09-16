using System.ComponentModel.DataAnnotations;

namespace MVCWithEF.Models
{
    public class Employee 
    {
        [Key]
        public int EmpID { get; set; }

        [Required(ErrorMessage ="Enter Name")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public string EmpGender { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Phone")]
        public string Phone { get; set; }

    }
}
