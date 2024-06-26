using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ExpedienteViewModel
    {

        public int IdExpediente { get; set; }
        public string cedula;
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public ExpedienteViewModel(int IdExpediente, string cedula, string Nombre, string PrimerApellido, string SegundoApellido)
        {
            this.IdExpediente = IdExpediente;
            this.cedula = cedula;
            this.Nombre = Nombre;
            this.PrimerApellido = PrimerApellido;
            this.SegundoApellido = SegundoApellido;
        }


    }
}
