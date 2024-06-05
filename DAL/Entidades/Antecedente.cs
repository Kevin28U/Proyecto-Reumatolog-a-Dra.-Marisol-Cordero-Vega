using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Antecedente
{
    public int IdAntecedentes { get; set; }

    public string? Ago { get; set; }

    public string? ApnoP { get; set; }

    public string? App { get; set; }

    public string? Ahf { get; set; }

    public string? Aqtx { get; set; }

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
