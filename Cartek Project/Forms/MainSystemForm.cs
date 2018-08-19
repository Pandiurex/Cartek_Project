using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using NpgsqlTypes;

namespace Cartek_Project
{
    public partial class MainSystemForm : MaterialForm
    {
        string employKind = "empacador";

        NpgsqlConnection con = new NpgsqlConnection();

        public MainSystemForm(string parametros)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);

            InitializeComponent();

            con.ConnectionString = parametros;
        }

        private void password_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            password.MaxLength = 16;
            password.PasswordChar = '*';

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                logIn_Click(sender, e);
            }
        }

        private void logIn_Click(object sender, EventArgs e)
        {

            if (username.Text == "" || username.Text == "Codigo de Empleado")
            {
                MessageBox.Show("Ingresa un Codigo de Empleado", "Username Error");
            }
            else if (password.Text == "" || password.Text == "Contraseña")
            {
                MessageBox.Show("Ingresa tu contraseña", "Password Error");
            }
            else
            {

                DataTable dataT = new DataTable();

                string query = "SELECT * FROM " + employKind + " WHERE nippersonal=@codigo AND contraseña=@password";
                NpgsqlCommand comando = new NpgsqlCommand(query, con);
                comando.Parameters.AddWithValue("@codigo", username.Text);
                comando.Parameters.AddWithValue("@password", password.Text);
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(comando);
                data.Fill(dataT);

                if (dataT.Rows.Count > 0 && employKind == "empacador")
                {
                    EmployForm employForm = new EmployForm(con.ConnectionString, username.Text);
                    this.Hide();
                    employForm.ShowDialog();
                    this.Show();
                }
                else if (dataT.Rows.Count > 0 && employKind == "gerente")
                {
                    ManagerForm managerForm = new ManagerForm(con.ConnectionString);
                    this.Hide();
                    managerForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Error No existe en la Base de Datos", "Error Log In", MessageBoxButtons.OK);
                }

            }
        }

        private void password_Click(object sender, EventArgs e)
        {
            if (password.Text == "Contraseña")
            {
                password.Text = "";
            }

        }

        private void username_Click(object sender, EventArgs e)
        {
            if (username.Text == "Codigo de Empleado")
            {
                username.Text = "";
            }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            employKind = "gerente";
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            employKind = "empacador";
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Codigo de Empleado";
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Contraseña";
            }
        }
    }
}
///Hecho por Cristopher Sinhue Estrada PAnduro Todos los Derechos Reservado