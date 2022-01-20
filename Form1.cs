using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_registro_de_estacionamiento
{
    public partial class Form1 : Form
    {
        string dia;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Mostrando la fecha actual
            lblFecha.Text = DateTime.Now.ToShortDateString();

            //Determinar el dia
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            dia = fecha.ToString("dddd");

            double costo = 0;
            switch (dia)
            {
                case "Sunday": costo = 2; break;
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                    costo = 4; break;
                case "Friday":
                case "Saturday":
                    costo = 7; break;
            }
            lblCosto.Text = costo.ToString("0.00");
        }


        private void BtnRegistar_Click(object sender, EventArgs e)
        {

            //Capturando los datos del formulario
            string placa = txtPlaca.Text;
            double costo = double.Parse(lblCosto.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime horaInicio = DateTime.Parse(txtHoraInicio.Text);
            DateTime horaFin = DateTime.Parse(txtHoraFin.Text);

            //Calcular la hora
            TimeSpan hora = horaFin - horaInicio;

            //Calcular el importe
            double importe = costo * (hora.TotalHours);

            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(horaInicio.ToString("t"));
            fila.SubItems.Add(horaFin.ToString("t"));
            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("C"));
            fila.SubItems.Add(importe.ToString("C"));
            lvRegistro.Items.Add(fila);

            txtPlaca.Clear();
            txtHoraFin.Clear();
            txtHoraInicio.Clear();
            txtPlaca.Focus();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtHoraFin.Clear();
            txtHoraInicio.Clear();
            txtPlaca.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Estas seguro de salir", "Estacionamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }

        private void TxtHoraInicio_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void LblFecha_Click(object sender, EventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            lvRegistro.Items.Clear();
        }

        private void TxtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
