namespace ClientApp
{
    partial class Form1
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
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnSelectTable = new System.Windows.Forms.Button();
            this.btnDisconnectServer = new System.Windows.Forms.Button();
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.btnQuery1 = new System.Windows.Forms.Button();
            this.btnQuery2 = new System.Windows.Forms.Button();
            this.btnQuery3 = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.txtEdit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Location = new System.Drawing.Point(624, 495);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(75, 38);
            this.btnConnectServer.TabIndex = 0;
            this.btnConnectServer.Text = "Connect To Server";
            this.btnConnectServer.UseVisualStyleBackColor = true;
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(13, 29);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(767, 389);
            this.mainDataGridView.TabIndex = 1;
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.Location = new System.Drawing.Point(13, 425);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(121, 21);
            this.cmbTables.TabIndex = 2;
            // 
            // btnSelectTable
            // 
            this.btnSelectTable.Enabled = false;
            this.btnSelectTable.Location = new System.Drawing.Point(140, 425);
            this.btnSelectTable.Name = "btnSelectTable";
            this.btnSelectTable.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTable.TabIndex = 3;
            this.btnSelectTable.Text = "Select Table";
            this.btnSelectTable.UseVisualStyleBackColor = true;
            this.btnSelectTable.Click += new System.EventHandler(this.btnSelectTable_Click);
            // 
            // btnDisconnectServer
            // 
            this.btnDisconnectServer.Enabled = false;
            this.btnDisconnectServer.Location = new System.Drawing.Point(705, 495);
            this.btnDisconnectServer.Name = "btnDisconnectServer";
            this.btnDisconnectServer.Size = new System.Drawing.Size(75, 38);
            this.btnDisconnectServer.TabIndex = 4;
            this.btnDisconnectServer.Text = "Disconect from Server";
            this.btnDisconnectServer.UseVisualStyleBackColor = true;
            this.btnDisconnectServer.Click += new System.EventHandler(this.btnDisconnectServer_Click);
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.Enabled = false;
            this.btnUpdateTable.Location = new System.Drawing.Point(705, 425);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(75, 38);
            this.btnUpdateTable.TabIndex = 5;
            this.btnUpdateTable.Text = "Update Table";
            this.btnUpdateTable.UseVisualStyleBackColor = true;
            this.btnUpdateTable.Click += new System.EventHandler(this.btnUpdateTable_Click);
            // 
            // btnQuery1
            // 
            this.btnQuery1.Enabled = false;
            this.btnQuery1.Location = new System.Drawing.Point(13, 452);
            this.btnQuery1.Name = "btnQuery1";
            this.btnQuery1.Size = new System.Drawing.Size(75, 23);
            this.btnQuery1.TabIndex = 6;
            this.btnQuery1.Text = "Query #1";
            this.btnQuery1.UseVisualStyleBackColor = true;
            this.btnQuery1.Click += new System.EventHandler(this.btnQuery1_Click);
            // 
            // btnQuery2
            // 
            this.btnQuery2.Enabled = false;
            this.btnQuery2.Location = new System.Drawing.Point(13, 481);
            this.btnQuery2.Name = "btnQuery2";
            this.btnQuery2.Size = new System.Drawing.Size(75, 23);
            this.btnQuery2.TabIndex = 7;
            this.btnQuery2.Text = "Query #2";
            this.btnQuery2.UseVisualStyleBackColor = true;
            this.btnQuery2.Click += new System.EventHandler(this.btnQuery2_Click);
            // 
            // btnQuery3
            // 
            this.btnQuery3.Enabled = false;
            this.btnQuery3.Location = new System.Drawing.Point(13, 510);
            this.btnQuery3.Name = "btnQuery3";
            this.btnQuery3.Size = new System.Drawing.Size(75, 23);
            this.btnQuery3.TabIndex = 8;
            this.btnQuery3.Text = "Query #3";
            this.btnQuery3.UseVisualStyleBackColor = true;
            this.btnQuery3.Click += new System.EventHandler(this.btnQuery3_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(13, 13);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(40, 13);
            this.lblText.TabIndex = 9;
            this.lblText.Text = "Table: ";
            // 
            // txtEdit
            // 
            this.txtEdit.Location = new System.Drawing.Point(599, 435);
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.Size = new System.Drawing.Size(100, 20);
            this.txtEdit.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 545);
            this.Controls.Add(this.txtEdit);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnQuery3);
            this.Controls.Add(this.btnQuery2);
            this.Controls.Add(this.btnQuery1);
            this.Controls.Add(this.btnUpdateTable);
            this.Controls.Add(this.btnDisconnectServer);
            this.Controls.Add(this.btnSelectTable);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.btnConnectServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnSelectTable;
        private System.Windows.Forms.Button btnDisconnectServer;
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.Button btnQuery1;
        private System.Windows.Forms.Button btnQuery2;
        private System.Windows.Forms.Button btnQuery3;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtEdit;
    }
}

