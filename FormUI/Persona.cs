using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosSQL {
    public class Persona {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public int Id { get; set; }

        public string  InformacionCompleta {
            get {
                // "Enmanuelle Acuña (emanuelacu@outlook.com)"
                return $"{ Nombre } { Apellido } ({ Correo })";
            }
        }
    }
}