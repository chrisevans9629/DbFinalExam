namespace DbFinalExam
{
    partial class SalesReport
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelSales = new System.Windows.Forms.Label();
            this.labelEstimates = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelProfit = new System.Windows.Forms.Label();
            this.labelEstCost = new System.Windows.Forms.Label();
            this.labelEstProfit = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerTo);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerFrom);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 62;
            this.splitContainer1.TabIndex = 1;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(395, 22);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(165, 22);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(699, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Report";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelSales
            // 
            this.labelSales.AutoSize = true;
            this.labelSales.Location = new System.Drawing.Point(13, 16);
            this.labelSales.Name = "labelSales";
            this.labelSales.Size = new System.Drawing.Size(60, 13);
            this.labelSales.TabIndex = 2;
            this.labelSales.Text = "Total Sales";
            // 
            // labelEstimates
            // 
            this.labelEstimates.AutoSize = true;
            this.labelEstimates.Location = new System.Drawing.Point(13, 40);
            this.labelEstimates.Name = "labelEstimates";
            this.labelEstimates.Size = new System.Drawing.Size(79, 13);
            this.labelEstimates.TabIndex = 3;
            this.labelEstimates.Text = "Total Estimates";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(115, 16);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(55, 13);
            this.labelCost.TabIndex = 4;
            this.labelCost.Text = "Total Cost";
            // 
            // labelProfit
            // 
            this.labelProfit.AutoSize = true;
            this.labelProfit.Location = new System.Drawing.Point(229, 16);
            this.labelProfit.Name = "labelProfit";
            this.labelProfit.Size = new System.Drawing.Size(58, 13);
            this.labelProfit.TabIndex = 5;
            this.labelProfit.Text = "Total Profit";
            // 
            // labelEstCost
            // 
            this.labelEstCost.AutoSize = true;
            this.labelEstCost.Location = new System.Drawing.Point(115, 40);
            this.labelEstCost.Name = "labelEstCost";
            this.labelEstCost.Size = new System.Drawing.Size(98, 13);
            this.labelEstCost.TabIndex = 6;
            this.labelEstCost.Text = "Total Estimate Cost";
            // 
            // labelEstProfit
            // 
            this.labelEstProfit.AutoSize = true;
            this.labelEstProfit.Location = new System.Drawing.Point(229, 40);
            this.labelEstProfit.Name = "labelEstProfit";
            this.labelEstProfit.Size = new System.Drawing.Size(101, 13);
            this.labelEstProfit.TabIndex = 7;
            this.labelEstProfit.Text = "Total Estimate Profit";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.labelSales);
            this.splitContainer2.Panel2.Controls.Add(this.labelEstimates);
            this.splitContainer2.Panel2.Controls.Add(this.labelCost);
            this.splitContainer2.Panel2.Controls.Add(this.labelProfit);
            this.splitContainer2.Panel2.Controls.Add(this.labelEstCost);
            this.splitContainer2.Panel2.Controls.Add(this.labelEstProfit);
            this.splitContainer2.Size = new System.Drawing.Size(800, 384);
            this.splitContainer2.SplitterDistance = 302;
            this.splitContainer2.TabIndex = 8;
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SalesReport";
            this.Text = "SalesReport";
            this.Load += new System.EventHandler(this.SalesReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelEstProfit;
        private System.Windows.Forms.Label labelEstCost;
        private System.Windows.Forms.Label labelProfit;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelEstimates;
        private System.Windows.Forms.Label labelSales;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}