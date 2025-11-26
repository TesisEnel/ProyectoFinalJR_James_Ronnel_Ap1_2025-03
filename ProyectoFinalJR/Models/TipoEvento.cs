using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalJR.Models;
public class TipoEvento
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "El nombre del tipo de evento es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no debe exceder los 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Descripcion { get; set; }

}