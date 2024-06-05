using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Sexo
{
    public int IdSexo { get; set; }

    public string? Sexo1 { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
