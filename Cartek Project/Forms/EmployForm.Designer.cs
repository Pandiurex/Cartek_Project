namespace Cartek_Project
{
    partial class EmployForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.registros = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.workTicketButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.addProductButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.productNum = new System.Windows.Forms.NumericUpDown();
            this.idProduct = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.productGrid = new System.Windows.Forms.DataGridView();
            this.idTicketBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ticketGrid = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.passwordBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.addressBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lineBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.errorBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.genreBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.laboralBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.operatorBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.curpBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.nipBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.dateBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.nameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.idErrorBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.errorGrid = new System.Windows.Forms.DataGridView();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 62);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(867, 40);
            this.materialTabSelector1.TabIndex = 0;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 108);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(823, 313);
            this.materialTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.registros);
            this.tabPage1.Controls.Add(this.workTicketButton);
            this.tabPage1.Controls.Add(this.addProductButton);
            this.tabPage1.Controls.Add(this.productNum);
            this.tabPage1.Controls.Add(this.idProduct);
            this.tabPage1.Controls.Add(this.productGrid);
            this.tabPage1.Controls.Add(this.idTicketBox);
            this.tabPage1.Controls.Add(this.ticketGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(815, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Facturas";
            // 
            // registros
            // 
            this.registros.Depth = 0;
            this.registros.Enabled = false;
            this.registros.Hint = "";
            this.registros.Location = new System.Drawing.Point(247, 138);
            this.registros.MaxLength = 32767;
            this.registros.MouseState = MaterialSkin.MouseState.HOVER;
            this.registros.Name = "registros";
            this.registros.PasswordChar = '\0';
            this.registros.SelectedText = "";
            this.registros.SelectionLength = 0;
            this.registros.SelectionStart = 0;
            this.registros.Size = new System.Drawing.Size(90, 23);
            this.registros.TabIndex = 7;
            this.registros.TabStop = false;
            this.registros.Text = "Registros";
            this.registros.UseSystemPasswordChar = false;
            // 
            // workTicketButton
            // 
            this.workTicketButton.AutoSize = true;
            this.workTicketButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.workTicketButton.Depth = 0;
            this.workTicketButton.Icon = null;
            this.workTicketButton.Location = new System.Drawing.Point(55, 166);
            this.workTicketButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.workTicketButton.Name = "workTicketButton";
            this.workTicketButton.Primary = true;
            this.workTicketButton.Size = new System.Drawing.Size(154, 36);
            this.workTicketButton.TabIndex = 6;
            this.workTicketButton.Text = "Trabajar Factura";
            this.workTicketButton.UseVisualStyleBackColor = true;
            this.workTicketButton.Click += new System.EventHandler(this.workTicketButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.AutoSize = true;
            this.addProductButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addProductButton.Depth = 0;
            this.addProductButton.Enabled = false;
            this.addProductButton.Icon = null;
            this.addProductButton.Location = new System.Drawing.Point(397, 208);
            this.addProductButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Primary = true;
            this.addProductButton.Size = new System.Drawing.Size(83, 36);
            this.addProductButton.TabIndex = 5;
            this.addProductButton.Text = "Agregar";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // productNum
            // 
            this.productNum.Enabled = false;
            this.productNum.Location = new System.Drawing.Point(399, 173);
            this.productNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.productNum.Name = "productNum";
            this.productNum.Size = new System.Drawing.Size(81, 20);
            this.productNum.TabIndex = 4;
            this.productNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // idProduct
            // 
            this.idProduct.Depth = 0;
            this.idProduct.Enabled = false;
            this.idProduct.Hint = "";
            this.idProduct.Location = new System.Drawing.Point(375, 138);
            this.idProduct.MaxLength = 32767;
            this.idProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.idProduct.Name = "idProduct";
            this.idProduct.PasswordChar = '\0';
            this.idProduct.SelectedText = "";
            this.idProduct.SelectionLength = 0;
            this.idProduct.SelectionStart = 0;
            this.idProduct.Size = new System.Drawing.Size(146, 23);
            this.idProduct.TabIndex = 3;
            this.idProduct.TabStop = false;
            this.idProduct.Text = "ID Producto";
            this.idProduct.UseSystemPasswordChar = false;
            this.idProduct.Click += new System.EventHandler(this.idProduct_Click);
            this.idProduct.Leave += new System.EventHandler(this.idProduct_Leave);
            // 
            // productGrid
            // 
            this.productGrid.BackgroundColor = System.Drawing.Color.White;
            this.productGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGrid.Location = new System.Drawing.Point(603, 0);
            this.productGrid.Name = "productGrid";
            this.productGrid.Size = new System.Drawing.Size(206, 263);
            this.productGrid.TabIndex = 2;
            // 
            // idTicketBox
            // 
            this.idTicketBox.Depth = 0;
            this.idTicketBox.Hint = "";
            this.idTicketBox.Location = new System.Drawing.Point(83, 137);
            this.idTicketBox.MaxLength = 10;
            this.idTicketBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.idTicketBox.Name = "idTicketBox";
            this.idTicketBox.PasswordChar = '\0';
            this.idTicketBox.SelectedText = "";
            this.idTicketBox.SelectionLength = 0;
            this.idTicketBox.SelectionStart = 0;
            this.idTicketBox.Size = new System.Drawing.Size(117, 23);
            this.idTicketBox.TabIndex = 1;
            this.idTicketBox.TabStop = false;
            this.idTicketBox.Text = "ID de Factura";
            this.idTicketBox.UseSystemPasswordChar = false;
            this.idTicketBox.Click += new System.EventHandler(this.idTicketBox_Click);
            this.idTicketBox.Leave += new System.EventHandler(this.idTicketBox_Leave);
            // 
            // ticketGrid
            // 
            this.ticketGrid.BackgroundColor = System.Drawing.Color.White;
            this.ticketGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ticketGrid.Location = new System.Drawing.Point(3, 3);
            this.ticketGrid.Name = "ticketGrid";
            this.ticketGrid.Size = new System.Drawing.Size(594, 129);
            this.ticketGrid.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.passwordBox);
            this.tabPage2.Controls.Add(this.addressBox);
            this.tabPage2.Controls.Add(this.lineBox);
            this.tabPage2.Controls.Add(this.errorBox);
            this.tabPage2.Controls.Add(this.genreBox);
            this.tabPage2.Controls.Add(this.laboralBox);
            this.tabPage2.Controls.Add(this.operatorBox);
            this.tabPage2.Controls.Add(this.curpBox);
            this.tabPage2.Controls.Add(this.nipBox);
            this.tabPage2.Controls.Add(this.dateBox);
            this.tabPage2.Controls.Add(this.nameBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(815, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mis Datos";
            // 
            // passwordBox
            // 
            this.passwordBox.Depth = 0;
            this.passwordBox.Enabled = false;
            this.passwordBox.Hint = "";
            this.passwordBox.Location = new System.Drawing.Point(446, 188);
            this.passwordBox.MaxLength = 32767;
            this.passwordBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '\0';
            this.passwordBox.SelectedText = "";
            this.passwordBox.SelectionLength = 0;
            this.passwordBox.SelectionStart = 0;
            this.passwordBox.Size = new System.Drawing.Size(207, 23);
            this.passwordBox.TabIndex = 10;
            this.passwordBox.TabStop = false;
            this.passwordBox.Text = "Contraseña";
            this.passwordBox.UseSystemPasswordChar = false;
            // 
            // addressBox
            // 
            this.addressBox.Depth = 0;
            this.addressBox.Enabled = false;
            this.addressBox.Hint = "";
            this.addressBox.Location = new System.Drawing.Point(579, 18);
            this.addressBox.MaxLength = 32767;
            this.addressBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.addressBox.Name = "addressBox";
            this.addressBox.PasswordChar = '\0';
            this.addressBox.SelectedText = "";
            this.addressBox.SelectionLength = 0;
            this.addressBox.SelectionStart = 0;
            this.addressBox.Size = new System.Drawing.Size(200, 23);
            this.addressBox.TabIndex = 9;
            this.addressBox.TabStop = false;
            this.addressBox.Text = "Direccion";
            this.addressBox.UseSystemPasswordChar = false;
            // 
            // lineBox
            // 
            this.lineBox.Depth = 0;
            this.lineBox.Enabled = false;
            this.lineBox.Hint = "";
            this.lineBox.Location = new System.Drawing.Point(579, 132);
            this.lineBox.MaxLength = 32767;
            this.lineBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.lineBox.Name = "lineBox";
            this.lineBox.PasswordChar = '\0';
            this.lineBox.SelectedText = "";
            this.lineBox.SelectionLength = 0;
            this.lineBox.SelectionStart = 0;
            this.lineBox.Size = new System.Drawing.Size(200, 23);
            this.lineBox.TabIndex = 8;
            this.lineBox.TabStop = false;
            this.lineBox.Text = "Renglones";
            this.lineBox.UseSystemPasswordChar = false;
            // 
            // errorBox
            // 
            this.errorBox.Depth = 0;
            this.errorBox.Enabled = false;
            this.errorBox.Hint = "";
            this.errorBox.Location = new System.Drawing.Point(278, 132);
            this.errorBox.MaxLength = 32767;
            this.errorBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.errorBox.Name = "errorBox";
            this.errorBox.PasswordChar = '\0';
            this.errorBox.SelectedText = "";
            this.errorBox.SelectionLength = 0;
            this.errorBox.SelectionStart = 0;
            this.errorBox.Size = new System.Drawing.Size(229, 23);
            this.errorBox.TabIndex = 7;
            this.errorBox.TabStop = false;
            this.errorBox.Text = "Error de Cliente";
            this.errorBox.UseSystemPasswordChar = false;
            // 
            // genreBox
            // 
            this.genreBox.Depth = 0;
            this.genreBox.Enabled = false;
            this.genreBox.Hint = "";
            this.genreBox.Location = new System.Drawing.Point(48, 132);
            this.genreBox.MaxLength = 32767;
            this.genreBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.genreBox.Name = "genreBox";
            this.genreBox.PasswordChar = '\0';
            this.genreBox.SelectedText = "";
            this.genreBox.SelectionLength = 0;
            this.genreBox.SelectionStart = 0;
            this.genreBox.Size = new System.Drawing.Size(125, 23);
            this.genreBox.TabIndex = 6;
            this.genreBox.TabStop = false;
            this.genreBox.Text = "Genero";
            this.genreBox.UseSystemPasswordChar = false;
            // 
            // laboralBox
            // 
            this.laboralBox.Depth = 0;
            this.laboralBox.Enabled = false;
            this.laboralBox.Hint = "";
            this.laboralBox.Location = new System.Drawing.Point(579, 69);
            this.laboralBox.MaxLength = 32767;
            this.laboralBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.laboralBox.Name = "laboralBox";
            this.laboralBox.PasswordChar = '\0';
            this.laboralBox.SelectedText = "";
            this.laboralBox.SelectionLength = 0;
            this.laboralBox.SelectionStart = 0;
            this.laboralBox.Size = new System.Drawing.Size(200, 23);
            this.laboralBox.TabIndex = 5;
            this.laboralBox.TabStop = false;
            this.laboralBox.Text = "Puesto";
            this.laboralBox.UseSystemPasswordChar = false;
            // 
            // operatorBox
            // 
            this.operatorBox.Depth = 0;
            this.operatorBox.Enabled = false;
            this.operatorBox.Hint = "";
            this.operatorBox.Location = new System.Drawing.Point(278, 69);
            this.operatorBox.MaxLength = 32767;
            this.operatorBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.operatorBox.Name = "operatorBox";
            this.operatorBox.PasswordChar = '\0';
            this.operatorBox.SelectedText = "";
            this.operatorBox.SelectionLength = 0;
            this.operatorBox.SelectionStart = 0;
            this.operatorBox.Size = new System.Drawing.Size(229, 23);
            this.operatorBox.TabIndex = 4;
            this.operatorBox.TabStop = false;
            this.operatorBox.Text = "Operadora";
            this.operatorBox.UseSystemPasswordChar = false;
            // 
            // curpBox
            // 
            this.curpBox.Depth = 0;
            this.curpBox.Enabled = false;
            this.curpBox.Hint = "";
            this.curpBox.Location = new System.Drawing.Point(20, 69);
            this.curpBox.MaxLength = 32767;
            this.curpBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.curpBox.Name = "curpBox";
            this.curpBox.PasswordChar = '\0';
            this.curpBox.SelectedText = "";
            this.curpBox.SelectionLength = 0;
            this.curpBox.SelectionStart = 0;
            this.curpBox.Size = new System.Drawing.Size(198, 23);
            this.curpBox.TabIndex = 3;
            this.curpBox.TabStop = false;
            this.curpBox.Text = "Curp";
            this.curpBox.UseSystemPasswordChar = false;
            // 
            // nipBox
            // 
            this.nipBox.Depth = 0;
            this.nipBox.Enabled = false;
            this.nipBox.Hint = "";
            this.nipBox.Location = new System.Drawing.Point(120, 188);
            this.nipBox.MaxLength = 32767;
            this.nipBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.nipBox.Name = "nipBox";
            this.nipBox.PasswordChar = '\0';
            this.nipBox.SelectedText = "";
            this.nipBox.SelectionLength = 0;
            this.nipBox.SelectionStart = 0;
            this.nipBox.Size = new System.Drawing.Size(200, 23);
            this.nipBox.TabIndex = 2;
            this.nipBox.TabStop = false;
            this.nipBox.Text = "NIP Empleado";
            this.nipBox.UseSystemPasswordChar = false;
            // 
            // dateBox
            // 
            this.dateBox.Depth = 0;
            this.dateBox.Enabled = false;
            this.dateBox.Hint = "";
            this.dateBox.Location = new System.Drawing.Point(278, 18);
            this.dateBox.MaxLength = 32767;
            this.dateBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.dateBox.Name = "dateBox";
            this.dateBox.PasswordChar = '\0';
            this.dateBox.SelectedText = "";
            this.dateBox.SelectionLength = 0;
            this.dateBox.SelectionStart = 0;
            this.dateBox.Size = new System.Drawing.Size(229, 23);
            this.dateBox.TabIndex = 1;
            this.dateBox.TabStop = false;
            this.dateBox.Text = "Fecha";
            this.dateBox.UseSystemPasswordChar = false;
            // 
            // nameBox
            // 
            this.nameBox.Depth = 0;
            this.nameBox.Enabled = false;
            this.nameBox.Hint = "";
            this.nameBox.Location = new System.Drawing.Point(20, 17);
            this.nameBox.MaxLength = 32767;
            this.nameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.nameBox.Name = "nameBox";
            this.nameBox.PasswordChar = '\0';
            this.nameBox.SelectedText = "";
            this.nameBox.SelectionLength = 0;
            this.nameBox.SelectionStart = 0;
            this.nameBox.Size = new System.Drawing.Size(198, 23);
            this.nameBox.TabIndex = 0;
            this.nameBox.TabStop = false;
            this.nameBox.Text = "Nombre Completo";
            this.nameBox.UseSystemPasswordChar = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.idErrorBox);
            this.tabPage3.Controls.Add(this.errorGrid);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(815, 287);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Errores de Cliente";
            // 
            // idErrorBox
            // 
            this.idErrorBox.Depth = 0;
            this.idErrorBox.Hint = "";
            this.idErrorBox.Location = new System.Drawing.Point(281, 193);
            this.idErrorBox.MaxLength = 32767;
            this.idErrorBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.idErrorBox.Name = "idErrorBox";
            this.idErrorBox.PasswordChar = '\0';
            this.idErrorBox.SelectedText = "";
            this.idErrorBox.SelectionLength = 0;
            this.idErrorBox.SelectionStart = 0;
            this.idErrorBox.Size = new System.Drawing.Size(231, 23);
            this.idErrorBox.TabIndex = 1;
            this.idErrorBox.TabStop = false;
            this.idErrorBox.Text = "Buscar Error por ID";
            this.idErrorBox.UseSystemPasswordChar = false;
            this.idErrorBox.Click += new System.EventHandler(this.idErrorBox_Click);
            this.idErrorBox.Leave += new System.EventHandler(this.idErrorBox_Leave);
            this.idErrorBox.TextChanged += new System.EventHandler(this.idErrorBox_TextChanged);
            // 
            // errorGrid
            // 
            this.errorGrid.BackgroundColor = System.Drawing.Color.White;
            this.errorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorGrid.Location = new System.Drawing.Point(0, 3);
            this.errorGrid.Name = "errorGrid";
            this.errorGrid.Size = new System.Drawing.Size(812, 150);
            this.errorGrid.TabIndex = 0;
            // 
            // EmployForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 433);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Name = "EmployForm";
            this.Text = "EmployForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployForm_FormClosing);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialSingleLineTextField passwordBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField addressBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField lineBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField errorBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField genreBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField laboralBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField operatorBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField curpBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField nipBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField dateBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField nameBox;
        private System.Windows.Forms.DataGridView ticketGrid;
        private MaterialSkin.Controls.MaterialSingleLineTextField idTicketBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField idProduct;
        private System.Windows.Forms.DataGridView productGrid;
        private System.Windows.Forms.NumericUpDown productNum;
        private MaterialSkin.Controls.MaterialRaisedButton addProductButton;
        private MaterialSkin.Controls.MaterialRaisedButton workTicketButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField registros;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialSingleLineTextField idErrorBox;
        private System.Windows.Forms.DataGridView errorGrid;
    }
}