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

    public partial class DataBaseLogIn : MaterialForm
    {

        NpgsqlConnection con = new NpgsqlConnection();

        public DataBaseLogIn()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);

            InitializeComponent();

        }

        private void dataBaseLogInButton_Click(object sender, EventArgs e)
        {
            string parametros = "Server=localhost;Port=5432;User Id=postgres;Password=" + database_password.Text + ";Database=cartek";
            bool correcto;
            con.ConnectionString = parametros;
            try
            {
                con.Open();
                correcto = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error.Message);
                correcto = false;
            }

            if (correcto == true)
            {
                this.Hide();
                MainSystemForm ventanaMenu = new MainSystemForm(parametros);
                ventanaMenu.ShowDialog();
                this.Close();
            }
        }

        private void database_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            database_password.MaxLength = 16;
            database_password.PasswordChar = '*';
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                dataBaseLogInButton_Click(sender, e);
            }
        }

        private void database_password_Click(object sender, EventArgs e)
        {
            if (database_password.Text == "Contraseña")
            {
                database_password.Text = "";
            }
        }
    }
}
///Hecho por Cristopher Sinhue Estrada PAnduro Todos los Derechos Reservado