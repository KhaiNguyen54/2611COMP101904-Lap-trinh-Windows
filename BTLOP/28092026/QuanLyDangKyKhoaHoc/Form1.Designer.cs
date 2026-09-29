namespace QuanLyDangKyKhoaHoc;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitle;
    private GroupBox gbStudent;
    private Label lblHoTen;
    private TextBox txtHoTen;
    private Label lblSoKyTu;
    private Label lblSDT;
    private TextBox txtSDT;
    private Label lblNgaySinh;
    private DateTimePicker dtpNgaySinh;
    private CheckBox chkNhanEmail;
    private GroupBox gbCourse;
    private Label lblKhoaHoc;
    private ComboBox cmbKhoaHoc;
    private Label lblHinhThuc;
    private RadioButton rbOnline;
    private RadioButton rbTrucTiep;
    private Label lblSoThang;
    private NumericUpDown numSoThang;
    private Label lblHocPhiLabel;
    private Label lblHocPhi;
    private Label lblTongTienLabel;
    private Label lblTongTien;
    private Button btnDangKy;
    private Button btnLamMoi;
    private Button btnThoat;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.WhiteSmoke;
        this.ClientSize = new Size(780, 580);
        this.Font = new Font("Segoe UI", 10F);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "Form1";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "ĐĂNG KÝ KHÓA HỌC NGẮN HẠN";

        lblTitle = new Label();
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.SteelBlue;
        lblTitle.Location = new Point(20, 20);
        lblTitle.Size = new Size(740, 40);
        lblTitle.Text = "ĐĂNG KÝ KHÓA HỌC NGẮN HẠN";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;

        gbStudent = new GroupBox();
        gbStudent.BackColor = Color.FromArgb(235, 244, 255);
        gbStudent.FlatStyle = FlatStyle.Flat;
        gbStudent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        gbStudent.Location = new Point(20, 80);
        gbStudent.Size = new Size(720, 200);
        gbStudent.Text = "Thông tin học viên";

        lblHoTen = new Label();
        lblHoTen.AutoSize = true;
        lblHoTen.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        lblHoTen.Location = new Point(20, 35);
        lblHoTen.Size = new Size(70, 23);
        lblHoTen.Text = "Họ tên:";

        txtHoTen = new TextBox();
        txtHoTen.Location = new Point(110, 30);
        txtHoTen.MaxLength = 50;
        txtHoTen.Size = new Size(430, 30);

        lblSoKyTu = new Label();
        lblSoKyTu.AutoSize = true;
        lblSoKyTu.ForeColor = Color.Gray;
        lblSoKyTu.Location = new Point(550, 35);
        lblSoKyTu.Size = new Size(80, 23);
        lblSoKyTu.Text = "0/50";

        lblSDT = new Label();
        lblSDT.AutoSize = true;
        lblSDT.Location = new Point(20, 80);
        lblSDT.Size = new Size(82, 23);
        lblSDT.Text = "Số điện thoại:";

        txtSDT = new TextBox();
        txtSDT.Location = new Point(110, 75);
        txtSDT.MaxLength = 11;
        txtSDT.Size = new Size(240, 30);

        lblNgaySinh = new Label();
        lblNgaySinh.AutoSize = true;
        lblNgaySinh.Location = new Point(380, 80);
        lblNgaySinh.Size = new Size(80, 23);
        lblNgaySinh.Text = "Ngày sinh:";

        dtpNgaySinh = new DateTimePicker();
        dtpNgaySinh.Format = DateTimePickerFormat.Short;
        dtpNgaySinh.Location = new Point(470, 75);
        dtpNgaySinh.Size = new Size(180, 30);

        chkNhanEmail = new CheckBox();
        chkNhanEmail.AutoSize = true;
        chkNhanEmail.Location = new Point(110, 125);
        chkNhanEmail.Size = new Size(220, 25);
        chkNhanEmail.Text = "Nhận email thông báo";

        gbCourse = new GroupBox();
        gbCourse.BackColor = Color.FromArgb(235, 244, 255);
        gbCourse.FlatStyle = FlatStyle.Flat;
        gbCourse.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        gbCourse.Location = new Point(20, 300);
        gbCourse.Size = new Size(720, 190);
        gbCourse.Text = "Thông tin khóa học";

        lblKhoaHoc = new Label();
        lblKhoaHoc.AutoSize = true;
        lblKhoaHoc.Location = new Point(20, 35);
        lblKhoaHoc.Size = new Size(88, 23);
        lblKhoaHoc.Text = "Khóa học:";

        cmbKhoaHoc = new ComboBox();
        cmbKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbKhoaHoc.Location = new Point(120, 30);
        cmbKhoaHoc.Size = new Size(250, 30);

        lblHinhThuc = new Label();
        lblHinhThuc.AutoSize = true;
        lblHinhThuc.Location = new Point(400, 35);
        lblHinhThuc.Size = new Size(96, 23);
        lblHinhThuc.Text = "Hình thức:";

        rbOnline = new RadioButton();
        rbOnline.AutoSize = true;
        rbOnline.Location = new Point(500, 32);
        rbOnline.Size = new Size(80, 25);
        rbOnline.Text = "Online";

        rbTrucTiep = new RadioButton();
        rbTrucTiep.AutoSize = true;
        rbTrucTiep.Location = new Point(590, 32);
        rbTrucTiep.Size = new Size(110, 25);
        rbTrucTiep.Text = "Trực tiếp";

        lblSoThang = new Label();
        lblSoThang.AutoSize = true;
        lblSoThang.Location = new Point(20, 85);
        lblSoThang.Size = new Size(86, 23);
        lblSoThang.Text = "Số tháng:";

        numSoThang = new NumericUpDown();
        numSoThang.Location = new Point(120, 80);
        numSoThang.Minimum = 1;
        numSoThang.Maximum = 12;
        numSoThang.Value = 3;
        numSoThang.Size = new Size(120, 30);

        lblHocPhiLabel = new Label();
        lblHocPhiLabel.AutoSize = true;
        lblHocPhiLabel.Location = new Point(400, 85);
        lblHocPhiLabel.Size = new Size(90, 23);
        lblHocPhiLabel.Text = "Học phí/tháng:";

        lblHocPhi = new Label();
        lblHocPhi.AutoSize = true;
        lblHocPhi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblHocPhi.ForeColor = Color.DarkGreen;
        lblHocPhi.Location = new Point(500, 85);
        lblHocPhi.Size = new Size(120, 23);
        lblHocPhi.Text = "0 VNĐ";

        lblTongTienLabel = new Label();
        lblTongTienLabel.AutoSize = true;
        lblTongTienLabel.Location = new Point(20, 135);
        lblTongTienLabel.Size = new Size(85, 23);
        lblTongTienLabel.Text = "Tổng tiền:";

        lblTongTien = new Label();
        lblTongTien.AutoSize = true;
        lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTongTien.ForeColor = Color.DarkBlue;
        lblTongTien.Location = new Point(120, 132);
        lblTongTien.Size = new Size(250, 30);
        lblTongTien.Text = "0 VNĐ";

        btnDangKy = new Button();
        btnDangKy.BackColor = Color.MediumSeaGreen;
        btnDangKy.FlatAppearance.BorderSize = 0;
        btnDangKy.FlatStyle = FlatStyle.Flat;
        btnDangKy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnDangKy.ForeColor = Color.White;
        btnDangKy.Location = new Point(160, 510);
        btnDangKy.Size = new Size(140, 42);
        btnDangKy.Text = "Đăng ký";

        btnLamMoi = new Button();
        btnLamMoi.BackColor = Color.RoyalBlue;
        btnLamMoi.FlatAppearance.BorderSize = 0;
        btnLamMoi.FlatStyle = FlatStyle.Flat;
        btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLamMoi.ForeColor = Color.White;
        btnLamMoi.Location = new Point(320, 510);
        btnLamMoi.Size = new Size(140, 42);
        btnLamMoi.Text = "Làm mới";

        btnThoat = new Button();
        btnThoat.BackColor = Color.IndianRed;
        btnThoat.FlatAppearance.BorderSize = 0;
        btnThoat.FlatStyle = FlatStyle.Flat;
        btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnThoat.ForeColor = Color.White;
        btnThoat.Location = new Point(480, 510);
        btnThoat.Size = new Size(140, 42);
        btnThoat.Text = "Thoát";

        gbStudent.Controls.Add(lblHoTen);
        gbStudent.Controls.Add(txtHoTen);
        gbStudent.Controls.Add(lblSoKyTu);
        gbStudent.Controls.Add(lblSDT);
        gbStudent.Controls.Add(txtSDT);
        gbStudent.Controls.Add(lblNgaySinh);
        gbStudent.Controls.Add(dtpNgaySinh);
        gbStudent.Controls.Add(chkNhanEmail);

        gbCourse.Controls.Add(lblKhoaHoc);
        gbCourse.Controls.Add(cmbKhoaHoc);
        gbCourse.Controls.Add(lblHinhThuc);
        gbCourse.Controls.Add(rbOnline);
        gbCourse.Controls.Add(rbTrucTiep);
        gbCourse.Controls.Add(lblSoThang);
        gbCourse.Controls.Add(numSoThang);
        gbCourse.Controls.Add(lblHocPhiLabel);
        gbCourse.Controls.Add(lblHocPhi);
        gbCourse.Controls.Add(lblTongTienLabel);
        gbCourse.Controls.Add(lblTongTien);

        this.Controls.Add(lblTitle);
        this.Controls.Add(gbStudent);
        this.Controls.Add(gbCourse);
        this.Controls.Add(btnDangKy);
        this.Controls.Add(btnLamMoi);
        this.Controls.Add(btnThoat);

        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
