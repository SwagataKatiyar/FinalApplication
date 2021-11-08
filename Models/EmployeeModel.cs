using System.ComponentModel.DataAnnotations;

namespace FinalApplication.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Title is required")]

        public string Title { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Enter Full Name ")]

        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone No. is required")]
        [Display(Name = "Enter Phone Number")]
        public int? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Display(Name = "Enter City ")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "Enter State  ")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal is required")]
        [Display(Name = "Enter Postal  ")]
        public int? Postal { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Enter Country ")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Enter Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Status is required")]

        public string Status { get; set; }

        [Required(ErrorMessage = "Certification is required")]

        public string Certification { get; set; }


        [Required(ErrorMessage = "Salary is required")]
        [Display(Name = "Enter Salary")]
        public int? Salary { get; set; }
        [Required(ErrorMessage = "Experience is required")]

        public string YearsOfExperience { get; set; }

    }
}
