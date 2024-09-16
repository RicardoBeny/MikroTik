namespace AppLTI
{
    partial class peersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(peersForm));
            this.listBoxServer = new System.Windows.Forms.ListBox();
            this.btnAtualizarServidorVPN = new System.Windows.Forms.Button();
            this.textBoxPublicKeyAdd = new System.Windows.Forms.TextBox();
            this.labelPublicKey = new System.Windows.Forms.Label();
            this.textBoxEditPublicKey = new System.Windows.Forms.TextBox();
            this.labelEditPeers = new System.Windows.Forms.Label();
            this.btnAddPeer = new System.Windows.Forms.Button();
            this.comboBoxSelectPeer = new System.Windows.Forms.ComboBox();
            this.btnLoadPeers = new System.Windows.Forms.Button();
            this.listBoxPeer = new System.Windows.Forms.ListBox();
            this.WireGuardLabel = new System.Windows.Forms.Label();
            this.checkBoxEditDesativa = new System.Windows.Forms.CheckBox();
            this.checkBoxEditAtiva = new System.Windows.Forms.CheckBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditWireGuard = new System.Windows.Forms.Button();
            this.btnDeletePeer = new System.Windows.Forms.Button();
            this.comboBoxElimPeer = new System.Windows.Forms.ComboBox();
            this.labelEliminarDHCP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIPAdd = new System.Windows.Forms.TextBox();
            this.labelPublicKeyEdit = new System.Windows.Forms.Label();
            this.checkBoxAddDesativo = new System.Windows.Forms.CheckBox();
            this.checkBoxAddAtivo = new System.Windows.Forms.CheckBox();
            this.labelEstadoAdd = new System.Windows.Forms.Label();
            this.textBoxEndIPEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.comboBoxAddServer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxEditServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxcomment = new System.Windows.Forms.TextBox();
            this.textBoxcommentEdit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxServer
            // 
            this.listBoxServer.FormattingEnabled = true;
            this.listBoxServer.ItemHeight = 16;
            this.listBoxServer.Location = new System.Drawing.Point(1233, 458);
            this.listBoxServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxServer.Name = "listBoxServer";
            this.listBoxServer.Size = new System.Drawing.Size(392, 308);
            this.listBoxServer.TabIndex = 121;
            // 
            // btnAtualizarServidorVPN
            // 
            this.btnAtualizarServidorVPN.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarServidorVPN.Location = new System.Drawing.Point(1233, 398);
            this.btnAtualizarServidorVPN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtualizarServidorVPN.Name = "btnAtualizarServidorVPN";
            this.btnAtualizarServidorVPN.Size = new System.Drawing.Size(393, 53);
            this.btnAtualizarServidorVPN.TabIndex = 119;
            this.btnAtualizarServidorVPN.Text = "Atualizar Servidor WireGuard";
            this.btnAtualizarServidorVPN.UseVisualStyleBackColor = true;
            this.btnAtualizarServidorVPN.Click += new System.EventHandler(this.btnAtualizarServidorVPN_Click);
            // 
            // textBoxPublicKeyAdd
            // 
            this.textBoxPublicKeyAdd.Location = new System.Drawing.Point(184, 468);
            this.textBoxPublicKeyAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPublicKeyAdd.Name = "textBoxPublicKeyAdd";
            this.textBoxPublicKeyAdd.Size = new System.Drawing.Size(437, 22);
            this.textBoxPublicKeyAdd.TabIndex = 118;
            // 
            // labelPublicKey
            // 
            this.labelPublicKey.AutoSize = true;
            this.labelPublicKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPublicKey.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublicKey.ForeColor = System.Drawing.Color.White;
            this.labelPublicKey.Location = new System.Drawing.Point(44, 460);
            this.labelPublicKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPublicKey.Name = "labelPublicKey";
            this.labelPublicKey.Size = new System.Drawing.Size(129, 34);
            this.labelPublicKey.TabIndex = 117;
            this.labelPublicKey.Text = "Public Key";
            // 
            // textBoxEditPublicKey
            // 
            this.textBoxEditPublicKey.Location = new System.Drawing.Point(783, 172);
            this.textBoxEditPublicKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEditPublicKey.Name = "textBoxEditPublicKey";
            this.textBoxEditPublicKey.Size = new System.Drawing.Size(364, 22);
            this.textBoxEditPublicKey.TabIndex = 116;
            // 
            // labelEditPeers
            // 
            this.labelEditPeers.AutoSize = true;
            this.labelEditPeers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEditPeers.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditPeers.ForeColor = System.Drawing.Color.White;
            this.labelEditPeers.Location = new System.Drawing.Point(776, 86);
            this.labelEditPeers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEditPeers.Name = "labelEditPeers";
            this.labelEditPeers.Size = new System.Drawing.Size(136, 34);
            this.labelEditPeers.TabIndex = 113;
            this.labelEditPeers.Text = "Editar Peer";
            // 
            // btnAddPeer
            // 
            this.btnAddPeer.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPeer.Location = new System.Drawing.Point(213, 398);
            this.btnAddPeer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPeer.Name = "btnAddPeer";
            this.btnAddPeer.Size = new System.Drawing.Size(215, 53);
            this.btnAddPeer.TabIndex = 111;
            this.btnAddPeer.Text = "Adicionar Peer";
            this.btnAddPeer.UseVisualStyleBackColor = true;
            this.btnAddPeer.Click += new System.EventHandler(this.btnAddServWire_Click);
            // 
            // comboBoxSelectPeer
            // 
            this.comboBoxSelectPeer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectPeer.FormattingEnabled = true;
            this.comboBoxSelectPeer.Location = new System.Drawing.Point(644, 121);
            this.comboBoxSelectPeer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSelectPeer.Name = "comboBoxSelectPeer";
            this.comboBoxSelectPeer.Size = new System.Drawing.Size(503, 24);
            this.comboBoxSelectPeer.TabIndex = 109;
            this.comboBoxSelectPeer.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectPeer_SelectedIndexChanged);
            // 
            // btnLoadPeers
            // 
            this.btnLoadPeers.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPeers.Location = new System.Drawing.Point(213, 69);
            this.btnLoadPeers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadPeers.Name = "btnLoadPeers";
            this.btnLoadPeers.Size = new System.Drawing.Size(169, 49);
            this.btnLoadPeers.TabIndex = 108;
            this.btnLoadPeers.Text = "Listar Peers";
            this.btnLoadPeers.UseVisualStyleBackColor = true;
            this.btnLoadPeers.Click += new System.EventHandler(this.btnLoadServidores_Click);
            // 
            // listBoxPeer
            // 
            this.listBoxPeer.FormattingEnabled = true;
            this.listBoxPeer.ItemHeight = 16;
            this.listBoxPeer.Location = new System.Drawing.Point(29, 127);
            this.listBoxPeer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxPeer.Name = "listBoxPeer";
            this.listBoxPeer.Size = new System.Drawing.Size(571, 228);
            this.listBoxPeer.TabIndex = 107;
            // 
            // WireGuardLabel
            // 
            this.WireGuardLabel.AutoSize = true;
            this.WireGuardLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WireGuardLabel.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WireGuardLabel.ForeColor = System.Drawing.Color.White;
            this.WireGuardLabel.Location = new System.Drawing.Point(792, 11);
            this.WireGuardLabel.Name = "WireGuardLabel";
            this.WireGuardLabel.Size = new System.Drawing.Size(131, 54);
            this.WireGuardLabel.TabIndex = 106;
            this.WireGuardLabel.Text = "Peers";
            // 
            // checkBoxEditDesativa
            // 
            this.checkBoxEditDesativa.AutoSize = true;
            this.checkBoxEditDesativa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxEditDesativa.Location = new System.Drawing.Point(843, 347);
            this.checkBoxEditDesativa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEditDesativa.Name = "checkBoxEditDesativa";
            this.checkBoxEditDesativa.Size = new System.Drawing.Size(99, 20);
            this.checkBoxEditDesativa.TabIndex = 124;
            this.checkBoxEditDesativa.Text = "Desativado";
            this.checkBoxEditDesativa.UseVisualStyleBackColor = false;
            // 
            // checkBoxEditAtiva
            // 
            this.checkBoxEditAtiva.AutoSize = true;
            this.checkBoxEditAtiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxEditAtiva.Location = new System.Drawing.Point(755, 346);
            this.checkBoxEditAtiva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEditAtiva.Name = "checkBoxEditAtiva";
            this.checkBoxEditAtiva.Size = new System.Drawing.Size(59, 20);
            this.checkBoxEditAtiva.TabIndex = 123;
            this.checkBoxEditAtiva.Text = "Ativo";
            this.checkBoxEditAtiva.UseVisualStyleBackColor = false;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEstado.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.White;
            this.labelEstado.Location = new System.Drawing.Point(640, 335);
            this.labelEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(89, 34);
            this.labelEstado.TabIndex = 122;
            this.labelEstado.Text = "Estado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1688, 945);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditWireGuard
            // 
            this.btnEditWireGuard.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditWireGuard.Location = new System.Drawing.Point(741, 385);
            this.btnEditWireGuard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditWireGuard.Name = "btnEditWireGuard";
            this.btnEditWireGuard.Size = new System.Drawing.Size(237, 38);
            this.btnEditWireGuard.TabIndex = 125;
            this.btnEditWireGuard.Text = "Editar Peer";
            this.btnEditWireGuard.UseVisualStyleBackColor = true;
            this.btnEditWireGuard.Click += new System.EventHandler(this.btnEditWireGuard_Click);
            // 
            // btnDeletePeer
            // 
            this.btnDeletePeer.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePeer.Location = new System.Drawing.Point(1336, 158);
            this.btnDeletePeer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeletePeer.Name = "btnDeletePeer";
            this.btnDeletePeer.Size = new System.Drawing.Size(185, 49);
            this.btnDeletePeer.TabIndex = 110;
            this.btnDeletePeer.Text = "Apagar Peer";
            this.btnDeletePeer.UseVisualStyleBackColor = true;
            this.btnDeletePeer.Click += new System.EventHandler(this.btnDeleteWireGuard_Click);
            // 
            // comboBoxElimPeer
            // 
            this.comboBoxElimPeer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxElimPeer.FormattingEnabled = true;
            this.comboBoxElimPeer.Location = new System.Drawing.Point(1233, 127);
            this.comboBoxElimPeer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxElimPeer.Name = "comboBoxElimPeer";
            this.comboBoxElimPeer.Size = new System.Drawing.Size(392, 24);
            this.comboBoxElimPeer.TabIndex = 112;
            // 
            // labelEliminarDHCP
            // 
            this.labelEliminarDHCP.AutoSize = true;
            this.labelEliminarDHCP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEliminarDHCP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEliminarDHCP.ForeColor = System.Drawing.Color.White;
            this.labelEliminarDHCP.Location = new System.Drawing.Point(1349, 86);
            this.labelEliminarDHCP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEliminarDHCP.Name = "labelEliminarDHCP";
            this.labelEliminarDHCP.Size = new System.Drawing.Size(163, 34);
            this.labelEliminarDHCP.TabIndex = 114;
            this.labelEliminarDHCP.Text = "Eliminar Peer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 510);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 34);
            this.label2.TabIndex = 134;
            this.label2.Text = "Endereço IP Permitido";
            // 
            // textBoxIPAdd
            // 
            this.textBoxIPAdd.Location = new System.Drawing.Point(316, 517);
            this.textBoxIPAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIPAdd.Name = "textBoxIPAdd";
            this.textBoxIPAdd.Size = new System.Drawing.Size(305, 22);
            this.textBoxIPAdd.TabIndex = 135;
            // 
            // labelPublicKeyEdit
            // 
            this.labelPublicKeyEdit.AutoSize = true;
            this.labelPublicKeyEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPublicKeyEdit.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublicKeyEdit.ForeColor = System.Drawing.Color.White;
            this.labelPublicKeyEdit.Location = new System.Drawing.Point(637, 165);
            this.labelPublicKeyEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPublicKeyEdit.Name = "labelPublicKeyEdit";
            this.labelPublicKeyEdit.Size = new System.Drawing.Size(129, 34);
            this.labelPublicKeyEdit.TabIndex = 136;
            this.labelPublicKeyEdit.Text = "Public Key";
            // 
            // checkBoxAddDesativo
            // 
            this.checkBoxAddDesativo.AutoSize = true;
            this.checkBoxAddDesativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxAddDesativo.Location = new System.Drawing.Point(257, 642);
            this.checkBoxAddDesativo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAddDesativo.Name = "checkBoxAddDesativo";
            this.checkBoxAddDesativo.Size = new System.Drawing.Size(99, 20);
            this.checkBoxAddDesativo.TabIndex = 139;
            this.checkBoxAddDesativo.Text = "Desativado";
            this.checkBoxAddDesativo.UseVisualStyleBackColor = false;
            // 
            // checkBoxAddAtivo
            // 
            this.checkBoxAddAtivo.AutoSize = true;
            this.checkBoxAddAtivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxAddAtivo.Location = new System.Drawing.Point(164, 642);
            this.checkBoxAddAtivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAddAtivo.Name = "checkBoxAddAtivo";
            this.checkBoxAddAtivo.Size = new System.Drawing.Size(59, 20);
            this.checkBoxAddAtivo.TabIndex = 138;
            this.checkBoxAddAtivo.Text = "Ativo";
            this.checkBoxAddAtivo.UseVisualStyleBackColor = false;
            // 
            // labelEstadoAdd
            // 
            this.labelEstadoAdd.AutoSize = true;
            this.labelEstadoAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEstadoAdd.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoAdd.ForeColor = System.Drawing.Color.White;
            this.labelEstadoAdd.Location = new System.Drawing.Point(44, 630);
            this.labelEstadoAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstadoAdd.Name = "labelEstadoAdd";
            this.labelEstadoAdd.Size = new System.Drawing.Size(89, 34);
            this.labelEstadoAdd.TabIndex = 137;
            this.labelEstadoAdd.Text = "Estado";
            // 
            // textBoxEndIPEdit
            // 
            this.textBoxEndIPEdit.Location = new System.Drawing.Point(921, 214);
            this.textBoxEndIPEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEndIPEdit.Name = "textBoxEndIPEdit";
            this.textBoxEndIPEdit.Size = new System.Drawing.Size(225, 22);
            this.textBoxEndIPEdit.TabIndex = 141;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(639, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 34);
            this.label3.TabIndex = 140;
            this.label3.Text = "Endereço IP Permitido";
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1600, 14);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(52, 50);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 144;
            this.pictureUsername.TabStop = false;
            // 
            // comboBoxAddServer
            // 
            this.comboBoxAddServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddServer.FormattingEnabled = true;
            this.comboBoxAddServer.Location = new System.Drawing.Point(184, 560);
            this.comboBoxAddServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAddServer.Name = "comboBoxAddServer";
            this.comboBoxAddServer.Size = new System.Drawing.Size(437, 24);
            this.comboBoxAddServer.TabIndex = 145;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 554);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 34);
            this.label4.TabIndex = 146;
            this.label4.Text = "Servidor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(640, 247);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 34);
            this.label5.TabIndex = 148;
            this.label5.Text = "Servidor";
            // 
            // comboBoxEditServer
            // 
            this.comboBoxEditServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditServer.FormattingEnabled = true;
            this.comboBoxEditServer.Location = new System.Drawing.Point(780, 254);
            this.comboBoxEditServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEditServer.Name = "comboBoxEditServer";
            this.comboBoxEditServer.Size = new System.Drawing.Size(437, 24);
            this.comboBoxEditServer.TabIndex = 147;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(44, 594);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 34);
            this.label1.TabIndex = 150;
            this.label1.Text = "Comentario";
            // 
            // textBoxcomment
            // 
            this.textBoxcomment.Location = new System.Drawing.Point(197, 606);
            this.textBoxcomment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxcomment.Name = "textBoxcomment";
            this.textBoxcomment.Size = new System.Drawing.Size(423, 22);
            this.textBoxcomment.TabIndex = 151;
            // 
            // textBoxcommentEdit
            // 
            this.textBoxcommentEdit.Location = new System.Drawing.Point(791, 304);
            this.textBoxcommentEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxcommentEdit.Name = "textBoxcommentEdit";
            this.textBoxcommentEdit.Size = new System.Drawing.Size(423, 22);
            this.textBoxcommentEdit.TabIndex = 153;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(637, 292);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 34);
            this.label7.TabIndex = 152;
            this.label7.Text = "Comentario";
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
            this.pictureBox2.TabIndex = 154;
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
            this.textBoxStatus.TabIndex = 155;
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
            this.textBoxIP.TabIndex = 156;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // peersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1667, 897);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxcommentEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxcomment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxEditServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxAddServer);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.textBoxEndIPEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxAddDesativo);
            this.Controls.Add(this.checkBoxAddAtivo);
            this.Controls.Add(this.labelEstadoAdd);
            this.Controls.Add(this.labelPublicKeyEdit);
            this.Controls.Add(this.textBoxIPAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEditWireGuard);
            this.Controls.Add(this.checkBoxEditDesativa);
            this.Controls.Add(this.checkBoxEditAtiva);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.listBoxServer);
            this.Controls.Add(this.btnAtualizarServidorVPN);
            this.Controls.Add(this.textBoxPublicKeyAdd);
            this.Controls.Add(this.labelPublicKey);
            this.Controls.Add(this.textBoxEditPublicKey);
            this.Controls.Add(this.labelEliminarDHCP);
            this.Controls.Add(this.labelEditPeers);
            this.Controls.Add(this.comboBoxElimPeer);
            this.Controls.Add(this.btnAddPeer);
            this.Controls.Add(this.btnDeletePeer);
            this.Controls.Add(this.comboBoxSelectPeer);
            this.Controls.Add(this.btnLoadPeers);
            this.Controls.Add(this.listBoxPeer);
            this.Controls.Add(this.WireGuardLabel);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "peersForm";
            this.Text = "WireGuard Peers";
            this.Load += new System.EventHandler(this.wireguardVPN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxServer;
        private System.Windows.Forms.Button btnAtualizarServidorVPN;
        private System.Windows.Forms.TextBox textBoxPublicKeyAdd;
        private System.Windows.Forms.Label labelPublicKey;
        private System.Windows.Forms.TextBox textBoxEditPublicKey;
        private System.Windows.Forms.Label labelEditPeers;
        private System.Windows.Forms.Button btnAddPeer;
        private System.Windows.Forms.ComboBox comboBoxSelectPeer;
        private System.Windows.Forms.Button btnLoadPeers;
        private System.Windows.Forms.ListBox listBoxPeer;
        private System.Windows.Forms.Label WireGuardLabel;
        private System.Windows.Forms.CheckBox checkBoxEditDesativa;
        private System.Windows.Forms.CheckBox checkBoxEditAtiva;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEditWireGuard;
        private System.Windows.Forms.Button btnDeletePeer;
        private System.Windows.Forms.ComboBox comboBoxElimPeer;
        private System.Windows.Forms.Label labelEliminarDHCP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIPAdd;
        private System.Windows.Forms.Label labelPublicKeyEdit;
        private System.Windows.Forms.CheckBox checkBoxAddDesativo;
        private System.Windows.Forms.CheckBox checkBoxAddAtivo;
        private System.Windows.Forms.Label labelEstadoAdd;
        private System.Windows.Forms.TextBox textBoxEndIPEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.ComboBox comboBoxAddServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxEditServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxcomment;
        private System.Windows.Forms.TextBox textBoxcommentEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}