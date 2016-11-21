namespace ClientApp.Forms
{
    partial class MainForm
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
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnSelectTable = new System.Windows.Forms.Button();
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.btnQuery1 = new System.Windows.Forms.Button();
            this.btnQuery2 = new System.Windows.Forms.Button();
            this.btnQuery3 = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.txtEdit = new System.Windows.Forms.TextBox();
            this.lblNewValue = new System.Windows.Forms.Label();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.lstQuaries = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.AllowUserToOrderColumns = true;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(13, 29);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(846, 231);
            this.mainDataGridView.TabIndex = 1;
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.Enabled = false;
            this.cmbTables.Location = new System.Drawing.Point(643, 331);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(121, 21);
            this.cmbTables.TabIndex = 2;
            // 
            // btnSelectTable
            // 
            this.btnSelectTable.Location = new System.Drawing.Point(770, 331);
            this.btnSelectTable.Name = "btnSelectTable";
            this.btnSelectTable.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTable.TabIndex = 3;
            this.btnSelectTable.Text = "Select Table";
            this.btnSelectTable.UseVisualStyleBackColor = true;
            this.btnSelectTable.Click += new System.EventHandler(this.btnSelectTable_Click);
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.Location = new System.Drawing.Point(784, 266);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(75, 38);
            this.btnUpdateTable.TabIndex = 5;
            this.btnUpdateTable.Text = "Update Table";
            this.btnUpdateTable.UseVisualStyleBackColor = true;
            this.btnUpdateTable.Click += new System.EventHandler(this.btnUpdateTable_Click);
            // 
            // btnQuery1
            // 
            this.btnQuery1.Location = new System.Drawing.Point(643, 358);
            this.btnQuery1.Name = "btnQuery1";
            this.btnQuery1.Size = new System.Drawing.Size(75, 23);
            this.btnQuery1.TabIndex = 6;
            this.btnQuery1.Text = "Query #1";
            this.btnQuery1.UseVisualStyleBackColor = true;
            this.btnQuery1.Click += new System.EventHandler(this.btnQuery1_Click);
            // 
            // btnQuery2
            // 
            this.btnQuery2.Location = new System.Drawing.Point(643, 387);
            this.btnQuery2.Name = "btnQuery2";
            this.btnQuery2.Size = new System.Drawing.Size(75, 23);
            this.btnQuery2.TabIndex = 7;
            this.btnQuery2.Text = "Query #2";
            this.btnQuery2.UseVisualStyleBackColor = true;
            this.btnQuery2.Click += new System.EventHandler(this.btnQuery2_Click);
            // 
            // btnQuery3
            // 
            this.btnQuery3.Location = new System.Drawing.Point(643, 416);
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
            this.txtEdit.Location = new System.Drawing.Point(685, 276);
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.Size = new System.Drawing.Size(93, 20);
            this.txtEdit.TabIndex = 10;
            // 
            // lblNewValue
            // 
            this.lblNewValue.AutoSize = true;
            this.lblNewValue.Location = new System.Drawing.Point(618, 279);
            this.lblNewValue.Name = "lblNewValue";
            this.lblNewValue.Size = new System.Drawing.Size(61, 13);
            this.lblNewValue.TabIndex = 11;
            this.lblNewValue.Text = "New value:";
            // 
            // lstTables
            // 
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(12, 289);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(135, 186);
            this.lstTables.TabIndex = 12;
            this.lstTables.SelectedIndexChanged += new System.EventHandler(this.lstTables_SelectedIndexChanged);
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Items.AddRange(new object[] {
            "Вывести студентов с нарушениями",
            "Вывести студентов по группам и специальностям",
            "Вывести средние оценки студентов"});
            this.lstTags.Location = new System.Drawing.Point(153, 289);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(354, 82);
            this.lstTags.TabIndex = 13;
            this.lstTags.SelectedIndexChanged += new System.EventHandler(this.lstTags_SelectedIndexChanged);
            // 
            // lstQuaries
            // 
            this.lstQuaries.FormattingEnabled = true;
            this.lstQuaries.Items.AddRange(new object[] {
            "Вывести всех студентов, которые учатся на Системной инженерии",
            "Вывести всех студентов, которые учатся только на 5",
            "Вывести студентов, которые опоздали 17 мая"});
            this.lstQuaries.Location = new System.Drawing.Point(154, 393);
            this.lstQuaries.Name = "lstQuaries";
            this.lstQuaries.Size = new System.Drawing.Size(353, 82);
            this.lstQuaries.TabIndex = 14;
            this.lstQuaries.SelectedIndexChanged += new System.EventHandler(this.lstQuaries_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tags:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Quaries:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tables:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 482);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstQuaries);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.lstTables);
            this.Controls.Add(this.lblNewValue);
            this.Controls.Add(this.txtEdit);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnQuery3);
            this.Controls.Add(this.btnQuery2);
            this.Controls.Add(this.btnQuery1);
            this.Controls.Add(this.btnUpdateTable);
            this.Controls.Add(this.btnSelectTable);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.mainDataGridView);
            this.Name = "MainForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnSelectTable;
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.Button btnQuery1;
        private System.Windows.Forms.Button btnQuery2;
        private System.Windows.Forms.Button btnQuery3;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtEdit;
        private System.Windows.Forms.Label lblNewValue;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.ListBox lstQuaries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

