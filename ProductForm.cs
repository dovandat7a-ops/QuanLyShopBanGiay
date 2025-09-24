using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyShopBanGiay
{
    public class ProductForm : Form
    {
        private DataGridView dgv;
        private Button btnLoad, btnSave, btnDelete, btnRefresh;
        private DataTable dt;
        private SqlDataAdapter adapter;
        private string connStr = DatabaseHelper.AppConnectionString;
        private string tableName = "Product";

        public ProductForm()
        {
            Text = "Quản lý Product";
            Width = 800;
            Height = 600;
            StartPosition = FormStartPosition.CenterParent;
            Initialize();
        }

        private void Initialize()
        {
            var panel = new FlowLayoutPanel(){Dock=DockStyle.Top,Height=40};
            btnLoad = new Button(){Text="Load"}; btnLoad.Click+=(s,e)=>LoadData();
            btnSave = new Button(){Text="Save"}; btnSave.Click+=(s,e)=>SaveData();
            btnDelete = new Button(){Text="Delete"}; btnDelete.Click+=(s,e)=>DeleteSelected();
            btnRefresh = new Button(){Text="Refresh"}; btnRefresh.Click+=(s,e)=>LoadData();
            panel.Controls.AddRange(new Control[]{btnLoad,btnSave,btnDelete,btnRefresh});

            dgv = new DataGridView(){Dock=DockStyle.Fill,ReadOnly=false,AllowUserToAddRows=true,SelectionMode=DataGridViewSelectionMode.FullRowSelect};

            Controls.Add(dgv);
            Controls.Add(panel);
        }

        private void LoadData()
        {
            try{
                var conn=new SqlConnection(connStr);
                adapter=new SqlDataAdapter($"SELECT * FROM [{tableName}]",conn);
                var builder=new SqlCommandBuilder(adapter);
                dt=new DataTable();
                adapter.Fill(dt);
                dgv.DataSource=dt;
            }catch(Exception ex){MessageBox.Show(ex.Message);}
        }

        private void SaveData()
        {
            try{
                if(adapter==null||dt==null)return;
                var builder=new SqlCommandBuilder(adapter);
                adapter.Update(dt);
                MessageBox.Show("Đã lưu!");
                LoadData();
            }catch(Exception ex){MessageBox.Show(ex.Message);}
        }

        private void DeleteSelected()
        {
            if(dgv.SelectedRows.Count==0)return;
            foreach(DataGridViewRow r in dgv.SelectedRows){
                if(!r.IsNewRow)((DataRowView)r.DataBoundItem).Row.Delete();
            }
            SaveData();
        }
    }
}
