namespace WinFormsApp3
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

    public partial class Form1 : Form
    {
        private Dictionary<string, bool> asistencia = new Dictionary<string, bool>();

        public Form1()
        {
            InitializeComponent();

            string[] estudiantes = { "Ana Gómez", "Carlos Pérez", "María Rodríguez", "Juan López", "Lucía Fernández" };

            listBox1.Items.Clear();
            foreach (var est in estudiantes)
            {
                asistencia[est] = false;
                listBox1.Items.Add(est);
            }

            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string estudiante = listBox1.SelectedItem.ToString();
                if (asistencia.ContainsKey(estudiante))
                {
                    checkBox1.Checked = asistencia[estudiante];
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string estudiante = listBox1.SelectedItem.ToString();
                asistencia[estudiante] = checkBox1.Checked;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int presentes = 0;
            List<string> nombresPresentes = new List<string>();

            foreach (var kvp in asistencia)
            {
                if (kvp.Value)
                {
                    presentes++;
                    nombresPresentes.Add(kvp.Key);
                }
            }

            string lista = presentes > 0 ? string.Join("\n - ", nombresPresentes) : "Ninguno";
            string mensaje = $"Total presentes: {presentes} de {asistencia.Count}\n\nEstudiantes presentes:\n - {lista}";

            MessageBox.Show(mensaje, "Resumen de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}