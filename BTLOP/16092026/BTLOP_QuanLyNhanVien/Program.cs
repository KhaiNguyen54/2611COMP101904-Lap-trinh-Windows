using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BTLOP_QuanLyNhanVien;

public class NhanVien
{
    public string MaNhanVien { get; }
    public string HoTen { get; }
    public double LuongCoBan { get; }

    public NhanVien(string maNhanVien, string hoTen, double luongCoBan)
    {
        if (string.IsNullOrWhiteSpace(maNhanVien))
            throw new ArgumentException("Ma nhan vien khong duoc de trong.");

        if (string.IsNullOrWhiteSpace(hoTen))
            throw new ArgumentException("Ho ten khong duoc de trong.");

        if (luongCoBan <= 0)
            throw new ArgumentException("Luong co ban phai lon hon 0.");

        MaNhanVien = maNhanVien.Trim();
        HoTen = hoTen.Trim();
        LuongCoBan = luongCoBan;
    }

    public virtual double TinhLuong()
    {
        return LuongCoBan;
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Ma NV: {MaNhanVien}");
        Console.WriteLine($"Ho ten: {HoTen}");
        Console.WriteLine($"Luong co ban: {DinhDangTien(LuongCoBan)}");
        Console.WriteLine($"Luong thuc nhan: {DinhDangTien(TinhLuong())}");
    }

    protected static string DinhDangTien(double soTien)
    {
        return soTien.ToString("#,##0", CultureInfo.InvariantCulture) + " VND";
    }
}

public class NhanVienVanPhong : NhanVien
{
    public int SoNgayLamViec { get; }

    public NhanVienVanPhong(string maNhanVien, string hoTen, double luongCoBan, int soNgayLamViec)
        : base(maNhanVien, hoTen, luongCoBan)
    {
        if (soNgayLamViec < 0 || soNgayLamViec > 31)
            throw new ArgumentException("So ngay lam viec phai nam trong khoang 0 den 31.");

        SoNgayLamViec = soNgayLamViec;
    }

    public override double TinhLuong()
    {
        return LuongCoBan + SoNgayLamViec * 200_000;
    }

    public override void HienThiThongTin()
    {
        Console.WriteLine("Loai nhan vien: Van phong");
        base.HienThiThongTin();
        Console.WriteLine($"So ngay lam viec: {SoNgayLamViec}");
    }
}

public class NhanVienKinhDoanh : NhanVien
{
    public double DoanhSo { get; }

    public NhanVienKinhDoanh(string maNhanVien, string hoTen, double luongCoBan, double doanhSo)
        : base(maNhanVien, hoTen, luongCoBan)
    {
        if (doanhSo < 0)
            throw new ArgumentException("Doanh so phai lon hon hoac bang 0.");

        DoanhSo = doanhSo;
    }

    public override double TinhLuong()
    {
        return LuongCoBan + DoanhSo * 0.05;
    }

