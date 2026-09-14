using System;

namespace Lab02;

internal class Program
{
// Ham nhap so nguyen tu ban phim
    static int NhapSoNguyen(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Du lieu khong hop le. Vui long nhap so nguyen.");
        }
    }
// Ham nhap so nguyen duong tu ban phim
    static int NhapSoNguyenDuong(string message)
    {
        while (true)
        {
            int value = NhapSoNguyen(message);

            if (value > 0)
                return value;

            Console.WriteLine("So phan tu n phai la so nguyen duong.");
        }
    }

// Ham nhap mang tu ban phim
    static int[] NhapMang()
    {
        int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
        int[] a = new int[n];

        for (int i = 0; i < a.Length; i++)
            a[i] = NhapSoNguyen($"Nhap a[{i}]: ");

        return a;
    }

// Ham xuat mang ra man hinh
    static void XuatMang(int[] a)
    {
        Console.Write("Mang: ");

        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i]);

            if (i < a.Length - 1)
                Console.Write(" ");
        }

        Console.WriteLine();
    }

// Ham tinh tong cac phan tu trong mang
    static int TinhTong(int[] a)
    {
        int tong = 0;

        for (int i = 0; i < a.Length; i++)
            tong += a[i];

        return tong;
    }

// Ham tim gia tri lon nhat trong mang
    static int TimMax(int[] a)
    {
        int max = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max)
                max = a[i];
        }

        return max;
    }

// Ham tim gia tri nho nhat trong mang
    static int TimMin(int[] a)
    {
        int min = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < min)
                min = a[i];
        }

        return min;
    }

// Ham dem so phan tu chan trong mang
    static int DemChan(int[] a)
    {
        int dem = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] % 2 == 0)
                dem++;
        }

        return dem;
    }

// Ham dem so phan tu le trong mang
    static int DemLe(int[] a)
    {
        int dem = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] % 2 != 0)
                dem++;
        }

        return dem;
    }

// Ham sap xep mang tang dan
    static void SapXepTangDan(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[i] > a[j])
                {
                    (a[i], a[j]) = (a[j], a[i]);
                }
            }
        }
    }

// Ham tim kiem gia tri x trong mang, tra ve vi tri dau tien neu tim thay, nguoc lai tra ve -1
    static int TimKiem(int[] a, int x)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == x)
                return i;
        }

        return -1;
    }

// Ham hien thi menu chuc nang
    static void HienThiMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== MENU =====");
        Console.WriteLine("1. Nhap mang");
        Console.WriteLine("2. Xuat mang");
        Console.WriteLine("3. Tinh tong");
        Console.WriteLine("4. Tim max/min");
        Console.WriteLine("5. Dem chan/le");
        Console.WriteLine("6. Sap xep tang dan");
        Console.WriteLine("7. Tim kiem");
        Console.WriteLine("0. Thoat");
    }

// Ham kiem tra xem mang da duoc nhap hay chua
    static bool KiemTraDaNhapMang(int[]? a)
    {
        if (a is not null)
            return true;

        Console.WriteLine("Chua nhap mang. Vui long chon chuc nang 1 truoc.");
        return false;
    }
    
// Ham main
    static void Main()
    {
        int[]? a = null;

        while (true)
        {
            HienThiMenu();
            int luaChon = NhapSoNguyen("Chon chuc nang: ");

            switch (luaChon)
            {
                case 1:
                    a = NhapMang();
                    Console.WriteLine("Nhap mang thanh cong.");
                    XuatMang(a);
                    break;

                case 2:
                    if (!KiemTraDaNhapMang(a))
                        break;

                    XuatMang(a!);
                    break;

                case 3:
                    if (!KiemTraDaNhapMang(a))
                        break;

                    Console.WriteLine($"Tong = {TinhTong(a!)}");
                    break;

                case 4:
                    if (!KiemTraDaNhapMang(a))
                        break;

                    Console.WriteLine($"Max = {TimMax(a!)}");
                    Console.WriteLine($"Min = {TimMin(a!)}");
                    break;

                case 5:
                    if (!KiemTraDaNhapMang(a))
                        break;

                    Console.WriteLine($"So phan tu chan = {DemChan(a!)}");
                    Console.WriteLine($"So phan tu le = {DemLe(a!)}");
                    break;

                case 6:
                    if (!KiemTraDaNhapMang(a))
                        break;

                    SapXepTangDan(a!);
                    Console.WriteLine("Mang sau khi sap xep tang dan:");
                    XuatMang(a!);
                    break;

                case 7:
                    if (!KiemTraDaNhapMang(a))
                        break;

                    int x = NhapSoNguyen("Nhap gia tri x: ");
                    int viTri = TimKiem(a!, x);

                    if (viTri >= 0)
                        Console.WriteLine($"Tim thay {x} tai vi tri dau tien: {viTri}");
                    else
                        Console.WriteLine($"Khong tim thay {x} trong mang.");
                    break;

                case 0:
                    Console.WriteLine("Ket thuc chuong trinh.");
                    return;

                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai tu 0 den 7.");
                    break;
            }
        }
    }
}
