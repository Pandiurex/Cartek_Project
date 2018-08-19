namespace Cartek_Project
{
    partial class DataBaseLogIn
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
            this.database_password = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.dataBaseLogInButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // database_password
            // 
            this.database_password.Depth = 0;
            this.database_password.Hint = "";
            this.database_password.Location = new System.Drawing.Point(142, 114);
            this.database_password.MaxLength = 32767;
            this.database_password.MouseState = MaterialSkin.MouseState.HOVER;
            this.database_password.Name = "database_password";
            this.database_password.PasswordChar = '\0';
            this.database_password.SelectedText = "";
            this.database_password.SelectionLength = 0;
            this.database_password.SelectionStart = 0;
            this.database_password.Size = new System.Drawing.Size(154, 23);
            this.database_password.TabIndex = 2;
            this.database_password.TabStop = false;
            this.database_password.Text = "Contraseña";
            this.database_password.UseSystemPasswordChar = false;
            this.database_password.Click += new System.EventHandler(this.database_password_Click);
            this.database_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.database_password_KeyPress);
            // 
            // dataBaseLogInButton
            // 
            this.dataBaseLogInButton.AutoSize = true;
            this.dataBaseLogInButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dataBaseLogInButton.Depth = 0;
            this.dataBaseLogInButton.Icon = null;
            this.dataBaseLogInButton.Location = new System.Drawing.Point(160, 143);
            this.dataBaseLogInButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.dataBaseLogInButton.Name = "dataBaseLogInButton";
            this.dataBaseLogInButton.Primary = true;
            this.dataBaseLogInButton.Size = new System.Drawing.Size(111, 36);
            this.dataBaseLogInButton.TabIndex = 1;
            this.dataBaseLogInButton.Text = "Inicia Sesion";
            this.dataBaseLogInButton.UseVisualStyleBackColor = true;
            this.dataBaseLogInButton.Click += new System.EventHandler(this.dataBaseLogInButton_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(105, 77);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(223, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Contraseña de la Base de Datos";
            // 
            // DataBaseLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 203);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dataBaseLogInButton);
            this.Controls.Add(this.database_password);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "DataBaseLogIn";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField database_password;
        private MaterialSkin.Controls.MaterialRaisedButton dataBaseLogInButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}