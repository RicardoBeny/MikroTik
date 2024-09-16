namespace AppLTI
{
    partial class dns_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dns_Form));
            this.labelDNS = new System.Windows.Forms.Label();
            this.btnAtivarDNS = new System.Windows.Forms.Button();
            this.btnDesativarDNS = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelConfDNS = new System.Windows.Forms.Label();
            this.textBoxEndDNS = new System.Windows.Forms.TextBox();
            this.labelEndIP = new System.Windows.Forms.Label();
            this.btnAddConfig = new System.Windows.Forms.Button();
            this.labelServidorEstado = new System.Windows.Forms.Label();
            this.btnAtualizarEntradas = new System.Windows.Forms.Button();
            this.labelEntDNS = new System.Windows.Forms.Label();
            this.listBoxEntradasDNS = new System.Windows.Forms.ListBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.buttonConfDNSestatico = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDNS
            // 
            this.labelDNS.AutoSize = true;
            this.labelDNS.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNS.ForeColor = System.Drawing.Color.White;
            this.labelDNS.Location = new System.Drawing.Point(514, 8);
            this.labelDNS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDNS.Name = "labelDNS";
            this.labelDNS.Size = new System.Drawing.Size(215, 43);
            this.labelDNS.TabIndex = 0;
            this.labelDNS.Text = "Servidor DNS";
            // 
            // btnAtivarDNS
            // 
            this.btnAtivarDNS.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivarDNS.Location = new System.Drawing.Point(927, 167);
            this.btnAtivarDNS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAtivarDNS.Name = "btnAtivarDNS";
            this.btnAtivarDNS.Size = new System.Drawing.Size(225, 31);
            this.btnAtivarDNS.TabIndex = 1;
            this.btnAtivarDNS.Text = "Ativar Servidor de DNS";
            this.btnAtivarDNS.UseVisualStyleBackColor = true;
            this.btnAtivarDNS.Click += new System.EventHandler(this.btnAtivarDNS_Click);
            // 
            // btnDesativarDNS
            // 
            this.btnDesativarDNS.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesativarDNS.Location = new System.Drawing.Point(914, 226);
            this.btnDesativarDNS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDesativarDNS.Name = "btnDesativarDNS";
            this.btnDesativarDNS.Size = new System.Drawing.Size(254, 31);
            this.btnDesativarDNS.TabIndex = 2;
            this.btnDesativarDNS.Text = "Desativar Servidor de DNS";
            this.btnDesativarDNS.UseVisualStyleBackColor = true;
            this.btnDesativarDNS.Click += new System.EventHandler(this.btnDesativarDNS_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1266, 769);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labelConfDNS
            // 
            this.labelConfDNS.AutoSize = true;
            this.labelConfDNS.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfDNS.ForeColor = System.Drawing.Color.White;
            this.labelConfDNS.Location = new System.Drawing.Point(608, 109);
            this.labelConfDNS.Name = "labelConfDNS";
            this.labelConfDNS.Size = new System.Drawing.Size(158, 26);
            this.labelConfDNS.TabIndex = 7;
            this.labelConfDNS.Text = "Configurar DNS";
            // 
            // textBoxEndDNS
            // 
            this.textBoxEndDNS.Location = new System.Drawing.Point(617, 167);
            this.textBoxEndDNS.Name = "textBoxEndDNS";
            this.textBoxEndDNS.Size = new System.Drawing.Size(184, 20);
            this.textBoxEndDNS.TabIndex = 9;
            // 
            // labelEndIP
            // 
            this.labelEndIP.AutoSize = true;
            this.labelEndIP.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndIP.ForeColor = System.Drawing.Color.White;
            this.labelEndIP.Location = new System.Drawing.Point(472, 167);
            this.labelEndIP.Name = "labelEndIP";
            this.labelEndIP.Size = new System.Drawing.Size(138, 23);
            this.labelEndIP.TabIndex = 11;
            this.labelEndIP.Text = "Forward Servers";
            // 
            // btnAddConfig
            // 
            this.btnAddConfig.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddConfig.Location = new System.Drawing.Point(578, 205);
            this.btnAddConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddConfig.Name = "btnAddConfig";
            this.btnAddConfig.Size = new System.Drawing.Size(235, 31);
            this.btnAddConfig.TabIndex = 12;
            this.btnAddConfig.Text = "Adicionar Configuração";
            this.btnAddConfig.UseVisualStyleBackColor = true;
            this.btnAddConfig.Click += new System.EventHandler(this.btnAddEntrada_Click);
            // 
            // labelServidorEstado
            // 
            this.labelServidorEstado.AutoSize = true;
            this.labelServidorEstado.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServidorEstado.ForeColor = System.Drawing.Color.White;
            this.labelServidorEstado.Location = new System.Drawing.Point(943, 109);
            this.labelServidorEstado.Name = "labelServidorEstado";
            this.labelServidorEstado.Size = new System.Drawing.Size(192, 26);
            this.labelServidorEstado.TabIndex = 13;
            this.labelServidorEstado.Text = "Estado do Servidor";
            // 
            // btnAtualizarEntradas
            // 
            this.btnAtualizarEntradas.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarEntradas.Location = new System.Drawing.Point(137, 588);
            this.btnAtualizarEntradas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAtualizarEntradas.Name = "btnAtualizarEntradas";
            this.btnAtualizarEntradas.Size = new System.Drawing.Size(235, 31);
            this.btnAtualizarEntradas.TabIndex = 14;
            this.btnAtualizarEntradas.Text = "Atualizar Entradas";
            this.btnAtualizarEntradas.UseVisualStyleBackColor = true;
            this.btnAtualizarEntradas.Click += new System.EventHandler(this.btnAtualizarEntradas_Click);
            // 
            // labelEntDNS
            // 
            this.labelEntDNS.AutoSize = true;
            this.labelEntDNS.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntDNS.ForeColor = System.Drawing.Color.White;
            this.labelEntDNS.Location = new System.Drawing.Point(148, 109);
            this.labelEntDNS.Name = "labelEntDNS";
            this.labelEntDNS.Size = new System.Drawing.Size(182, 26);
            this.labelEntDNS.TabIndex = 6;
            this.labelEntDNS.Text = "Servidor e estado";
            // 
            // listBoxEntradasDNS
            // 
            this.listBoxEntradasDNS.FormattingEnabled = true;
            this.listBoxEntradasDNS.Location = new System.Drawing.Point(29, 150);
            this.listBoxEntradasDNS.Name = "listBoxEntradasDNS";
            this.listBoxEntradasDNS.Size = new System.Drawing.Size(438, 433);
            this.listBoxEntradasDNS.TabIndex = 5;
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1200, 11);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(39, 41);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 111;
            this.pictureUsername.TabStop = false;
            // 
            // buttonConfDNSestatico
            // 
            this.buttonConfDNSestatico.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfDNSestatico.Location = new System.Drawing.Point(896, 331);
            this.buttonConfDNSestatico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConfDNSestatico.Name = "buttonConfDNSestatico";
            this.buttonConfDNSestatico.Size = new System.Drawing.Size(283, 31);
            this.buttonConfDNSestatico.TabIndex = 125;
            this.buttonConfDNSestatico.Text = "Configurar DNS estático";
            this.buttonConfDNSestatico.UseVisualStyleBackColor = true;
            this.buttonConfDNSestatico.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 135;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.ForeColor = System.Drawing.Color.White;
            this.textBoxStatus.Location = new System.Drawing.Point(12, 654);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(954, 16);
            this.textBoxStatus.TabIndex = 136;
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxIP.Location = new System.Drawing.Point(1041, 11);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(154, 47);
            this.textBoxIP.TabIndex = 137;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dns_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1250, 682);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonConfDNSestatico);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.btnAtualizarEntradas);
            this.Controls.Add(this.labelServidorEstado);
            this.Controls.Add(this.btnAddConfig);
            this.Controls.Add(this.labelEndIP);
            this.Controls.Add(this.textBoxEndDNS);
            this.Controls.Add(this.labelConfDNS);
            this.Controls.Add(this.labelEntDNS);
            this.Controls.Add(this.listBoxEntradasDNS);
            this.Controls.Add(this.btnDesativarDNS);
            this.Controls.Add(this.btnAtivarDNS);
            this.Controls.Add(this.labelDNS);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "dns_Form";
            this.Text = "Página DNS";
            this.Load += new System.EventHandler(this.dns_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDNS;
        private System.Windows.Forms.Button btnAtivarDNS;
        private System.Windows.Forms.Button btnDesativarDNS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelConfDNS;
        private System.Windows.Forms.TextBox textBoxEndDNS;
        private System.Windows.Forms.Label labelEndIP;
        private System.Windows.Forms.Button btnAddConfig;
        private System.Windows.Forms.Label labelServidorEstado;
        private System.Windows.Forms.Button btnAtualizarEntradas;
        private System.Windows.Forms.Label labelEntDNS;
        private System.Windows.Forms.ListBox listBoxEntradasDNS;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.Button buttonConfDNSestatico;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}