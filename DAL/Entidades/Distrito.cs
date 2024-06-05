using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Distrito
{
    public int IdDistrito { get; set; }

    public int? IdCanton { get; set; }

    public string? NombreDistrito { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Canton? IdCantonNavigation { get; set; }
}
