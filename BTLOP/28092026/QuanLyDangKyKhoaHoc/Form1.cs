namespace QuanLyDangKyKhoaHoc;

public partial class Form1 : Form
{
    private readonly List<CourseOption> _courses = new()
    {
        new("Lập trình C# cơ bản", 900000m, 1200000m),
        new("Excel nâng cao", 700000m, 950000m),
        new("Tiếng Anh giao tiếp", 650000m, 850000m),
        new("Marketing số", 800000m, 1100000m)
    };

    public Form1()
    {
        InitializeComponent();
        SetupDefaultValues();
        RegisterEvents();
        UpdateCourseInfo();
    }

    private void SetupDefaultValues()
    {
        this.Text = "ĐĂNG KÝ KHÓA HỌC NGẮN HẠN";
        this.MinimumSize = new Size(780, 620);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormClosing += Form1_FormClosing;

        cmbKhoaHoc.DataSource = _courses;
        cmbKhoaHoc.DisplayMember = nameof(CourseOption.Name);
        cmbKhoaHoc.SelectedIndex = 0;

        dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
        numSoThang.Value = 3;
        rbOnline.Checked = true;
        UpdateCharacterCounter();
    }

    private void RegisterEvents()
    {
        txtHoTen.TextChanged += (_, _) => UpdateCharacterCounter();
        cmbKhoaHoc.SelectedIndexChanged += (_, _) => UpdateCourseInfo();
        rbOnline.CheckedChanged += (_, _) => UpdateCourseInfo();
        rbTrucTiep.CheckedChanged += (_, _) => UpdateCourseInfo();
        numSoThang.ValueChanged += (_, _) => UpdateCourseInfo();
        btnDangKy.Click += btnDangKy_Click;
        btnLamMoi.Click += btnLamMoi_Click;
        btnThoat.Click += btnThoat_Click;
    }

    private void UpdateCharacterCounter()
    {
        lblSoKyTu.Text = $"{txtHoTen.TextLength}/50";
    }

    private void UpdateCourseInfo()
    {
        if (cmbKhoaHoc.SelectedItem is not CourseOption course)
            return;

        decimal fee = rbOnline.Checked ? course.OnlinePrice : course.OfflinePrice;
        decimal total = fee * numSoThang.Value;

        lblHocPhi.Text = $"{fee:N0} VNĐ";
        lblTongTien.Text = $"{total:N0} VNĐ";
    }

    private void btnDangKy_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show("Vui lòng nhập họ tên học viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSDT.Text))
        {
            MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSDT.Focus();
            return;
        }

        if (cmbKhoaHoc.SelectedItem is not CourseOption course)
        {
            MessageBox.Show("Vui lòng chọn khóa học.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbKhoaHoc.Focus();
            return;
        }

        var method = rbOnline.Checked ? "Online" : "Trực tiếp";
        var emailNotice = chkNhanEmail.Checked ? "Có" : "Không";

        var message = $"Đăng ký thành công!\n\n" +
            $"Học viên: {txtHoTen.Text}\n" +
            $"SĐT: {txtSDT.Text}\n" +
            $"Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}\n" +
            $"Nhận email: {emailNotice}\n" +
            $"Khóa học: {course.Name}\n" +
            $"Hình thức: {method}\n" +
            $"Số tháng: {numSoThang.Value}\n" +
            $"Tổng tiền: {lblTongTien.Text}";

        MessageBox.Show(message, "Xác nhận đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        txtHoTen.Clear();
        txtSDT.Clear();
        chkNhanEmail.Checked = false;
        cmbKhoaHoc.SelectedIndex = 0;
        rbOnline.Checked = true;
        numSoThang.Value = 3;
        dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
        UpdateCharacterCounter();
        UpdateCourseInfo();
        txtHoTen.Focus();
    }

    private void btnThoat_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("Bạn có chắc muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
            Application.Exit();
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        var result = MessageBox.Show("Bạn có chắc muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result != DialogResult.Yes)
            e.Cancel = true;
    }
}

public sealed class CourseOption
{
    public string Name { get; }
    public decimal OnlinePrice { get; }
    public decimal OfflinePrice { get; }

    public CourseOption(string name, decimal onlinePrice, decimal offlinePrice)
    {
        Name = name;
        OnlinePrice = onlinePrice;
        OfflinePrice = offlinePrice;
    }
}
