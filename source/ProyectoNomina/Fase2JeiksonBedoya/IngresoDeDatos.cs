using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase2JeiksonBedoya
{
    public partial class IngresoDeDatos : Form
    {
        Nomina nomina = new Nomina();
        public class Cargo
        {
            public string NombreCargo { get; set; }
            public double SalarioCargo { get; set; }

            public Cargo(string nombreCargo, double salarioCargo)
            {
                NombreCargo = nombreCargo;
                SalarioCargo = salarioCargo;
            }
        }
        List<Cargo> cargoList;
        public IngresoDeDatos()
        {
            InitializeComponent();
            DateTime fecha = DateTime.Now;
            string fechaform = fecha.ToString("dd/MM/yyyy");
            txtFecha.Text = fechaform;
            cargoList = new List<Cargo>();
            cargoList.Add(new Cargo("Electricista", 60000));
            cargoList.Add(new Cargo("Mecanico", 65000));
            cargoList.Add(new Cargo("Soldador", 70000));
            cargoList.Add(new Cargo("Servicios generales", 40000));
            cargoList.Add(new Cargo("Administrativo", 50000));

            foreach (Cargo cargo in cargoList)
            {
                cbCargo.Items.Add(cargo.NombreCargo);
            }

            cbCargo.SelectedIndexChanged += CbCargo_SelectedIndexChanged;
        }

        private void CbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cbCargo.SelectedIndex;
            if (indice >= 0 && indice < cargoList.Count)
            {
                double SalarioCargo = cargoList[indice].SalarioCargo;
                txtSalarioDia.Text = SalarioCargo.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir del formulario?", "Salir", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtGenero.Text) || string.IsNullOrWhiteSpace(cbCargo.Text) ||
                string.IsNullOrWhiteSpace(txtDias.Text))
            {
                MessageBox.Show("Todos las casillas son obligatorias.", "Error", MessageBoxButtons.OK);
                return;
            }
            nomina.Identificacion = int.Parse(txtIdentificacion.Text);
            nomina.Nombre = txtNombre.Text;
            nomina.Genero = txtGenero.Text;
            nomina.Cargo = cbCargo.Text;
            nomina.DiasLaborados = int.Parse(txtDias.Text);
            nomina.FechaRegistro = txtFecha.Text;
            nomina.SalarioDia = double.Parse(txtSalarioDia.Text);
            MessageBox.Show("Se guardó el registro.");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.Show();
            Hide();
            reporte.txtId.Text = nomina.Identificacion.ToString();
            reporte.txtnombres.Text = nomina.Nombre;
            reporte.cbGeneros.Text = nomina.Genero;
            reporte.cbCargos.Text = nomina.Cargo;
            reporte.txtDiasLab.Text = nomina.DiasLaborados.ToString() + " Dias";
            reporte.txtFechaReg.Text = nomina.FechaRegistro;
            reporte.txtValSalario.Text = nomina.SalarioDia.ToString("C");
            reporte.txtDevengado.Text = nomina.SalarioDevengado(nomina.DiasLaborados, nomina.SalarioDia).ToString("C");
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbCargo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSalarioDia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
