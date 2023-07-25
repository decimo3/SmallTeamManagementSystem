namespace sge.Models;
using System.ComponentModel.DataAnnotations;
public class AuthRequest
{
    [Required]
    [Display(Name="Matrícula")]
    public int matricula {get; set;}
    [Required]
    [Display(Name="Senha")]
    public string palavra {get; set;}
}