    public override void HienThiThongTin()
    {
        Console.WriteLine("Loai nhan vien: Kinh doanh");
        base.HienThiThongTin();
        Console.WriteLine($"Doanh so: {DinhDangTien(DoanhSo)}");
    }
}

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<NhanVien> danhSach = new();

        Console.WriteLine("CHUONG TRINH QUAN LY NHAN VIEN");
        Console.WriteLine("Vui long nhap it nhat 5 nhan vien.");
        NhapDanhSachNhanVien(danhSach);

        while (true)
        {
            HienThiMenu();
            int luaChon = NhapSoNguyen("Chon chuc nang: ");

            switch (luaChon)
            {
                case 1:
                    XuatDanhSachNhanVien(danhSach);
                    break;

                case 2:
                    TimNhanVienTheoMa(danhSach);
                    break;

                case 3:
                    TimNhanVienLuongCaoNhat(danhSach);
                    break;

                case 4:
                    TinhTongLuongCongTy(danhSach);
                    break;

                case 0:
                    Console.WriteLine("Ket thuc chuong trinh.");
                    return;

                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai tu 0 den 4.");
                    break;
            }
        }
    }

    private static void NhapDanhSachNhanVien(List<NhanVien> danhSach)
    {
        int soLuong = NhapSoNguyenToiThieu("Nhap so luong nhan vien: ", 5);

        for (int i = 0; i < soLuong; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"--- Nhap nhan vien thu {i + 1} ---");
            danhSach.Add(NhapNhanVien());
        }
    }

    private static NhanVien NhapNhanVien()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("1. Nhan vien van phong");
                Console.WriteLine("2. Nhan vien kinh doanh");
                int loai = NhapSoNguyenTrongKhoang("Chon loai nhan vien: ", 1, 2);

                string maNhanVien = NhapChuoiKhongRong("Nhap ma nhan vien: ");
                string hoTen = NhapChuoiKhongRong("Nhap ho ten: ");

                return loai switch
                {
                    1 => new NhanVienVanPhong(
                        maNhanVien,
                        hoTen,
                        NhapSoThucLonHon("Nhap luong co ban: ", 0),
                        NhapSoNguyenTrongKhoang("Nhap so ngay lam viec (0-31): ", 0, 31)),

                    _ => new NhanVienKinhDoanh(
                        maNhanVien,
                        hoTen,
                        NhapSoThucLonHon("Nhap luong co ban: ", 0),
                        NhapSoThucToiThieu("Nhap doanh so: ", 0))
                };
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Du lieu khong hop le: {ex.Message}");
                Console.WriteLine("Vui long nhap lai nhan vien nay.");
            }
        }
    }

    private static void HienThiMenu()
    {
        Console.WriteLine();
        Console.WriteLine("========== MENU ==========");
        Console.WriteLine("1. Xuat danh sach nhan vien");
        Console.WriteLine("2. Tim nhan vien theo ma");
        Console.WriteLine("3. Tim nhan vien co luong cao nhat");
        Console.WriteLine("4. Tinh tong luong cong ty phai tra");
        Console.WriteLine("0. Thoat");
    }

    private static void XuatDanhSachNhanVien(List<NhanVien> danhSach)
    {
        Console.WriteLine();
        Console.WriteLine("===== DANH SACH NHAN VIEN =====");

        for (int i = 0; i < danhSach.Count; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Nhan vien thu {i + 1}");
            danhSach[i].HienThiThongTin();
        }
    }

    private static void TimNhanVienTheoMa(List<NhanVien> danhSach)
    {
        string maCanTim = NhapChuoiKhongRong("Nhap ma nhan vien can tim: ");
        NhanVien? nhanVien = danhSach.FirstOrDefault(nv =>
            string.Equals(nv.MaNhanVien, maCanTim, StringComparison.OrdinalIgnoreCase));

        if (nhanVien is null)
        {
            Console.WriteLine("Khong tim thay nhan vien co ma da nhap.");
            return;
        }

        Console.WriteLine("Tim thay nhan vien:");
        nhanVien.HienThiThongTin();
    }

    private static void TimNhanVienLuongCaoNhat(List<NhanVien> danhSach)
    {
        double luongCaoNhat = danhSach.Max(nv => nv.TinhLuong());
        List<NhanVien> ketQua = danhSach
            .Where(nv => Math.Abs(nv.TinhLuong() - luongCaoNhat) < 0.001)
            .ToList();

        Console.WriteLine($"Luong cao nhat: {luongCaoNhat:#,##0} VND");
        Console.WriteLine("Nhan vien co luong cao nhat:");

        foreach (NhanVien nhanVien in ketQua)
        {
            Console.WriteLine();
            nhanVien.HienThiThongTin();
        }
    }

    private static void TinhTongLuongCongTy(List<NhanVien> danhSach)
    {
        double tongLuong = danhSach.Sum(nv => nv.TinhLuong());
        Console.WriteLine($"Tong luong cong ty phai tra: {tongLuong:#,##0} VND");
    }

    private static string NhapChuoiKhongRong(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Du lieu khong duoc de trong.");
        }
    }

    private static int NhapSoNguyen(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int giaTri))
                return giaTri;

            Console.WriteLine("Du lieu khong hop le. Vui long nhap so nguyen.");
        }
    }

    private static int NhapSoNguyenToiThieu(string thongBao, int min)
    {
        while (true)
        {
            int giaTri = NhapSoNguyen(thongBao);

            if (giaTri >= min)
                return giaTri;

            Console.WriteLine($"Gia tri phai lon hon hoac bang {min}.");
        }
    }

    private static int NhapSoNguyenTrongKhoang(string thongBao, int min, int max)
    {
        while (true)
        {
            int giaTri = NhapSoNguyen(thongBao);

            if (giaTri >= min && giaTri <= max)
                return giaTri;

            Console.WriteLine($"Gia tri phai nam trong khoang {min} den {max}.");
        }
    }

    private static double NhapSoThuc(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? input = Console.ReadLine();

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double giaTri))
                return giaTri;

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out giaTri))
                return giaTri;

            Console.WriteLine("Du lieu khong hop le. Vui long nhap so.");
        }
    }

    private static double NhapSoThucToiThieu(string thongBao, double min)
    {
        while (true)
        {
            double giaTri = NhapSoThuc(thongBao);

            if (giaTri >= min)
                return giaTri;

            Console.WriteLine($"Gia tri phai lon hon hoac bang {min}.");
        }
    }

    private static double NhapSoThucLonHon(string thongBao, double min)
    {
        while (true)
        {
            double giaTri = NhapSoThuc(thongBao);

            if (giaTri > min)
                return giaTri;

            Console.WriteLine($"Gia tri phai lon hon {min}.");
        }
    }
}
