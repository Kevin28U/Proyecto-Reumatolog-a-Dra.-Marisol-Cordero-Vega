using System;
using System.Collections.Generic;

namespace Proyecto_Final_CentroMedico;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Telefono { get; set; }

    public string? Contrasena { get; set; }

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
