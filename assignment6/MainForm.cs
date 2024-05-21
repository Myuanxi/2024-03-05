using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderManagementSystem
{
    public partial class MainForm : Form
    {
        private OrderService orderService;
        private BindingSource orderBindingSource;
        private BindingSource orderDetailsBindingSource;

        public MainForm()
        {
            InitializeComponent();
            orderService = new OrderService();
            orderBindingSource = new BindingSource();
            orderDetailsBindingSource = new BindingSource();

            orderBindingSource.DataSource = orderService.GetOrdersSortedByDefault();
            orderDetailsBindingSource.DataSource = orderBindingSource;
            orderDetailsBindingSource.DataMember = "OrderDetails";

            dataGridViewOrders.DataSource = orderBindingSource;
            dataGridViewOrderDetails.DataSource = orderDetailsBindingSource;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderForm();
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(orderForm.Order);
                orderBindingSource.DataSource = orderService.GetOrdersSortedByDefault();
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order order)
            {
                var orderForm = new OrderForm(order);
                if (orderForm.ShowDialog() == DialogResult.OK)
                {
                    orderService.UpdateOrder(orderForm.Order);
                    orderBindingSource.DataSource = orderService.GetOrdersSortedByDefault();
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order order)
            {
                orderService.RemoveOrder(order.OrderID);
                orderBindingSource.DataSource = orderService.GetOrdersSortedByDefault();
            }
        }

        private void btnQueryOrder_Click(object sender, EventArgs e)
        {
            var queryForm = new QueryForm();
            if (queryForm.ShowDialog() == DialogResult.OK)
            {
                orderBindingSource.DataSource = orderService.QueryOrders(queryForm.Query);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 初始化数据绑定
            dataGridViewOrders.AutoGenerateColumns = true;
            dataGridViewOrderDetails.AutoGenerateColumns = true;
        }
    }
}
