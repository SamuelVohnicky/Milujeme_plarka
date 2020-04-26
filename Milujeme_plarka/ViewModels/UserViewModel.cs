using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Jméno")]
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Role")]
        public IList<string> Roles { get; set; }
        [Display(Name = "Všechny role")]
        public IList<IdentityRole> AllRoles { get; set; }
    }
}
