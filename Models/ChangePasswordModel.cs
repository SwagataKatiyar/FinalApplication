using System.ComponentModel.DataAnnotations;

namespace FinalApplication.Models
{
    public class ChangePasswordModel
    {

        [Key]
        [Required, DataType(DataType.Password), Display(Name = "Current password")]
        public string Pwd { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "New password")]
        public string NewPwd { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm new password")]
        [Compare("NewPwd", ErrorMessage = "Confirm new password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
