using Proyecto_Final_CentroMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class PagosViewModel
    {

        public int IdPago { get; set; }

        public int? IdUsuario { get; set; }

        public double? TotalPagar { get; set; }

        public string? Detalle { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }

        public PagosViewModel(int IdPago, int IdUsuario, double? TotalPagar, string Detalle)
        {
            this.IdPago = IdPago;
            this.IdUsuario = IdUsuario;
            this.TotalPagar = TotalPagar;
            this.Detalle = Detalle;
        }


    }
}
