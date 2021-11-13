using System;
using System.Text;
namespace Đồ_án_I
{
    class Program
    {
        public static int menu()
        {


            Console.Clear();
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=============MAIN MENU=============");
            Console.WriteLine("========HỆ THỐNG QUẢN LÝ SINH VIÊN KHOA CNTT========");
            Console.WriteLine("‖1.   QUẢN LÝ SINH VIÊN                           ‖");
            Console.WriteLine("‖2.   QUẢN LÝ ĐIỂM SINH VIÊN                      ‖");
            Console.WriteLine("‖3.   THOAT                                       ‖");
            Console.WriteLine("===================================================");
            int t;
            do
            {
                Console.Write("\n Chọn mục : ");
                t = int.Parse(Console.ReadLine());
                return t;
            }
            while (t < 1 || t > 4);


        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            QLSV sv = new QLSV();
            QLScore qlsc = new QLScore();
            Console.Clear();
            do
            {
                switch (menu())
                {
                    case 1:
                        do
                        {
                            switch (QLmenu.menu1())
                            {
                                case 1: Console.Clear(); sv.ImportSV(); break;
                                case 2: sv.SearchSV(); break;
                                case 3: sv.DeleteSV(); break;
                                case 4: sv.EditSV(); break;
                                case 5: sv.ShowSV(); break;
                                case 6: Đồ_án_I.Program.menu(); Console.ReadKey(); break;
                            }
                        } while (QLmenu.menu1() != 6);
                        Console.ReadKey();
                        break;
                    case 2:
                        do
                        {
                            switch (QLmenu.menu2())
                            {

                                case 1: qlsc.ImportScore(); break;
                                case 2: qlsc.SearchScore(); Console.ReadKey(); break;
                                case 3: qlsc.DeleteScore(); Console.ReadKey(); break;
                                case 4: qlsc.EditScore(); Console.ReadKey(); break;
                                case 5: qlsc.ShowScore(); Console.ReadKey(); break;
                                case 6: Đồ_án_I.Program.menu(); break;
                            }
                        } while (QLmenu.menu2() != 6);
                        Console.ReadKey(); break;
                    case 3:
                        Environment.Exit(0); break;
                }
            } while (true);

        }
    }
}


