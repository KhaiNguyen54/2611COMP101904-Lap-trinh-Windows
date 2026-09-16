Xây dựng chương trình Console C# quản lý nhân viên, áp dụng các kiến thức về Class, Property, Constructor, Encapsulation, Kế thừa và Đa hình.
Yêu cầu
Xây dựng lớp NhanVien gồm:
Mã nhân viên.
Họ tên.
Lương cơ bản (> 0).
Constructor khởi tạo thông tin.
Phương thức virtual double TinhLuong().
Phương thức virtual void HienThiThongTin().
Xây dựng hai lớp kế thừa từ NhanVien:
NhanVienVanPhong
Bổ sung SoNgayLamViec (0–31).
Sử dụng base(...) trong Constructor.
Lương = Lương cơ bản + Số ngày làm việc × 200.000.
Override TinhLuong() và HienThiThongTin().
NhanVienKinhDoanh
Bổ sung DoanhSo (≥ 0).
Sử dụng base(...) trong Constructor.
Lương = Lương cơ bản + 5% × Doanh số.
Override TinhLuong() và HienThiThongTin().
Chương trình chính
Sử dụng:
List<NhanVien> danhSach = new List<NhanVien>();
Cho phép nhập ít nhất 5 nhân viên thuộc hai loại trên và xây dựng menu:
========== MENU ==========
1. Xuất danh sách nhân viên
2. Tìm nhân viên theo mã
3. Tìm nhân viên có lương cao nhất
4. Tính tổng lương công ty phải trả
0. Thoát
Yêu cầu: Khi xuất thông tin và tính lương, phải sử dụng đa hình thông qua HienThiThongTin() và TinhLuong(). Không sử dụng if/switch để kiểm tra nhân viên thuộc lớp NhanVienVanPhong hay NhanVienKinhDoanh khi thực hiện các chức năng trên.
Bonus: Xây dựng thêm NhanVienThoiVu có SoGioLam, LuongTheoGio và:
Lương = Số giờ làm × Lương theo giờ
Sau khi thêm loại nhân viên mới, không được thay đổi thuật toán tìm nhân viên có lương cao nhất và tính tổng lương.