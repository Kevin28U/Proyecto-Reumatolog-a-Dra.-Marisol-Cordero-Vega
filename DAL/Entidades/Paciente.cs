using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Paciente
{
    public string CedulaPaciente { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public int? Edad { get; set; }

    public int? IdSexo { get; set; }

    public int? IdOcupacion { get; set; }

    public int? IdDireccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();

    public virtual Direccion? IdDireccionNavigation { get; set; }

    public virtual Ocupacion? IdOcupacionNavigation { get; set; }

    public virtual Sexo? IdSexoNavigation { get; set; }
}
