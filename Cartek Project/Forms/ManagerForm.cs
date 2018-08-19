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
    public partial class ManagerForm : MaterialForm
    {

        string query = "";
        string ticketQuery = "";
        string productQuery = "";
        string errorQuery = "";
        string controlQuery = "";

        string tipoError = "Faltante";

        string name = "";
        string address = "";
        string genre = "H";
        string laboral = "";
        string nip = "";
        string password = "";
        string date = "";
        string curp = "";
        string distribution = "";

        string numberTicket = "";
        string clientNameTicket = "";
        string destinyTicket = "";
        string originTicket = "";
        string routeTicket = "";
        string dateTicket = "";
        string lineTicket = "";
        string pieceTicket = "";
        double finalPrice = 0;
        string status = "";
        double parcialPrice = 0;


        DataSet data = new DataSet();
        DataSet dataTicket = new DataSet();
        DataSet dataProduct = new DataSet();
        DataSet dataError = new DataSet();
        DataSet dataControl = new DataSet();

        NpgsqlConnection con = new NpgsqlConnection();

        public ManagerForm(string parametros)
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

            query = "SELECT * FROM empacador;";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(data);
            employGrid.DataSource = data.Tables[0];

            ticketQuery = "SELECT * FROM facturas;";
            NpgsqlDataAdapter addTicket = new NpgsqlDataAdapter(ticketQuery, con);
            addTicket.Fill(dataTicket);
            ticketGrid.DataSource = dataTicket.Tables[0];

            productQuery = "SELECT * FROM producto;";
            NpgsqlDataAdapter addProduct = new NpgsqlDataAdapter(productQuery, con);
            addProduct.Fill(dataProduct);
            productGrid.DataSource = dataProduct.Tables[0];

            errorQuery = "SELECT * FROM errorescliente;";
            NpgsqlDataAdapter addError = new NpgsqlDataAdapter(errorQuery, con);
            addError.Fill(dataError);
            errorGrid.DataSource = dataError.Tables[0];

            Calificacion();

        }

        private void manCheck_CheckedChanged(object sender, EventArgs e)
        {
            genre = "H";
        }

        private void womenChheck_CheckedChanged(object sender, EventArgs e)
        {
            genre = "M";
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text != "" && searchBox.Text != "Busqueda por NIP")
            {
                data.Clear();
                employGrid.DataSource = data.Tables[0];

                query = "SELECT * FROM empacador WHERE nippersonal LIKE '" + searchBox.Text + "%';";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
                add.Fill(data);
                employGrid.DataSource = data.Tables[0];
            }
            else if (searchBox.Text == "" || searchBox.Text == "Busqueda por NIP")
            {
                data.Clear();
                employGrid.DataSource = data.Tables[0];

                query = "SELECT * FROM empacador;";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
                add.Fill(data);
                employGrid.DataSource = data.Tables[0];
            }
        }

        private void searchTicketBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTicketBox.Text != "" && searchTicketBox.Text != "Busqueda por ID")
            {
                dataTicket.Clear();
                ticketGrid.DataSource = dataTicket.Tables[0];

                ticketQuery = "SELECT * FROM facturas WHERE numerofactura LIKE '" + searchTicketBox.Text + "%';";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(ticketQuery, con);
                add.Fill(dataTicket);
                ticketGrid.DataSource = dataTicket.Tables[0];
            }
            else if (searchTicketBox.Text == "" || searchTicketBox.Text == "Busqueda por ID")
            {
                dataTicket.Clear();
                ticketGrid.DataSource = dataTicket.Tables[0];

                ticketQuery = "SELECT * FROM facturas;";
                NpgsqlDataAdapter addTicket = new NpgsqlDataAdapter(ticketQuery, con);
                addTicket.Fill(dataTicket);
                ticketGrid.DataSource = dataTicket.Tables[0];
            }
        }

        private void addEmployButton_Click(object sender, EventArgs e)
        {
            name = nameBox.Text;
            address = addressBox.Text;
            nip = nipBox.Text;
            password = passwordBox.Text;
            date = dateBox.Text;
            curp = curpBox.Text;
            distribution = operatorBox.Text;
            laboral = laboralBox.Text;
            insertReg(name, date, address, nip, password, genre, curp, distribution, laboral);

            data.Clear();
            employGrid.DataSource = data.Tables[0];

            query = "SELECT * FROM empacador";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(data);
            employGrid.DataSource = data.Tables[0];

            dataControl.Clear();
            controlGrid.DataSource = dataControl.Tables[0];

            controlQuery = "SELECT * FROM promedio;";
            NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(controlQuery, con);
            add2.Fill(dataControl);
            controlGrid.DataSource = dataControl.Tables[0];
        }
        private void insertReg(string name, string dateE, string address, string nip, string password, string genre, string curp, string distribution, string laboral)
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("INSERT INTO empacador(nombre,fechaexpedicionlaboral,direccion,nippersonal,contraseña,genero,erroresdecliente,renglonesempacados,curp,operadora,puesto) " +
                    "VALUES ('" + name + "','" + dateE + "','" + address + "'," + nip + ",'" + password + "','" + genre + "'," + 0 + "," + 0 + ",'" + curp + "','" + distribution + "','" + laboral + "');", con);
                comando.ExecuteNonQuery();

                NpgsqlCommand comando2 = new NpgsqlCommand("INSERT INTO promedio(idempleado,nombre) " +
                    "VALUES ('" + nip + "','" + name + "');", con);
                comando2.ExecuteNonQuery();


                nameBox.Text = "Nombre";
                addressBox.Text = "Direccion";
                nipBox.Text = "NIP de Empleado";
                passwordBox.Text = "Contraseña";
                dateBox.Text = "Fecha Inicio (dd/mm/yyyy)";
                curpBox.Text = "CURP";
                operatorBox.Text = "Operadora";
                laboralBox.Text = "Puesto Laboral";
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }
        private void eliminarReg()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("DELETE FROM empacador WHERE nippersonal='" + searchBox.Text.ToString() + "';", con);
                comando.ExecuteReader();

                NpgsqlCommand comando2 = new NpgsqlCommand("DELETE FROM promedio WHERE idempleado='" + searchBox.Text.ToString() + "';", con);
                comando2.ExecuteReader();

                searchBox.Text = "Busqueda por NIP";
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string idElim = searchBox.Text;

            eliminarReg();

            data.Clear();
            employGrid.DataSource = data.Tables[0];

            query = "SELECT * FROM empacador";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(data);
            employGrid.DataSource = data.Tables[0];

            controlQuery = "SELECT * FROM promedio;";
            NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(controlQuery, con);
            add2.Fill(dataControl);
            controlGrid.DataSource = dataControl.Tables[0];

        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            name = nameBox.Text;
            address = addressBox.Text;
            nip = nipBox.Text;
            password = passwordBox.Text;
            date = dateBox.Text;
            curp = curpBox.Text;
            distribution = operatorBox.Text;
            laboral = laboralBox.Text;
            modifyReg(name, date, address, nip, password, genre, curp, distribution, laboral);

            data.Clear();
            employGrid.DataSource = data.Tables[0];

            query = "SELECT * FROM empacador";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(data);
            employGrid.DataSource = data.Tables[0];

            dataControl.Clear();
            controlGrid.DataSource = dataControl.Tables[0];

            controlQuery = "SELECT * FROM promedio;";
            NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(controlQuery, con);
            add2.Fill(dataControl);
            controlGrid.DataSource = dataControl.Tables[0];
        }

        private void modifyReg(string name, string dateE, string address, string nip, string password, string genre, string curp, string distribution, string laboral)
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("UPDATE empacador SET nombre='" + name + "',fechaexpedicionlaboral='" + dateE + "',direccion='" + address + "',contraseña='" + password + "',genero='" + genre + "',erroresdecliente= " + 0 + ",renglonesempacados=" + 0 + ",curp= '" + curp + "',operadora='" + distribution + "',puesto='" + laboral + "' WHERE nippersonal='" + nip + "' ;", con);
                comando.ExecuteNonQuery();

                NpgsqlCommand comando2 = new NpgsqlCommand("UPDATE promedio SET nombre='" + name + "' WHERE idempleado='" + nip + "';", con);
                comando2.ExecuteNonQuery();

                nameBox.Text = "Nombre";
                addressBox.Text = "Direccion";
                nipBox.Text = "NIP de Empleado";
                passwordBox.Text = "Contraseña";
                dateBox.Text = "Fecha Inicio (dd/mm/yyyy)";
                curpBox.Text = "CURP";
                operatorBox.Text = "Operadora";
                laboralBox.Text = "Puesto Laboral";
                nipBox.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void modifyTicketButton_Click(object sender, EventArgs e)
        {
            numberTicket = ticketNumberBox.Text;
            clientNameTicket = clientNameTicketBox.Text;
            destinyTicket = destinyTicketBox.Text;
            originTicket = originTicketBox.Text;
            routeTicket = routeTicketBox.Text;
            dateTicket = dateTicketBox.Text;
            lineTicket = linesTicketBox.Text;
            pieceTicket = pieceTicketBox.Text;
            finalPrice = Convert.ToDouble(parcialPriceBox.Text) + (Convert.ToDouble(parcialPriceBox.Text) * .15);
            status = statusTicketBox.Text;
            parcialPrice = Convert.ToDouble(parcialPriceBox.Text);

            modifyTicketReg();

            dataTicket.Clear();
            ticketGrid.DataSource = dataTicket.Tables[0];

            ticketQuery = "SELECT * FROM facturas";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(ticketQuery, con);
            add.Fill(dataTicket);
            ticketGrid.DataSource = dataTicket.Tables[0];

        }

        private void modifyTicketReg()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("UPDATE facturas SET numerofactura='" + numberTicket + "',nombrecliente='" + clientNameTicket + "',direcciondestino='" + destinyTicket + "',direccionsalida='" + originTicket + "',rutaenvio= '" + routeTicket + "',fechafacturacion='" + dateTicket + "',numerorenglones=" + lineTicket + ",lineaspiezas=" + pieceTicket + ",costoparcial=" + parcialPrice + ",iva= " + .15 + ",costototal=" + finalPrice + ",statuspedido= '" + status + "' ;", con);
                comando.ExecuteNonQuery();

                ticketNumberBox.Text = "Numero Factura";
                clientNameTicketBox.Text = "Nombre de Cliente";
                destinyTicketBox.Text = "Direccion Destino";
                originTicketBox.Text = "Direccion Origen";
                routeTicketBox.Text = "Ruta";
                dateTicketBox.Text = "Fecha Facturacion";
                linesTicketBox.Text = "Renglones";
                pieceTicketBox.Text = "Lineas Piezas";
                parcialPriceBox.Text = "Costo Parcial";
                finalPriceTicketBox.Text = "Costo Total";
                statusTicketBox.Text = "Status Pedido";

                ticketNumberBox.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void employGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = employGrid.CurrentRow;

            nameBox.Text = Convert.ToString(fila.Cells[0].Value);
            dateBox.Text = Convert.ToString(fila.Cells[1].Value);
            addressBox.Text = Convert.ToString(fila.Cells[2].Value);
            nipBox.Text = Convert.ToString(fila.Cells[3].Value);
            passwordBox.Text = Convert.ToString(fila.Cells[4].Value);
            curpBox.Text = Convert.ToString(fila.Cells[8].Value);
            operatorBox.Text = Convert.ToString(fila.Cells[9].Value);
            laboralBox.Text = Convert.ToString(fila.Cells[10].Value);

            searchBox.Text = Convert.ToString(fila.Cells[3].Value);

            nipBox.Enabled = true;

        }

        private void ticketGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = ticketGrid.CurrentRow;

            ticketNumberBox.Text = Convert.ToString(fila.Cells[0].Value);
            clientNameTicketBox.Text = Convert.ToString(fila.Cells[1].Value);
            destinyTicketBox.Text = Convert.ToString(fila.Cells[2].Value);
            originTicketBox.Text = Convert.ToString(fila.Cells[3].Value);
            routeTicketBox.Text = Convert.ToString(fila.Cells[4].Value);
            dateTicketBox.Text = Convert.ToString(fila.Cells[5].Value);
            linesTicketBox.Text = Convert.ToString(fila.Cells[6].Value);
            pieceTicketBox.Text = Convert.ToString(fila.Cells[7].Value);
            parcialPriceBox.Text = Convert.ToString(fila.Cells[8].Value);
            statusTicketBox.Text = Convert.ToString(fila.Cells[11].Value);
            finalPriceTicketBox.Text = Convert.ToString(Convert.ToDouble(parcialPriceBox.Text) + (Convert.ToDouble(parcialPriceBox.Text) * .15));

            searchTicketBox.Text = Convert.ToString(fila.Cells[0].Value);

            ticketNumberBox.Enabled = true;
            productButton.Enabled = true;
        }

        private void ticketButton_Click(object sender, EventArgs e)
        {
            numberTicket = ticketNumberBox.Text;
            clientNameTicket = clientNameTicketBox.Text;
            destinyTicket = destinyTicketBox.Text;
            originTicket = originTicketBox.Text;
            routeTicket = routeTicketBox.Text;
            dateTicket = dateTicketBox.Text;
            lineTicket = linesTicketBox.Text;
            pieceTicket = pieceTicketBox.Text;
            finalPrice = Convert.ToDouble(parcialPriceBox.Text) + (Convert.ToDouble(parcialPriceBox.Text) * .15);
            status = statusTicketBox.Text;
            parcialPrice = Convert.ToDouble(parcialPriceBox.Text);

            Producto ventanaProducto = new Producto(numberTicket, con.ConnectionString);
            ventanaProducto.ShowDialog();

            insertRegTicket();

            dataTicket.Clear();
            ticketGrid.DataSource = dataTicket.Tables[0];

            ticketQuery = "SELECT * FROM facturas";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(ticketQuery, con);
            add.Fill(dataTicket);
            ticketGrid.DataSource = dataTicket.Tables[0];

        }


        private void cleanDataButton_Click(object sender, EventArgs e)
        {
            ticketNumberBox.Text = "Numero Factura";
            clientNameTicketBox.Text = "Nombre de Cliente";
            destinyTicketBox.Text = "Direccion Destino";
            originTicketBox.Text = "Direccion Origen";
            routeTicketBox.Text = "Ruta";
            dateTicketBox.Text = "Fecha Facturacion";
            linesTicketBox.Text = "Renglones";
            pieceTicketBox.Text = "Lineas Piezas";
            parcialPriceBox.Text = "Costo Parcial";
            finalPriceTicketBox.Text = "Costo Total";
            statusTicketBox.Text = "Status Pedido";
            searchTicketBox.Text = "Busqueda por ID";

            ticketNumberBox.Enabled = true;
            productButton.Enabled = false;
        }


        private void cleanDataButtonE_Click(object sender, EventArgs e)
        {
            nameBox.Text = "Nombre";
            addressBox.Text = "Direccion";
            nipBox.Text = "NIP de Empleado";
            passwordBox.Text = "Contraseña";
            dateBox.Text = "Fecha Inicio (dd/mm/yyyy)";
            curpBox.Text = "CURP";
            operatorBox.Text = "Operadora";
            laboralBox.Text = "Puesto Laboral";
            searchBox.Text = "Busqueda por NIP";

            nipBox.Enabled = true;
        }

        private void insertRegTicket()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("INSERT INTO facturas(numerofactura,nombrecliente,direcciondestino,direccionsalida,rutaenvio,fechafacturacion,numerorenglones,lineaspiezas,costoparcial,iva,costototal,statuspedido) " +
                    "VALUES ('" + numberTicket + "','" + clientNameTicket + "','" + destinyTicket + "','" + originTicket + "','" + routeTicket + "','" + dateTicket + "'," + lineTicket + "," + pieceTicket + "," + parcialPrice + "," + .15 + "," + finalPrice + ",'" + status + "');", con);
                comando.ExecuteNonQuery();

                ticketNumberBox.Text = "Numero Factura";
                clientNameTicketBox.Text = "Nombre de Cliente";
                destinyTicketBox.Text = "Direccion Destino";
                originTicketBox.Text = "Direccion Origen";
                routeTicketBox.Text = "Ruta";
                dateTicketBox.Text = "Fecha Facturacion";
                linesTicketBox.Text = "Renglones";
                pieceTicketBox.Text = "Lineas Piezas";
                parcialPriceBox.Text = "Costo Parcial";
                finalPriceTicketBox.Text = "Costo Total";
                statusTicketBox.Text = "Status Pedido";
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void deleteTicketButton_Click(object sender, EventArgs e)
        {
            string idElim = searchTicketBox.Text;

            eliminarRegTicket();

            dataTicket.Clear();
            ticketGrid.DataSource = dataTicket.Tables[0];

            ticketQuery = "SELECT * FROM facturas";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(ticketQuery, con);
            add.Fill(dataTicket);
            ticketGrid.DataSource = dataTicket.Tables[0];

        }

        private void eliminarRegTicket()
        {
            try
            {

                NpgsqlCommand comando = new NpgsqlCommand("DELETE FROM facturas WHERE numerofactura='" + searchTicketBox.Text.ToString() + "';", con);
                comando.ExecuteReader();

                NpgsqlCommand comando2 = new NpgsqlCommand("DELETE FROM productofactura WHERE idfactura='" + searchTicketBox.Text.ToString() + "';", con);
                comando2.ExecuteReader();

                searchTicketBox.Text = "Busqueda por ID";
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void ticketNumberBox_Click(object sender, EventArgs e)
        {
            if (ticketNumberBox.Text == "Numero Factura")
            {
                ticketNumberBox.Text = "";
            }
        }

        private void clientNameTicketBox_Click(object sender, EventArgs e)
        {
            if (clientNameTicketBox.Text == "Nombre de Cliente")
            {
                clientNameTicketBox.Text = "";
            }
        }

        private void destinyTicketBox_Click(object sender, EventArgs e)
        {
            if (destinyTicketBox.Text == "Direccion Destino")
            {
                destinyTicketBox.Text = "";
            }
        }

        private void originTicketBox_Click(object sender, EventArgs e)
        {
            if (originTicketBox.Text == "Direccion Origen")
            {
                originTicketBox.Text = "";
            }
        }

        private void routeTicketBox_Click(object sender, EventArgs e)
        {
            if (routeTicketBox.Text == "Ruta")
            {
                routeTicketBox.Text = "";
            }
        }

        private void dateTicketBox_Click(object sender, EventArgs e)
        {
            if (dateTicketBox.Text == "Fecha Facturacion(dd/mm/yyyy)")
            {
                dateTicketBox.Text = "";
            }
        }

        private void linesTicketBox_Click(object sender, EventArgs e)
        {
            if (linesTicketBox.Text == "Renglones")
            {
                linesTicketBox.Text = "";
            }
        }

        private void pieceTicketBox_Click(object sender, EventArgs e)
        {
            if (pieceTicketBox.Text == "Lineas Piezas")
            {
                pieceTicketBox.Text = "";
            }
        }

        private void finalPriceTicketBox_Click(object sender, EventArgs e)
        {
            if (finalPriceTicketBox.Text == "Costo Total")
            {
                finalPriceTicketBox.Text = "";
            }
        }

        private void statusTicketBox_Click(object sender, EventArgs e)
        {
            if (statusTicketBox.Text == "Status Pedido")
            {
                statusTicketBox.Text = "";
            }
        }

        private void parcialPriceBox_Click(object sender, EventArgs e)
        {
            if (parcialPriceBox.Text == "Costo Parcial")
            {
                parcialPriceBox.Text = "";
            }
        }

        private void ticketNumberBox_Leave(object sender, EventArgs e)
        {
            if (ticketNumberBox.Text == "")
            {
                ticketNumberBox.Text = "Numero Factura";
            }
        }

        private void clientNameTicketBox_Leave(object sender, EventArgs e)
        {
            if (clientNameTicketBox.Text == "")
            {
                clientNameTicketBox.Text = "Nombre de Cliente";
            }
        }

        private void destinyTicketBox_Leave(object sender, EventArgs e)
        {
            if (destinyTicketBox.Text == "")
            {
                destinyTicketBox.Text = "Direccion Destino";
            }
        }

        private void originTicketBox_Leave(object sender, EventArgs e)
        {

        }

        private void routeTicketBox_Leave(object sender, EventArgs e)
        {
            if (routeTicketBox.Text == "")
            {
                routeTicketBox.Text = "Ruta";
            }
        }

        private void dateTicketBox_Leave(object sender, EventArgs e)
        {
            if (dateTicketBox.Text == "")
            {
                dateTicketBox.Text = "Fecha Facturacion(dd/mm/yyyy)";
            }
        }

        private void linesTicketBox_Leave(object sender, EventArgs e)
        {
            if (linesTicketBox.Text == "")
            {
                linesTicketBox.Text = "Renglones";
            }
        }

        private void pieceTicketBox_Leave(object sender, EventArgs e)
        {
            if (pieceTicketBox.Text == "")
            {
                pieceTicketBox.Text = "Lineas Piezas";
            }
        }

        private void parcialPriceBox_Leave(object sender, EventArgs e)
        {
            if (parcialPriceBox.Text == "")
            {
                parcialPriceBox.Text = "Costo Parcial";
            }
            else if (parcialPriceBox.Text != "")
            {
                double aux = 0;
                double iva = .15;
                aux = Convert.ToDouble(parcialPriceBox.Text) + (Convert.ToDouble(parcialPriceBox.Text) * iva);
                finalPriceTicketBox.Text = aux.ToString();
            }
        }

        private void finalPriceTicketBox_Leave(object sender, EventArgs e)
        {
            if (finalPriceTicketBox.Text == "")
            {
                finalPriceTicketBox.Text = "Costo Total";
            }
        }

        private void statusTicketBox_Leave(object sender, EventArgs e)
        {
            if (statusTicketBox.Text == "")
            {
                statusTicketBox.Text = "Status Pedido";
            }
        }

        private void searchTicketBox_Click(object sender, EventArgs e)
        {
            if (searchTicketBox.Text == "Busqueda por ID")
            {
                searchTicketBox.Text = "";
            }
        }

        private void searchTicketBox_Leave(object sender, EventArgs e)
        {
            if (searchTicketBox.Text == "")
            {
                searchTicketBox.Text = "Busqueda por ID";
            }
        }

        private void nipBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ticketNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dateTicketBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void linesTicketBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void pieceTicketBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void parcialPriceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void searchTicketBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar)
               || Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void nameBox_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "Nombre")
            {
                nameBox.Text = "";
            }
        }

        private void nameBox_Leave(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                nameBox.Text = "Nombre";
            }
        }

        private void addressBox_Click(object sender, EventArgs e)
        {
            if (addressBox.Text == "Direccion")
            {
                addressBox.Text = "";
            }
        }

        private void addressBox_Leave(object sender, EventArgs e)
        {
            if (addressBox.Text == "")
            {
                addressBox.Text = "Direccion";
            }
        }

        private void nipBox_Click(object sender, EventArgs e)
        {
            if (nipBox.Text == "NIP de Empleado")
            {
                nipBox.Text = "";
            }
        }

        private void nipBox_Leave(object sender, EventArgs e)
        {
            if (nipBox.Text == "")
            {
                nipBox.Text = "NIP de Empleado";
            }
            if (nipBox.Text == "" || nipBox.Text == "NIP de Empleado")
            {
                addEmployButton.Enabled = false;
            }
            else
            {
                addEmployButton.Enabled = true;
            }

        }

        private void passwordBox_Click(object sender, EventArgs e)
        {
            passwordBox.MaxLength = 16;
            passwordBox.PasswordChar = '*';
            if (passwordBox.Text == "Contraseña")
            {
                passwordBox.Text = "";
            }
        }

        private void passwordBox_Leave(object sender, EventArgs e)
        {
            if (passwordBox.Text == "")
            {
                passwordBox.Text = "Contraseña";
            }
        }

        private void dateBox_Click(object sender, EventArgs e)
        {
            if (dateBox.Text == "Fecha Inicio (dd/mm/yyyy)")
            {
                dateBox.Text = "";
            }
        }

        private void dateBox_Leave(object sender, EventArgs e)
        {
            if (dateBox.Text == "")
            {
                dateBox.Text = "Fecha Inicio (dd/mm/yyyy)";
            }
        }

        private void curpBox_Click(object sender, EventArgs e)
        {
            if (curpBox.Text == "CURP")
            {
                curpBox.Text = "";
            }
        }

        private void curpBox_Leave(object sender, EventArgs e)
        {
            if (curpBox.Text == "")
            {
                curpBox.Text = "CURP";
            }
        }

        private void laboralBox_Click(object sender, EventArgs e)
        {
            if (laboralBox.Text == "Puesto Laboral")
            {
                laboralBox.Text = "";
            }
        }

        private void laboralBox_Leave(object sender, EventArgs e)
        {
            if (laboralBox.Text == "")
            {
                laboralBox.Text = "Puesto Laboral";
            }
        }

        private void operatorBox_Click(object sender, EventArgs e)
        {
            if (operatorBox.Text == "Operadora")
            {
                operatorBox.Text = "";
            }
        }

        private void operatorBox_Leave(object sender, EventArgs e)
        {
            if (operatorBox.Text == "")
            {
                operatorBox.Text = "Operadora";
            }
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            if (searchBox.Text == "Busqueda por NIP")
            {
                searchBox.Text = "";
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = "Busqueda por NIP";
            }
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            Producto ventanaProducto = new Producto(ticketNumberBox.Text, con.ConnectionString);
            ventanaProducto.ShowDialog();

            dataProduct.Clear();
            productGrid.DataSource = dataProduct.Tables[0];

            productQuery = "SELECT * FROM producto";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(productQuery, con);
            add.Fill(dataProduct);
            productGrid.DataSource = dataProduct.Tables[0];
        }

        private void idProductBox_Click(object sender, EventArgs e)
        {
            if (idProductBox.Text == "Codigo Producto")
            {
                idProductBox.Text = "";
            }
        }

        private void productNameBox_Click(object sender, EventArgs e)
        {
            if (productNameBox.Text == "Nombre del Producto")
            {
                productNameBox.Text = "";
            }
        }

        private void priceProductBox_Click(object sender, EventArgs e)
        {
            if (priceProductBox.Text == "Precio")
            {
                priceProductBox.Text = "";
            }
        }

        private void categoryProductBox_Click(object sender, EventArgs e)
        {
            if (categoryProductBox.Text == "Categoria")
            {
                categoryProductBox.Text = "";
            }
        }

        private void searchProductBox_Click(object sender, EventArgs e)
        {
            if (searchProductBox.Text == "Buscar Producto")
            {
                searchProductBox.Text = "";
            }
        }

        private void idProductBox_Leave(object sender, EventArgs e)
        {
            if (idProductBox.Text == "")
            {
                idProductBox.Text = "Codigo Producto";
            }
        }

        private void productNameBox_Leave(object sender, EventArgs e)
        {
            if (productNameBox.Text == "")
            {
                productNameBox.Text = "Nombre del Producto";
            }
        }

        private void priceProductBox_Leave(object sender, EventArgs e)
        {
            if (priceProductBox.Text == "")
            {
                priceProductBox.Text = "Precio";
            }
        }

        private void categoryProductBox_Leave(object sender, EventArgs e)
        {
            if (categoryProductBox.Text == "")
            {
                categoryProductBox.Text = "Categoria";
            }
        }

        private void searchProductBox_Leave(object sender, EventArgs e)
        {
            if (searchProductBox.Text == "")
            {
                searchProductBox.Text = "Buscar Producto";
            }
        }

        private void searchProductBox_TextChanged(object sender, EventArgs e)
        {
            if (searchProductBox.Text != "" && searchProductBox.Text != "Buscar Producto")
            {
                dataProduct.Clear();
                productGrid.DataSource = dataProduct.Tables[0];

                productQuery = "SELECT * FROM producto WHERE codigo LIKE '" + searchProductBox.Text + "%';";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(productQuery, con);
                add.Fill(dataProduct);
                productGrid.DataSource = dataProduct.Tables[0];
            }
            else if (searchProductBox.Text == "" || searchProductBox.Text == "Buscar Producto")
            {
                dataProduct.Clear();
                productGrid.DataSource = dataProduct.Tables[0];

                productQuery = "SELECT * FROM producto;";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(productQuery, con);
                add.Fill(dataProduct);
                productGrid.DataSource = dataProduct.Tables[0];
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {

            addProduct();

            dataProduct.Clear();
            productGrid.DataSource = dataProduct.Tables[0];

            productQuery = "SELECT * FROM producto";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(productQuery, con);
            add.Fill(dataProduct);
            productGrid.DataSource = dataProduct.Tables[0];
        }
        private void addProduct()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("INSERT INTO producto" +
                    "VALUES ('" + idProductBox.Text + "'," + Convert.ToDouble(numericBox.Value) + ",'" + productNameBox.Text + "'," + Convert.ToDouble(priceProductBox.Text) + ",'" + categoryProductBox.Text + "');", con);
                comando.ExecuteNonQuery();

                idProductBox.Text = "Codigo Producto";
                productNameBox.Text = "Nombre del Producto";
                priceProductBox.Text = "Precio";
                categoryProductBox.Text = "Categoria";
                numericBox.Value = 1;
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }
        private void deleteProductButton_Click(object sender, EventArgs e)
        {

            deleteProduct();

            dataProduct.Clear();
            productGrid.DataSource = dataProduct.Tables[0];

            productQuery = "SELECT * FROM producto";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(productQuery, con);
            add.Fill(dataProduct);
            productGrid.DataSource = dataProduct.Tables[0];

        }

        private void deleteProduct()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("DELETE FROM producto WHERE codigo='" + searchProductBox.Text.ToString() + "';", con);
                comando.ExecuteReader();

                NpgsqlCommand comando2 = new NpgsqlCommand("DELETE FROM productofactura WHERE idproducto='" + searchProductBox.Text.ToString() + "';", con);
                comando2.ExecuteReader();

                searchProductBox.Text = "Buscar Producto";
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void modifyProductButton_Click(object sender, EventArgs e)
        {
            modifyProduct();

            dataProduct.Clear();
            productGrid.DataSource = dataProduct.Tables[0];

            productQuery = "SELECT * FROM producto";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(productQuery, con);
            add.Fill(dataProduct);
            productGrid.DataSource = dataProduct.Tables[0];
        }

        private void modifyProduct()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("UPDATE producto SET codigo='" + idProductBox.Text + "',cantidad=" + Convert.ToDouble(numericBox.Value) + ",nombre='" + productNameBox.Text + "',precio=" + Convert.ToDouble(priceProductBox.Text) + ",categoria='" + categoryProductBox.Text + "' WHERE codigo='" + searchProductBox.Text + "' ;", con);
                comando.ExecuteNonQuery();

                idProductBox.Text = "Codigo Producto";
                productNameBox.Text = "Nombre del Producto";
                priceProductBox.Text = "Precio";
                categoryProductBox.Text = "Categoria";
                numericBox.Value = 1;
                idProductBox.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }
        private void cleanProductButton_Click(object sender, EventArgs e)
        {
            idProductBox.Text = "Codigo Producto";
            productNameBox.Text = "Nombre del Producto";
            categoryProductBox.Text = "Categoria";
            priceProductBox.Text = "Precio";
            searchProductBox.Text = "Buscar Producto";

            numericBox.Value = 1;

            idProductBox.Enabled = true;
        }

        private void productGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = productGrid.CurrentRow;

            idProductBox.Text = Convert.ToString(fila.Cells[0].Value);
            numericBox.Value = Convert.ToDecimal(fila.Cells[1].Value);
            productNameBox.Text = Convert.ToString(fila.Cells[2].Value);
            priceProductBox.Text = Convert.ToString(fila.Cells[3].Value);
            categoryProductBox.Text = Convert.ToString(fila.Cells[4].Value);

            searchProductBox.Text = Convert.ToString(fila.Cells[0].Value);

            idProductBox.Enabled = false;
        }

        private void idErrorBox_Click(object sender, EventArgs e)
        {
            if (idErrorBox.Text == "Numero de Reporte")
            {
                idErrorBox.Text = "";
            }
        }

        private void clientNameBox_Click(object sender, EventArgs e)
        {
            if (clientNameBox.Text == "Nombre del Cliente")
            {
                clientNameBox.Text = "";
            }
        }

        private void addressClientBox_Click(object sender, EventArgs e)
        {
            if (addressClientBox.Text == "Direccion de Cliente")
            {
                addressClientBox.Text = "";
            }
        }

        private void packerBox_Click(object sender, EventArgs e)
        {
            if (packerBox.Text == "Paqueteria")
            {
                packerBox.Text = "";
            }
        }

        private void employNameBox_Click(object sender, EventArgs e)
        {
            if (employNameBox.Text == "Nombre de Empacador")
            {
                employNameBox.Text = "";
            }
        }

        private void dateErrorBox_Click(object sender, EventArgs e)
        {
            if (dateErrorBox.Text == "Fecha de Reclamacion")
            {
                dateErrorBox.Text = "";
            }
        }

        private void dateSendBox_Click(object sender, EventArgs e)
        {
            if (dateSendBox.Text == "Fecha de Salida")
            {
                dateSendBox.Text = "";
            }
        }

        private void descriptionBox_Click(object sender, EventArgs e)
        {
            if (descriptionBox.Text == "Descripcion")
            {
                descriptionBox.Text = "";
            }
        }

        private void idErrorBox_Leave(object sender, EventArgs e)
        {
            if (idErrorBox.Text == "")
            {
                idErrorBox.Text = "Numero de Reporte";
            }
        }

        private void clientNameBox_Leave(object sender, EventArgs e)
        {
            if (clientNameBox.Text == "")
            {
                clientNameBox.Text = "Nombre del Cliente";
            }
        }

        private void addressClientBox_Leave(object sender, EventArgs e)
        {
            if (addressClientBox.Text == "")
            {
                addressClientBox.Text = "Direccion de Cliente";
            }
        }

        private void packerBox_Leave(object sender, EventArgs e)
        {
            if (packerBox.Text == "")
            {
                packerBox.Text = "Paqueteria";
            }
        }

        private void employNameBox_Leave(object sender, EventArgs e)
        {
            if (employNameBox.Text == "")
            {
                employNameBox.Text = "Nombre de Empacador";
            }
        }

        private void dateErrorBox_Leave(object sender, EventArgs e)
        {
            if (dateErrorBox.Text == "")
            {
                dateErrorBox.Text = "Fecha de Reclamacion";
            }
        }

        private void dateSendBox_Leave(object sender, EventArgs e)
        {
            if (dateSendBox.Text == "")
            {
                dateSendBox.Text = "Fecha de Salida";
            }
        }

        private void descriptionBox_Leave(object sender, EventArgs e)
        {
            if (descriptionBox.Text == "")
            {
                descriptionBox.Text = "Descripcion";
            }
        }

        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void missButton_CheckedChanged(object sender, EventArgs e)
        {
            tipoError = "Faltante";
        }

        private void changeButton_CheckedChanged(object sender, EventArgs e)
        {
            tipoError = "Cambiado";
        }

        private void overButton_CheckedChanged(object sender, EventArgs e)
        {
            tipoError = "Sobrante";
        }

        private void searchErrorBox_Click(object sender, EventArgs e)
        {
            if (searchErrorBox.Text == "Buscar Error")
            {
                searchErrorBox.Text = "";
            }
        }

        private void searchErrorBox_Leave(object sender, EventArgs e)
        {
            if (searchErrorBox.Text == "")
            {
                searchErrorBox.Text = "Buscar Error";
            }
        }

        private void addErrorButton_Click(object sender, EventArgs e)
        {
            addError();

            dataError.Clear();
            errorGrid.DataSource = dataError.Tables[0];

            errorQuery = "SELECT * FROM errorescliente";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(errorQuery, con);
            add.Fill(dataError);
            errorGrid.DataSource = dataError.Tables[0];

            dataControl.Clear();
            controlGrid.DataSource = dataControl.Tables[0];

            controlQuery = "SELECT * FROM promedio;";
            NpgsqlDataAdapter add2 = new NpgsqlDataAdapter(controlQuery, con);
            add2.Fill(dataControl);
            controlGrid.DataSource = dataControl.Tables[0];


        }

        private void addError()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("INSERT INTO errorescliente " +
                    "VALUES('" + idErrorBox.Text + "','" + clientNameBox.Text + "','" + tipoError + "','" + addressClientBox.Text + "','" + packerBox.Text + "','" + idEmployBox.Text + "','" + employNameBox.Text + "'," + numError.Value + ",'" + dateErrorBox.Text + "','" + dateSendBox.Text + "','" + descriptionBox.Text + "');", con);
                comando.ExecuteNonQuery();

                NpgsqlCommand comando2 = new NpgsqlCommand("UPDATE promedio SET errores=errores + 1 WHERE idempleado='" + idEmployBox.Text + "';", con);
                comando2.ExecuteNonQuery();

                idErrorBox.Text = "Numero de Reporte";
                clientNameBox.Text = "Nombre del Cliente";
                addressClientBox.Text = "Direccion de Cliente";
                packerBox.Text = "Paqueteria";
                idEmployBox.Text = "Codigo Empacador";
                employNameBox.Text = "Nombre de Empacador";
                numError.Value = 1;
                dateErrorBox.Text = "Fecha de Reclamacion";
                dateSendBox.Text = "Fecha de Salida";
                descriptionBox.Text = "Descripcion";

            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void idEmployBox_Click(object sender, EventArgs e)
        {
            if (idEmployBox.Text == "Codigo Empacador")
            {
                idEmployBox.Text = "";
            }
        }

        private void idEmployBox_Leave(object sender, EventArgs e)
        {
            if (idEmployBox.Text == "")
            {
                idEmployBox.Text = "Codigo Empacador";
            }
        }

        private void deleteErrorButton_Click(object sender, EventArgs e)
        {
            deleteError();

            dataError.Clear();
            errorGrid.DataSource = dataError.Tables[0];

            errorQuery = "SELECT * FROM errorescliente";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(errorQuery, con);
            add.Fill(dataError);
            errorGrid.DataSource = dataError.Tables[0];
        }

        private void deleteError()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("DELETE FROM errorescliente WHERE iderror='" + searchErrorBox.Text.ToString() + "';", con);
                comando.ExecuteReader();

                searchProductBox.Text = "Buscar Error";
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void errorGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = errorGrid.CurrentRow;

            idErrorBox.Text = Convert.ToString(fila.Cells[0].Value);
            clientNameBox.Text = Convert.ToString(fila.Cells[1].Value);
            if (Convert.ToString(fila.Cells[2].Value) == "Faltante")
            {
                missButton.Select();
            }
            if (Convert.ToString(fila.Cells[2].Value) == "Sobrante")
            {
                overButton.Select();
            }
            if (Convert.ToString(fila.Cells[2].Value) == "Cambiado")
            {
                changeButton.Select();
            }
            addressClientBox.Text = Convert.ToString(fila.Cells[3].Value);
            packerBox.Text = Convert.ToString(fila.Cells[4].Value);
            idEmployBox.Text = Convert.ToString(fila.Cells[5].Value);
            employNameBox.Text = Convert.ToString(fila.Cells[6].Value);
            numError.Value = Convert.ToDecimal(fila.Cells[7].Value);
            dateErrorBox.Text = Convert.ToString(fila.Cells[8].Value);
            dateSendBox.Text = Convert.ToString(fila.Cells[9].Value);
            descriptionBox.Text = Convert.ToString(fila.Cells[10].Value);

            searchErrorBox.Text = Convert.ToString(fila.Cells[0].Value);

            idErrorBox.Enabled = false;
        }

        private void modifyErrorButton_Click(object sender, EventArgs e)
        {
            modifyError();

            dataError.Clear();
            errorGrid.DataSource = dataError.Tables[0];

            errorQuery = "SELECT * FROM errorescliente";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(errorQuery, con);
            add.Fill(dataError);
            errorGrid.DataSource = dataError.Tables[0];
        }

        private void modifyError()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("UPDATE errorescliente SET nombrecliente='" + clientNameBox.Text + "',tipoerror='" + tipoError + "',direccioncliente='" + addressClientBox.Text + "',paqueteria='" + packerBox.Text + "',codigoempacador='" + idEmployBox.Text + "',nombreempacador='" + employNameBox.Text + "',cantidad=" + numError.Value + ",fechareporte='" + dateErrorBox.Text + "',fechasalida='" + dateSendBox.Text + "',descripcion='" + descriptionBox.Text + "' WHERE iderror='" + searchErrorBox.Text + "' ;", con);
                comando.ExecuteNonQuery();

                idErrorBox.Text = "Numero de Reporte";
                clientNameBox.Text = "Nombre del Cliente";
                addressClientBox.Text = "Direccion de Cliente";
                packerBox.Text = "Paqueteria";
                idEmployBox.Text = "Codigo Empacador";
                employNameBox.Text = "Nombre de Empacador";
                numError.Value = 1;
                dateErrorBox.Text = "Fecha de Reclamacion";
                dateSendBox.Text = "Fecha de Salida";
                descriptionBox.Text = "Descripcion";
                idErrorBox.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
        }

        private void cleanErrorButton_Click(object sender, EventArgs e)
        {
            idErrorBox.Text = "Numero de Reporte";
            clientNameBox.Text = "Nombre del Cliente";
            addressClientBox.Text = "Direccion de Cliente";
            packerBox.Text = "Paqueteria";
            idEmployBox.Text = "Codigo Empacador";
            employNameBox.Text = "Nombre de Empacador";
            numError.Value = 1;
            tipoError = "Faltante";
            missButton.Select();
            dateErrorBox.Text = "Fecha de Reclamacion";
            dateSendBox.Text = "Fecha de Salida";
            descriptionBox.Text = "Descripcion";

            searchErrorBox.Text = "Buscar Error";

            idErrorBox.Enabled = true;
        }

        private void idEmployControlBox_Click(object sender, EventArgs e)
        {
            if (idEmployControlBox.Text == "Codigo Empleado")
            {
                idEmployControlBox.Text = "";
            }
        }

        private void idEmployControlBox_Leave(object sender, EventArgs e)
        {
            if (idEmployControlBox.Text == "")
            {
                idEmployControlBox.Text = "Codigo Empleado";
            }
        }

        private void idEmployControlBox_TextChanged(object sender, EventArgs e)
        {
            if (idEmployControlBox.Text != "" && idEmployControlBox.Text != "Codigo Empleado")
            {
                dataControl.Clear();
                controlGrid.DataSource = dataControl.Tables[0];

                controlQuery = "SELECT * FROM promedio WHERE idempleado LIKE '" + idEmployControlBox.Text + "%';";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(controlQuery, con);
                add.Fill(dataControl);
                controlGrid.DataSource = dataControl.Tables[0];
            }
            else if (idEmployControlBox.Text == "" || idEmployControlBox.Text == "Codigo Empleado")
            {
                dataControl.Clear();
                controlGrid.DataSource = dataControl.Tables[0];

                controlQuery = "SELECT * FROM promedio;";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(controlQuery, con);
                add.Fill(dataControl);
                controlGrid.DataSource = dataControl.Tables[0];
            }
        }

        private void controlGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = controlGrid.CurrentRow;

            idEmployControlBox.Text = Convert.ToString(fila.Cells[0].Value);
            nameControlBox.Text = Convert.ToString(fila.Cells[1].Value);
            lineControlBox.Text = Convert.ToString(fila.Cells[2].Value);
            ticketControlBox.Text = Convert.ToString(fila.Cells[3].Value);
            errorControlBox.Text = Convert.ToString(fila.Cells[4].Value);
            totalControlBox.Text = Convert.ToString(fila.Cells[5].Value);


            bonoControlBox.Enabled = true;
            addBonoButton.Enabled = true;
        }

        private void addBonoButton_Click(object sender, EventArgs e)
        {
            bonoControlBox.Enabled = false;
            addBonoButton.Enabled = false;

            bonoControlBox.Text = "Bono";

            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("UPDATE promedio SET bono = bono + " + bonoControlBox.Text + " WHERE idempleado='" + idEmployControlBox.Text + "' ;", con);
                comando.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
            dataControl.Clear();
            controlGrid.DataSource = dataControl.Tables[0];

            controlQuery = "SELECT * FROM promedio;";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(controlQuery, con);
            add.Fill(dataControl);
            controlGrid.DataSource = dataControl.Tables[0];
        }

        private void bonoControlBox_Click(object sender, EventArgs e)
        {
            if (bonoControlBox.Text == "Bono")
            {
                bonoControlBox.Text = "";
            }
        }

        private void cleanControlButton_Click(object sender, EventArgs e)
        {
            idEmployControlBox.Text = "Codigo Empleado";
            nameControlBox.Text = "Nombre Empleado";
            lineControlBox.Text = "Renglones";
            ticketControlBox.Text = "Facturas";
            errorControlBox.Text = "Errores";
            totalControlBox.Text = "Calificacion";

            bonoControlBox.Text = "Bono";
            addBonoButton.Enabled = false;
            idEmployControlBox.Enabled = true;
            bonoControlBox.Enabled = false;
        }
        private void Calificacion()
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand("UPDATE promedio SET calificacion='C' WHERE renglon<=3;", con);
                comando.ExecuteReader();

                NpgsqlCommand comando2 = new NpgsqlCommand("UPDATE promedio SET calificacion='B' WHERE renglon<=6 AND renglon>3;", con);
                comando2.ExecuteReader();

                NpgsqlCommand comando3 = new NpgsqlCommand("UPDATE promedio SET calificacion='A' WHERE renglon>7;", con);
                comando3.ExecuteReader();
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR:" + error.Message);
            }
            controlQuery = "SELECT * FROM promedio;";
            NpgsqlDataAdapter addControl = new NpgsqlDataAdapter(controlQuery, con);
            addControl.Fill(dataControl);
            controlGrid.DataSource = dataControl.Tables[0];
        }
    }
}

///Hecho por Cristopher Sinhue Estrada PAnduro Todos los Derechos Reservado