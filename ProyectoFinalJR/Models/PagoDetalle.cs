using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalJR.Models;

public class PagosDetalle
{
    [Key]
    public int PagoId { get; set; }

    [Required(ErrorMessage = "El evento asociado es obligatorio.")]
    public int EventoId { get; set; }

    [Required(ErrorMessage = "El monto pagado es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser positivo.")]
    public decimal MontoPagado { get; set; }

    [Required(ErrorMessage = "La fecha del pago es obligatoria.")]
    public DateTime FechaPago { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El método de pago es obligatorio.")]
    [StringLength(50, ErrorMessage = "El metodo no debe exceder los 50 caracteres.")]
    public string Metodo { get; set; } = string.Empty; 

    [Required(ErrorMessage = "El estado del pago es obligatorio.")]
    [StringLength(50, ErrorMessage = "El estado no debe exceder los 50 caracteres.")]
    public string Estado { get; set; } = "Pendiente"; 

    [ForeignKey("EventoId")]
    public EventoDetalle? Evento { get; set; }

}