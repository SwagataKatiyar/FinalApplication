﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApplication.Models
{
   public class ResetPasswordModel
        {
        [Required]
           public string UserId { get; set; }

           
            public string Token { get; set; }

            [Required, DataType(DataType.Password)]
            public string NewPassword { get; set; }

            [Required, DataType(DataType.Password)]
            [Compare("NewPassword")]
            public string ConfirmNewPassword { get; set; }

            public bool IsSuccess { get; set; }
        }
    }

