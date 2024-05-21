using System;
using System.Windows.Forms;

namespace OrderManagementSystem
{
    public partial class OrderDetailForm : Form
    {
        public OrderDetails OrderDetail { get; private set; }

        public OrderDetailForm() : this(new OrderDetails("", 0, 0))
        {
        }

        public OrderDetailForm(OrderDetails orderDetail)
        {
            InitializeComponent();
            OrderDetail = orderDetail;

            txtProductName.DataBindings.Add("Text", OrderDetail, "ProductName");
            txtQuantity.DataBindings.Add("Text", OrderDetail, "Quantity");
            txtPrice.DataBindings.Add("Text", OrderDetail, "Price");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
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
