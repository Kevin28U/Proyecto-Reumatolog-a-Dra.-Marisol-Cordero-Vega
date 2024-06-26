using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class VerExpedienteViewModel
    {
        public string cedula {  get; set; }
        public string nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateOnly FechaNacimiento { get; set; }   
        public int edad { set; get; }
        public string Sexo { set; get; }
        public string Ocupacion { set; get; }
        public string Provincia { set; get; }
        public string Canton {  get; set; }
        public string Direccion {  set; get; }
        public string AGO {  set; get; }
        public string APnoP { set; get; }
        public string APP { set; get; }
        public string AHF { set; get; }
        public string AQTx { set; get; }

        public VerExpedienteViewModel(string cedula,
                string nombre, 
                string primerApellido, 
                string segundoApellido, 
                DateOnly fechaNacimiento, 
                int edad, string sexo, 
                string ocupacion, 
                string provincia, 
                string canton, 
                string direccion,
                string aGO, 
                string aPnoP, 
                string aPP, 
                string aHF, 
                string aQTx
            )
        {
            this.cedula = cedula;
            this.nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            this.edad = edad;
            Sexo = sexo;
            Ocupacion = ocupacion;
            Provincia = provincia;
            Canton = canton;
            Direccion = direccion;
            AGO = aGO;
            APnoP = aPnoP;
            APP = aPP;
            AHF = aHF;
            AQTx = aQTx;
        }
    }
}
