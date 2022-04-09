using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ASS
{
    public partial class Form1 : Form
    {
        public void ShowData(string sql)
        {
            Utility.OpenConnection();
            dsThongTin.DataSource = Utility.GetDataTable("select * from SinhVien");
        }
        public Form1()
        {
            InitializeComponent();
            this.ShowData("select * from SinhVien");
        }
        public void Clear(){
            txtHoSV.Text = "";
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtMaKhoa.Text = "";
            cbGioiTinh.Text = "";            
                }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dsThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.ReadOnly = true;
            int row;
            row = dsThongTin.CurrentRow.Index;
            txtMaSV.Text = dsThongTin.Rows[row].Cells[0].Value.ToString();
            txtHoSV.Text = dsThongTin.Rows[row].Cells[1].Value.ToString();
            txtTenSV.Text = dsThongTin.Rows[row].Cells[2].Value.ToString();
            dtDatetime.Text = dsThongTin.Rows[row].Cells[3].Value.ToString();
            cbGioiTinh.Text = dsThongTin.Rows[row].Cells[4].Value.ToString();
            txtMaKhoa.Text = dsThongTin.Rows[row].Cells[5].Value.ToString();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có thực sự muốn thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
        string sql = "insert into SinhVien values ('" + txtMaSV.Text + "', '" + txtHoSV.Text + "', '" + txtTenSV.Text + "', '" + dtDatetime.Text + "', N'" + cbGioiTinh.Text + "', '" + txtMaKhoa.Text + "')";
            Utility.Excute(sql);
            this.ShowData("select * from SinhVien");
            this.Clear();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            txtHoSV.Text = "";
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtMaKhoa.Text = "";
            cbGioiTinh.Text = "";
            dtDatetime.Text = "";
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có thực sự muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (f == DialogResult.Yes)
            {
                int ChiSo = dsThongTin.CurrentRow.Index;
                string sql = "delete from SinhVien where MaSV= '" + dsThongTin[0, ChiSo].Value.ToString() + "'";
                Utility.Excute(sql);
                this.ShowData("");
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "MaSV", "*" + txtFind.Text + "*");
            (dsThongTin.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
    }
}
