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
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.lstQueries = new System.Windows.Forms.ListBox();
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
            this.mainDataGridView.Location = new System.Drawing.Point(13, 12);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(846, 248);
            this.mainDataGridView.TabIndex = 1;
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.Location = new System.Drawing.Point(784, 266);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(75, 38);
            this.btnUpdateTable.TabIndex = 5;
            this.btnUpdateTable.Text = "Update Cell";
            this.btnUpdateTable.UseVisualStyleBackColor = true;
            this.btnUpdateTable.Click += new System.EventHandler(this.btnUpdateTable_Click);
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
            // lstQueries
            // 
            this.lstQueries.FormattingEnabled = true;
            this.lstQueries.Items.AddRange(new object[] {
            "Вывести всех студентов, которые учатся на Системной инженерии",
            "Вывести всех студентов, которые учатся только на 5",
            "Вывести студентов, которые опоздали 17 мая"});
            this.lstQueries.Location = new System.Drawing.Point(154, 393);
            this.lstQueries.Name = "lstQueries";
            this.lstQueries.Size = new System.Drawing.Size(353, 82);
            this.lstQueries.TabIndex = 14;
            this.lstQueries.SelectedIndexChanged += new System.EventHandler(this.lstQueries_SelectedIndexChanged);
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
            this.label2.Text = "Queries:";
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
            this.Controls.Add(this.lstQueries);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.lstTables);
            this.Controls.Add(this.btnUpdateTable);
            this.Controls.Add(this.mainDataGridView);
            this.Name = "MainForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.ListBox lstQueries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

