using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_CentroMedico;

public partial class Paciente
{
    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression("^[0-9]{9}$", ErrorMessage = "La cédula debe contener solo 9 dígitos numéricos.")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "La cédula debe contener exactamente 9 dígitos.")]
    public string CedulaPaciente { get; set; } = null!;

    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(100, ErrorMessage = "Texto ingresado supera la longitud máxima permitida")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(100, ErrorMessage = "Texto ingresado supera la longitud máxima permitida")]
    public string? PrimerApellido { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(100, ErrorMessage = "Texto ingresado supera la longitud máxima permitida")]
    public string? SegundoApellido { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [Range(0, 150, ErrorMessage = "Edad no válida")]
    public int? Edad { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [Range(1, 2, ErrorMessage = "Ingrese un valor de sexo válido")]

    public int? IdSexo { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]

    public int? IdOcupacion { get; set; }


    public int? IdDireccion { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateOnly? FechaNacimiento { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();


    public virtual Direccion? IdDireccionNavigation { get; set; }

    public virtual Ocupacion? IdOcupacionNavigation { get; set; }

    public virtual Sexo? IdSexoNavigation { get; set; }
}
