using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final_CentroMedico;

public partial class Direccion
{

    public int IdDireccion { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public int? IdProvincia { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public int? IdCanton { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string? Direccion1 { get; set; }

    public virtual Canton? IdCantonNavigation { get; set; }

    public virtual Provincium? IdProvinciaNavigation { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
