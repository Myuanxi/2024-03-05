namespace OrderManagementSystem
{
    partial class QueryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblMinAmount;
        private System.Windows.Forms.NumericUpDown nudMinAmount;
        private System.Windows.Forms.Label lblMaxAmount;
        private System.Windows.Forms.NumericUpDown nudMaxAmount;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblMinAmount = new System.Windows.Forms.Label();
            this.nudMinAmount = new System.Windows.Forms.NumericUpDown();
            this.lblMaxAmount = new System.Windows.Forms.Label();
            this.nudMaxAmount = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAmount)).BeginInit();
            this.SuspendLayout();

            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 15);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer";

            // txtCustomer
            this.txtCustomer.Location = new System.Drawing.Point(93, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(179, 20);
            this.txtCustomer.TabIndex = 1;

            // lblMinAmount
            this.lblMinAmount.AutoSize = true;
            this.lblMinAmount.Location = new System.Drawing.Point(12, 41);
            this.lblMinAmount.Name = "lblMinAmount";
            this.lblMinAmount.Size = new System.Drawing.Size(65, 13);
            this.lblMinAmount.TabIndex = 2;
            this.lblMinAmount.Text = "Min Amount";

            // nudMinAmount
            this.nudMinAmount.DecimalPlaces = 2;
            this.nudMinAmount.Location = new System.Drawing.Point(93, 39);
            this.nudMinAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudMinAmount.Name = "nudMinAmount";
            this.nudMinAmount.Size = new System.Drawing.Size(179, 20);
            this.nudMinAmount.TabIndex = 3;

            // lblMaxAmount
            this.lblMaxAmount.AutoSize = true;
            this.lblMaxAmount.Location = new System.Drawing.Point(12, 67);
            this.lblMaxAmount.Name = "lblMaxAmount";
            this.lblMaxAmount.Size = new System.Drawing.Size(68, 13);
            this.lblMaxAmount.TabIndex = 4;
            this.lblMaxAmount.Text = "Max Amount";

            // nudMaxAmount
            this.nudMaxAmount.DecimalPlaces = 2;
            this.nudMaxAmount.Location = new System.Drawing.Point(93, 65);
            this.nudMaxAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudMaxAmount.Name = "nudMaxAmount";
            this.nudMaxAmount.Size = new System.Drawing.Size(179, 20);
            this.nudMaxAmount.TabIndex = 5;

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(116, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(197, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // QueryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudMaxAmount);
            this.Controls.Add(this.lblMaxAmount);
            this.Controls.Add(this.nudMinAmount);
            this.Controls.Add(this.lblMinAmount);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Name = "QueryForm";
            this.Text = "Query Order";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
