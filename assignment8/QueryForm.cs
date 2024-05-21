using System;
using System.Windows.Forms;

namespace OrderManagementSystem
{
    public partial class QueryForm : Form
    {
        public Func<Order, bool> Query { get; private set; }

        public QueryForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var customer = txtCustomer.Text;
            var minAmount = nudMinAmount.Value;
            var maxAmount = nudMaxAmount.Value;

            Query = o => (string.IsNullOrEmpty(customer) || o.Customer.Contains(customer)) &&
                         o.TotalAmount >= minAmount &&
                         o.TotalAmount <= maxAmount;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
