using System;
using System.Text.RegularExpressions; // Necesario para validar teléfono y correo
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Capturar los datos eliminando espacios en blanco a los extremos
            string nombre = textBox1.Text.Trim();
            string telefono = textBox2.Text.Trim();
            string correo = textBox3.Text.Trim();

            // 2. Validación del Nombre (No puede estar vacío)
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El campo 'Nombre' no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            // 3. Validación del Teléfono (Solo números, entre 7 y 11 dígitos)
            if (!Regex.IsMatch(telefono, @"^\d{7,11}$"))
            {
                MessageBox.Show("Ingresa un número de teléfono válido (solo dígitos, entre 7 y 11 números).", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // 4. Validación del Correo Electrónico (Formato básico usuario@dominio.com)
            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingresa una dirección de correo electrónico válida.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            // 5. Acumular el cliente en el ListBox
            string nuevoCliente = $"{nombre} | Tel: {telefono} | {correo}";
            listBox1.Items.Add(nuevoCliente);

            // 6. Limpiar los campos y devolver el cursor al primer TextBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();

            MessageBox.Show("Cliente registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}