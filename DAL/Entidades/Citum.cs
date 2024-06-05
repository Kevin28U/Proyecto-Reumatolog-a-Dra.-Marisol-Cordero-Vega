using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Citum
{
    public int IdCita { get; set; }

    public string? CedulaPaciente { get; set; }

    public int? IdUsuario { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Motivo { get; set; }

    public virtual Paciente? CedulaPacienteNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
