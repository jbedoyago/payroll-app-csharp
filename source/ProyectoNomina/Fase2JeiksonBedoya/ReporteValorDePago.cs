using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase2JeiksonBedoya
{
    public partial class ReporteValorDePago : Form
    {
        public ReporteValorDePago()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IngresoDeDatos ingDatos = new IngresoDeDatos();
            if (txtContra.Text != "")
            {
                if (txtContra.Text == "123")
                {
                    ingDatos.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta. Intente nuevamente.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContra.Clear();
                }
            }
        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
