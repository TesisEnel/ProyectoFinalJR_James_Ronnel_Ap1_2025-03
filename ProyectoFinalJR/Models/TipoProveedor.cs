using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalJR.Models;

public class TipoProveedor
{
    [Key]
    public int TipoProveedorId { get; set; }

    [Required(ErrorMessage = "El nombre del tipo de proveedor es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no debe exceder los 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Descripcion { get; set; }
}