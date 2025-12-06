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
    [StringLength(16, MinimumLength = 16, ErrorMessage = "Debe ingresar 16 dígitos.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números.")]
    public string? NumeroTarjeta { get; set; }

    [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Formato MM/AA inválido.")]
    public string? FechaVencimiento { get; set; }

    [StringLength(4, MinimumLength = 3, ErrorMessage = "Debe ingresar 3 o 4 dígitos.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números.")]
    public string? CVV { get; set; }

    [ForeignKey("EventoId")]
    public EventoDetalle? Evento { get; set; }
}