using System;
using System.ComponentModel.DataAnnotations;

namespace FinalApplication.Models
{
    public class AccountModel
    {
        [Key]
        public String UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Name is required")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "LoginID")]
        [Required(ErrorMessage = "Login Id is required")]
        public int loginId { get; set; }


        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Compare("Pwd", ErrorMessage = "The password do not match.")]
        public string ConfirmPwd { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public char Gender { get; set; }
    }
}
