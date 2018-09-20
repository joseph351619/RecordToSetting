namespace RecordToSetting
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRecordList = new System.Windows.Forms.DataGridView();
            this.dgvSettingList = new System.Windows.Forms.DataGridView();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dtpBeginSearchDate = new System.Windows.Forms.DateTimePicker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecordList
            // 
            this.dgvRecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecordList.Location = new System.Drawing.Point(12, 278);
            this.dgvRecordList.Name = "dgvRecordList";
            this.dgvRecordList.RowTemplate.Height = 24;
            this.dgvRecordList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecordList.Size = new System.Drawing.Size(501, 258);
            this.dgvRecordList.TabIndex = 0;
            this.dgvRecordList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecordList_CellClick);
            // 
            // dgvSettingList
            // 
            this.dgvSettingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettingList.Location = new System.Drawing.Point(541, 278);
            this.dgvSettingList.Name = "dgvSettingList";
            this.dgvSettingList.ReadOnly = true;
            this.dgvSettingList.RowTemplate.Height = 24;
            this.dgvSettingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSettingList.Size = new System.Drawing.Size(437, 258);
            this.dgvSettingList.TabIndex = 1;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(512, 12);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(38, 23);
            this.btnTransfer.TabIndex = 2;
            this.btnTransfer.Text = "→";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(894, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dtpBeginSearchDate
            // 
            this.dtpBeginSearchDate.Location = new System.Drawing.Point(12, 10);
            this.dtpBeginSearchDate.Name = "dtpBeginSearchDate";
            this.dtpBeginSearchDate.Size = new System.Drawing.Size(200, 22);
            this.dtpBeginSearchDate.TabIndex = 4;
            this.dtpBeginSearchDate.ValueChanged += new System.EventHandler(this.dtpBeginSearchDate_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(208, 130);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(595, 130);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 573);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtpBeginSearchDate);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.dgvSettingList);
            this.Controls.Add(this.dgvRecordList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRecordList;
        private System.Windows.Forms.DataGridView dgvSettingList;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DateTimePicker dtpBeginSearchDate;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

