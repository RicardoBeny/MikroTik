namespace AppLTI
{
    partial class endIPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(endIPForm));
            this.checkBoxEditDesativa = new System.Windows.Forms.CheckBox();
            this.checkBoxEditAtiva = new System.Windows.Forms.CheckBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxSim = new System.Windows.Forms.CheckBox();
            this.checkBoxNão = new System.Windows.Forms.CheckBox();
            this.textBoxEditNetwork = new System.Windows.Forms.TextBox();
            this.labelNetworkEdit = new System.Windows.Forms.Label();
            this.textBoxEditIPAddress = new System.Windows.Forms.TextBox();
            this.labelIPaddEdit = new System.Windows.Forms.Label();
            this.labelEliminarIP = new System.Windows.Forms.Label();
            this.labelEditIP = new System.Windows.Forms.Label();
            this.labelNetwork = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.textBoxNetwork = new System.Windows.Forms.TextBox();
            this.textBoxEndIP = new System.Windows.Forms.TextBox();
            this.comboBoxElimIP = new System.Windows.Forms.ComboBox();
            this.btnEditEndIP = new System.Windows.Forms.Button();
            this.btnAddEndIP = new System.Windows.Forms.Button();
            this.btnDeleteEndIP = new System.Windows.Forms.Button();
            this.comboBoxSelectIP = new System.Windows.Forms.ComboBox();
            this.btnLoadIP = new System.Windows.Forms.Button();
            this.listBoxEnderecosIP = new System.Windows.Forms.ListBox();
            this.endIPLabel = new System.Windows.Forms.Label();
            this.labelInterface = new System.Windows.Forms.Label();
            this.comboBoxInterfaces = new System.Windows.Forms.ComboBox();
            this.btnAtualizarInt = new System.Windows.Forms.Button();
            this.labelEditInterface = new System.Windows.Forms.Label();
            this.comboBoxEditInterface = new System.Windows.Forms.ComboBox();
            this.listBoxInterfaces = new System.Windows.Forms.ListBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxComentarioAdd = new System.Windows.Forms.TextBox();
            this.textBoxComentEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxEditDesativa
            // 
            this.checkBoxEditDesativa.AutoSize = true;
            this.checkBoxEditDesativa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxEditDesativa.ForeColor = System.Drawing.Color.White;
            this.checkBoxEditDesativa.Location = new System.Drawing.Point(690, 337);
            this.checkBoxEditDesativa.Name = "checkBoxEditDesativa";
            this.checkBoxEditDesativa.Size = new System.Drawing.Size(80, 17);
            this.checkBoxEditDesativa.TabIndex = 48;
            this.checkBoxEditDesativa.Text = "Desativado";
            this.checkBoxEditDesativa.UseVisualStyleBackColor = false;
            // 
            // checkBoxEditAtiva
            // 
            this.checkBoxEditAtiva.AutoSize = true;
            this.checkBoxEditAtiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxEditAtiva.ForeColor = System.Drawing.Color.White;
            this.checkBoxEditAtiva.Location = new System.Drawing.Point(623, 338);
            this.checkBoxEditAtiva.Name = "checkBoxEditAtiva";
            this.checkBoxEditAtiva.Size = new System.Drawing.Size(50, 17);
            this.checkBoxEditAtiva.TabIndex = 47;
            this.checkBoxEditAtiva.Text = "Ativo";
            this.checkBoxEditAtiva.UseVisualStyleBackColor = false;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEstado.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.White;
            this.labelEstado.Location = new System.Drawing.Point(510, 335);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(104, 23);
            this.labelEstado.TabIndex = 46;
            this.labelEstado.Text = "Estado do IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 674);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 45;
            this.label3.Text = "Ativa?";
            // 
            // checkBoxSim
            // 
            this.checkBoxSim.AutoSize = true;
            this.checkBoxSim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxSim.Location = new System.Drawing.Point(130, 674);
            this.checkBoxSim.Name = "checkBoxSim";
            this.checkBoxSim.Size = new System.Drawing.Size(43, 17);
            this.checkBoxSim.TabIndex = 44;
            this.checkBoxSim.Text = "Sim";
            this.checkBoxSim.UseVisualStyleBackColor = false;
            // 
            // checkBoxNão
            // 
            this.checkBoxNão.AutoSize = true;
            this.checkBoxNão.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxNão.Location = new System.Drawing.Point(194, 674);
            this.checkBoxNão.Name = "checkBoxNão";
            this.checkBoxNão.Size = new System.Drawing.Size(46, 17);
            this.checkBoxNão.TabIndex = 43;
            this.checkBoxNão.Text = "Não";
            this.checkBoxNão.UseVisualStyleBackColor = false;
            // 
            // textBoxEditNetwork
            // 
            this.textBoxEditNetwork.Location = new System.Drawing.Point(622, 211);
            this.textBoxEditNetwork.Name = "textBoxEditNetwork";
            this.textBoxEditNetwork.Size = new System.Drawing.Size(239, 20);
            this.textBoxEditNetwork.TabIndex = 42;
            // 
            // labelNetworkEdit
            // 
            this.labelNetworkEdit.AutoSize = true;
            this.labelNetworkEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNetworkEdit.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNetworkEdit.ForeColor = System.Drawing.Color.White;
            this.labelNetworkEdit.Location = new System.Drawing.Point(510, 208);
            this.labelNetworkEdit.Name = "labelNetworkEdit";
            this.labelNetworkEdit.Size = new System.Drawing.Size(75, 23);
            this.labelNetworkEdit.TabIndex = 41;
            this.labelNetworkEdit.Text = "Network";
            // 
            // textBoxEditIPAddress
            // 
            this.textBoxEditIPAddress.Location = new System.Drawing.Point(623, 166);
            this.textBoxEditIPAddress.Name = "textBoxEditIPAddress";
            this.textBoxEditIPAddress.Size = new System.Drawing.Size(238, 20);
            this.textBoxEditIPAddress.TabIndex = 40;
            // 
            // labelIPaddEdit
            // 
            this.labelIPaddEdit.AutoSize = true;
            this.labelIPaddEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelIPaddEdit.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIPaddEdit.ForeColor = System.Drawing.Color.White;
            this.labelIPaddEdit.Location = new System.Drawing.Point(510, 161);
            this.labelIPaddEdit.Name = "labelIPaddEdit";
            this.labelIPaddEdit.Size = new System.Drawing.Size(102, 23);
            this.labelIPaddEdit.TabIndex = 39;
            this.labelIPaddEdit.Text = "Endereço IP";
            // 
            // labelEliminarIP
            // 
            this.labelEliminarIP.AutoSize = true;
            this.labelEliminarIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEliminarIP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEliminarIP.ForeColor = System.Drawing.Color.White;
            this.labelEliminarIP.Location = new System.Drawing.Point(998, 83);
            this.labelEliminarIP.Name = "labelEliminarIP";
            this.labelEliminarIP.Size = new System.Drawing.Size(102, 26);
            this.labelEliminarIP.TabIndex = 38;
            this.labelEliminarIP.Text = "Eliminar IP";
            // 
            // labelEditIP
            // 
            this.labelEditIP.AutoSize = true;
            this.labelEditIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEditIP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditIP.ForeColor = System.Drawing.Color.White;
            this.labelEditIP.Location = new System.Drawing.Point(617, 83);
            this.labelEditIP.Name = "labelEditIP";
            this.labelEditIP.Size = new System.Drawing.Size(83, 26);
            this.labelEditIP.TabIndex = 37;
            this.labelEditIP.Text = "Editar IP";
            // 
            // labelNetwork
            // 
            this.labelNetwork.AutoSize = true;
            this.labelNetwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNetwork.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNetwork.ForeColor = System.Drawing.Color.White;
            this.labelNetwork.Location = new System.Drawing.Point(22, 568);
            this.labelNetwork.Name = "labelNetwork";
            this.labelNetwork.Size = new System.Drawing.Size(75, 23);
            this.labelNetwork.TabIndex = 36;
            this.labelNetwork.Text = "Network";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelIPAddress.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIPAddress.ForeColor = System.Drawing.Color.White;
            this.labelIPAddress.Location = new System.Drawing.Point(22, 530);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(102, 23);
            this.labelIPAddress.TabIndex = 35;
            this.labelIPAddress.Text = "Endereço IP";
            // 
            // textBoxNetwork
            // 
            this.textBoxNetwork.Location = new System.Drawing.Point(130, 571);
            this.textBoxNetwork.Name = "textBoxNetwork";
            this.textBoxNetwork.Size = new System.Drawing.Size(372, 20);
            this.textBoxNetwork.TabIndex = 34;
            // 
            // textBoxEndIP
            // 
            this.textBoxEndIP.Location = new System.Drawing.Point(130, 533);
            this.textBoxEndIP.Name = "textBoxEndIP";
            this.textBoxEndIP.Size = new System.Drawing.Size(372, 20);
            this.textBoxEndIP.TabIndex = 33;
            // 
            // comboBoxElimIP
            // 
            this.comboBoxElimIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxElimIP.FormattingEnabled = true;
            this.comboBoxElimIP.Location = new System.Drawing.Point(878, 117);
            this.comboBoxElimIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxElimIP.Name = "comboBoxElimIP";
            this.comboBoxElimIP.Size = new System.Drawing.Size(362, 21);
            this.comboBoxElimIP.TabIndex = 32;
            // 
            // btnEditEndIP
            // 
            this.btnEditEndIP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditEndIP.Location = new System.Drawing.Point(571, 364);
            this.btnEditEndIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditEndIP.Name = "btnEditEndIP";
            this.btnEditEndIP.Size = new System.Drawing.Size(217, 36);
            this.btnEditEndIP.TabIndex = 31;
            this.btnEditEndIP.Text = "Editar Endereço IP";
            this.btnEditEndIP.UseVisualStyleBackColor = true;
            this.btnEditEndIP.Click += new System.EventHandler(this.btnEditEndIP_Click);
            // 
            // btnAddEndIP
            // 
            this.btnAddEndIP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEndIP.Location = new System.Drawing.Point(26, 480);
            this.btnAddEndIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddEndIP.Name = "btnAddEndIP";
            this.btnAddEndIP.Size = new System.Drawing.Size(214, 33);
            this.btnAddEndIP.TabIndex = 30;
            this.btnAddEndIP.Text = "Adicionar Endereço IP";
            this.btnAddEndIP.UseVisualStyleBackColor = true;
            this.btnAddEndIP.Click += new System.EventHandler(this.btnAddEndIP_Click);
            // 
            // btnDeleteEndIP
            // 
            this.btnDeleteEndIP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEndIP.Location = new System.Drawing.Point(956, 156);
            this.btnDeleteEndIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteEndIP.Name = "btnDeleteEndIP";
            this.btnDeleteEndIP.Size = new System.Drawing.Size(212, 34);
            this.btnDeleteEndIP.TabIndex = 29;
            this.btnDeleteEndIP.Text = "Eliminar Endereço IP";
            this.btnDeleteEndIP.UseVisualStyleBackColor = true;
            this.btnDeleteEndIP.Click += new System.EventHandler(this.btnDeleteRotas_Click);
            // 
            // comboBoxSelectIP
            // 
            this.comboBoxSelectIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectIP.FormattingEnabled = true;
            this.comboBoxSelectIP.Location = new System.Drawing.Point(514, 117);
            this.comboBoxSelectIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxSelectIP.Name = "comboBoxSelectIP";
            this.comboBoxSelectIP.Size = new System.Drawing.Size(347, 21);
            this.comboBoxSelectIP.TabIndex = 28;
            this.comboBoxSelectIP.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectIP_SelectedIndexChanged);
            // 
            // btnLoadIP
            // 
            this.btnLoadIP.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadIP.Location = new System.Drawing.Point(26, 78);
            this.btnLoadIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadIP.Name = "btnLoadIP";
            this.btnLoadIP.Size = new System.Drawing.Size(476, 37);
            this.btnLoadIP.TabIndex = 27;
            this.btnLoadIP.Text = "Listar Todos os Endereços IP";
            this.btnLoadIP.UseVisualStyleBackColor = true;
            this.btnLoadIP.Click += new System.EventHandler(this.btnLoadIP_Click);
            // 
            // listBoxEnderecosIP
            // 
            this.listBoxEnderecosIP.FormattingEnabled = true;
            this.listBoxEnderecosIP.Location = new System.Drawing.Point(26, 117);
            this.listBoxEnderecosIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxEnderecosIP.Name = "listBoxEnderecosIP";
            this.listBoxEnderecosIP.Size = new System.Drawing.Size(476, 342);
            this.listBoxEnderecosIP.TabIndex = 26;
            // 
            // endIPLabel
            // 
            this.endIPLabel.AutoSize = true;
            this.endIPLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.endIPLabel.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endIPLabel.ForeColor = System.Drawing.Color.White;
            this.endIPLabel.Location = new System.Drawing.Point(525, 9);
            this.endIPLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.endIPLabel.Name = "endIPLabel";
            this.endIPLabel.Size = new System.Drawing.Size(216, 43);
            this.endIPLabel.TabIndex = 25;
            this.endIPLabel.Text = "Endereços IP";
            // 
            // labelInterface
            // 
            this.labelInterface.AutoSize = true;
            this.labelInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelInterface.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInterface.ForeColor = System.Drawing.Color.White;
            this.labelInterface.Location = new System.Drawing.Point(22, 604);
            this.labelInterface.Name = "labelInterface";
            this.labelInterface.Size = new System.Drawing.Size(167, 23);
            this.labelInterface.TabIndex = 49;
            this.labelInterface.Text = "Interface Associada";
            // 
            // comboBoxInterfaces
            // 
            this.comboBoxInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterfaces.FormattingEnabled = true;
            this.comboBoxInterfaces.Location = new System.Drawing.Point(195, 609);
            this.comboBoxInterfaces.Name = "comboBoxInterfaces";
            this.comboBoxInterfaces.Size = new System.Drawing.Size(307, 21);
            this.comboBoxInterfaces.TabIndex = 50;
            // 
            // btnAtualizarInt
            // 
            this.btnAtualizarInt.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarInt.Location = new System.Drawing.Point(956, 364);
            this.btnAtualizarInt.Name = "btnAtualizarInt";
            this.btnAtualizarInt.Size = new System.Drawing.Size(214, 33);
            this.btnAtualizarInt.TabIndex = 51;
            this.btnAtualizarInt.Text = "Atualizar Interfaces";
            this.btnAtualizarInt.UseVisualStyleBackColor = true;
            this.btnAtualizarInt.Click += new System.EventHandler(this.btnAtualizarInt_Click);
            // 
            // labelEditInterface
            // 
            this.labelEditInterface.AutoSize = true;
            this.labelEditInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEditInterface.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditInterface.ForeColor = System.Drawing.Color.White;
            this.labelEditInterface.Location = new System.Drawing.Point(510, 253);
            this.labelEditInterface.Name = "labelEditInterface";
            this.labelEditInterface.Size = new System.Drawing.Size(167, 23);
            this.labelEditInterface.TabIndex = 52;
            this.labelEditInterface.Text = "Interface Associada";
            // 
            // comboBoxEditInterface
            // 
            this.comboBoxEditInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditInterface.FormattingEnabled = true;
            this.comboBoxEditInterface.Location = new System.Drawing.Point(683, 253);
            this.comboBoxEditInterface.Name = "comboBoxEditInterface";
            this.comboBoxEditInterface.Size = new System.Drawing.Size(178, 21);
            this.comboBoxEditInterface.TabIndex = 53;
            // 
            // listBoxInterfaces
            // 
            this.listBoxInterfaces.FormattingEnabled = true;
            this.listBoxInterfaces.Location = new System.Drawing.Point(915, 403);
            this.listBoxInterfaces.Name = "listBoxInterfaces";
            this.listBoxInterfaces.Size = new System.Drawing.Size(301, 251);
            this.listBoxInterfaces.TabIndex = 55;
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1200, 11);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(39, 41);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 114;
            this.pictureUsername.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 637);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 115;
            this.label1.Text = "Comentario";
            // 
            // textBoxComentarioAdd
            // 
            this.textBoxComentarioAdd.Location = new System.Drawing.Point(130, 643);
            this.textBoxComentarioAdd.Name = "textBoxComentarioAdd";
            this.textBoxComentarioAdd.Size = new System.Drawing.Size(372, 20);
            this.textBoxComentarioAdd.TabIndex = 116;
            // 
            // textBoxComentEdit
            // 
            this.textBoxComentEdit.Location = new System.Drawing.Point(618, 298);
            this.textBoxComentEdit.Name = "textBoxComentEdit";
            this.textBoxComentEdit.Size = new System.Drawing.Size(243, 20);
            this.textBoxComentEdit.TabIndex = 118;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(510, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 117;
            this.label2.Text = "Comentario";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 136;
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
            this.textBoxStatus.Location = new System.Drawing.Point(12, 701);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(954, 16);
            this.textBoxStatus.TabIndex = 137;
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
            this.textBoxIP.TabIndex = 138;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1266, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // endIPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1250, 729);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxComentEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxComentarioAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.listBoxInterfaces);
            this.Controls.Add(this.comboBoxEditInterface);
            this.Controls.Add(this.labelEditInterface);
            this.Controls.Add(this.btnAtualizarInt);
            this.Controls.Add(this.comboBoxInterfaces);
            this.Controls.Add(this.labelInterface);
            this.Controls.Add(this.checkBoxEditDesativa);
            this.Controls.Add(this.checkBoxEditAtiva);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxSim);
            this.Controls.Add(this.checkBoxNão);
            this.Controls.Add(this.textBoxEditNetwork);
            this.Controls.Add(this.labelNetworkEdit);
            this.Controls.Add(this.textBoxEditIPAddress);
            this.Controls.Add(this.labelIPaddEdit);
            this.Controls.Add(this.labelEliminarIP);
            this.Controls.Add(this.labelEditIP);
            this.Controls.Add(this.labelNetwork);
            this.Controls.Add(this.labelIPAddress);
            this.Controls.Add(this.textBoxNetwork);
            this.Controls.Add(this.textBoxEndIP);
            this.Controls.Add(this.comboBoxElimIP);
            this.Controls.Add(this.btnEditEndIP);
            this.Controls.Add(this.btnAddEndIP);
            this.Controls.Add(this.btnDeleteEndIP);
            this.Controls.Add(this.comboBoxSelectIP);
            this.Controls.Add(this.btnLoadIP);
            this.Controls.Add(this.listBoxEnderecosIP);
            this.Controls.Add(this.endIPLabel);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "endIPForm";
            this.Text = "endIPForm";
            this.Load += new System.EventHandler(this.endIPForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxEditDesativa;
        private System.Windows.Forms.CheckBox checkBoxEditAtiva;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxSim;
        private System.Windows.Forms.CheckBox checkBoxNão;
        private System.Windows.Forms.TextBox textBoxEditNetwork;
        private System.Windows.Forms.Label labelNetworkEdit;
        private System.Windows.Forms.TextBox textBoxEditIPAddress;
        private System.Windows.Forms.Label labelIPaddEdit;
        private System.Windows.Forms.Label labelEliminarIP;
        private System.Windows.Forms.Label labelEditIP;
        private System.Windows.Forms.Label labelNetwork;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.TextBox textBoxNetwork;
        private System.Windows.Forms.TextBox textBoxEndIP;
        private System.Windows.Forms.ComboBox comboBoxElimIP;
        private System.Windows.Forms.Button btnEditEndIP;
        private System.Windows.Forms.Button btnAddEndIP;
        private System.Windows.Forms.Button btnDeleteEndIP;
        private System.Windows.Forms.ComboBox comboBoxSelectIP;
        private System.Windows.Forms.Button btnLoadIP;
        private System.Windows.Forms.ListBox listBoxEnderecosIP;
        private System.Windows.Forms.Label endIPLabel;
        private System.Windows.Forms.Label labelInterface;
        private System.Windows.Forms.ComboBox comboBoxInterfaces;
        private System.Windows.Forms.Button btnAtualizarInt;
        private System.Windows.Forms.Label labelEditInterface;
        private System.Windows.Forms.ListBox listBoxInterfaces;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxComentarioAdd;
        private System.Windows.Forms.TextBox textBoxComentEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEditInterface;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}