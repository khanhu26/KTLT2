using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OnThi_cau2
{
    struct HocSinh
    {
        public string MaHS;
        public string HoTen;
        public DateTime NgaySinh;
        public int SoLanVP;

        public string ToString()
        {
            return $"({MaHS},{HoTen},{NgaySinh.ToString("dd/MM/yy")},{SoLanVP})";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ////Khai bao và số lượng thuốc
            //int n = 0;
            //HocSinh[] arrA;
            //Console.Write("Nhap so luong hoc sinh trong danh sach: ");
            //int.TryParse(Console.ReadLine(), out n);
            ////Cau a: Goi ham nhap danh sach n thuoc
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //arrA = NhapDSHocSinh(n);
            ////Cau b: Goi ham xuat danh sach n thuoc
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine($"\tXUAT DANH SACH {n} HOC SINH: ");
            //XuatDSHocinh(arrA);
            ////Cau c: Tim va ghi thong tin cua thuoc co so luong lon nhat
            //TimGhiSLVPMax(arrA, "SLVP_max.txt");
            //Cau d: Nhap n danh sach
            //khai bao va cap phat ma tran thuoc
            Console.ForegroundColor = ConsoleColor.Red;
            HocSinh[][] arrHS;
            NhapMaTran(out arrHS);
            //Cau e: Xuat ma tran thuoc
            Console.ForegroundColor = ConsoleColor.Cyan;
            XuatMaTran(arrHS);
            //Cau f: In tong so luong tren moi dong
            Console.ForegroundColor = ConsoleColor.Cyan;
            InTongSLVPTheoDong(arrHS);
        }
        /// <summary>
        ///Cau f: In tong so luong tren moi dong
        /// </summary>
        /// <param name="arrHS"></param>
        static void InTongSLVPTheoDong(HocSinh[][] arrHS)
        {
            for (int i = 0; i < arrHS.GetLength(0); i++)
            {
                int TongSL_VP = 0;
                for (int j = 0; j < arrHS[i].Length; j++)
                {
                    TongSL_VP = TongSL_VP + arrHS[i][j].SoLanVP;
                }
                Console.WriteLine($"Tong so lan vi pham tren dong {i+1} la: {TongSL_VP}");
            }
        }
        /// <summary>
        /// Cau e:Ham xuat ma tran
        /// </summary>
        /// <param name="arrHS"></param>
        static void XuatMaTran(HocSinh[][] arrHS)
        {
            Console.WriteLine("\t\t\t-----XUAT THONG TIN SINH VIEN-----");
            for (int i = 0; i < arrHS.GetLength(0); i++)
            {
                Console.WriteLine("=============================================================");
                Console.WriteLine("\t\t\tSinh vien thu: {0}", i + 1);
                Console.WriteLine("=============================================================");
                Console.WriteLine($"{"Ma HS",10}, {"Ho Ten",15}, {"Ngay Sinh",15}, {"So Lan Vi Pham",15}");
                for (int j = 0; j < arrHS[i].Length; j++)
                {
                    Console.WriteLine($"{arrHS[i][j].MaHS,8} {arrHS[i][j].HoTen,15} {arrHS[i][j].NgaySinh.ToString("dd/MM/yyyy"),18} {arrHS[i][j].SoLanVP,10}");

                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Cau d:Ham nhap ma tran 
        /// </summary>
        /// <param name="arrHS"></param>
        static void NhapMaTran(out HocSinh[][] arrHS)
        {
            //Khai bao va nhap so dong
            int n = 0, sl_vp = 0;
            Console.Write("Nhap so dong cua ma tran n = ");
            int.TryParse(Console.ReadLine(), out n);
            //Cap phát ma tran n dong
            arrHS = new HocSinh[n][];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap so hoc sinh vi pham cho dong thu {i + 1}: ");
                int.TryParse(Console.ReadLine(), out sl_vp);
                arrHS[i] = NhapDSHocSinh(sl_vp);
            }
        }
        /// <summary>
        /// Cau c:Ham ghi so lan vi pham trong 1 ngay
        /// </summary>
        /// <param name="arrA"></param>
        /// <param name="path"></param>
        static void TimGhiSLVPMax(HocSinh[] arrA, string path)
        {
            //Tim so luong max
            HocSinh max = arrA[0];
            for (int i = 1; i < arrA.Length; i++)
            {
                if (arrA[i].SoLanVP > max.SoLanVP)
                {
                    max = arrA[i];
                }
            }
            //Ghi vao file
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Thong tin cua hoc sinh co so lan vi pham lon nhat: ");
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
        /// Cau b:Ham xuat danh sach hoc sinh
        /// </summary>
        /// <param name="arrA"></param>
        static void XuatDSHocinh(HocSinh[] arrA)
        {
            Console.WriteLine("\n \t----THONG TIN HOC SINH---- \n");
            Console.WriteLine($"{"Ma HS", 10}, {"Ho Ten",15}, {"Ngay Sinh",15}, {"So Lan Vi Pham",15}");
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.WriteLine($"{arrA[i].MaHS,8} {arrA[i].HoTen,15} {arrA[i].NgaySinh.ToString("dd/MM/yyyy"),18} {arrA[i].SoLanVP,10}");
            }
        }
        /// <summary>
        /// Cau a:Ham nhap danh sach hoc sinh
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static HocSinh[] NhapDSHocSinh(int n)
        {
            HocSinh[] arrA = new HocSinh[n];
            for (int i = 0; i < arrA.Length; i++)
            {
                arrA[i] = NhapHocSinh();
            }
            return arrA;
        }
        /// <summary>
        /// Ham nhap thong tin cho mot hoc sinh
        /// </summary>
        /// <returns></returns>
        static HocSinh NhapHocSinh()
        {
            HocSinh hs = new HocSinh();
            do
            {
                Console.Write("\tNhap Ma HS: ");
                hs.MaHS = Console.ReadLine();
            } while (KiemTraChuoi(hs.MaHS) == false);
            do
            {
                Console.Write("\tNhap Ho Ten: ");
                hs.HoTen = Console.ReadLine();
            } while (KiemTraChuoi(hs.HoTen) == false);
            Console.Write("\tNhap Ngay Sinh (theo dong ho he thong): ");
            DateTime.TryParse(Console.ReadLine(), out hs.NgaySinh);
            Console.Write("\tNhap So lan VP: ");
            int.TryParse(Console.ReadLine(), out hs.SoLanVP);
            Console.WriteLine("------------------------------------");
            return hs;
        }
        static bool KiemTraChuoi(string s)
        {
            if (s.Length > 30 || s[0] == ' ' || s[s.Length - 1] == ' ' || s.Contains(" ") == true)
            {
                return false;
            }
            return true;
        }
    }
}
