namespace AppLTI
{
    partial class dhcpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dhcpForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBoxInterfaces = new System.Windows.Forms.ListBox();
            this.comboBoxEditInterface = new System.Windows.Forms.ComboBox();
            this.labelEditInterface = new System.Windows.Forms.Label();
            this.btnAtualizarInt = new System.Windows.Forms.Button();
            this.checkBoxEditDesativa = new System.Windows.Forms.CheckBox();
            this.checkBoxEditAtiva = new System.Windows.Forms.CheckBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelAtivo = new System.Windows.Forms.Label();
            this.checkBoxSim = new System.Windows.Forms.CheckBox();
            this.checkBoxNão = new System.Windows.Forms.CheckBox();
            this.labelAddressPoolEdit = new System.Windows.Forms.Label();
            this.textBoxEditNomeServidor = new System.Windows.Forms.TextBox();
            this.labeDHCPNameEdit = new System.Windows.Forms.Label();
            this.labelEliminarDHCP = new System.Windows.Forms.Label();
            this.labelEditDHCP = new System.Windows.Forms.Label();
            this.comboBoxElimDHCP = new System.Windows.Forms.ComboBox();
            this.btnEditServDHCP = new System.Windows.Forms.Button();
            this.btnAddServDHCP = new System.Windows.Forms.Button();
            this.btnDeleteDHCP = new System.Windows.Forms.Button();
            this.comboBoxSelectDHCP = new System.Windows.Forms.ComboBox();
            this.btnLoadDHCP = new System.Windows.Forms.Button();
            this.listBoxServidoresDHCP = new System.Windows.Forms.ListBox();
            this.DHCPLabel = new System.Windows.Forms.Label();
            this.textBoxEndereçoServidor = new System.Windows.Forms.TextBox();
            this.labelEndDoServidor = new System.Windows.Forms.Label();
            this.textBoxLeaseTime = new System.Windows.Forms.TextBox();
            this.labelLEaseTime = new System.Windows.Forms.Label();
            this.textBoxAddLeaseTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAddEndereçoServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxAddInterface = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAddNomeServidor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAtualizarIPPool = new System.Windows.Forms.Button();
            this.btnConfIPPool = new System.Windows.Forms.Button();
            this.listBoxIPPool = new System.Windows.Forms.ListBox();
            this.comboBoxEditPool = new System.Windows.Forms.ComboBox();
            this.comboBoxPoolAssociada = new System.Windows.Forms.ComboBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.textBoxcomment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCommentEdit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.pictureBox1.Location = new System.Drawing.Point(-12, -38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1688, 945);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listBoxInterfaces
            // 
            this.listBoxInterfaces.FormattingEnabled = true;
            this.listBoxInterfaces.ItemHeight = 16;
            this.listBoxInterfaces.Location = new System.Drawing.Point(1179, 363);
            this.listBoxInterfaces.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxInterfaces.Name = "listBoxInterfaces";
            this.listBoxInterfaces.Size = new System.Drawing.Size(472, 196);
            this.listBoxInterfaces.TabIndex = 85;
            // 
            // comboBoxEditInterface
            // 
            this.comboBoxEditInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditInterface.FormattingEnabled = true;
            this.comboBoxEditInterface.Location = new System.Drawing.Point(912, 420);
            this.comboBoxEditInterface.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxEditInterface.Name = "comboBoxEditInterface";
            this.comboBoxEditInterface.Size = new System.Drawing.Size(236, 24);
            this.comboBoxEditInterface.TabIndex = 84;
            // 
            // labelEditInterface
            // 
            this.labelEditInterface.AutoSize = true;
            this.labelEditInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEditInterface.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditInterface.ForeColor = System.Drawing.Color.White;
            this.labelEditInterface.Location = new System.Drawing.Point(679, 414);
            this.labelEditInterface.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEditInterface.Name = "labelEditInterface";
            this.labelEditInterface.Size = new System.Drawing.Size(208, 29);
            this.labelEditInterface.TabIndex = 83;
            this.labelEditInterface.Text = "Interface Associada";
            // 
            // btnAtualizarInt
            // 
            this.btnAtualizarInt.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarInt.Location = new System.Drawing.Point(1273, 297);
            this.btnAtualizarInt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtualizarInt.Name = "btnAtualizarInt";
            this.btnAtualizarInt.Size = new System.Drawing.Size(283, 41);
            this.btnAtualizarInt.TabIndex = 82;
            this.btnAtualizarInt.Text = "Atualizar Interfaces";
            this.btnAtualizarInt.UseVisualStyleBackColor = true;
            this.btnAtualizarInt.Click += new System.EventHandler(this.btnAtualizarInt_Click);
            // 
            // checkBoxEditDesativa
            // 
            this.checkBoxEditDesativa.AutoSize = true;
            this.checkBoxEditDesativa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxEditDesativa.ForeColor = System.Drawing.Color.White;
            this.checkBoxEditDesativa.Location = new System.Drawing.Point(1005, 474);
            this.checkBoxEditDesativa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEditDesativa.Name = "checkBoxEditDesativa";
            this.checkBoxEditDesativa.Size = new System.Drawing.Size(99, 20);
            this.checkBoxEditDesativa.TabIndex = 79;
            this.checkBoxEditDesativa.Text = "Desativado";
            this.checkBoxEditDesativa.UseVisualStyleBackColor = false;
            // 
            // checkBoxEditAtiva
            // 
            this.checkBoxEditAtiva.AutoSize = true;
            this.checkBoxEditAtiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxEditAtiva.ForeColor = System.Drawing.Color.White;
            this.checkBoxEditAtiva.Location = new System.Drawing.Point(908, 473);
            this.checkBoxEditAtiva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEditAtiva.Name = "checkBoxEditAtiva";
            this.checkBoxEditAtiva.Size = new System.Drawing.Size(59, 20);
            this.checkBoxEditAtiva.TabIndex = 78;
            this.checkBoxEditAtiva.Text = "Ativo";
            this.checkBoxEditAtiva.UseVisualStyleBackColor = false;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEstado.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.White;
            this.labelEstado.Location = new System.Drawing.Point(679, 465);
            this.labelEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(192, 29);
            this.labelEstado.TabIndex = 77;
            this.labelEstado.Text = "Estado do Servidor";
            // 
            // labelAtivo
            // 
            this.labelAtivo.AutoSize = true;
            this.labelAtivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAtivo.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAtivo.ForeColor = System.Drawing.Color.White;
            this.labelAtivo.Location = new System.Drawing.Point(536, 801);
            this.labelAtivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAtivo.Name = "labelAtivo";
            this.labelAtivo.Size = new System.Drawing.Size(61, 29);
            this.labelAtivo.TabIndex = 76;
            this.labelAtivo.Text = "Ativo";
            // 
            // checkBoxSim
            // 
            this.checkBoxSim.AutoSize = true;
            this.checkBoxSim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxSim.Location = new System.Drawing.Point(613, 810);
            this.checkBoxSim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSim.Name = "checkBoxSim";
            this.checkBoxSim.Size = new System.Drawing.Size(52, 20);
            this.checkBoxSim.TabIndex = 75;
            this.checkBoxSim.Text = "Sim";
            this.checkBoxSim.UseVisualStyleBackColor = false;
            // 
            // checkBoxNão
            // 
            this.checkBoxNão.AutoSize = true;
            this.checkBoxNão.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxNão.Location = new System.Drawing.Point(684, 810);
            this.checkBoxNão.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxNão.Name = "checkBoxNão";
            this.checkBoxNão.Size = new System.Drawing.Size(55, 20);
            this.checkBoxNão.TabIndex = 74;
            this.checkBoxNão.Text = "Não";
            this.checkBoxNão.UseVisualStyleBackColor = false;
            // 
            // labelAddressPoolEdit
            // 
            this.labelAddressPoolEdit.AutoSize = true;
            this.labelAddressPoolEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAddressPoolEdit.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddressPoolEdit.ForeColor = System.Drawing.Color.White;
            this.labelAddressPoolEdit.Location = new System.Drawing.Point(679, 256);
            this.labelAddressPoolEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAddressPoolEdit.Name = "labelAddressPoolEdit";
            this.labelAddressPoolEdit.Size = new System.Drawing.Size(159, 29);
            this.labelAddressPoolEdit.TabIndex = 72;
            this.labelAddressPoolEdit.Text = "Pool Associada";
            // 
            // textBoxEditNomeServidor
            // 
            this.textBoxEditNomeServidor.Location = new System.Drawing.Point(883, 198);
            this.textBoxEditNomeServidor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEditNomeServidor.Name = "textBoxEditNomeServidor";
            this.textBoxEditNomeServidor.Size = new System.Drawing.Size(263, 22);
            this.textBoxEditNomeServidor.TabIndex = 71;
            // 
            // labeDHCPNameEdit
            // 
            this.labeDHCPNameEdit.AutoSize = true;
            this.labeDHCPNameEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labeDHCPNameEdit.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeDHCPNameEdit.ForeColor = System.Drawing.Color.White;
            this.labeDHCPNameEdit.Location = new System.Drawing.Point(679, 198);
            this.labeDHCPNameEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeDHCPNameEdit.Name = "labeDHCPNameEdit";
            this.labeDHCPNameEdit.Size = new System.Drawing.Size(184, 29);
            this.labeDHCPNameEdit.TabIndex = 70;
            this.labeDHCPNameEdit.Text = "Nome do Servidor";
            // 
            // labelEliminarDHCP
            // 
            this.labelEliminarDHCP.AutoSize = true;
            this.labelEliminarDHCP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEliminarDHCP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEliminarDHCP.ForeColor = System.Drawing.Color.White;
            this.labelEliminarDHCP.Location = new System.Drawing.Point(1267, 102);
            this.labelEliminarDHCP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEliminarDHCP.Name = "labelEliminarDHCP";
            this.labelEliminarDHCP.Size = new System.Drawing.Size(271, 34);
            this.labelEliminarDHCP.TabIndex = 69;
            this.labelEliminarDHCP.Text = "Eliminar Servidor DHCP";
            // 
            // labelEditDHCP
            // 
            this.labelEditDHCP.AutoSize = true;
            this.labelEditDHCP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEditDHCP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditDHCP.ForeColor = System.Drawing.Color.White;
            this.labelEditDHCP.Location = new System.Drawing.Point(771, 102);
            this.labelEditDHCP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEditDHCP.Name = "labelEditDHCP";
            this.labelEditDHCP.Size = new System.Drawing.Size(244, 34);
            this.labelEditDHCP.TabIndex = 68;
            this.labelEditDHCP.Text = "Editar Servidor DHCP";
            // 
            // comboBoxElimDHCP
            // 
            this.comboBoxElimDHCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxElimDHCP.FormattingEnabled = true;
            this.comboBoxElimDHCP.Location = new System.Drawing.Point(1169, 144);
            this.comboBoxElimDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxElimDHCP.Name = "comboBoxElimDHCP";
            this.comboBoxElimDHCP.Size = new System.Drawing.Size(481, 24);
            this.comboBoxElimDHCP.TabIndex = 63;
            // 
            // btnEditServDHCP
            // 
            this.btnEditServDHCP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditServDHCP.Location = new System.Drawing.Point(769, 535);
            this.btnEditServDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditServDHCP.Name = "btnEditServDHCP";
            this.btnEditServDHCP.Size = new System.Drawing.Size(289, 44);
            this.btnEditServDHCP.TabIndex = 62;
            this.btnEditServDHCP.Text = "Editar Servidor DHCP";
            this.btnEditServDHCP.UseVisualStyleBackColor = true;
            this.btnEditServDHCP.Click += new System.EventHandler(this.btnEditServDHCP_Click);
            // 
            // btnAddServDHCP
            // 
            this.btnAddServDHCP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddServDHCP.Location = new System.Drawing.Point(388, 591);
            this.btnAddServDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddServDHCP.Name = "btnAddServDHCP";
            this.btnAddServDHCP.Size = new System.Drawing.Size(371, 41);
            this.btnAddServDHCP.TabIndex = 61;
            this.btnAddServDHCP.Text = "Adicionar Servidor DHCP";
            this.btnAddServDHCP.UseVisualStyleBackColor = true;
            this.btnAddServDHCP.Click += new System.EventHandler(this.btnAddServDHCP_Click);
            // 
            // btnDeleteDHCP
            // 
            this.btnDeleteDHCP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDHCP.Location = new System.Drawing.Point(1273, 192);
            this.btnDeleteDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteDHCP.Name = "btnDeleteDHCP";
            this.btnDeleteDHCP.Size = new System.Drawing.Size(283, 42);
            this.btnDeleteDHCP.TabIndex = 60;
            this.btnDeleteDHCP.Text = "Apagar Servidor DHCP";
            this.btnDeleteDHCP.UseVisualStyleBackColor = true;
            this.btnDeleteDHCP.Click += new System.EventHandler(this.btnDeleteDHCP_Click);
            // 
            // comboBoxSelectDHCP
            // 
            this.comboBoxSelectDHCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectDHCP.FormattingEnabled = true;
            this.comboBoxSelectDHCP.Location = new System.Drawing.Point(684, 144);
            this.comboBoxSelectDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSelectDHCP.Name = "comboBoxSelectDHCP";
            this.comboBoxSelectDHCP.Size = new System.Drawing.Size(461, 24);
            this.comboBoxSelectDHCP.TabIndex = 59;
            this.comboBoxSelectDHCP.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectDHCP_SelectedIndexChanged);
            // 
            // btnLoadDHCP
            // 
            this.btnLoadDHCP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDHCP.Location = new System.Drawing.Point(33, 96);
            this.btnLoadDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadDHCP.Name = "btnLoadDHCP";
            this.btnLoadDHCP.Size = new System.Drawing.Size(635, 46);
            this.btnLoadDHCP.TabIndex = 58;
            this.btnLoadDHCP.Text = "Listar Todos os Servidores DHCP";
            this.btnLoadDHCP.UseVisualStyleBackColor = true;
            this.btnLoadDHCP.Click += new System.EventHandler(this.btnLoadDHCP_Click);
            // 
            // listBoxServidoresDHCP
            // 
            this.listBoxServidoresDHCP.FormattingEnabled = true;
            this.listBoxServidoresDHCP.ItemHeight = 16;
            this.listBoxServidoresDHCP.Location = new System.Drawing.Point(33, 144);
            this.listBoxServidoresDHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxServidoresDHCP.Name = "listBoxServidoresDHCP";
            this.listBoxServidoresDHCP.Size = new System.Drawing.Size(633, 420);
            this.listBoxServidoresDHCP.TabIndex = 57;
            // 
            // DHCPLabel
            // 
            this.DHCPLabel.AutoSize = true;
            this.DHCPLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DHCPLabel.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DHCPLabel.ForeColor = System.Drawing.Color.White;
            this.DHCPLabel.Location = new System.Drawing.Point(697, 11);
            this.DHCPLabel.Name = "DHCPLabel";
            this.DHCPLabel.Size = new System.Drawing.Size(292, 54);
            this.DHCPLabel.TabIndex = 56;
            this.DHCPLabel.Text = "Servidor DHCP";
            // 
            // textBoxEndereçoServidor
            // 
            this.textBoxEndereçoServidor.Location = new System.Drawing.Point(908, 313);
            this.textBoxEndereçoServidor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEndereçoServidor.Name = "textBoxEndereçoServidor";
            this.textBoxEndereçoServidor.Size = new System.Drawing.Size(237, 22);
            this.textBoxEndereçoServidor.TabIndex = 87;
            // 
            // labelEndDoServidor
            // 
            this.labelEndDoServidor.AutoSize = true;
            this.labelEndDoServidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEndDoServidor.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDoServidor.ForeColor = System.Drawing.Color.White;
            this.labelEndDoServidor.Location = new System.Drawing.Point(679, 309);
            this.labelEndDoServidor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndDoServidor.Name = "labelEndDoServidor";
            this.labelEndDoServidor.Size = new System.Drawing.Size(220, 29);
            this.labelEndDoServidor.TabIndex = 86;
            this.labelEndDoServidor.Text = "Endereço do Servidor";
            // 
            // textBoxLeaseTime
            // 
            this.textBoxLeaseTime.Location = new System.Drawing.Point(817, 367);
            this.textBoxLeaseTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLeaseTime.Name = "textBoxLeaseTime";
            this.textBoxLeaseTime.Size = new System.Drawing.Size(328, 22);
            this.textBoxLeaseTime.TabIndex = 89;
            // 
            // labelLEaseTime
            // 
            this.labelLEaseTime.AutoSize = true;
            this.labelLEaseTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelLEaseTime.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLEaseTime.ForeColor = System.Drawing.Color.White;
            this.labelLEaseTime.Location = new System.Drawing.Point(679, 363);
            this.labelLEaseTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLEaseTime.Name = "labelLEaseTime";
            this.labelLEaseTime.Size = new System.Drawing.Size(121, 29);
            this.labelLEaseTime.TabIndex = 88;
            this.labelLEaseTime.Text = "Lease Time";
            // 
            // textBoxAddLeaseTime
            // 
            this.textBoxAddLeaseTime.Location = new System.Drawing.Point(677, 663);
            this.textBoxAddLeaseTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAddLeaseTime.Name = "textBoxAddLeaseTime";
            this.textBoxAddLeaseTime.Size = new System.Drawing.Size(328, 22);
            this.textBoxAddLeaseTime.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(536, 660);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 98;
            this.label1.Text = "Lease Time";
            // 
            // textBoxAddEndereçoServidor
            // 
            this.textBoxAddEndereçoServidor.Location = new System.Drawing.Point(276, 766);
            this.textBoxAddEndereçoServidor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAddEndereçoServidor.Name = "textBoxAddEndereçoServidor";
            this.textBoxAddEndereçoServidor.Size = new System.Drawing.Size(237, 22);
            this.textBoxAddEndereçoServidor.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 766);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 29);
            this.label2.TabIndex = 96;
            this.label2.Text = "Endereço do Servidor";
            // 
            // comboBoxAddInterface
            // 
            this.comboBoxAddInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddInterface.FormattingEnabled = true;
            this.comboBoxAddInterface.Location = new System.Drawing.Point(769, 719);
            this.comboBoxAddInterface.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxAddInterface.Name = "comboBoxAddInterface";
            this.comboBoxAddInterface.Size = new System.Drawing.Size(236, 24);
            this.comboBoxAddInterface.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(536, 716);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 29);
            this.label3.TabIndex = 94;
            this.label3.Text = "Interface Associada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 716);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 29);
            this.label4.TabIndex = 92;
            this.label4.Text = "Pool Associada";
            // 
            // textBoxAddNomeServidor
            // 
            this.textBoxAddNomeServidor.Location = new System.Drawing.Point(251, 663);
            this.textBoxAddNomeServidor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAddNomeServidor.Name = "textBoxAddNomeServidor";
            this.textBoxAddNomeServidor.Size = new System.Drawing.Size(263, 22);
            this.textBoxAddNomeServidor.TabIndex = 91;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(33, 663);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 29);
            this.label5.TabIndex = 90;
            this.label5.Text = "Nome do Servidor";
            // 
            // btnAtualizarIPPool
            // 
            this.btnAtualizarIPPool.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarIPPool.Location = new System.Drawing.Point(1273, 567);
            this.btnAtualizarIPPool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtualizarIPPool.Name = "btnAtualizarIPPool";
            this.btnAtualizarIPPool.Size = new System.Drawing.Size(283, 41);
            this.btnAtualizarIPPool.TabIndex = 100;
            this.btnAtualizarIPPool.Text = "Atualizar IP Pool";
            this.btnAtualizarIPPool.UseVisualStyleBackColor = true;
            this.btnAtualizarIPPool.Click += new System.EventHandler(this.btnAtualizarIPPool_Click);
            // 
            // btnConfIPPool
            // 
            this.btnConfIPPool.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfIPPool.Location = new System.Drawing.Point(1273, 820);
            this.btnConfIPPool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfIPPool.Name = "btnConfIPPool";
            this.btnConfIPPool.Size = new System.Drawing.Size(283, 41);
            this.btnConfIPPool.TabIndex = 101;
            this.btnConfIPPool.Text = "Configurar IP Pool";
            this.btnConfIPPool.UseVisualStyleBackColor = true;
            this.btnConfIPPool.Click += new System.EventHandler(this.btnConfIPPool_Click);
            // 
            // listBoxIPPool
            // 
            this.listBoxIPPool.FormattingEnabled = true;
            this.listBoxIPPool.ItemHeight = 16;
            this.listBoxIPPool.Location = new System.Drawing.Point(1169, 615);
            this.listBoxIPPool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxIPPool.Name = "listBoxIPPool";
            this.listBoxIPPool.Size = new System.Drawing.Size(472, 196);
            this.listBoxIPPool.TabIndex = 102;
            // 
            // comboBoxEditPool
            // 
            this.comboBoxEditPool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditPool.FormattingEnabled = true;
            this.comboBoxEditPool.Location = new System.Drawing.Point(857, 256);
            this.comboBoxEditPool.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEditPool.Name = "comboBoxEditPool";
            this.comboBoxEditPool.Size = new System.Drawing.Size(291, 24);
            this.comboBoxEditPool.TabIndex = 103;
            // 
            // comboBoxPoolAssociada
            // 
            this.comboBoxPoolAssociada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPoolAssociada.FormattingEnabled = true;
            this.comboBoxPoolAssociada.Location = new System.Drawing.Point(212, 719);
            this.comboBoxPoolAssociada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPoolAssociada.Name = "comboBoxPoolAssociada";
            this.comboBoxPoolAssociada.Size = new System.Drawing.Size(301, 24);
            this.comboBoxPoolAssociada.TabIndex = 104;
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1600, 14);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(52, 50);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 108;
            this.pictureUsername.TabStop = false;
            // 
            // textBoxcomment
            // 
            this.textBoxcomment.Location = new System.Drawing.Point(677, 761);
            this.textBoxcomment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxcomment.Name = "textBoxcomment";
            this.textBoxcomment.Size = new System.Drawing.Size(328, 22);
            this.textBoxcomment.TabIndex = 110;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(536, 758);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 29);
            this.label7.TabIndex = 109;
            this.label7.Text = "Comment";
            // 
            // textBoxCommentEdit
            // 
            this.textBoxCommentEdit.Location = new System.Drawing.Point(820, 508);
            this.textBoxCommentEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCommentEdit.Name = "textBoxCommentEdit";
            this.textBoxCommentEdit.Size = new System.Drawing.Size(328, 22);
            this.textBoxCommentEdit.TabIndex = 112;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(679, 505);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 29);
            this.label8.TabIndex = 111;
            this.label8.Text = "Comment";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 134;
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
            this.textBoxStatus.TabIndex = 135;
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
            this.textBoxIP.TabIndex = 136;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dhcpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1667, 897);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxCommentEdit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxcomment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.comboBoxPoolAssociada);
            this.Controls.Add(this.comboBoxEditPool);
            this.Controls.Add(this.listBoxIPPool);
            this.Controls.Add(this.btnConfIPPool);
            this.Controls.Add(this.btnAtualizarIPPool);
            this.Controls.Add(this.textBoxAddLeaseTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAddEndereçoServidor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAddInterface);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAddNomeServidor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxLeaseTime);
            this.Controls.Add(this.labelLEaseTime);
            this.Controls.Add(this.textBoxEndereçoServidor);
            this.Controls.Add(this.labelEndDoServidor);
            this.Controls.Add(this.listBoxInterfaces);
            this.Controls.Add(this.comboBoxEditInterface);
            this.Controls.Add(this.labelEditInterface);
            this.Controls.Add(this.btnAtualizarInt);
            this.Controls.Add(this.checkBoxEditDesativa);
            this.Controls.Add(this.checkBoxEditAtiva);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.labelAtivo);
            this.Controls.Add(this.checkBoxSim);
            this.Controls.Add(this.checkBoxNão);
            this.Controls.Add(this.labelAddressPoolEdit);
            this.Controls.Add(this.textBoxEditNomeServidor);
            this.Controls.Add(this.labeDHCPNameEdit);
            this.Controls.Add(this.labelEliminarDHCP);
            this.Controls.Add(this.labelEditDHCP);
            this.Controls.Add(this.comboBoxElimDHCP);
            this.Controls.Add(this.btnEditServDHCP);
            this.Controls.Add(this.btnAddServDHCP);
            this.Controls.Add(this.btnDeleteDHCP);
            this.Controls.Add(this.comboBoxSelectDHCP);
            this.Controls.Add(this.btnLoadDHCP);
            this.Controls.Add(this.listBoxServidoresDHCP);
            this.Controls.Add(this.DHCPLabel);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "dhcpForm";
            this.Text = "dhcpForm";
            this.Load += new System.EventHandler(this.dhcpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBoxInterfaces;
        private System.Windows.Forms.ComboBox comboBoxEditInterface;
        private System.Windows.Forms.Label labelEditInterface;
        private System.Windows.Forms.Button btnAtualizarInt;
        private System.Windows.Forms.CheckBox checkBoxEditDesativa;
        private System.Windows.Forms.CheckBox checkBoxEditAtiva;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label labelAtivo;
        private System.Windows.Forms.CheckBox checkBoxSim;
        private System.Windows.Forms.CheckBox checkBoxNão;
        private System.Windows.Forms.Label labelAddressPoolEdit;
        private System.Windows.Forms.TextBox textBoxEditNomeServidor;
        private System.Windows.Forms.Label labeDHCPNameEdit;
        private System.Windows.Forms.Label labelEliminarDHCP;
        private System.Windows.Forms.Label labelEditDHCP;
        private System.Windows.Forms.ComboBox comboBoxElimDHCP;
        private System.Windows.Forms.Button btnEditServDHCP;
        private System.Windows.Forms.Button btnAddServDHCP;
        private System.Windows.Forms.Button btnDeleteDHCP;
        private System.Windows.Forms.ComboBox comboBoxSelectDHCP;
        private System.Windows.Forms.Button btnLoadDHCP;
        private System.Windows.Forms.ListBox listBoxServidoresDHCP;
        private System.Windows.Forms.Label DHCPLabel;
        private System.Windows.Forms.TextBox textBoxEndereçoServidor;
        private System.Windows.Forms.Label labelEndDoServidor;
        private System.Windows.Forms.TextBox textBoxLeaseTime;
        private System.Windows.Forms.Label labelLEaseTime;
        private System.Windows.Forms.TextBox textBoxAddLeaseTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAddEndereçoServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAddInterface;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAddNomeServidor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAtualizarIPPool;
        private System.Windows.Forms.Button btnConfIPPool;
        private System.Windows.Forms.ListBox listBoxIPPool;
        private System.Windows.Forms.ComboBox comboBoxEditPool;
        private System.Windows.Forms.ComboBox comboBoxPoolAssociada;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.TextBox textBoxcomment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCommentEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}