using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    public partial class FormMain : Form
    {
        string flag;
        DataTable dtSV;
        public FormMain()
        {
            InitializeComponent();
        }
        public void LockControl()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnTim.Enabled = false;
            txtMaSv.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtTim.ReadOnly = true;
            btnThem.Focus();
        }
        public void UnlockControl()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnTim.Enabled = true;
            txtMaSv.ReadOnly = false;
            txtHoTen.ReadOnly = false;
            txtTim.ReadOnly = false;
            txtMaSv.Focus();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LockControl();
            dtSV = creatTable();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnlockControl();
            flag="add";
            txtMaSv.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Text="";
            comQueQuan.Text = "";
            comLop.Text = "";
            comKhoa.Text = "";
            chNam.Checked=fa;
            chNu.Checked = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnlockControl();
            flag = "edit";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flag=="add")
            {
                if(CheckData())
                {
                    string a;
                    if (chNam.Checked == true)
                        a = chNam.Text;
                    else
                        a = chNu.Text;
                    dtSV.Rows.Add(txtMaSv.Text, txtHoTen.Text, txtNgaySinh.Text, a, comQueQuan.Text, comLop.Text, comKhoa.Text);
                    dataGridView1.DataSource = dtSV;
                    dataGridView1.RefreshEdit();
                }
                LockControl();
            }
        }
        public bool CheckData()
        {
            if (string.IsNullOrWhiteSpace(txtMaSv.Text))
            {
                MessageBox.Show("bạn chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSv.Focus();
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("bạn chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
            }
            if (string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show("bạn chưa nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgaySinh.Focus();
            }
            if (string.IsNullOrWhiteSpace(coQueQuan.Name))
            {
                MessageBox.Show("bạn chưa nhập quê quán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (string.IsNullOrWhiteSpace(coLop.Name))
            {
                MessageBox.Show("bạn chưa nhập Lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (string.IsNullOrWhiteSpace(coKhoa.Name))
            {
                MessageBox.Show("bạn chưa nhập khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(chNam.Checked==false&&chNu.Checked==false)
                MessageBox.Show("bạn chưa nhập khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public DataTable creatTable()
        {
            DataTable dt= new DataTable();
            dt.Columns.Add("MaSv");
            dt.Columns.Add("TenSv");
            dt.Columns.Add("NsSv");
            dt.Columns.Add("GTSv");
            dt.Columns.Add("QQSv");
            dt.Columns.Add("LopSv");
            dt.Columns.Add("KSv");
            return dt;
        }
    }
}
