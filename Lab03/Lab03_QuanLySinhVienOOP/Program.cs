using System;
using System.Collections.Generic;

namespace Lab03_QuanLySinhVienOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLySinhVien qlsv = new QuanLySinhVien();
            int luaChon = -1;

            while (luaChon != 0)
            {
                Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Tim sinh vien theo ma");
                Console.WriteLine("4. Tim sinh vien theo ten");
                Console.WriteLine("5. Sua diem trung binh");
                Console.WriteLine("6. Xoa sinh vien");
                Console.WriteLine("7. Sap xep theo diem giam dan");
                Console.WriteLine("8. Loc sinh vien dat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");
                
                if (!int.TryParse(Console.ReadLine(), out luaChon))
                {
                    Console.WriteLine("Loi: Vui long nhap so hop le!");
                    continue;
                }

                switch (luaChon)
                {
                    case 1: ThemSinhVienUI(qlsv); break;
                    case 2: HienThiDanhSach(qlsv.LayDanhSach()); break;
                    case 3: TimTheoMaUI(qlsv); break;
                    case 4: TimTheoTenUI(qlsv); break;
                    case 5: SuaDiemUI(qlsv); break;
                    case 6: XoaUI(qlsv); break;
                    case 7: HienThiDanhSach(qlsv.SapXepTheoDiem()); break;
                    case 8: HienThiDanhSach(qlsv.LocSinhVienDat()); break;
                    case 0: Console.WriteLine("Thoat chuong trinh."); break;
                    default: Console.WriteLine("Chuc nang khong ton tai!"); break;
                }
            }
        }

        static void ThemSinhVienUI(QuanLySinhVien qlsv)
        {
            try
            {
                Console.Write("Nhap ma SV: ");
                string ma = Console.ReadLine();
                Console.Write("Nhap ho ten: ");
                string ten = Console.ReadLine();
                
                DateTime ngaySinh;
                while (true)
                {
                    Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                        break;
                    Console.WriteLine("Loi: Ngay sinh khong hop le.");
                }

                Console.Write("Nhap ma lop: ");
                string lop = Console.ReadLine();

                double diem;
                while (true)
                {
                    Console.Write("Nhap diem trung binh (0-10): ");
                    if (double.TryParse(Console.ReadLine(), out diem) && diem >= 0 && diem <= 10)
                        break;
                    Console.WriteLine("Loi: Diem khong hop le, vui long nhap tu 0 den 10.");
                }

                SinhVien sv = new SinhVien(ma, ten, ngaySinh, lop, diem);
                if (qlsv.Them(sv))
                    Console.WriteLine("Them sinh vien thanh cong!");
                else
                    Console.WriteLine("Loi: Ma sinh vien da ton tai!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi he thong: {ex.Message}");
            }
        }

        static void HienThiDanhSach(List<SinhVien> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach hien dang trong.");
                return;
            }
            foreach (var sv in ds)
            {
                sv.LayThongTin();
            }
        }

        static void TimTheoMaUI(QuanLySinhVien qlsv)
        {
            Console.Write("Nhap ma SV can tim: ");
            string ma = Console.ReadLine();
            SinhVien sv = qlsv.TimTheoMa(ma);
            if (sv != null)
                sv.LayThongTin();
            else
                Console.WriteLine("Khong tim thay sinh vien.");
        }

        static void TimTheoTenUI(QuanLySinhVien qlsv)
        {
            Console.Write("Nhap tu khoa ten: ");
            string tuKhoa = Console.ReadLine();
            var ds = qlsv.TimTheoTen(tuKhoa);
            if (ds.Count > 0)
                HienThiDanhSach(ds);
            else
                Console.WriteLine("Khong tim thay sinh vien nao chua tu khoa tren.");
        }

        static void SuaDiemUI(QuanLySinhVien qlsv)
        {
            Console.Write("Nhap ma SV can sua diem: ");
            string ma = Console.ReadLine();
            Console.Write("Nhap diem moi (0-10): ");
            if (double.TryParse(Console.ReadLine(), out double diemMoi) && diemMoi >= 0 && diemMoi <= 10)
            {
                if (qlsv.SuaDiem(ma, diemMoi))
                    Console.WriteLine("Sua diem thanh cong.");
                else
                    Console.WriteLine("Khong tim thay sinh vien.");
            }
            else
            {
                Console.WriteLine("Loi: Diem khong hop le.");
            }
        }

        static void XoaUI(QuanLySinhVien qlsv)
        {
            Console.Write("Nhap ma SV can xoa: ");
            string ma = Console.ReadLine();
            if (qlsv.Xoa(ma))
                Console.WriteLine("Xoa thanh cong.");
            else
                Console.WriteLine("Khong tim thay sinh vien.");
        }
    }
}