using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinalApplication.Models
{
    public class ApplicationClass : IdentityUser

        {
            [Key]
            public string UserId { get; set; }


            public int loginId { get; set; }

         


        public DateTime DOB { get; set; }


            public char Gender { get; set; }


            
        
        }


   

}
