namespace win
{
    partial class ReadyUpload
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instanceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentStatuIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createPersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.annualDemandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lifeCycleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.demoFinishTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testFinishTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smallAmountFinishTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchFinishTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instanceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkResultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noticeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectStatuChangeInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourcePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uploadResponseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadResponseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "上传";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件列表";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(357, 217);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(58, 25);
            this.btnChooseFile.TabIndex = 3;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 248);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(457, 112);
            this.listBox1.TabIndex = 4;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.instanceID,
            this.descriptIDDataGridViewTextBoxColumn,
            this.projectNameDataGridViewTextBoxColumn,
            this.customernameDataGridViewTextBoxColumn,
            this.currentStatuIDDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.createPersonDataGridViewTextBoxColumn,
            this.targetPriceDataGridViewTextBoxColumn,
            this.annualDemandDataGridViewTextBoxColumn,
            this.lifeCycleDataGridViewTextBoxColumn,
            this.paymentMethodDataGridViewTextBoxColumn,
            this.productTypeDataGridViewTextBoxColumn,
            this.demoFinishTimeDataGridViewTextBoxColumn,
            this.testFinishTimeDataGridViewTextBoxColumn,
            this.smallAmountFinishTimeDataGridViewTextBoxColumn,
            this.batchFinishTimeDataGridViewTextBoxColumn,
            this.instanceIDDataGridViewTextBoxColumn,
            this.checkResultDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.noticeDataGridViewTextBoxColumn,
            this.projectStatusDataGridViewTextBoxColumn,
            this.userDataGridViewTextBoxColumn,
            this.projectStatuChangeInfoDataGridViewTextBoxColumn,
            this.resourcePathDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.projectBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(455, 171);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // instanceID
            // 
            this.instanceID.DataPropertyName = "instanceID";
            this.instanceID.HeaderText = "instanceID";
            this.instanceID.Name = "instanceID";
            this.instanceID.ReadOnly = true;
            // 
            // descriptIDDataGridViewTextBoxColumn
            // 
            this.descriptIDDataGridViewTextBoxColumn.DataPropertyName = "descriptID";
            this.descriptIDDataGridViewTextBoxColumn.HeaderText = "descriptID";
            this.descriptIDDataGridViewTextBoxColumn.Name = "descriptIDDataGridViewTextBoxColumn";
            this.descriptIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // projectNameDataGridViewTextBoxColumn
            // 
            this.projectNameDataGridViewTextBoxColumn.DataPropertyName = "projectName";
            this.projectNameDataGridViewTextBoxColumn.HeaderText = "projectName";
            this.projectNameDataGridViewTextBoxColumn.Name = "projectNameDataGridViewTextBoxColumn";
            this.projectNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customernameDataGridViewTextBoxColumn
            // 
            this.customernameDataGridViewTextBoxColumn.DataPropertyName = "customername";
            this.customernameDataGridViewTextBoxColumn.HeaderText = "customername";
            this.customernameDataGridViewTextBoxColumn.Name = "customernameDataGridViewTextBoxColumn";
            this.customernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentStatuIDDataGridViewTextBoxColumn
            // 
            this.currentStatuIDDataGridViewTextBoxColumn.DataPropertyName = "currentStatuID";
            this.currentStatuIDDataGridViewTextBoxColumn.HeaderText = "currentStatuID";
            this.currentStatuIDDataGridViewTextBoxColumn.Name = "currentStatuIDDataGridViewTextBoxColumn";
            this.currentStatuIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createPersonDataGridViewTextBoxColumn
            // 
            this.createPersonDataGridViewTextBoxColumn.DataPropertyName = "createPerson";
            this.createPersonDataGridViewTextBoxColumn.HeaderText = "createPerson";
            this.createPersonDataGridViewTextBoxColumn.Name = "createPersonDataGridViewTextBoxColumn";
            this.createPersonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // targetPriceDataGridViewTextBoxColumn
            // 
            this.targetPriceDataGridViewTextBoxColumn.DataPropertyName = "targetPrice";
            this.targetPriceDataGridViewTextBoxColumn.HeaderText = "targetPrice";
            this.targetPriceDataGridViewTextBoxColumn.Name = "targetPriceDataGridViewTextBoxColumn";
            this.targetPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // annualDemandDataGridViewTextBoxColumn
            // 
            this.annualDemandDataGridViewTextBoxColumn.DataPropertyName = "annualDemand";
            this.annualDemandDataGridViewTextBoxColumn.HeaderText = "annualDemand";
            this.annualDemandDataGridViewTextBoxColumn.Name = "annualDemandDataGridViewTextBoxColumn";
            this.annualDemandDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lifeCycleDataGridViewTextBoxColumn
            // 
            this.lifeCycleDataGridViewTextBoxColumn.DataPropertyName = "lifeCycle";
            this.lifeCycleDataGridViewTextBoxColumn.HeaderText = "lifeCycle";
            this.lifeCycleDataGridViewTextBoxColumn.Name = "lifeCycleDataGridViewTextBoxColumn";
            this.lifeCycleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "paymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "paymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            this.paymentMethodDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productTypeDataGridViewTextBoxColumn
            // 
            this.productTypeDataGridViewTextBoxColumn.DataPropertyName = "productType";
            this.productTypeDataGridViewTextBoxColumn.HeaderText = "productType";
            this.productTypeDataGridViewTextBoxColumn.Name = "productTypeDataGridViewTextBoxColumn";
            this.productTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // demoFinishTimeDataGridViewTextBoxColumn
            // 
            this.demoFinishTimeDataGridViewTextBoxColumn.DataPropertyName = "demoFinishTime";
            this.demoFinishTimeDataGridViewTextBoxColumn.HeaderText = "demoFinishTime";
            this.demoFinishTimeDataGridViewTextBoxColumn.Name = "demoFinishTimeDataGridViewTextBoxColumn";
            this.demoFinishTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testFinishTimeDataGridViewTextBoxColumn
            // 
            this.testFinishTimeDataGridViewTextBoxColumn.DataPropertyName = "testFinishTime";
            this.testFinishTimeDataGridViewTextBoxColumn.HeaderText = "testFinishTime";
            this.testFinishTimeDataGridViewTextBoxColumn.Name = "testFinishTimeDataGridViewTextBoxColumn";
            this.testFinishTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // smallAmountFinishTimeDataGridViewTextBoxColumn
            // 
            this.smallAmountFinishTimeDataGridViewTextBoxColumn.DataPropertyName = "smallAmountFinishTime";
            this.smallAmountFinishTimeDataGridViewTextBoxColumn.HeaderText = "smallAmountFinishTime";
            this.smallAmountFinishTimeDataGridViewTextBoxColumn.Name = "smallAmountFinishTimeDataGridViewTextBoxColumn";
            this.smallAmountFinishTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batchFinishTimeDataGridViewTextBoxColumn
            // 
            this.batchFinishTimeDataGridViewTextBoxColumn.DataPropertyName = "batchFinishTime";
            this.batchFinishTimeDataGridViewTextBoxColumn.HeaderText = "batchFinishTime";
            this.batchFinishTimeDataGridViewTextBoxColumn.Name = "batchFinishTimeDataGridViewTextBoxColumn";
            this.batchFinishTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // instanceIDDataGridViewTextBoxColumn
            // 
            this.instanceIDDataGridViewTextBoxColumn.DataPropertyName = "instanceID";
            this.instanceIDDataGridViewTextBoxColumn.HeaderText = "instanceID";
            this.instanceIDDataGridViewTextBoxColumn.Name = "instanceIDDataGridViewTextBoxColumn";
            this.instanceIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkResultDataGridViewTextBoxColumn
            // 
            this.checkResultDataGridViewTextBoxColumn.DataPropertyName = "checkResult";
            this.checkResultDataGridViewTextBoxColumn.HeaderText = "checkResult";
            this.checkResultDataGridViewTextBoxColumn.Name = "checkResultDataGridViewTextBoxColumn";
            this.checkResultDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "customer";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noticeDataGridViewTextBoxColumn
            // 
            this.noticeDataGridViewTextBoxColumn.DataPropertyName = "notice";
            this.noticeDataGridViewTextBoxColumn.HeaderText = "notice";
            this.noticeDataGridViewTextBoxColumn.Name = "noticeDataGridViewTextBoxColumn";
            this.noticeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // projectStatusDataGridViewTextBoxColumn
            // 
            this.projectStatusDataGridViewTextBoxColumn.DataPropertyName = "projectStatus";
            this.projectStatusDataGridViewTextBoxColumn.HeaderText = "projectStatus";
            this.projectStatusDataGridViewTextBoxColumn.Name = "projectStatusDataGridViewTextBoxColumn";
            this.projectStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.DataPropertyName = "user";
            this.userDataGridViewTextBoxColumn.HeaderText = "user";
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // projectStatuChangeInfoDataGridViewTextBoxColumn
            // 
            this.projectStatuChangeInfoDataGridViewTextBoxColumn.DataPropertyName = "projectStatuChangeInfo";
            this.projectStatuChangeInfoDataGridViewTextBoxColumn.HeaderText = "projectStatuChangeInfo";
            this.projectStatuChangeInfoDataGridViewTextBoxColumn.Name = "projectStatuChangeInfoDataGridViewTextBoxColumn";
            this.projectStatuChangeInfoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resourcePathDataGridViewTextBoxColumn
            // 
            this.resourcePathDataGridViewTextBoxColumn.DataPropertyName = "resourcePath";
            this.resourcePathDataGridViewTextBoxColumn.HeaderText = "resourcePath";
            this.resourcePathDataGridViewTextBoxColumn.Name = "resourcePathDataGridViewTextBoxColumn";
            this.resourcePathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(Model.project);
            // 
            // uploadResponseBindingSource
            // 
            this.uploadResponseBindingSource.DataSource = typeof(win.ResourceService.UploadResponse);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "选择的项目:";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.ForeColor = System.Drawing.Color.Red;
            this.lblProjectName.Location = new System.Drawing.Point(92, 12);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(125, 12);
            this.lblProjectName.TabIndex = 14;
            this.lblProjectName.Text = "未选择(单击选择项目)";
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(12, 385);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(457, 111);
            this.txtInfo.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "备注";
            // 
            // ReadyUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 555);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "ReadyUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上传文件/添加备注";
            this.Load += new System.EventHandler(this.ReadyUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadResponseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.BindingSource uploadResponseBindingSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instanceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentStatuIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createPersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn annualDemandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lifeCycleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn demoFinishTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testFinishTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn smallAmountFinishTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchFinishTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instanceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkResultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noticeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectStatuChangeInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourcePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label3;
    }
}