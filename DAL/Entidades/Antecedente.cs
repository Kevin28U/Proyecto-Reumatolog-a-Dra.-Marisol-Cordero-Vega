using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_CentroMedico;

public partial class Antecedente
{
    public int IdAntecedentes { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(2000, ErrorMessage = "Texto ingresado supera la longitud máxima permitida")]
    public string? Ago { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(2000, ErrorMessage = "Texto ingresado supera la longitud máxima permitida")]
    public string? ApnoP { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(2000, ErrorMessage = "Texto ingresado supera la longitud máxima permitida")]
    public string? App { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(2000, ErrorMessage = "Texto ingresado supera la longitud máxima permitida")]
    public string? Ahf { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(2000, ErrorMessage = "Texto ingresado supera la longitud máxima permitida")]
    public string? Aqtx { get; set; }

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
