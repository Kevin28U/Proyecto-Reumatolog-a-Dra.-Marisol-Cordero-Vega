using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Canton
{
    public int IdCanton { get; set; }

    public int? IdProvincia { get; set; }

    public string? NombreProvincia { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

    public virtual Provincium? IdProvinciaNavigation { get; set; }
}
