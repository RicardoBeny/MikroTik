namespace AppLTI
{
    partial class mainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInterfaces = new System.Windows.Forms.Button();
            this.btnServDHCP = new System.Windows.Forms.Button();
            this.btnRedes = new System.Windows.Forms.Button();
            this.btnRotas = new System.Windows.Forms.Button();
            this.btnEndIP = new System.Windows.Forms.Button();
            this.btnServDNS = new System.Windows.Forms.Button();
            this.buttonWireGuard = new System.Windows.Forms.Button();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonSSHTerminal = new System.Windows.Forms.Button();
            this.buttonPagWeb = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-11, -39);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1688, 982);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(683, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Página Principal";
            // 
            // btnInterfaces
            // 
            this.btnInterfaces.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterfaces.Location = new System.Drawing.Point(304, 576);
            this.btnInterfaces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInterfaces.Name = "btnInterfaces";
            this.btnInterfaces.Size = new System.Drawing.Size(257, 37);
            this.btnInterfaces.TabIndex = 2;
            this.btnInterfaces.Text = "Interfaces";
            this.btnInterfaces.UseVisualStyleBackColor = true;
            this.btnInterfaces.Click += new System.EventHandler(this.btnInterfaces_Click);
            // 
            // btnServDHCP
            // 
            this.btnServDHCP.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServDHCP.Location = new System.Drawing.Point(304, 257);
            this.btnServDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnServDHCP.Name = "btnServDHCP";
            this.btnServDHCP.Size = new System.Drawing.Size(257, 38);
            this.btnServDHCP.TabIndex = 3;
            this.btnServDHCP.Text = "Servidor DHCP";
            this.btnServDHCP.UseVisualStyleBackColor = true;
            this.btnServDHCP.Click += new System.EventHandler(this.btnServDHCP_Click);
            // 
            // btnRedes
            // 
            this.btnRedes.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedes.Location = new System.Drawing.Point(721, 745);
            this.btnRedes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRedes.Name = "btnRedes";
            this.btnRedes.Size = new System.Drawing.Size(257, 38);
            this.btnRedes.TabIndex = 4;
            this.btnRedes.Text = "Redes Wireless";
            this.btnRedes.UseVisualStyleBackColor = true;
            this.btnRedes.Click += new System.EventHandler(this.btnRedes_Click);
            // 
            // btnRotas
            // 
            this.btnRotas.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotas.Location = new System.Drawing.Point(1105, 587);
            this.btnRotas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRotas.Name = "btnRotas";
            this.btnRotas.Size = new System.Drawing.Size(257, 38);
            this.btnRotas.TabIndex = 6;
            this.btnRotas.Text = "Rotas";
            this.btnRotas.UseVisualStyleBackColor = true;
            this.btnRotas.Click += new System.EventHandler(this.btnRotas_Click);
            // 
            // btnEndIP
            // 
            this.btnEndIP.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndIP.Location = new System.Drawing.Point(1123, 276);
            this.btnEndIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEndIP.Name = "btnEndIP";
            this.btnEndIP.Size = new System.Drawing.Size(257, 38);
            this.btnEndIP.TabIndex = 7;
            this.btnEndIP.Text = "Endereços IP";
            this.btnEndIP.UseVisualStyleBackColor = true;
            this.btnEndIP.Click += new System.EventHandler(this.btnEndIP_Click);
            // 
            // btnServDNS
            // 
            this.btnServDNS.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServDNS.Location = new System.Drawing.Point(721, 108);
            this.btnServDNS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnServDNS.Name = "btnServDNS";
            this.btnServDNS.Size = new System.Drawing.Size(257, 38);
            this.btnServDNS.TabIndex = 8;
            this.btnServDNS.Text = "Servidor DNS";
            this.btnServDNS.UseVisualStyleBackColor = true;
            this.btnServDNS.Click += new System.EventHandler(this.btnServDNS_Click);
            // 
            // buttonWireGuard
            // 
            this.buttonWireGuard.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWireGuard.Location = new System.Drawing.Point(721, 415);
            this.buttonWireGuard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonWireGuard.Name = "buttonWireGuard";
            this.buttonWireGuard.Size = new System.Drawing.Size(257, 38);
            this.buttonWireGuard.TabIndex = 9;
            this.buttonWireGuard.Text = "WireGuard";
            this.buttonWireGuard.UseVisualStyleBackColor = true;
            this.buttonWireGuard.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1600, 14);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(52, 50);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 131;
            this.pictureUsername.TabStop = false;
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxIP.Location = new System.Drawing.Point(1388, 14);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(205, 58);
            this.textBoxIP.TabIndex = 129;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonSSHTerminal
            // 
            this.buttonSSHTerminal.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSSHTerminal.Location = new System.Drawing.Point(1395, 745);
            this.buttonSSHTerminal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSHTerminal.Name = "buttonSSHTerminal";
            this.buttonSSHTerminal.Size = new System.Drawing.Size(257, 38);
            this.buttonSSHTerminal.TabIndex = 132;
            this.buttonSSHTerminal.Text = "Terminal";
            this.buttonSSHTerminal.UseVisualStyleBackColor = true;
            this.buttonSSHTerminal.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonPagWeb
            // 
            this.buttonPagWeb.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPagWeb.Location = new System.Drawing.Point(1395, 788);
            this.buttonPagWeb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPagWeb.Name = "buttonPagWeb";
            this.buttonPagWeb.Size = new System.Drawing.Size(257, 38);
            this.buttonPagWeb.TabIndex = 133;
            this.buttonPagWeb.Text = "Interface Web";
            this.buttonPagWeb.UseVisualStyleBackColor = true;
            this.buttonPagWeb.Click += new System.EventHandler(this.buttonPagWeb_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.ForeColor = System.Drawing.Color.White;
            this.textBoxStatus.Location = new System.Drawing.Point(16, 805);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(1272, 20);
            this.textBoxStatus.TabIndex = 134;
            // 
            // mainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1655, 839);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.buttonPagWeb);
            this.Controls.Add(this.buttonSSHTerminal);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.buttonWireGuard);
            this.Controls.Add(this.btnServDNS);
            this.Controls.Add(this.btnEndIP);
            this.Controls.Add(this.btnRotas);
            this.Controls.Add(this.btnRedes);
            this.Controls.Add(this.btnServDHCP);
            this.Controls.Add(this.btnInterfaces);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "mainPage";
            this.Text = "Main Page";
            this.Load += new System.EventHandler(this.mainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInterfaces;
        private System.Windows.Forms.Button btnServDHCP;
        private System.Windows.Forms.Button btnRedes;
        private System.Windows.Forms.Button btnRotas;
        private System.Windows.Forms.Button btnEndIP;
        private System.Windows.Forms.Button btnServDNS;
        private System.Windows.Forms.Button buttonWireGuard;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonSSHTerminal;
        private System.Windows.Forms.Button buttonPagWeb;
        private System.Windows.Forms.TextBox textBoxStatus;
    }
}