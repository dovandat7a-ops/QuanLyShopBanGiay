using System;
using System.Windows.Forms;

namespace QuanLyShopBanGiay
{
    public class MainForm : Form
    {
        private MenuStrip menu;

        public MainForm()
        {
            Text = "Quản Lý Shop Bán Giày";
            Width = 1000;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            menu = new MenuStrip();
            var ql = new ToolStripMenuItem("Quản lý");
            var mCustomer = new ToolStripMenuItem("Khách hàng", null, (s,e)=> new CustomersForm().ShowDialog());
            var mProduct = new ToolStripMenuItem("Sản phẩm", null, (s,e)=> new ProductForm().ShowDialog());
            var mEmployee = new ToolStripMenuItem("Nhân viên", null, (s,e)=> new EmployeeForm().ShowDialog());
            var mSupplier = new ToolStripMenuItem("Nhà cung cấp", null, (s,e)=> new SupplierForm().ShowDialog());
            var mOrders = new ToolStripMenuItem("Đơn hàng", null, (s,e)=> new OrdersForm().ShowDialog());
            var mOrderDetails = new ToolStripMenuItem("Chi tiết đơn hàng", null, (s,e)=> new OrderDetailsForm().ShowDialog());
            ql.DropDownItems.AddRange(new[]{mCustomer,mProduct,mEmployee,mSupplier,mOrders,mOrderDetails});
            menu.Items.Add(ql);
            MainMenuStrip = menu;
            Controls.Add(menu);
        }
    }
}
