using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private List<SinhVien> danhSachSV = new List<SinhVien>();

        public bool Them(SinhVien sv)
        {
            // Kiểm tra mã sinh viên không được trùng
            if (danhSachSV.Any(s => s.MaSinhVien == sv.MaSinhVien))
                return false;
            
            danhSachSV.Add(sv);
            return true;
        }

        public List<SinhVien> LayDanhSach()
        {
            return danhSachSV;
        }

        public SinhVien TimTheoMa(string maSV)
        {
            return danhSachSV.FirstOrDefault(s => s.MaSinhVien == maSV);
        }

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return danhSachSV.Where(s => s.HoTen.ToLower().Contains(tuKhoa.ToLower())).ToList();
        }

        public bool SuaDiem(string maSV, double diemMoi)
        {
            SinhVien sv = TimTheoMa(maSV);
            if (sv != null)
            {
                sv.DiemTrungBinh = diemMoi;
                return true;
            }
            return false;
        }

        public bool Xoa(string maSV)
        {
            SinhVien sv = TimTheoMa(maSV);
            if (sv != null)
            {
                danhSachSV.Remove(sv);
                return true;
            }
            return false;
        }

        public List<SinhVien> SapXepTheoDiem()
        {
            return danhSachSV.OrderByDescending(s => s.DiemTrungBinh).ToList();
        }

        public List<SinhVien> LocSinhVienDat()
        {
            return danhSachSV.Where(s => s.DiemTrungBinh >= 5.0).ToList();
        }
    }
}