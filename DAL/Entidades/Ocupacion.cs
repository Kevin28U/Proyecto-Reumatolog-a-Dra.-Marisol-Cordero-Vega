using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Ocupacion
{
    public int IdOcupacion { get; set; }

    public string? Ocupacion1 { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
