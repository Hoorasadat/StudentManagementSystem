using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.WEB.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [MaxLength(256)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
