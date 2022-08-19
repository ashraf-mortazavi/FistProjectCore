
using System.ComponentModel.DataAnnotations;

namespace FistProjectCore.Models;
public class Friend
{
    [Required]
    [MaxLength(50)]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "PhoneNumber")]
    public string PhoneNumber { get; set; }

    
    [Display(Name = "Picture")]
    public string Picture { get; set; }

    public int Id {get; set;}
}