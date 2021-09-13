//19211tt0981
//lethihuynhnhu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OnThi_ktlt2
{
    struct Thuoc
    {
        public string MaThuoc;
        public string TenThuoc;
        public DateTime NgayNhap;
        public int SoLuong;

        //
        public string ToString()
        {
            return $"({MaThuoc},{TenThuoc},{NgayNhap.ToString("dd/MM/yy")},{SoLuong})";

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Khai bao và số lượng thuốc
            int sL = 0;
            Thuoc[] arrA;
            Console.Write("Nhap so luong thuoc trong danh sach: ");
            int.TryParse(Console.ReadLine(), out sL);
            //Cau a: Goi ham nhap danh sach n thuoc
            Console.ForegroundColor = ConsoleColor.Yellow;
            arrA = NhapDSThuoc(sL);
            //Cau b: Goi ham xuat danh sach n thuoc
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"xuat danh sach {sL} thuoc: ");
            XuatDSThuoc(arrA);
            //Cau c: Tim va ghi thong tin cua thuoc co so luong lon nhat
            TimGhiSLMax(arrA, "ThuocMax.txt");
            //Cau d: Nhap n danh sach
            //khai bao va cap phat ma tran thuoc
            Console.ForegroundColor = ConsoleColor.Red;
            Thuoc[][] arrM;
            NhapMaTran(out arrM);
            //Cau e: Xuat ma tran thuoc
            Console.ForegroundColor = ConsoleColor.Cyan;
            XuatMaTran(arrM);
            //Cau f: In tong so luong tren moi dong
            Console.ForegroundColor = ConsoleColor.Cyan;
            InTongSLTheoDong(arrM);
        }
        /// <summary>
        ///Cau f: In tong so luong tren moi dong
        /// </summary>
        /// <param name="arrM"></param>
        static void InTongSLTheoDong(Thuoc[][] arrM)
        {
            for (int i = 0; i < arrM.GetLength(0); i++)
            {
                int TongSL = 0;
                for (int j = 0; j < arrM[i].Length; j++)
                {
                    TongSL = TongSL + arrM[i][j].SoLuong;
                }
                Console.WriteLine($"Tong so luong tren dong {i} la: {TongSL}");
            }
        }
        /// <summary>
        /// Cau e: Xuat n danh sach thuoc
        /// </summary>
        /// <param name="arrM"></param>
        static void XuatMaTran(Thuoc[][]arrM)
        {
            for (int i = 0; i < arrM.GetLength(0); i++)
            {
                for (int j = 0; j < arrM[i].Length; j++)
                {
                    Console.Write($"{arrM[i][j].ToString(), -15}");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// cau d: Nhap n danh sach thuoc
        /// </summary>
        /// <param name="arrM"></param>
        static void NhapMaTran(out Thuoc[][]arrM)
        {
            //Khai bao va nhap so dong
            int n = 0, slThuoc = 0;
            Console.Write("Nhap so dong cua ma tran n = ");
            int.TryParse(Console.ReadLine(), out n);
            //Cap phát ma tran n dong
            arrM = new Thuoc[n][];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap so luong thuoc cho dong thu {i+1}: ");
                int.TryParse(Console.ReadLine(), out slThuoc);
                arrM[i] = NhapDSThuoc(slThuoc);
            }
        }
        /// <summary>
        /// cau c: Tim va ghi thong tin cua thuoc co so luong lon nhat
        /// </summary>
        /// <param name="arrA"></param>
        /// <param name="path"></param>
        /// 
        static void TimGhiSLMax(Thuoc[] arrA, string path)
        {
            //Tim so luong max
            Thuoc max = arrA[0];
            for (int i = 1; i < arrA.Length; i++)
            {
                if (arrA[i].SoLuong > max.SoLuong)
                {
                    max = arrA[i];
                }
            }
            //Ghi vao file
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Thong tin cua thuoc co so luong lon nhat: ");
                    sw.WriteLine(max.ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ghi file that bai!!!");
                throw;
            }
        }
        /// <summary>
        /// cau b: Xuat danh sach thuoc
        /// </summary>
        /// <param name="arrA"></param>
        static void XuatDSThuoc(Thuoc[] arrA)
        {
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.WriteLine(arrA[i].ToString());
            }
        }
        /// <summary>
        /// Câu a: Hàm nhập danh sách thuốc
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static Thuoc[] NhapDSThuoc(int n)
        {
            Thuoc[] arrA = new Thuoc[n];
            for (int i = 0; i < arrA.Length; i++)
            {
                arrA[i] = NhapThuoc();
            }
            return arrA;
        }
        /// <summary>
        /// Ham nhap thong tin cho 1 thuoc
        /// </summary>
        /// <returns></returns>
        static Thuoc NhapThuoc()
        {
            Thuoc th = new Thuoc();
            do
            {
                Console.Write("\tNhap Ma Thuoc: ");
                th.MaThuoc = Console.ReadLine();
            } while (KiemTraChuoi(th.MaThuoc) == false);
            do
            {
                Console.Write("\tNhap Ten Thuoc: ");
                th.TenThuoc = Console.ReadLine();
            } while (KiemTraChuoi(th.TenThuoc) == false);
            Console.Write("\tNhap Ngay Nhap (theo dong ho he thong): ");
            DateTime.TryParse(Console.ReadLine(), out th.NgayNhap);
            Console.Write("\tNhap So Luong: ");
            int.TryParse(Console.ReadLine(), out th.SoLuong);
            Console.WriteLine("---------------------------------------");
            return th;
        }
        static bool KiemTraChuoi(string s)
        {
            if (s.Length > 30 || s[0] == ' ' || s[s.Length-1] == ' ' || s.Contains(" ")==true)
            {
                return false;
            }
            return true;
        }
        //Tim max cách 2 ghi rieng
        //static Thuoc TimSLMax(Thuoc[] arrA)
        //{
        //    Thuoc max = arrA[0];
        //    for (int i = 1; i < arrA.Length; i++)
        //    {
        //        if (arrA[i].SoLuong > max.SoLuong)
        //        {
        //            max = arrA[i];
        //        }
        //    }
        //    return max;
        //}
        ////Ghi so luong max cach 2 ghi rieng
        //static void GhiSLMax(Thuoc[] arrA, string path)
        //{
        //    Thuoc max = TimSLMax(arrA);
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(path))
        //        {
        //            sw.WriteLine("Thong tin cua thuoc co so luong lon nhat: ");
        //            sw.WriteLine(max.ToString());
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Ghi file that bai!!!");
        //        throw;
        //    }
        //}
    }
}
