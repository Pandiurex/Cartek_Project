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
    public partial class Producto : MaterialForm
    {
        NpgsqlConnection con = new NpgsqlConnection();
        DataSet data = new DataSet();
        DataSet data2 = new DataSet();
        string query = "";
        string query2 = "";
        string idTicket = "";


        public Producto(string numberTicket, string parametros)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);

            InitializeComponent();

            con.ConnectionString = parametros;

            try
            {
                con.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error.Message);
            }

            idTicket = numberTicket;

            idTicketBox.Text = idTicket;

            query = "SELECT * FROM producto;";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(data);
            productGrid.DataSource = data.Tables[0];

            query2 = "SELECT * FROM productofactura WHERE idfactura='" + idTicketBox.Text.ToString() + "';";
            NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(query2, con);
            add2.Fill(data2);
            productoFacturaGrid.DataSource = data2.Tables[0];
        }
        private void AddProducto()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("INSERT INTO productofactura " +
                    "VALUES ('" + idTicketBox.Text + "','" + idProductBox.Text + "','" + quantityBox.Value.ToString() + "');", con);
                comando.ExecuteNonQuery();

                NpgsqlCommand comando2 = new NpgsqlCommand("UPDATE producto SET cantidad= cantidad-" + Convert.ToDouble(quantityBox.Value.ToString()) + "  WHERE codigo='" + idProductBox.Text + "';", con);
                comando2.ExecuteNonQuery();

                idProductBox.Text = "ID Producto";
                quantityBox.Value = 1;
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void idProductBox_Click(object sender, EventArgs e)
        {
            if (idProductBox.Text == "ID Producto")
            {
                idProductBox.Text = "";
            }
        }

        private void idProductBox_Leave(object sender, EventArgs e)
        {
            if (idProductBox.Text == "")
            {
                idProductBox.Text = "ID Producto";
            }
        }

        private void idProductBox_TextChanged(object sender, EventArgs e)
        {
            if (idProductBox.Text != "" && idProductBox.Text != "ID Producto")
            {
                data.Clear();
                productGrid.DataSource = data.Tables[0];

                query = "SELECT * FROM producto WHERE codigo LIKE '" + idProductBox.Text + "%';";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
                add.Fill(data);
                productGrid.DataSource = data.Tables[0];
            }
            else if (idProductBox.Text == "" || idProductBox.Text == "ID Producto")
            {
                data.Clear();
                productGrid.DataSource = data.Tables[0];

                query = "SELECT * FROM producto;";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
                add.Fill(data);
                productGrid.DataSource = data.Tables[0];
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            AddProducto();

            data.Clear();
            productGrid.DataSource = data.Tables[0];

            query = "SELECT * FROM producto";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(data);
            productGrid.DataSource = data.Tables[0];

            data2.Clear();
            productoFacturaGrid.DataSource = data2.Tables[0];

            query2 = "SELECT * FROM productofactura WHERE idfactura='" + idTicketBox.Text.ToString() + "';";
            NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(query2, con);
            add2.Fill(data2);
            productoFacturaGrid.DataSource = data2.Tables[0];
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            eliminarReg();

            data.Clear();
            productGrid.DataSource = data.Tables[0];

            query = "SELECT * FROM producto";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(data);
            productGrid.DataSource = data.Tables[0];

            data2.Clear();
            productoFacturaGrid.DataSource = data2.Tables[0];

            query2 = "SELECT * FROM productofactura WHERE idfactura='" + idTicketBox.Text.ToString() + "';";
            NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(query2, con);
            add2.Fill(data2);
            productoFacturaGrid.DataSource = data2.Tables[0];
        }
        private void eliminarReg()
        {
            DataGridViewRow fila = productoFacturaGrid.CurrentRow;

            try
            {
                NpgsqlCommand comando2 = new NpgsqlCommand("UPDATE producto SET cantidad= cantidad+" + Convert.ToDouble(fila.Cells[2].Value) + "  WHERE codigo='" + searchBox.Text + "';", con);
                comando2.ExecuteNonQuery();

                NpgsqlCommand comando = new NpgsqlCommand("DELETE FROM productofactura WHERE idproducto='" + searchBox.Text.ToString() + "';", con);
                comando.ExecuteReader();

                searchBox.Text = "Buscar Para Eliminar";
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void Producto_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            if (searchBox.Text == "Buscar Para Eliminar")
            {
                searchBox.Text = "";
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = "Buscar Para Eliminar";
            }
        }
    }
}
///Hecho por Cristopher Sinhue Estrada PAnduro Todos los Derechos Reservado