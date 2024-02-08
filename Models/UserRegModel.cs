using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD_PROJECT.Models
{
    public class UserRegModel
    {
        [Required]
        [DisplayName("User ID")]
        public int Id { get; set; }


        [Required]
        [DisplayName("Email Id")]
        public string Emailid { get; set; }


        [Required]
        [DisplayName("User Password")]
        public string Password { get; set; }


        [Required]
        [DisplayName("UserName")]
        public string Name { get; set; }

    }
}