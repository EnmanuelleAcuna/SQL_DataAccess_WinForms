using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosSQL {
    public static class Helper {
        public static string ConVal(string nombre) {
            return ConfigurationManager.ConnectionStrings[nombre].ConnectionString;
        }
    }
}