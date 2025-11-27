using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalJR.Models;

public class Evento
{
    [Key]
    public int EventoId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar el Tipo de Evento.")]
    public int TipoEventoId { get; set; }
    public int? TipoProveedorId { get; set; }

    [Required(ErrorMessage = "El nombre del evento es obligatorio.")]
    [StringLength(150, ErrorMessage = "El nombre no debe exceder los 150 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "La descripción no debe exceder los 1000 caracteres.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required(ErrorMessage = "La hora es obligatoria.")]
    [StringLength(10, ErrorMessage = "La hora debe tener un formato válido.")]
    public string Hora { get; set; } = string.Empty;

    [Required(ErrorMessage = "El lugar es obligatorio.")]
    [StringLength(250, ErrorMessage = "El lugar no debe exceder los 250 caracteres.")]
    public string Lugar { get; set; } = string.Empty;

    [Required(ErrorMessage = "El presupuesto inicial es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El presupuesto debe ser positivo.")]
    public decimal PresupuestoInicial { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio.")]
    [StringLength(50)]
    public string Estado { get; set; } = "Pendiente";


    [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
    public string UsuarioId { get; set; } = string.Empty;

    [ForeignKey("TipoEventoId")]
    public TipoEvento? TipoEvento { get; set; }

    [ForeignKey("TipoProveedorId")]
    public TipoProveedor? TipoProveedor { get; set; }
}