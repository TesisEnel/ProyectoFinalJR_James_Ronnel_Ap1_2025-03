using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalJR.Models;

public class Cita
{
    [Key]
    public int CitaId { get; set; }

    [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
    public DateOnly FechaCita { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required(ErrorMessage = "La hora de la cita es obligatoria.")]
    [StringLength(10, ErrorMessage = "La hora debe tener un formato válido.")]
    public string HoraCita { get; set; } = string.Empty;

    [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
    public string UsuarioId { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Evento asociado es obligatorio.")]
    public int EventoId { get; set; }

    public int? ProveedorId { get; set; }

    [ForeignKey("EventoId")]
    public EventoDetalle? Evento { get; set; }

    [ForeignKey("ProveedorId")]
    public TipoProveedor? Proveedor { get; set; }

    // Nota: Necesitas la clase ApplicationUser
    // [ForeignKey("UsuarioId")]
    // public ApplicationUser? Usuario { get; set; } 
}