using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Data
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        [Display(Name ="User Name")]
        public string? Name { get; set; }
    }
}
