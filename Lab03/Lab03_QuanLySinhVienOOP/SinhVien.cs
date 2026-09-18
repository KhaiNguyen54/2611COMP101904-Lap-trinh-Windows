using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }
        
        private double diemTrungBinh;
        public double DiemTrungBinh
        {
            get { return diemTrungBinh; }
            set
            {
                if (value >= 0 && value <= 10)
                    diemTrungBinh = value;
                else
                    throw new ArgumentException("Diem trung binh phai tu 0 den 10.");
            }
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh) 
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh; // Tự động gọi property để kiểm tra hợp lệ
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.0) return "Gioi";
            if (DiemTrungBinh >= 6.5) return "Kha";
            if (DiemTrungBinh >= 5.0) return "Trung binh";
            return "Yeu";
        }

        public override void LayThongTin()
        {
            Console.Write($"Ma SV: {MaSinhVien} - ");
            base.LayThongTin();
            Console.WriteLine($" - Lop: {MaLop} - Diem TB: {DiemTrungBinh} - Xep loai: {XepLoai()}");
        }
    }
}