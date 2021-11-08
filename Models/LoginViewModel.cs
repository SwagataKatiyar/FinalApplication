using System.ComponentModel.DataAnnotations;

namespace FinalApplication.Models
{
    public class LoginViewModel
    {
       

    
    [Display(Name = "Enter User ID")]
        [Required(ErrorMessage = "User Id is required")]
        public string UserId { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Enter Password")]
    public string Pwd { get; set; }


    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}
}