namespace AppLTI
{
    partial class wireGuardServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wireGuardServerForm));
            this.buttonCopyPublicKey = new System.Windows.Forms.Button();
            this.textBoxPublicKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonkeysObtain = new System.Windows.Forms.Button();
            this.listBoxServer = new System.Windows.Forms.ListBox();
            this.btnAtualizarServidorVPN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxNomeAdd = new System.Windows.Forms.TextBox();
            this.labelPublicKey = new System.Windows.Forms.Label();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.labelNomeEdit = new System.Windows.Forms.Label();
            this.textBoxEditName = new System.Windows.Forms.TextBox();
            this.labelEditPeers = new System.Windows.Forms.Label();
            this.comboBoxSelectServer = new System.Windows.Forms.ComboBox();
            this.comboBoxPubKeyServer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxelimServer = new System.Windows.Forms.ComboBox();
            this.buttonelimServer = new System.Windows.Forms.Button();
            this.buttoneditServer = new System.Windows.Forms.Button();
            this.buttonConfPeers = new System.Windows.Forms.Button();
            this.listBoxPeers = new System.Windows.Forms.ListBox();
            this.buttonPeersServer = new System.Windows.Forms.Button();
            this.comboBoxListPeersServer = new System.Windows.Forms.ComboBox();
            this.WireGuardLabel = new System.Windows.Forms.Label();
            this.checkBoxAddDesativo = new System.Windows.Forms.CheckBox();
            this.checkBoxAddAtivo = new System.Windows.Forms.CheckBox();
            this.labelEstadoAdd = new System.Windows.Forms.Label();
            this.checkBoxDesativoEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxAtivoEdit = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPortEscuta = new System.Windows.Forms.TextBox();
            this.buttonCopyPort = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.textBoxComentario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxcommentEdit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxPorto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxRefazerChaves = new System.Windows.Forms.ComboBox();
            this.buttonRefazerChaves = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCopyPublicKey
            // 
            this.buttonCopyPublicKey.Location = new System.Drawing.Point(1001, 743);
            this.buttonCopyPublicKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCopyPublicKey.Name = "buttonCopyPublicKey";
            this.buttonCopyPublicKey.Size = new System.Drawing.Size(65, 25);
            this.buttonCopyPublicKey.TabIndex = 140;
            this.buttonCopyPublicKey.Text = "Copiar";
            this.buttonCopyPublicKey.UseVisualStyleBackColor = true;
            this.buttonCopyPublicKey.Click += new System.EventHandler(this.buttonCopyPublicKey_Click);
            // 
            // textBoxPublicKey
            // 
            this.textBoxPublicKey.Enabled = false;
            this.textBoxPublicKey.Location = new System.Drawing.Point(707, 743);
            this.textBoxPublicKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPublicKey.Name = "textBoxPublicKey";
            this.textBoxPublicKey.Size = new System.Drawing.Size(276, 22);
            this.textBoxPublicKey.TabIndex = 139;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(568, 736);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 34);
            this.label1.TabIndex = 138;
            this.label1.Text = "Public Key";
            // 
            // buttonkeysObtain
            // 
            this.buttonkeysObtain.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonkeysObtain.Location = new System.Drawing.Point(667, 638);
            this.buttonkeysObtain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonkeysObtain.Name = "buttonkeysObtain";
            this.buttonkeysObtain.Size = new System.Drawing.Size(356, 43);
            this.buttonkeysObtain.TabIndex = 137;
            this.buttonkeysObtain.Text = "Obter Public Key do Servidor";
            this.buttonkeysObtain.UseVisualStyleBackColor = true;
            this.buttonkeysObtain.Click += new System.EventHandler(this.buttonkeysObtain_Click);
            // 
            // listBoxServer
            // 
            this.listBoxServer.FormattingEnabled = true;
            this.listBoxServer.ItemHeight = 16;
            this.listBoxServer.Location = new System.Drawing.Point(33, 185);
            this.listBoxServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxServer.Name = "listBoxServer";
            this.listBoxServer.Size = new System.Drawing.Size(488, 436);
            this.listBoxServer.TabIndex = 136;
            // 
            // btnAtualizarServidorVPN
            // 
            this.btnAtualizarServidorVPN.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarServidorVPN.Location = new System.Drawing.Point(84, 124);
            this.btnAtualizarServidorVPN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtualizarServidorVPN.Name = "btnAtualizarServidorVPN";
            this.btnAtualizarServidorVPN.Size = new System.Drawing.Size(393, 53);
            this.btnAtualizarServidorVPN.TabIndex = 135;
            this.btnAtualizarServidorVPN.Text = "Atualizar Servidor WireGuard";
            this.btnAtualizarServidorVPN.UseVisualStyleBackColor = true;
            this.btnAtualizarServidorVPN.Click += new System.EventHandler(this.btnAtualizarServidorVPN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1688, 945);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 134;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxNomeAdd
            // 
            this.textBoxNomeAdd.Location = new System.Drawing.Point(136, 704);
            this.textBoxNomeAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNomeAdd.Name = "textBoxNomeAdd";
            this.textBoxNomeAdd.Size = new System.Drawing.Size(340, 22);
            this.textBoxNomeAdd.TabIndex = 143;
            // 
            // labelPublicKey
            // 
            this.labelPublicKey.AutoSize = true;
            this.labelPublicKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPublicKey.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublicKey.ForeColor = System.Drawing.Color.White;
            this.labelPublicKey.Location = new System.Drawing.Point(43, 697);
            this.labelPublicKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPublicKey.Name = "labelPublicKey";
            this.labelPublicKey.Size = new System.Drawing.Size(84, 34);
            this.labelPublicKey.TabIndex = 142;
            this.labelPublicKey.Text = "Nome:";
            // 
            // btnAddServer
            // 
            this.btnAddServer.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddServer.Location = new System.Drawing.Point(151, 641);
            this.btnAddServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(265, 43);
            this.btnAddServer.TabIndex = 141;
            this.btnAddServer.Text = "Adicionar Servidor";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // labelNomeEdit
            // 
            this.labelNomeEdit.AutoSize = true;
            this.labelNomeEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNomeEdit.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeEdit.ForeColor = System.Drawing.Color.White;
            this.labelNomeEdit.Location = new System.Drawing.Point(567, 217);
            this.labelNomeEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNomeEdit.Name = "labelNomeEdit";
            this.labelNomeEdit.Size = new System.Drawing.Size(84, 34);
            this.labelNomeEdit.TabIndex = 147;
            this.labelNomeEdit.Text = "Nome:";
            // 
            // textBoxEditName
            // 
            this.textBoxEditName.Location = new System.Drawing.Point(660, 224);
            this.textBoxEditName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEditName.Name = "textBoxEditName";
            this.textBoxEditName.Size = new System.Drawing.Size(416, 22);
            this.textBoxEditName.TabIndex = 146;
            // 
            // labelEditPeers
            // 
            this.labelEditPeers.AutoSize = true;
            this.labelEditPeers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEditPeers.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditPeers.ForeColor = System.Drawing.Color.White;
            this.labelEditPeers.Location = new System.Drawing.Point(752, 127);
            this.labelEditPeers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEditPeers.Name = "labelEditPeers";
            this.labelEditPeers.Size = new System.Drawing.Size(180, 34);
            this.labelEditPeers.TabIndex = 145;
            this.labelEditPeers.Text = "Editar Servidor";
            // 
            // comboBoxSelectServer
            // 
            this.comboBoxSelectServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectServer.FormattingEnabled = true;
            this.comboBoxSelectServer.Location = new System.Drawing.Point(573, 172);
            this.comboBoxSelectServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSelectServer.Name = "comboBoxSelectServer";
            this.comboBoxSelectServer.Size = new System.Drawing.Size(503, 24);
            this.comboBoxSelectServer.TabIndex = 144;
            this.comboBoxSelectServer.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectServer_SelectedIndexChanged);
            // 
            // comboBoxPubKeyServer
            // 
            this.comboBoxPubKeyServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPubKeyServer.FormattingEnabled = true;
            this.comboBoxPubKeyServer.Location = new System.Drawing.Point(580, 700);
            this.comboBoxPubKeyServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPubKeyServer.Name = "comboBoxPubKeyServer";
            this.comboBoxPubKeyServer.Size = new System.Drawing.Size(503, 24);
            this.comboBoxPubKeyServer.TabIndex = 148;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1252, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 34);
            this.label2.TabIndex = 150;
            this.label2.Text = "Eliminar Servidor";
            // 
            // comboBoxelimServer
            // 
            this.comboBoxelimServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxelimServer.FormattingEnabled = true;
            this.comboBoxelimServer.Location = new System.Drawing.Point(1161, 180);
            this.comboBoxelimServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxelimServer.Name = "comboBoxelimServer";
            this.comboBoxelimServer.Size = new System.Drawing.Size(415, 24);
            this.comboBoxelimServer.TabIndex = 149;
            // 
            // buttonelimServer
            // 
            this.buttonelimServer.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonelimServer.Location = new System.Drawing.Point(1244, 224);
            this.buttonelimServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonelimServer.Name = "buttonelimServer";
            this.buttonelimServer.Size = new System.Drawing.Size(237, 43);
            this.buttonelimServer.TabIndex = 151;
            this.buttonelimServer.Text = "Eliminar Servidor";
            this.buttonelimServer.UseVisualStyleBackColor = true;
            this.buttonelimServer.Click += new System.EventHandler(this.buttonelimServer_Click);
            // 
            // buttoneditServer
            // 
            this.buttoneditServer.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttoneditServer.Location = new System.Drawing.Point(727, 409);
            this.buttoneditServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttoneditServer.Name = "buttoneditServer";
            this.buttoneditServer.Size = new System.Drawing.Size(237, 43);
            this.buttoneditServer.TabIndex = 152;
            this.buttoneditServer.TabStop = false;
            this.buttoneditServer.Text = "Editar Servidor";
            this.buttoneditServer.UseVisualStyleBackColor = true;
            this.buttoneditServer.Click += new System.EventHandler(this.buttoneditServer_Click);
            // 
            // buttonConfPeers
            // 
            this.buttonConfPeers.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfPeers.Location = new System.Drawing.Point(1192, 332);
            this.buttonConfPeers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConfPeers.Name = "buttonConfPeers";
            this.buttonConfPeers.Size = new System.Drawing.Size(356, 43);
            this.buttonConfPeers.TabIndex = 153;
            this.buttonConfPeers.Text = "Configurar Peers";
            this.buttonConfPeers.UseVisualStyleBackColor = true;
            this.buttonConfPeers.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxPeers
            // 
            this.listBoxPeers.FormattingEnabled = true;
            this.listBoxPeers.ItemHeight = 16;
            this.listBoxPeers.Location = new System.Drawing.Point(1161, 501);
            this.listBoxPeers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxPeers.Name = "listBoxPeers";
            this.listBoxPeers.Size = new System.Drawing.Size(415, 308);
            this.listBoxPeers.TabIndex = 154;
            // 
            // buttonPeersServer
            // 
            this.buttonPeersServer.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPeersServer.Location = new System.Drawing.Point(1192, 409);
            this.buttonPeersServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPeersServer.Name = "buttonPeersServer";
            this.buttonPeersServer.Size = new System.Drawing.Size(356, 43);
            this.buttonPeersServer.TabIndex = 155;
            this.buttonPeersServer.Text = "Listar Peers do Servidor";
            this.buttonPeersServer.UseVisualStyleBackColor = true;
            this.buttonPeersServer.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxListPeersServer
            // 
            this.comboBoxListPeersServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListPeersServer.FormattingEnabled = true;
            this.comboBoxListPeersServer.Location = new System.Drawing.Point(1161, 468);
            this.comboBoxListPeersServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxListPeersServer.Name = "comboBoxListPeersServer";
            this.comboBoxListPeersServer.Size = new System.Drawing.Size(415, 24);
            this.comboBoxListPeersServer.TabIndex = 156;
            // 
            // WireGuardLabel
            // 
            this.WireGuardLabel.AutoSize = true;
            this.WireGuardLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WireGuardLabel.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WireGuardLabel.ForeColor = System.Drawing.Color.White;
            this.WireGuardLabel.Location = new System.Drawing.Point(797, 26);
            this.WireGuardLabel.Name = "WireGuardLabel";
            this.WireGuardLabel.Size = new System.Drawing.Size(95, 54);
            this.WireGuardLabel.TabIndex = 157;
            this.WireGuardLabel.Text = "VPN";
            // 
            // checkBoxAddDesativo
            // 
            this.checkBoxAddDesativo.AutoSize = true;
            this.checkBoxAddDesativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxAddDesativo.Location = new System.Drawing.Point(256, 790);
            this.checkBoxAddDesativo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAddDesativo.Name = "checkBoxAddDesativo";
            this.checkBoxAddDesativo.Size = new System.Drawing.Size(99, 20);
            this.checkBoxAddDesativo.TabIndex = 160;
            this.checkBoxAddDesativo.Text = "Desativado";
            this.checkBoxAddDesativo.UseVisualStyleBackColor = false;
            // 
            // checkBoxAddAtivo
            // 
            this.checkBoxAddAtivo.AutoSize = true;
            this.checkBoxAddAtivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxAddAtivo.Location = new System.Drawing.Point(163, 789);
            this.checkBoxAddAtivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAddAtivo.Name = "checkBoxAddAtivo";
            this.checkBoxAddAtivo.Size = new System.Drawing.Size(59, 20);
            this.checkBoxAddAtivo.TabIndex = 159;
            this.checkBoxAddAtivo.Text = "Ativo";
            this.checkBoxAddAtivo.UseVisualStyleBackColor = false;
            // 
            // labelEstadoAdd
            // 
            this.labelEstadoAdd.AutoSize = true;
            this.labelEstadoAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEstadoAdd.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoAdd.ForeColor = System.Drawing.Color.White;
            this.labelEstadoAdd.Location = new System.Drawing.Point(43, 777);
            this.labelEstadoAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstadoAdd.Name = "labelEstadoAdd";
            this.labelEstadoAdd.Size = new System.Drawing.Size(89, 34);
            this.labelEstadoAdd.TabIndex = 158;
            this.labelEstadoAdd.Text = "Estado";
            // 
            // checkBoxDesativoEdit
            // 
            this.checkBoxDesativoEdit.AutoSize = true;
            this.checkBoxDesativoEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxDesativoEdit.ForeColor = System.Drawing.Color.White;
            this.checkBoxDesativoEdit.Location = new System.Drawing.Point(780, 366);
            this.checkBoxDesativoEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDesativoEdit.Name = "checkBoxDesativoEdit";
            this.checkBoxDesativoEdit.Size = new System.Drawing.Size(99, 20);
            this.checkBoxDesativoEdit.TabIndex = 163;
            this.checkBoxDesativoEdit.Text = "Desativado";
            this.checkBoxDesativoEdit.UseVisualStyleBackColor = false;
            // 
            // checkBoxAtivoEdit
            // 
            this.checkBoxAtivoEdit.AutoSize = true;
            this.checkBoxAtivoEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxAtivoEdit.ForeColor = System.Drawing.Color.White;
            this.checkBoxAtivoEdit.Location = new System.Drawing.Point(687, 366);
            this.checkBoxAtivoEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAtivoEdit.Name = "checkBoxAtivoEdit";
            this.checkBoxAtivoEdit.Size = new System.Drawing.Size(59, 20);
            this.checkBoxAtivoEdit.TabIndex = 162;
            this.checkBoxAtivoEdit.Text = "Ativo";
            this.checkBoxAtivoEdit.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(568, 354);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 34);
            this.label3.TabIndex = 161;
            this.label3.Text = "Estado";
            // 
            // textBoxPortEscuta
            // 
            this.textBoxPortEscuta.Enabled = false;
            this.textBoxPortEscuta.Location = new System.Drawing.Point(707, 778);
            this.textBoxPortEscuta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPortEscuta.Name = "textBoxPortEscuta";
            this.textBoxPortEscuta.Size = new System.Drawing.Size(276, 22);
            this.textBoxPortEscuta.TabIndex = 164;
            // 
            // buttonCopyPort
            // 
            this.buttonCopyPort.Location = new System.Drawing.Point(1001, 778);
            this.buttonCopyPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCopyPort.Name = "buttonCopyPort";
            this.buttonCopyPort.Size = new System.Drawing.Size(65, 25);
            this.buttonCopyPort.TabIndex = 165;
            this.buttonCopyPort.Text = "Copiar";
            this.buttonCopyPort.UseVisualStyleBackColor = true;
            this.buttonCopyPort.Click += new System.EventHandler(this.buttonCopyPort_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(604, 778);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 34);
            this.label4.TabIndex = 166;
            this.label4.Text = "Porto";
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1600, 14);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(52, 50);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 169;
            this.pictureUsername.TabStop = false;
            // 
            // textBoxComentario
            // 
            this.textBoxComentario.Location = new System.Drawing.Point(189, 742);
            this.textBoxComentario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxComentario.Name = "textBoxComentario";
            this.textBoxComentario.Size = new System.Drawing.Size(287, 22);
            this.textBoxComentario.TabIndex = 171;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(43, 735);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 34);
            this.label5.TabIndex = 170;
            this.label5.Text = "Comentario";
            // 
            // textBoxcommentEdit
            // 
            this.textBoxcommentEdit.Location = new System.Drawing.Point(727, 271);
            this.textBoxcommentEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxcommentEdit.Name = "textBoxcommentEdit";
            this.textBoxcommentEdit.Size = new System.Drawing.Size(349, 22);
            this.textBoxcommentEdit.TabIndex = 173;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(568, 263);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 34);
            this.label7.TabIndex = 172;
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
            this.pictureBox2.TabIndex = 174;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // textBoxPorto
            // 
            this.textBoxPorto.Location = new System.Drawing.Point(660, 315);
            this.textBoxPorto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPorto.Name = "textBoxPorto";
            this.textBoxPorto.Size = new System.Drawing.Size(416, 22);
            this.textBoxPorto.TabIndex = 176;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(568, 308);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 34);
            this.label8.TabIndex = 175;
            this.label8.Text = "Porto";
            // 
            // comboBoxRefazerChaves
            // 
            this.comboBoxRefazerChaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRefazerChaves.FormattingEnabled = true;
            this.comboBoxRefazerChaves.Location = new System.Drawing.Point(580, 556);
            this.comboBoxRefazerChaves.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxRefazerChaves.Name = "comboBoxRefazerChaves";
            this.comboBoxRefazerChaves.Size = new System.Drawing.Size(503, 24);
            this.comboBoxRefazerChaves.TabIndex = 178;
            // 
            // buttonRefazerChaves
            // 
            this.buttonRefazerChaves.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefazerChaves.Location = new System.Drawing.Point(727, 501);
            this.buttonRefazerChaves.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRefazerChaves.Name = "buttonRefazerChaves";
            this.buttonRefazerChaves.Size = new System.Drawing.Size(237, 43);
            this.buttonRefazerChaves.TabIndex = 177;
            this.buttonRefazerChaves.Text = "Refazer Chaves";
            this.buttonRefazerChaves.UseVisualStyleBackColor = true;
            this.buttonRefazerChaves.Click += new System.EventHandler(this.buttonRefazerChaves_Click);
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
            this.textBoxStatus.TabIndex = 179;
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
            this.textBoxIP.TabIndex = 180;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // wireGuardServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 897);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.comboBoxRefazerChaves);
            this.Controls.Add(this.buttonRefazerChaves);
            this.Controls.Add(this.textBoxPorto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxcommentEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxComentario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCopyPort);
            this.Controls.Add(this.textBoxPortEscuta);
            this.Controls.Add(this.checkBoxDesativoEdit);
            this.Controls.Add(this.checkBoxAtivoEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxAddDesativo);
            this.Controls.Add(this.checkBoxAddAtivo);
            this.Controls.Add(this.labelEstadoAdd);
            this.Controls.Add(this.WireGuardLabel);
            this.Controls.Add(this.comboBoxListPeersServer);
            this.Controls.Add(this.buttonPeersServer);
            this.Controls.Add(this.listBoxPeers);
            this.Controls.Add(this.buttonConfPeers);
            this.Controls.Add(this.buttoneditServer);
            this.Controls.Add(this.buttonelimServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxelimServer);
            this.Controls.Add(this.comboBoxPubKeyServer);
            this.Controls.Add(this.labelNomeEdit);
            this.Controls.Add(this.textBoxEditName);
            this.Controls.Add(this.labelEditPeers);
            this.Controls.Add(this.comboBoxSelectServer);
            this.Controls.Add(this.textBoxNomeAdd);
            this.Controls.Add(this.labelPublicKey);
            this.Controls.Add(this.btnAddServer);
            this.Controls.Add(this.buttonCopyPublicKey);
            this.Controls.Add(this.textBoxPublicKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonkeysObtain);
            this.Controls.Add(this.listBoxServer);
            this.Controls.Add(this.btnAtualizarServidorVPN);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "wireGuardServerForm";
            this.Text = "wireGuardServerForm";
            this.Load += new System.EventHandler(this.wireGuardServerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCopyPublicKey;
        private System.Windows.Forms.TextBox textBoxPublicKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonkeysObtain;
        private System.Windows.Forms.ListBox listBoxServer;
        private System.Windows.Forms.Button btnAtualizarServidorVPN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxNomeAdd;
        private System.Windows.Forms.Label labelPublicKey;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.Label labelNomeEdit;
        private System.Windows.Forms.TextBox textBoxEditName;
        private System.Windows.Forms.Label labelEditPeers;
        private System.Windows.Forms.ComboBox comboBoxSelectServer;
        private System.Windows.Forms.ComboBox comboBoxPubKeyServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxelimServer;
        private System.Windows.Forms.Button buttonelimServer;
        private System.Windows.Forms.Button buttoneditServer;
        private System.Windows.Forms.Button buttonConfPeers;
        private System.Windows.Forms.ListBox listBoxPeers;
        private System.Windows.Forms.Button buttonPeersServer;
        private System.Windows.Forms.ComboBox comboBoxListPeersServer;
        private System.Windows.Forms.Label WireGuardLabel;
        private System.Windows.Forms.CheckBox checkBoxAddDesativo;
        private System.Windows.Forms.CheckBox checkBoxAddAtivo;
        private System.Windows.Forms.Label labelEstadoAdd;
        private System.Windows.Forms.CheckBox checkBoxDesativoEdit;
        private System.Windows.Forms.CheckBox checkBoxAtivoEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPortEscuta;
        private System.Windows.Forms.Button buttonCopyPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.TextBox textBoxComentario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxcommentEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxPorto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxRefazerChaves;
        private System.Windows.Forms.Button buttonRefazerChaves;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}