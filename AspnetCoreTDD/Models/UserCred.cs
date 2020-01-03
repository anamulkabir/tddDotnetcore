using System.ComponentModel.DataAnnotations;
namespace AspnetCoreTDD.Models
{
    public class UserCred
    {
        public int UserCredID { get; set; }
        [Display(Name = "User Name")]
        [StringLength(30, MinimumLength = 8)]
        [Required(ErrorMessage = "User Name is required")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}