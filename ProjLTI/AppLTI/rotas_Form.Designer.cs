namespace AppLTI
{
    partial class rotas_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rotas_Form));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RotasLabel = new System.Windows.Forms.Label();
            this.listBoxRotas = new System.Windows.Forms.ListBox();
            this.btnLoadRotas = new System.Windows.Forms.Button();
            this.comboBoxSelectRotas = new System.Windows.Forms.ComboBox();
            this.btnDeleteRotas = new System.Windows.Forms.Button();
            this.btnAddRota = new System.Windows.Forms.Button();
            this.btnEditRota = new System.Windows.Forms.Button();
            this.comboBoxElimRota = new System.Windows.Forms.ComboBox();
            this.textBoxDestAddress = new System.Windows.Forms.TextBox();
            this.textBoxGateway = new System.Windows.Forms.TextBox();
            this.labelDestAddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEdit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEndDestEdit = new System.Windows.Forms.Label();
            this.textBoxEditEndDestino = new System.Windows.Forms.TextBox();
            this.labelGatewayEdit = new System.Windows.Forms.Label();
            this.textBoxEditGateway = new System.Windows.Forms.TextBox();
            this.checkBoxNão = new System.Windows.Forms.CheckBox();
            this.checkBoxSim = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.checkBoxEditAtiva = new System.Windows.Forms.CheckBox();
            this.checkBoxEditDesativa = new System.Windows.Forms.CheckBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1688, 945);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // RotasLabel
            // 
            this.RotasLabel.AutoSize = true;
            this.RotasLabel.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotasLabel.ForeColor = System.Drawing.Color.White;
            this.RotasLabel.Location = new System.Drawing.Point(764, 11);
            this.RotasLabel.Name = "RotasLabel";
            this.RotasLabel.Size = new System.Drawing.Size(130, 54);
            this.RotasLabel.TabIndex = 1;
            this.RotasLabel.Text = "Rotas";
            // 
            // listBoxRotas
            // 
            this.listBoxRotas.FormattingEnabled = true;
            this.listBoxRotas.ItemHeight = 16;
            this.listBoxRotas.Location = new System.Drawing.Point(33, 143);
            this.listBoxRotas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxRotas.Name = "listBoxRotas";
            this.listBoxRotas.Size = new System.Drawing.Size(633, 420);
            this.listBoxRotas.TabIndex = 2;
            // 
            // btnLoadRotas
            // 
            this.btnLoadRotas.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadRotas.Location = new System.Drawing.Point(33, 95);
            this.btnLoadRotas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadRotas.Name = "btnLoadRotas";
            this.btnLoadRotas.Size = new System.Drawing.Size(635, 46);
            this.btnLoadRotas.TabIndex = 3;
            this.btnLoadRotas.Text = "Listar Todas as Rotas";
            this.btnLoadRotas.UseVisualStyleBackColor = true;
            this.btnLoadRotas.Click += new System.EventHandler(this.btnLoadRotas_Click);
            // 
            // comboBoxSelectRotas
            // 
            this.comboBoxSelectRotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectRotas.FormattingEnabled = true;
            this.comboBoxSelectRotas.Location = new System.Drawing.Point(684, 143);
            this.comboBoxSelectRotas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSelectRotas.Name = "comboBoxSelectRotas";
            this.comboBoxSelectRotas.Size = new System.Drawing.Size(461, 24);
            this.comboBoxSelectRotas.TabIndex = 4;
            this.comboBoxSelectRotas.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectRotas_SelectedIndexChanged);
            // 
            // btnDeleteRotas
            // 
            this.btnDeleteRotas.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRotas.Location = new System.Drawing.Point(1273, 191);
            this.btnDeleteRotas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteRotas.Name = "btnDeleteRotas";
            this.btnDeleteRotas.Size = new System.Drawing.Size(283, 42);
            this.btnDeleteRotas.TabIndex = 5;
            this.btnDeleteRotas.Text = "Apagar Rota";
            this.btnDeleteRotas.UseVisualStyleBackColor = true;
            this.btnDeleteRotas.Click += new System.EventHandler(this.btnDeleteRotas_Click);
            // 
            // btnAddRota
            // 
            this.btnAddRota.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRota.Location = new System.Drawing.Point(33, 590);
            this.btnAddRota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddRota.Name = "btnAddRota";
            this.btnAddRota.Size = new System.Drawing.Size(285, 41);
            this.btnAddRota.TabIndex = 6;
            this.btnAddRota.Text = "Adicionar Rota";
            this.btnAddRota.UseVisualStyleBackColor = true;
            this.btnAddRota.Click += new System.EventHandler(this.btnAddRota_Click);
            // 
            // btnEditRota
            // 
            this.btnEditRota.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRota.Location = new System.Drawing.Point(760, 361);
            this.btnEditRota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditRota.Name = "btnEditRota";
            this.btnEditRota.Size = new System.Drawing.Size(289, 44);
            this.btnEditRota.TabIndex = 7;
            this.btnEditRota.Text = "Editar Rota";
            this.btnEditRota.UseVisualStyleBackColor = true;
            this.btnEditRota.Click += new System.EventHandler(this.btnEditRota_Click);
            // 
            // comboBoxElimRota
            // 
            this.comboBoxElimRota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxElimRota.FormattingEnabled = true;
            this.comboBoxElimRota.Location = new System.Drawing.Point(1169, 143);
            this.comboBoxElimRota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxElimRota.Name = "comboBoxElimRota";
            this.comboBoxElimRota.Size = new System.Drawing.Size(481, 24);
            this.comboBoxElimRota.TabIndex = 8;
            // 
            // textBoxDestAddress
            // 
            this.textBoxDestAddress.Location = new System.Drawing.Point(263, 655);
            this.textBoxDestAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDestAddress.Name = "textBoxDestAddress";
            this.textBoxDestAddress.Size = new System.Drawing.Size(404, 22);
            this.textBoxDestAddress.TabIndex = 9;
            // 
            // textBoxGateway
            // 
            this.textBoxGateway.Location = new System.Drawing.Point(263, 702);
            this.textBoxGateway.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGateway.Name = "textBoxGateway";
            this.textBoxGateway.Size = new System.Drawing.Size(404, 22);
            this.textBoxGateway.TabIndex = 10;
            // 
            // labelDestAddress
            // 
            this.labelDestAddress.AutoSize = true;
            this.labelDestAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDestAddress.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDestAddress.ForeColor = System.Drawing.Color.White;
            this.labelDestAddress.Location = new System.Drawing.Point(28, 651);
            this.labelDestAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDestAddress.Name = "labelDestAddress";
            this.labelDestAddress.Size = new System.Drawing.Size(210, 29);
            this.labelDestAddress.TabIndex = 11;
            this.labelDestAddress.Text = "Endereço de destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 698);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Gateway";
            // 
            // labelEdit
            // 
            this.labelEdit.AutoSize = true;
            this.labelEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEdit.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEdit.ForeColor = System.Drawing.Color.White;
            this.labelEdit.Location = new System.Drawing.Point(821, 101);
            this.labelEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new System.Drawing.Size(135, 34);
            this.labelEdit.TabIndex = 13;
            this.labelEdit.Text = "Editar Rota";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1329, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 34);
            this.label2.TabIndex = 14;
            this.label2.Text = "Eliminar Rota";
            // 
            // labelEndDestEdit
            // 
            this.labelEndDestEdit.AutoSize = true;
            this.labelEndDestEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEndDestEdit.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDestEdit.ForeColor = System.Drawing.Color.White;
            this.labelEndDestEdit.Location = new System.Drawing.Point(679, 199);
            this.labelEndDestEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndDestEdit.Name = "labelEndDestEdit";
            this.labelEndDestEdit.Size = new System.Drawing.Size(210, 29);
            this.labelEndDestEdit.TabIndex = 15;
            this.labelEndDestEdit.Text = "Endereço de destino";
            // 
            // textBoxEditEndDestino
            // 
            this.textBoxEditEndDestino.Location = new System.Drawing.Point(913, 203);
            this.textBoxEditEndDestino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEditEndDestino.Name = "textBoxEditEndDestino";
            this.textBoxEditEndDestino.Size = new System.Drawing.Size(232, 22);
            this.textBoxEditEndDestino.TabIndex = 16;
            // 
            // labelGatewayEdit
            // 
            this.labelGatewayEdit.AutoSize = true;
            this.labelGatewayEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelGatewayEdit.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGatewayEdit.ForeColor = System.Drawing.Color.White;
            this.labelGatewayEdit.Location = new System.Drawing.Point(679, 255);
            this.labelGatewayEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGatewayEdit.Name = "labelGatewayEdit";
            this.labelGatewayEdit.Size = new System.Drawing.Size(95, 29);
            this.labelGatewayEdit.TabIndex = 17;
            this.labelGatewayEdit.Text = "Gateway";
            // 
            // textBoxEditGateway
            // 
            this.textBoxEditGateway.Location = new System.Drawing.Point(828, 258);
            this.textBoxEditGateway.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEditGateway.Name = "textBoxEditGateway";
            this.textBoxEditGateway.Size = new System.Drawing.Size(317, 22);
            this.textBoxEditGateway.TabIndex = 18;
            // 
            // checkBoxNão
            // 
            this.checkBoxNão.AutoSize = true;
            this.checkBoxNão.Location = new System.Drawing.Point(328, 743);
            this.checkBoxNão.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxNão.Name = "checkBoxNão";
            this.checkBoxNão.Size = new System.Drawing.Size(55, 20);
            this.checkBoxNão.TabIndex = 19;
            this.checkBoxNão.Text = "Não";
            this.checkBoxNão.UseVisualStyleBackColor = true;
            // 
            // checkBoxSim
            // 
            this.checkBoxSim.AutoSize = true;
            this.checkBoxSim.Location = new System.Drawing.Point(263, 743);
            this.checkBoxSim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSim.Name = "checkBoxSim";
            this.checkBoxSim.Size = new System.Drawing.Size(52, 20);
            this.checkBoxSim.TabIndex = 20;
            this.checkBoxSim.Text = "Sim";
            this.checkBoxSim.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(104, 743);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ativa";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEstado.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.White;
            this.labelEstado.Location = new System.Drawing.Point(679, 306);
            this.labelEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(149, 29);
            this.labelEstado.TabIndex = 22;
            this.labelEstado.Text = "Estado da rota";
            // 
            // checkBoxEditAtiva
            // 
            this.checkBoxEditAtiva.AutoSize = true;
            this.checkBoxEditAtiva.Location = new System.Drawing.Point(869, 314);
            this.checkBoxEditAtiva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEditAtiva.Name = "checkBoxEditAtiva";
            this.checkBoxEditAtiva.Size = new System.Drawing.Size(59, 20);
            this.checkBoxEditAtiva.TabIndex = 23;
            this.checkBoxEditAtiva.Text = "Ativa";
            this.checkBoxEditAtiva.UseVisualStyleBackColor = true;
            // 
            // checkBoxEditDesativa
            // 
            this.checkBoxEditDesativa.AutoSize = true;
            this.checkBoxEditDesativa.Location = new System.Drawing.Point(956, 315);
            this.checkBoxEditDesativa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEditDesativa.Name = "checkBoxEditDesativa";
            this.checkBoxEditDesativa.Size = new System.Drawing.Size(99, 20);
            this.checkBoxEditDesativa.TabIndex = 24;
            this.checkBoxEditDesativa.Text = "Desativada";
            this.checkBoxEditDesativa.UseVisualStyleBackColor = true;
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
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 132;
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
            this.textBoxStatus.Location = new System.Drawing.Point(16, 863);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(1272, 20);
            this.textBoxStatus.TabIndex = 141;
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxIP.Location = new System.Drawing.Point(1388, 14);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(205, 58);
            this.textBoxIP.TabIndex = 142;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rotas_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1667, 897);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.checkBoxEditDesativa);
            this.Controls.Add(this.checkBoxEditAtiva);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxSim);
            this.Controls.Add(this.checkBoxNão);
            this.Controls.Add(this.textBoxEditGateway);
            this.Controls.Add(this.labelGatewayEdit);
            this.Controls.Add(this.textBoxEditEndDestino);
            this.Controls.Add(this.labelEndDestEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDestAddress);
            this.Controls.Add(this.textBoxGateway);
            this.Controls.Add(this.textBoxDestAddress);
            this.Controls.Add(this.comboBoxElimRota);
            this.Controls.Add(this.btnEditRota);
            this.Controls.Add(this.btnAddRota);
            this.Controls.Add(this.btnDeleteRotas);
            this.Controls.Add(this.comboBoxSelectRotas);
            this.Controls.Add(this.btnLoadRotas);
            this.Controls.Add(this.listBoxRotas);
            this.Controls.Add(this.RotasLabel);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "rotas_Form";
            this.Text = "Rotas";
            this.Load += new System.EventHandler(this.rotas_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label RotasLabel;
        private System.Windows.Forms.ListBox listBoxRotas;
        private System.Windows.Forms.Button btnLoadRotas;
        private System.Windows.Forms.ComboBox comboBoxSelectRotas;
        private System.Windows.Forms.Button btnDeleteRotas;
        private System.Windows.Forms.Button btnAddRota;
        private System.Windows.Forms.Button btnEditRota;
        private System.Windows.Forms.ComboBox comboBoxElimRota;
        private System.Windows.Forms.TextBox textBoxDestAddress;
        private System.Windows.Forms.TextBox textBoxGateway;
        private System.Windows.Forms.Label labelDestAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEndDestEdit;
        private System.Windows.Forms.TextBox textBoxEditEndDestino;
        private System.Windows.Forms.Label labelGatewayEdit;
        private System.Windows.Forms.TextBox textBoxEditGateway;
        private System.Windows.Forms.CheckBox checkBoxNão;
        private System.Windows.Forms.CheckBox checkBoxSim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.CheckBox checkBoxEditAtiva;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.CheckBox checkBoxEditDesativa;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}