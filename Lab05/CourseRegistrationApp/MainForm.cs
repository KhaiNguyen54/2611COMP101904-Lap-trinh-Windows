using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CourseRegistrationApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Nạp danh sách khóa học
            List<Course> courses = new List<Course>()
            {
                new Course { Name = "C# WinForms cơ bản", Price = 800000 },
                new Course { Name = "SQL Server cơ bản", Price = 700000 },
                new Course { Name = "Web Frontend cơ bản", Price = 750000 },
                new Course { Name = "Lập trình Python cơ bản", Price = 650000 }
            };

            cboKhoaHoc.DataSource = courses;
            
            // Thiết lập mặc định
            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;
            
            radOnline.Checked = true;
            
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            if (cboKhoaHoc.SelectedItem is Course selectedCourse)
            {
                decimal total = selectedCourse.Price * numSoThang.Value;
                lblTongTien.Text = total.ToString("N0") + " VND";
            }
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }

            Course selectedCourse = (Course)cboKhoaHoc.SelectedItem;
            decimal total = selectedCourse.Price * numSoThang.Value;
            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
            string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";

            string message = $"THÔNG TIN ĐĂNG KÝ:\n" +
                             $"- Họ tên: {txtHoTen.Text.Trim()}\n" +
                             $"- Số điện thoại: {txtSoDienThoai.Text.Trim()}\n" +
                             $"- Ngày sinh: {dtpNgaySinh.Value.ToShortDateString()}\n" +
                             $"- Khóa học: {selectedCourse.Name}\n" +
                             $"- Hình thức: {hinhThuc}\n" +
                             $"- Số tháng: {numSoThang.Value}\n" +
                             $"- Tổng tiền: {total.ToString("N0")} VND\n" +
                             $"- Nhận email: {nhanEmail}";

            MessageBox.Show(message, "Xác nhận đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            chkNhanEmail.Checked = false;
            
            if (cboKhoaHoc.Items.Count > 0)
                cboKhoaHoc.SelectedIndex = 0;
            
            radOnline.Checked = true;
            numSoThang.Value = 1;
            
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}