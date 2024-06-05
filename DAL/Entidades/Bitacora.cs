using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Bitacora
{
    public int IdBitacora { get; set; }

    public int? IdExpediente { get; set; }

    public string? Sintomatologia { get; set; }

    public string? Evolucion { get; set; }

    public string? CambiosTratamiento { get; set; }

    public virtual Expediente? IdExpedienteNavigation { get; set; }
}
