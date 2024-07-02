using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Expediente
{
    public int IdExpediente { get; set; }

    public string? CedulaPaciente { get; set; }

    public int? IdAntecedentes { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();

    public virtual Paciente? CedulaPacienteNavigation { get; set; }

    public virtual Antecedente? IdAntecedentesNavigation { get; set; }
}
