using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatosSQL {
    public partial class Dashboard : Form {
        List<Persona> personas = new List<Persona>();

        public Dashboard() {
            InitializeComponent();

            UpdateBinding();
        }

        private void UpdateBinding() {
            LBListaPersonasEncontradas.DataSource = personas;
            LBListaPersonasEncontradas.DisplayMember = "InformacionCompleta";

        }

        private void BtnBuscar_Click(object sender, EventArgs e) {
            AccesoDatos db = new AccesoDatos();

            personas = db.ObtenerPersonas(TBApellido.Text);

            UpdateBinding();
        }

        private void BtnInsertar_Click(object sender, EventArgs e) {
            AccesoDatos db = new AccesoDatos();

            Persona persona = new Persona {
                Nombre = TBInsertarNombre.Text,
                Apellido = TBInsertarApellido.Text,
                Correo = TBInsertarCorreoElectronico.Text,
                Telefono = TBInsertarTelefono.Text,
            };

            db.InsertarPersona(persona);

            TBInsertarNombre.Text = string.Empty;
            TBInsertarApellido.Text = string.Empty;
            TBInsertarCorreoElectronico.Text = string.Empty;
            TBInsertarTelefono.Text = string.Empty;
        }
    }
}
