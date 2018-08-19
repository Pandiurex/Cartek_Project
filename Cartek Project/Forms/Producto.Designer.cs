namespace Cartek_Project
{
    partial class Producto
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
            this.idTicketBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.productGrid = new System.Windows.Forms.DataGridView();
            this.idProductBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.quantityBox = new System.Windows.Forms.NumericUpDown();
            this.addButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.deleteButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.productoFacturaGrid = new System.Windows.Forms.DataGridView();
            this.searchBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoFacturaGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // idTicketBox
            // 
            this.idTicketBox.Depth = 0;
            this.idTicketBox.Enabled = false;
            this.idTicketBox.Hint = "";
            this.idTicketBox.Location = new System.Drawing.Point(12, 77);
            this.idTicketBox.MaxLength = 32767;
            this.idTicketBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.idTicketBox.Name = "idTicketBox";
            this.idTicketBox.PasswordChar = '\0';
            this.idTicketBox.SelectedText = "";
            this.idTicketBox.SelectionLength = 0;
            this.idTicketBox.SelectionStart = 0;
            this.idTicketBox.Size = new System.Drawing.Size(196, 23);
            this.idTicketBox.TabIndex = 0;
            this.idTicketBox.TabStop = false;
            this.idTicketBox.Text = "ID Factura";
            this.idTicketBox.UseSystemPasswordChar = false;
            // 
            // productGrid
            // 
            this.productGrid.BackgroundColor = System.Drawing.Color.White;
            this.productGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGrid.Location = new System.Drawing.Point(224, 77);
            this.productGrid.Name = "productGrid";
            this.productGrid.Size = new System.Drawing.Size(535, 157);
            this.productGrid.TabIndex = 1;
            // 
            // idProductBox
            // 
            this.idProductBox.Depth = 0;
            this.idProductBox.Hint = "";
            this.idProductBox.Location = new System.Drawing.Point(12, 118);
            this.idProductBox.MaxLength = 32767;
            this.idProductBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.idProductBox.Name = "idProductBox";
            this.idProductBox.PasswordChar = '\0';
            this.idProductBox.SelectedText = "";
            this.idProductBox.SelectionLength = 0;
            this.idProductBox.SelectionStart = 0;
            this.idProductBox.Size = new System.Drawing.Size(196, 23);
            this.idProductBox.TabIndex = 2;
            this.idProductBox.TabStop = false;
            this.idProductBox.Text = "ID Producto";
            this.idProductBox.UseSystemPasswordChar = false;
            this.idProductBox.Click += new System.EventHandler(this.idProductBox_Click);
            this.idProductBox.Leave += new System.EventHandler(this.idProductBox_Leave);
            this.idProductBox.TextChanged += new System.EventHandler(this.idProductBox_TextChanged);
            // 
            // quantityBox
            // 
            this.quantityBox.Location = new System.Drawing.Point(66, 161);
            this.quantityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(55, 20);
            this.quantityBox.TabIndex = 3;
            this.quantityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addButton.Depth = 0;
            this.addButton.Icon = null;
            this.addButton.Location = new System.Drawing.Point(22, 198);
            this.addButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addButton.Name = "addButton";
            this.addButton.Primary = true;
            this.addButton.Size = new System.Drawing.Size(158, 36);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Agregar Producto";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSize = true;
            this.deleteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteButton.Depth = 0;
            this.deleteButton.Icon = null;
            this.deleteButton.Location = new System.Drawing.Point(54, 316);
            this.deleteButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Primary = true;
            this.deleteButton.Size = new System.Drawing.Size(84, 36);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Remover";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // productoFacturaGrid
            // 
            this.productoFacturaGrid.BackgroundColor = System.Drawing.Color.White;
            this.productoFacturaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productoFacturaGrid.Location = new System.Drawing.Point(224, 251);
            this.productoFacturaGrid.Name = "productoFacturaGrid";
            this.productoFacturaGrid.Size = new System.Drawing.Size(535, 142);
            this.productoFacturaGrid.TabIndex = 6;
            // 
            // searchBox
            // 
            this.searchBox.Depth = 0;
            this.searchBox.Hint = "";
            this.searchBox.Location = new System.Drawing.Point(12, 287);
            this.searchBox.MaxLength = 32767;
            this.searchBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.searchBox.Name = "searchBox";
            this.searchBox.PasswordChar = '\0';
            this.searchBox.SelectedText = "";
            this.searchBox.SelectionLength = 0;
            this.searchBox.SelectionStart = 0;
            this.searchBox.Size = new System.Drawing.Size(197, 23);
            this.searchBox.TabIndex = 7;
            this.searchBox.TabStop = false;
            this.searchBox.Text = "Buscar Para Eliminar";
            this.searchBox.UseSystemPasswordChar = false;
            this.searchBox.Click += new System.EventHandler(this.searchBox_Click);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 429);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.productoFacturaGrid);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.quantityBox);
            this.Controls.Add(this.idProductBox);
            this.Controls.Add(this.productGrid);
            this.Controls.Add(this.idTicketBox);
            this.Name = "Producto";
            this.Text = "Producto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Producto_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoFacturaGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField idTicketBox;
        private System.Windows.Forms.DataGridView productGrid;
        private MaterialSkin.Controls.MaterialSingleLineTextField idProductBox;
        private System.Windows.Forms.NumericUpDown quantityBox;
        private MaterialSkin.Controls.MaterialRaisedButton addButton;
        private MaterialSkin.Controls.MaterialRaisedButton deleteButton;
        private System.Windows.Forms.DataGridView productoFacturaGrid;
        private MaterialSkin.Controls.MaterialSingleLineTextField searchBox;
    }
}