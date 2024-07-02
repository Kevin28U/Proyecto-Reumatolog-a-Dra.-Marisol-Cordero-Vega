using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Bitacora
{
    public int IdBitacora { get; set; }

    public int? IdExpediente { get; set; }

    public string? PadecimientoActual { get; set; }

    public string? ExamenFisico { get; set; }

    public string? ImpresionDiagnostica { get; set; }

    public string? PlanTratamiento { get; set; }

    public virtual Expediente? IdExpedienteNavigation { get; set; }
}
