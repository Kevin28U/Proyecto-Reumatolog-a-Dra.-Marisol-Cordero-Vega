using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? IdUsuario { get; set; }

    public double? TotalPagar { get; set; }

    public string? Detalle { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
