using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BangKeo
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        string username;
        public TrangChu(string s)
        {
            InitializeComponent();
            lbUsername.Text = s;
            username = s;
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild !=null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle= FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            Connect.Ketnoi();
            if(username=="nhanvien")
            {
                btn_fNhanvien.Hide();
                btn_fHoadonnhap.Hide();
                btn_fSanPham.Hide();
                btn_fNhacungcap.Hide();
                button4.Hide();
            }
        }

        private void btn_fNhanvien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVien());
            label1.Text = btn_fNhanvien.Text;
        }

        private void btn_fKhachhang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHang());
            label1.Text = btn_fKhachhang.Text;
        }

        private void btn_fHoadonban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BanHang());
            label1.Text = btn_fHoadonban.Text;
        }

        private void btn_fHoadonnhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhapHang());
            label1.Text = btn_fHoadonnhap.Text;
        }

        private void btn_fSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SanPham());
            label1.Text = btn_fSanPham.Text;
        }

        private void btn_fNhacungcap_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new NhaCungCap());
            label1.Text = btn_fNhacungcap.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoaiSanPham());
            label1.Text = button4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==System.Windows.Forms.DialogResult.OK)
            {
                Connect.NgatKetnoi();
                Application.Exit();
            }
            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            label1.Text = "Trang Chủ";
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.OK)
            {
                Connect.NgatKetnoi();
                e.Cancel = true;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất tài khoản?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                Connect.NgatKetnoi();
                this.Close();
            }
        }
    }
}
