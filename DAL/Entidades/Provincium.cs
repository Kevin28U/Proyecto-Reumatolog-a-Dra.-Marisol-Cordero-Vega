using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Provincium
{
    public int IdProvincia { get; set; }

    public string? NombreProvincia { get; set; }

    public virtual ICollection<Canton> Cantons { get; set; } = new List<Canton>();

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();
}
