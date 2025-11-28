using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalJR.Models;

public class Sugerencia
{
    [Key]
    public int SugerenciaId { get; set; }

    [Required(ErrorMessage = "El asunto de la sugerencia es obligatorio.")]
    [StringLength(100, ErrorMessage = "El asunto no debe exceder los 50 caracteres.")]
    public string Asunto { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción de la sugerencia es obligatoria.")]
    [StringLength(500, ErrorMessage = "La descripción no debe exceder los 200 caracteres.")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
    public string UsuarioId { get; set; } = string.Empty;

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

}