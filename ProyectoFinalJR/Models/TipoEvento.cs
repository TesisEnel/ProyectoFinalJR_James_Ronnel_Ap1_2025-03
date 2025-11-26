using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalJR.Models;

[Table("tipo_evento")]
public class TipoEvento
{
    [Key]
    [Display(Name = "ID")]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "El nombre del tipo de evento es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no debe exceder los 100 caracteres.")]
    [Display(Name = "Nombre del Tipo")]
    public string Nombre { get; set; } = string.Empty;

    [Display(Name = "Descripción")]
    [StringLength(500)]
    public string? Descripcion { get; set; }

}