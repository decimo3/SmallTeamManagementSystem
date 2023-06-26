namespace sge.Models;
using System.ComponentModel.DataAnnotations;
public class AuthRequest
{
    [Required]
    public int matricula {get; set;}
    [Required]
    public string palavra {get; set;}
}
