namespace AppLTI
{
    partial class interfaces
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(interfaces));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInterfacesN = new System.Windows.Forms.Button();
            this.interfacesLabel = new System.Windows.Forms.Label();
            this.listBoxInterfaces = new System.Windows.Forms.ListBox();
            this.btnWireless = new System.Windows.Forms.Button();
            this.listBoxWireless = new System.Windows.Forms.ListBox();
            this.btnBridge = new System.Windows.Forms.Button();
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
            this.pictureBox1.Location = new System.Drawing.Point(-12, -37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1688, 945);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnInterfacesN
            // 
            this.btnInterfacesN.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterfacesN.Location = new System.Drawing.Point(59, 122);
            this.btnInterfacesN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInterfacesN.Name = "btnInterfacesN";
            this.btnInterfacesN.Size = new System.Drawing.Size(564, 58);
            this.btnInterfacesN.TabIndex = 1;
            this.btnInterfacesN.Text = "Listar Todas as Interfaces";
            this.btnInterfacesN.UseVisualStyleBackColor = true;
            this.btnInterfacesN.Click += new System.EventHandler(this.btnInterfacesN_Click);
            // 
            // interfacesLabel
            // 
            this.interfacesLabel.AutoSize = true;
            this.interfacesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.interfacesLabel.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfacesLabel.ForeColor = System.Drawing.Color.White;
            this.interfacesLabel.Location = new System.Drawing.Point(720, 25);
            this.interfacesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.interfacesLabel.Name = "interfacesLabel";
            this.interfacesLabel.Size = new System.Drawing.Size(220, 54);
            this.interfacesLabel.TabIndex = 2;
            this.interfacesLabel.Text = "Interfaces";
            // 
            // listBoxInterfaces
            // 
            this.listBoxInterfaces.FormattingEnabled = true;
            this.listBoxInterfaces.ItemHeight = 16;
            this.listBoxInterfaces.Location = new System.Drawing.Point(59, 220);
            this.listBoxInterfaces.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxInterfaces.Name = "listBoxInterfaces";
            this.listBoxInterfaces.Size = new System.Drawing.Size(563, 628);
            this.listBoxInterfaces.TabIndex = 3;
            // 
            // btnWireless
            // 
            this.btnWireless.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWireless.Location = new System.Drawing.Point(668, 122);
            this.btnWireless.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWireless.Name = "btnWireless";
            this.btnWireless.Size = new System.Drawing.Size(564, 58);
            this.btnWireless.TabIndex = 4;
            this.btnWireless.Text = "Listar Todas as Interfaces Wireless";
            this.btnWireless.UseVisualStyleBackColor = true;
            this.btnWireless.Click += new System.EventHandler(this.btnWireless_Click);
            // 
            // listBoxWireless
            // 
            this.listBoxWireless.FormattingEnabled = true;
            this.listBoxWireless.ItemHeight = 16;
            this.listBoxWireless.Location = new System.Drawing.Point(668, 220);
            this.listBoxWireless.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxWireless.Name = "listBoxWireless";
            this.listBoxWireless.Size = new System.Drawing.Size(563, 628);
            this.listBoxWireless.TabIndex = 5;
            // 
            // btnBridge
            // 
            this.btnBridge.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBridge.Location = new System.Drawing.Point(1279, 447);
            this.btnBridge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBridge.Name = "btnBridge";
            this.btnBridge.Size = new System.Drawing.Size(372, 47);
            this.btnBridge.TabIndex = 6;
            this.btnBridge.Text = "Interfaces Bridge";
            this.btnBridge.UseVisualStyleBackColor = true;
            this.btnBridge.Click += new System.EventHandler(this.btnBridge_Click);
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1600, 14);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(52, 50);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 117;
            this.pictureUsername.TabStop = false;
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
            this.pictureBox2.TabIndex = 133;
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
            this.textBoxStatus.TabIndex = 138;
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
            this.textBoxIP.TabIndex = 139;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // interfaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1667, 897);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.btnBridge);
            this.Controls.Add(this.listBoxWireless);
            this.Controls.Add(this.btnWireless);
            this.Controls.Add(this.listBoxInterfaces);
            this.Controls.Add(this.interfacesLabel);
            this.Controls.Add(this.btnInterfacesN);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "interfaces";
            this.Text = "Interfaces";
            this.Load += new System.EventHandler(this.interfaces_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInterfacesN;
        private System.Windows.Forms.Label interfacesLabel;
        private System.Windows.Forms.ListBox listBoxInterfaces;
        private System.Windows.Forms.Button btnWireless;
        private System.Windows.Forms.ListBox listBoxWireless;
        private System.Windows.Forms.Button btnBridge;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}