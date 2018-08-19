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
    public partial class EmployForm : MaterialForm
    {

        NpgsqlConnection con = new NpgsqlConnection();
        DataSet data = new DataSet();
        DataSet data2 = new DataSet();
        DataSet dataProduct = new DataSet();
        DataSet dataError = new DataSet();

        string query = "";
        string productQuery = "";
        string errorQuery = "";
        string nip;

        public EmployForm(string parametros, string nip)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey900, Accent.LightBlue200, TextShade.WHITE);

            InitializeComponent();

            con.ConnectionString = parametros;

            this.nip = nip;

            try
            {
                con.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error.Message);
            }

            query = "SELECT * FROM facturas;";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(data);
            ticketGrid.DataSource = data.Tables[0];

            errorQuery = "SELECT * FROM errorescliente WHERE codigoempacador='" + nip + "';";
            NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(errorQuery, con);
            add2.Fill(dataError);
            errorGrid.DataSource = dataError.Tables[0];

            getInfoEmploy();
        }
        private void getInfoEmploy()
        {

            DataTable dataT = new DataTable();
            query = "SELECT * FROM empacador WHERE nippersonal=@codigo";
            NpgsqlCommand comando = new NpgsqlCommand(query, con);
            comando.Parameters.AddWithValue("@codigo", nip);
            NpgsqlDataAdapter data3 = new NpgsqlDataAdapter(comando);
            data3.Fill(dataT);

            DataRow row = dataT.Rows[0];

            nameBox.Text = row["nombre"].ToString();
            dateBox.Text = row["fechaexpedicionlaboral"].ToString();
            addressBox.Text = row["direccion"].ToString();
            curpBox.Text = row["curp"].ToString();
            operatorBox.Text = row["operadora"].ToString();
            laboralBox.Text = row["puesto"].ToString();
            genreBox.Text = row["genero"].ToString();
            errorBox.Text = row["erroresdecliente"].ToString();
            lineBox.Text = row["renglonesempacados"].ToString();
            nipBox.Text = row["nippersonal"].ToString();
            passwordBox.Text = row["contraseña"].ToString();


        }

        private void idTicketBox_Click(object sender, EventArgs e)
        {
            if (idTicketBox.Text == "ID de Factura")
            {
                idTicketBox.Text = "";
            }
        }

        private void idProduct_Click(object sender, EventArgs e)
        {
            if (idProduct.Text == "ID Producto")
            {
                idProduct.Text = "";
            }
        }

        private void workTicketButton_Click(object sender, EventArgs e)
        {
            DataTable dataT = new DataTable();
            string querySelect = "SELECT * FROM facturas WHERE numerofactura=@factura";
            NpgsqlCommand comando = new NpgsqlCommand(querySelect, con);
            comando.Parameters.AddWithValue("@factura", idTicketBox.Text);
            NpgsqlDataAdapter datas = new NpgsqlDataAdapter(comando);
            datas.Fill(dataT);

            if (dataT.Rows.Count > 0)
            {
                idProduct.Enabled = true;
                productNum.Enabled = true;
                addProductButton.Enabled = true;
                idTicketBox.Enabled = false;
                workTicketButton.Enabled = false;

                data.Clear();

                query = "select * from productofactura where idfactura='" + idTicketBox.Text + "';";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
                add.Fill(data2);
                ticketGrid.DataSource = data2.Tables[0];

                productQuery = "select * from producto;";
                NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(productQuery, con);
                add2.Fill(dataProduct);
                productGrid.DataSource = dataProduct.Tables[0];

                double registro = Convert.ToDouble(ticketGrid.Rows.Count.ToString()) - 1;
                registros.Text = registro.ToString();

                if (registro == 0)
                {
                    MessageBox.Show("No hay Productos por Verificar", "Verificado", MessageBoxButtons.OK);
                    NpgsqlCommand comando2 = new NpgsqlCommand("DELETE FROM facturas WHERE numerofactura='" + idTicketBox.Text + "';", con);
                    comando2.ExecuteReader();
                    NpgsqlCommand comando4 = new NpgsqlCommand("UPDATE promedio SET facturas=facturas+1 WHERE idempleado='" + nip + "';", con);
                    comando4.ExecuteReader();

                    data.Clear();
                    data2.Clear();
                    ticketGrid.DataSource = data.Tables[0];

                    query = "SELECT * FROM facturas;";
                    NpgsqlDataAdapter add3 = new NpgsqlDataAdapter(query, con);
                    add3.Fill(data);
                    ticketGrid.DataSource = data.Tables[0];

                    idTicketBox.Enabled = true;
                    workTicketButton.Enabled = true;
                    registros.Text = "Registros";
                    idTicketBox.Text = "ID de Factura";
                    idProduct.Text = "ID Producto";
                    productNum.Value = 1;

                    idProduct.Enabled = false;
                    productNum.Enabled = false;
                    addProductButton.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Hay " + registros.Text + " por verificar", "Verificado", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No Coincide la Factura", "Error", MessageBoxButtons.OK);
            }


        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            DataTable dataT = new DataTable();
            double registro = Convert.ToDouble(ticketGrid.Rows.Count.ToString()) - 1;
            registros.Text = registro.ToString();

            string queryCompare = "SELECT * FROM productofactura WHERE idfactura=@factura AND idproducto=@codigo AND cantidad=@cantidad";
            NpgsqlCommand comando = new NpgsqlCommand(queryCompare, con);
            comando.Parameters.AddWithValue("@factura", idTicketBox.Text);
            comando.Parameters.AddWithValue("@codigo", idProduct.Text);
            comando.Parameters.AddWithValue("@cantidad", productNum.Value.ToString());
            NpgsqlDataAdapter datas = new NpgsqlDataAdapter(comando);
            datas.Fill(dataT);

            if (dataT.Rows.Count > 0)
            {
                try
                {
                    NpgsqlCommand comando2 = new NpgsqlCommand("DELETE FROM productofactura WHERE idproducto='" + idProduct.Text + "';", con);
                    comando2.ExecuteReader();

                    NpgsqlCommand comando3 = new NpgsqlCommand("UPDATE promedio SET renglon=renglon+1 WHERE idempleado='" + nip + "';", con);
                    comando3.ExecuteReader();

                    idProduct.Text = "ID Producto";
                    productNum.Value = 1;
                    MessageBox.Show("Coincide Perfectamente", "Verificado", MessageBoxButtons.OK);
                    registro--;
                    registros.Text = registro.ToString();

                }
                catch (Exception error)
                {
                    MessageBox.Show("ERROR:" + error.Message);
                }

                if (registro == 0)
                {
                    NpgsqlCommand comando2 = new NpgsqlCommand("DELETE FROM facturas WHERE numerofactura='" + idTicketBox.Text + "';", con);
                    comando2.ExecuteReader();

                    MessageBox.Show("No hay Productos por Verificar", "Verificado", MessageBoxButtons.OK);
                    NpgsqlCommand comando4 = new NpgsqlCommand("UPDATE promedio SET facturas=facturas+1 WHERE idempleado='" + nip + "';", con);
                    comando4.ExecuteReader();

                    data.Clear();
                    data2.Clear();
                    ticketGrid.DataSource = data.Tables[0];

                    query = "SELECT * FROM facturas;";
                    NpgsqlDataAdapter add3 = new NpgsqlDataAdapter(query, con);
                    add3.Fill(data);
                    ticketGrid.DataSource = data.Tables[0];

                    idTicketBox.Enabled = true;
                    workTicketButton.Enabled = true;
                    registros.Text = "Registros";
                    idTicketBox.Text = "ID de Factura";
                    idProduct.Text = "ID Producto";
                    productNum.Value = 1;

                    idProduct.Enabled = false;
                    productNum.Enabled = false;
                    addProductButton.Enabled = false;
                }

                data2.Clear();
                ticketGrid.DataSource = data2.Tables[0];

                query = "select * from productofactura where idfactura='" + idTicketBox.Text + "';";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
                add.Fill(data2);
                ticketGrid.DataSource = data2.Tables[0];

            }
            else
            {
                MessageBox.Show("Error Verifica los Datos Porfavor", "Error De Comparacion", MessageBoxButtons.OK);
            }

        }

        private void idTicketBox_Leave(object sender, EventArgs e)
        {
            if (idTicketBox.Text == "")
            {
                idTicketBox.Text = "ID de Factura";
            }
        }

        private void idProduct_Leave(object sender, EventArgs e)
        {
            if (idProduct.Text == "")
            {
                idProduct.Text = "ID Producto";
            }
        }

        private void EmployForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void idErrorBox_Click(object sender, EventArgs e)
        {
            if (idErrorBox.Text == "Buscar Error por ID")
            {
                idErrorBox.Text = "";
            }
        }

        private void idErrorBox_Leave(object sender, EventArgs e)
        {
            if (idErrorBox.Text == "")
            {
                idErrorBox.Text = "Buscar Error por ID";
            }
        }

        private void idErrorBox_TextChanged(object sender, EventArgs e)
        {
            if (idErrorBox.Text != "" && idErrorBox.Text != "Buscar Error por ID")
            {
                dataError.Clear();
                errorGrid.DataSource = dataError.Tables[0];

                errorQuery = "SELECT * FROM errorescliente WHERE codigoempacador='" + nip + "' AND iderror LIKE '" + idErrorBox.Text + "%';";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(errorQuery, con);
                add.Fill(dataError);
                errorGrid.DataSource = dataError.Tables[0];
            }
            else if (idErrorBox.Text == "" || idErrorBox.Text == "Buscar Error por ID")
            {
                dataError.Clear();
                errorGrid.DataSource = dataError.Tables[0];

                errorQuery = "SELECT * FROM errorescliente WHERE codigoempacador='" + nip + "';";
                NpgsqlDataAdapter addTicket = new NpgsqlDataAdapter(errorQuery, con);
                addTicket.Fill(dataError);
                errorGrid.DataSource = dataError.Tables[0];
            }
        }
    }
}
///Hecho por Cristopher Sinhue Estrada PAnduro Todos los Derechos Reservado