using System;
using System.Collections.Generic;
using System.Text;


namespace Đồ_án_I
{
    public class QLmenu
    {
        public static int menu1()
        {
            Console.Clear();
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=============MAIN MENU=============");
            Console.WriteLine("========HỆ THỐNG QUẢN LÝ SINH VIÊN KHOA CNTT========");
            Console.WriteLine("===============QUẢN LÝ SINH VIÊN====================");
            Console.WriteLine("‖1.   Nhập danh sách sinh viên                      ‖");
            Console.WriteLine("‖2.   Tìm sinh viên                                 ‖");
            Console.WriteLine("‖3.   Xóa thông tin sinh viên                       ‖");
            Console.WriteLine("‖4.   Sửa thông tin sinh viên                       ‖");
            Console.WriteLine("‖5.   Hien thi cac sinh viên                        ‖");
            Console.WriteLine("‖6.   Quay lại                                      ‖");
            Console.Write("\n Chọn mục: ");
            int t;
            do
            {
                t = int.Parse(Console.ReadLine());
                return t;
            }
            while (t < 1 || t > 6);

        }
        public static int menu2()
        {
            {
                Console.Clear();
                Console.InputEncoding = Encoding.UTF8;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("=============MAIN MENU=============");
                Console.WriteLine("========HỆ THỐNG QUẢN LÝ SINH VIÊN KHOA CNTT========");
                Console.WriteLine("===============QUẢN LÝ ĐIỂM SINH VIÊN====================");
                Console.WriteLine("‖1.   Nhập điểm sinh viên                               ‖");
                Console.WriteLine("‖2.   Tìm điểm sinh viên theo mã                        ‖");
                Console.WriteLine("‖3.   Xóa điểm sinh viên                                ‖");
                Console.WriteLine("‖4.   Sửa điểm sinh viên                                ‖");
                Console.WriteLine("‖5.   Hiển thị điểm sinh viên                           ‖");
                Console.WriteLine("‖6.   Quay lại                                          ‖");
            }
            Console.Write("\n Bạn hãy chọn mục (1->6): ");
            int t;
            do
            {
                t = int.Parse(Console.ReadLine());
                return t;
            }
            while (t < 1 || t > 6);
        }
    }
}