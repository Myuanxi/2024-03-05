using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderManagementSystem
{
    public partial class OrderForm : Form
    {
        public Order Order { get; private set; }
        private BindingSource orderDetailsBindingSource;

        public OrderForm() : this(new Order(Guid.NewGuid().ToString(), ""))
        {
        }

        public OrderForm(Order order)
        {
            InitializeComponent();
            Order = order;
            orderDetailsBindingSource = new BindingSource();
            orderDetailsBindingSource.DataSource = Order.OrderDetails;

            txtOrderID.DataBindings.Add("Text", Order, "OrderID");
            txtCustomer.DataBindings.Add("Text", Order, "Customer");
            dataGridViewOrderDetails.DataSource = orderDetailsBindingSource;
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            var detailForm = new OrderDetailForm();
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                Order.OrderDetails.Add(detailForm.OrderDetail);
                orderDetailsBindingSource.ResetBindings(false);
            }
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
