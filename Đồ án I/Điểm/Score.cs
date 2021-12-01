using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Đồ_án_I
{
    #region Các thành phần dữ liệu được nạp vào
    public class Score
    {
        private int masv;
        private double dstt, gdtc, ktmt, dhnn, ltpcb, gdqpvan, knm, pldc, gt, gdtc2, mmm, ctdlvgt, hdh, csktlt;
        public int MaSv
        {
            get { return masv; }
            set
            {
                if (value >= 1)
                    masv = value;
            }
        }
        public double Dstt
        {
            get { return dstt; }
            set
            {
                if (value >= 0 && value <= 10)
                    dstt = value;
            }
        }
        public double Gdtc
        {
            get { return gdtc; }
            set
            {
                if (value >= 0 && value <= 10)
                    gdtc = value;
            }
        }
        public double Ktmt
        {
            get { return ktmt; }
            set
            {
                if (value >= 0 && value <= 10)
                    ktmt = value;
            }
        }
        public double Dhnn
        {
            get { return dhnn; }
            set
            {
                if (value >= 0 && value <= 10)
                    dhnn = value;
            }
        }
        public double Ltpcb
        {
            get { return ltpcb; }
            set
            {
                if (value >= 0 && value <= 10)
                    ltpcb = value;
            }
        }
        public double Gdqpvan
        {
            get { return gdqpvan; }
            set
            {
                if (value >= 0 && value <= 10)
                    gdqpvan = value;
            }
        }
        public double Knm
        {
            get { return knm; }
            set
            {
                if (value >= 0 && value <= 10)
                    knm = value;
            }
        }
        public double Pldc
        {
            get { return pldc; }
            set
            {
                if (value >= 0 && value <= 10)
                    pldc = value;
            }
        }
        public double Gt
        {
            get { return gt; }
            set
            {
                if (value >= 0 && value <= 10)
                    gt = value;
            }
        }
        public double Gdtc2
        {
            get { return gdtc2; }
            set
            {
                if (value >= 0 && value <= 10)
                    gdtc2 = value;
            }
        }
        public double Mmm
        {
            get { return mmm; }
            set
            {
                if (value >= 0 && value <= 10)
                    mmm = value;
            }
        }
        public double Ctdlvgt
        {
            get { return ctdlvgt; }
            set
            {
                if (value >= 0 && value <= 10)
                    ctdlvgt = value;
            }
        }
        public double Hdh
        {
            get { return hdh; }
            set
            {
                if (value >= 0 && value <= 10)
                    hdh = value;
            }
        }
        public double Csktlt
        {
            get { return csktlt; }
            set
            {
                if (value >= 0 && value <= 10)
                    csktlt = value;
            }
        }
        #endregion
        #region Các phương thức
        public Score()
        { }
        public Score(Score sc)
        {
            this.dstt = sc.dstt;
            this.gdtc = sc.gdtc;
            this.ktmt = sc.ktmt;
            this.dhnn = sc.dhnn;
            this.ltpcb = sc.ltpcb;
            this.gdqpvan = sc.gdqpvan;
            this.knm = sc.knm;
            this.pldc = sc.pldc;
            this.gt = sc.gt;
            this.gdtc2 = sc.gdtc2;
            this.mmm = sc.mmm;
            this.ctdlvgt = sc.ctdlvgt;
            this.hdh = sc.hdh;
            this.csktlt = sc.csktlt;
        }
        public Score(int masv, double dstt, double gdtc, double ktmt, double dhnn, double ltpcb, double gdqpvan, double knm, double pldc, double gt, double gdtc2, double mmm, double ctdlvgt, double hdh, double csktlt)
        {
            this.masv = masv;
            this.dstt = dstt;
            this.gdtc = gdtc;
            this.ktmt = ktmt;
            this.dhnn = dhnn;
            this.ltpcb = ltpcb;
            this.gdqpvan = gdqpvan;
            this.knm = knm;
            this.pldc = pldc;
            this.gt = gt;
            this.gdtc2 = gdtc2;
            this.mmm = mmm;
            this.ctdlvgt = ctdlvgt;
            this.hdh = hdh;
            this.csktlt = csktlt;
        }

    }
    #endregion
    class QLScore
    {
        #region Xử lý với tệp
        private string txtfile = "Score.txt";
        //Lấy toàn bộ dữ liệu có trong file Score.txt đưa vào một danh sách 
        public List<Score> GetAllData()
        {
            List<Score> list = new List<Score>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Score(int.Parse(a[0]), double.Parse(a[1]), double.Parse(a[2]), double.Parse(a[3]), double.Parse(a[4]), double.Parse(a[5]), double.Parse(a[6]), double.Parse(a[7]), double.Parse(a[8]), double.Parse(a[9]), double.Parse(a[10]), double.Parse(a[11]), double.Parse(a[12]), double.Parse(a[13]), double.Parse(a[14])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Thêm thông tin điểm sinh viên
        public void Insert(Score SC)
        {

            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(SC.MaSv + "#" + SC.Dstt + "#" + SC.Gdtc + "#" + SC.Ktmt + "#" + SC.Dhnn + "#" + SC.Ltpcb + "#" + SC.Gdqpvan + "#" + SC.Knm + "#" + SC.Pldc + "#" + SC.Gt + "#" + SC.Gdtc2 + "#" + SC.Mmm + "#" + SC.Ctdlvgt + "#" + SC.Hdh + "#" + SC.Csktlt);
            fwrite.Close();
        }
        //Xóa một thông tin điểm sinh viên khi biết mã sinh viên
        public void Delete(int masv)
        {
            List<Score> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Score SC in list)
                if (SC.MaSv != masv)
                    fwrite.WriteLine(SC.MaSv + "#" + SC.Dstt + "#" + SC.Gdtc + "#" + SC.Ktmt + "#" + SC.Dhnn + "#" + SC.Ltpcb + "#" + SC.Gdqpvan + "#" + SC.Knm + "#" + SC.Pldc + "#" + SC.Gt + "#" + SC.Gdtc2 + "#" + SC.Mmm + "#" + SC.Ctdlvgt + "#" + SC.Hdh + "#" + SC.Csktlt);
            fwrite.Close();
        }
        //Sửa một thông tin điểm sinh viên
        public void Update(Score x)
        {
            List<Score> list = GetAllData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].MaSv == x.MaSv) { list[i] = x; break; }

            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Score SC in list)
                fwrite.WriteLine(SC.MaSv + "#" + SC.Dstt + "#" + SC.Gdtc + "#" + SC.Ktmt + "#" + SC.Dhnn + "#" + SC.Ltpcb + "#" + SC.Gdqpvan + "#" + SC.Knm + "#" + SC.Pldc + "#" + SC.Gt + "#" + SC.Gdtc2 + "#" + SC.Mmm + "#" + SC.Ctdlvgt + "#" + SC.Hdh + "#" + SC.Csktlt);
            fwrite.Close();
        }
        #endregion
        public bool check(int masv)
        {

            foreach (Score SC in GetAllData())
                if (SC.MaSv != masv)
                {
                    return true;
                }
            return false;
        }
        #region Hàm thêm điểm sinh viên
        public void Add(Score SC)
        {
            if (SC.MaSv >1)
            {
                Insert(SC);
            }
            else
                throw new Exception("Dữ liệu bạn thêm vào bị sai");
        }
        public void ImportScore()
        {
            do
            {
                //Hiên thị mẫu nhập
                Console.Clear();
                Console.WriteLine("                           NHẬP THÔNG TIN ĐIỂM SINH VIÊN");
                Console.WriteLine("====================================================================================");
                Console.WriteLine("| Mã sinh viên :                                                                   |");
                Console.WriteLine("| Điểm môn Đại số tuyến tính :                                                     |");
                Console.WriteLine("| Điểm môn Giáo dục thể chất :                                                     |");
                Console.WriteLine("| Điểm môn Kỹ thuật máy tính :                                                     |");
                Console.WriteLine("| Điểm môn Định hướng nghề nghiệp :                                                |");
                Console.WriteLine("| Điểm môn Lập trình Python cơ bản :                                               |");
                Console.WriteLine("| Điểm môn Giáo dục quốc phòng và an ninh :                                        |");
                Console.WriteLine("| Điểm môn Kỹ năng mềm :                                                           |");
                Console.WriteLine("| Điểm môn Pháp luật đại cương :                                                   |");
                Console.WriteLine("| Điểm môn Giải tích :                                                             |");
                Console.WriteLine("| Điểm môn Giáo dục thể chất 2:                                                    |");
                Console.WriteLine("| Điểm môn Mạng máy tính:                                                          |");
                Console.WriteLine("| Điểm môn Cấu trúc dữ liệu và giải thuật:                                         |");
                Console.WriteLine("| Điểm môn Hệ điều hành:                                                           |");
                Console.WriteLine("| Điểm môn Cơ sở kỹ thuật lập trình:                                               |");
                Console.WriteLine("====================================================================================");
                Console.WriteLine();
                //Hiển thị danh sách đã nhập
                int x = 0;
                int y = 17;
                int v = ShowScore3(GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Esc de thoat, Enter de luu!", 15);
                //Yêu cầu nhập thông tin theo mẫu nhập
                Score sc = new Score();
                Console.SetCursorPosition(19, 2); sc.MaSv = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(30, 3); sc.Dstt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(30, 4); sc.Gdtc = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(30, 5); sc.Ktmt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(35, 6); sc.Dhnn = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(36, 7); sc.Ltpcb = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(43, 8); sc.Gdqpvan = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(24, 9); sc.Knm = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(32, 10); sc.Pldc = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(22, 11); sc.Gt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(43, 12); sc.Gdtc2 = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(40, 13); sc.Mmm = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(60, 14); sc.Ctdlvgt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(40, 15); sc.Hdh = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(60, 16); sc.Csktlt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(60, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else if (kt.Key == ConsoleKey.Enter) Add(sc);
            } while (true);
        }
        public int ShowScore3(List<Score> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {
            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("┌─────────┬────┬────┬────┬────┬──────────┬───────┬───┬────┬─────────┬─────┬─────────────┬───────┬─────────────┬──────┐");
            y = y + 5;
            Console.SetCursorPosition(x, y); Console.Write("│  Mã SV");
            Console.SetCursorPosition(x + 10, y); Console.Write("│ĐSTT");
            Console.SetCursorPosition(x + 15, y); Console.Write("│GDTC");
            Console.SetCursorPosition(x + 20, y); Console.Write("│KTMT ");
            Console.SetCursorPosition(x + 25, y); Console.Write("│ĐHNN");
            Console.SetCursorPosition(x + 30, y); Console.Write("│LTPythonCB");
            Console.SetCursorPosition(x + 41, y); Console.Write("│GDQP&AN");
            Console.SetCursorPosition(x + 49, y); Console.Write("│KNM");
            Console.SetCursorPosition(x + 53, y); Console.Write("│PLĐC");
            Console.SetCursorPosition(x + 58, y); Console.Write("│Giải tích");
            Console.SetCursorPosition(x + 68, y); Console.Write("│GDTC2");
            Console.SetCursorPosition(x + 74, y); Console.Write("│Mạng máy tính");
            Console.SetCursorPosition(x + 88, y); Console.Write("│CTDL&GT");
            Console.SetCursorPosition(x + 96, y); Console.Write("│Hệ điều hành");
            Console.SetCursorPosition(x + 110, y); Console.Write("│CSKTLT│");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(0, y); Console.Write("│" + list[i].MaSv);
                Console.SetCursorPosition(10, y); Console.Write("│" + list[i].Dstt);
                Console.SetCursorPosition(15, y); Console.Write("│" + list[i].Gdtc);
                Console.SetCursorPosition(20, y); Console.Write("│" + list[i].Ktmt);
                Console.SetCursorPosition(25, y); Console.Write("│" + list[i].Dhnn);
                Console.SetCursorPosition(30, y); Console.Write("│" + list[i].Ltpcb);
                Console.SetCursorPosition(41, y); Console.Write("│" + list[i].Gdqpvan);
                Console.SetCursorPosition(49, y); Console.Write("│" + list[i].Knm);
                Console.SetCursorPosition(53, y); Console.Write("│" + list[i].Pldc);
                Console.SetCursorPosition(58, y); Console.Write("│" + list[i].Gt);
                Console.SetCursorPosition(68, y); Console.Write("│" + list[i].Gdtc2);
                Console.SetCursorPosition(74, y); Console.Write("│" + list[i].Mmm);
                Console.SetCursorPosition(88, y); Console.Write("│" + list[i].Ctdlvgt);
                Console.SetCursorPosition(96, y); Console.Write("│" + list[i].Hdh);
                Console.SetCursorPosition(110, y); Console.Write("│" + list[i].Csktlt);
                Console.SetCursorPosition(117, y); Console.Write("│");
                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine("└─────────┴────┴────┴────┴────┴──────────┴───────┴───┴────┴─────────┴─────┴─────────────┴───────┴─────────────┴──────┘");
            Console.Write(tieudecuoi);
            return Console.CursorTop;//Trả về vị trí hàng hiện tại
        }
        #endregion
        #region Hàm xoá điểm sinh viên
        public void DeleteScore(int masv)
        {
            List<Score> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Score sc in list)
                if (sc.MaSv !=masv)
                    fwrite.WriteLine(sc.MaSv + "#" + sc.Dstt + "#" + sc.Gdtc + "#" + sc.Ktmt + "#" + sc.Dhnn + "#" + sc.Ltpcb + "#" + sc.Gdqpvan + "#" + sc.Knm + "#" + sc.Pldc + "#" + sc.Gt + "#" + sc.Gdtc2 + "#" + sc.Mmm + "#" + sc.Ctdlvgt + "#" + sc.Hdh + "#" + sc.Csktlt);
            fwrite.Close();
        }
        public void DeleteScore()
        {
            do
            {
                Console.Clear();
                ShowScore(GetAllData(), 0, 0, "                 DANH SÁCH THÔNG TIN ĐIỂM SINH VIÊN                 ", "Nhập mã sinh viên để xóa, thoát nhấn enter!", 20);
                int d =int.Parse( Console.ReadLine());
                ConsoleKeyInfo kt = Console.ReadKey();
                if (d == 0) return;
                else Delete(d);
            } while (true);
        }
        #endregion
        #region Hàm sửa điểm sinh viên
        //Sửa điểm sinh viên
        public void EditScore()
        {
            //////Hiên thị mẫu nhập
            Console.Clear();
            int masv;
            do
            {
                try
                {
                    Console.Write("Nhập mã cần sửa: ");
                    masv = int.Parse(Console.ReadLine());

                    if (!check(masv))
                    {
                        Console.WriteLine("Mã Điện Thoại không tồn tại !!!");
                        continue;
                    }
                    else
                        break;
                }
                catch (Exception) { }
            } while (true);

            Delete(masv);
            Console.WriteLine("Nhập các thông tin cần sửa:");
            ImportScore();
            Console.WriteLine("Đã cập nhật thành công!!!");

        }
        #endregion
        #region Hàm tìm kiếm điểm sinh viên 
        //tìm kiếm thông tin sinh viên
        public List<Score> Search()
        {
            int masvcheck;
            List<Score> list = GetAllData();
            List<Score> kq = new List<Score>();
            Console.Write("Nhập mã sinh viên cần tìm:");
            masvcheck =int.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].MaSv == masvcheck)
                    kq.Add(new Score(list[i]));
            }
            return kq;
        }
        //Tìm điểm của 1 sinh viên
        public void SearchScore()
        {
            string masv = "";
            do
            {
                Console.Clear();
                List<Score> list = Search();
                ShowScore2(list, 0, 0, "                 DANH SÁCH THÔNG TIN ĐIỂM SINH VIÊN                       ", "Nhấn Enter de thoat!", 30);
                masv = Console.ReadLine();
                if (masv == "") return;
            } while (true);
        }
        public int ShowScore2(List<Score> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {
            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("┌────┬──────┬───────┬────┬──────────┬───────┬────┬─────┬─────────┬─────┬─────────────┬───────┬────────────┬──────┐");
            y = y + 4;
            Console.SetCursorPosition(x , y); Console.Write("│ĐSTT");
            Console.SetCursorPosition(x + 5, y); Console.Write("│GDTC");
            Console.SetCursorPosition(x + 12, y); Console.Write("│KTMT ");
            Console.SetCursorPosition(x + 20, y); Console.Write("│ĐHNN");
            Console.SetCursorPosition(x + 25, y); Console.Write("│LTPythonCB");
            Console.SetCursorPosition(x + 36, y); Console.Write("│GDQP&AN");
            Console.SetCursorPosition(x + 44, y); Console.Write("│KNM");
            Console.SetCursorPosition(x + 49, y); Console.Write("│PLĐC");
            Console.SetCursorPosition(x + 55, y); Console.Write("│Giải tích");
            Console.SetCursorPosition(x + 65, y); Console.Write("│GDTC2");
            Console.SetCursorPosition(x + 71, y); Console.Write("│Mạng máy tính");
            Console.SetCursorPosition(x + 85, y); Console.Write("│CTDL&GT");
            Console.SetCursorPosition(x + 93, y); Console.Write("│Hệ điều hành");
            Console.SetCursorPosition(x + 106, y); Console.Write("│CSKTLT│");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(0, y); Console.Write("│" + list[i].Dstt);
                Console.SetCursorPosition(5, y); Console.Write("│" + list[i].Gdtc);
                Console.SetCursorPosition(12, y); Console.Write("│" + list[i].Ktmt);
                Console.SetCursorPosition(20, y); Console.Write("│" + list[i].Dhnn);
                Console.SetCursorPosition(25, y); Console.Write("│" + list[i].Ltpcb);
                Console.SetCursorPosition(36, y); Console.Write("│" + list[i].Gdqpvan);
                Console.SetCursorPosition(44, y); Console.Write("│" + list[i].Knm);
                Console.SetCursorPosition(49, y); Console.Write("│" + list[i].Pldc);
                Console.SetCursorPosition(55, y); Console.Write("│" + list[i].Gt);
                Console.SetCursorPosition(65, y); Console.Write("│" + list[i].Gdtc2);
                Console.SetCursorPosition(71, y); Console.Write("│" + list[i].Mmm);
                Console.SetCursorPosition(85, y); Console.Write("│" + list[i].Ctdlvgt);
                Console.SetCursorPosition(93, y); Console.Write("│" + list[i].Hdh);
                Console.SetCursorPosition(106, y); Console.Write("│" + list[i].Csktlt);
                Console.SetCursorPosition(113, y);Console.Write("│");
                Console.WriteLine("");
                Console.WriteLine("└────┴──────┴───────┴────┴──────────┴───────┴────┴─────┴─────────┴─────┴─────────────┴───────┴────────────┴──────┘");
                if ((++d) == n) break;
            }
            Console.WriteLine();
            Console.Write(tieudecuoi);
            return Console.CursorTop;//Trả về vị trí hàng hiện tại
        }

        #endregion
        #region Hàm hiển thị điểm sinh viên
        public int ShowScore(List<Score> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {
            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("┌─────────┬────┬────┬────┬────┬──────────┬───────┬───┬────┬─────────┬─────┬─────────────┬───────┬─────────────┬──────┐");
            y = y + 3;
            Console.SetCursorPosition(x , y); Console.Write("│  Mã SV");
            Console.SetCursorPosition(x + 10, y); Console.Write("│ĐSTT");
            Console.SetCursorPosition(x + 15, y); Console.Write("│GDTC");
            Console.SetCursorPosition(x + 20, y); Console.Write("│KTMT ");
            Console.SetCursorPosition(x + 25, y); Console.Write("│ĐHNN");
            Console.SetCursorPosition(x + 30, y); Console.Write("│LTPythonCB");
            Console.SetCursorPosition(x + 41, y); Console.Write("│GDQP&AN");
            Console.SetCursorPosition(x + 49, y); Console.Write("│KNM");
            Console.SetCursorPosition(x + 53, y); Console.Write("│PLĐC");
            Console.SetCursorPosition(x + 58, y); Console.Write("│Giải tích");
            Console.SetCursorPosition(x + 68, y); Console.Write("│GDTC2");
            Console.SetCursorPosition(x + 74, y); Console.Write("│Mạng máy tính");
            Console.SetCursorPosition(x + 88, y); Console.Write("│CTDL&GT");
            Console.SetCursorPosition(x + 96, y); Console.Write("│Hệ điều hành");
            Console.SetCursorPosition(x + 110, y); Console.Write("│CSKTLT│");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(0, y); Console.Write("│"+list[i].MaSv);
                Console.SetCursorPosition(10, y); Console.Write("│" + list[i].Dstt);
                Console.SetCursorPosition(15, y); Console.Write("│" + list[i].Gdtc);
                Console.SetCursorPosition(20, y); Console.Write("│" + list[i].Ktmt);
                Console.SetCursorPosition(25, y); Console.Write("│" + list[i].Dhnn);
                Console.SetCursorPosition(30, y); Console.Write("│" + list[i].Ltpcb);
                Console.SetCursorPosition(41, y); Console.Write("│" + list[i].Gdqpvan);
                Console.SetCursorPosition(49, y); Console.Write("│" + list[i].Knm);
                Console.SetCursorPosition(53, y); Console.Write("│" + list[i].Pldc);
                Console.SetCursorPosition(58, y); Console.Write("│" + list[i].Gt);
                Console.SetCursorPosition(68, y); Console.Write("│" + list[i].Gdtc2);
                Console.SetCursorPosition(74, y); Console.Write("│" + list[i].Mmm);
                Console.SetCursorPosition(88, y); Console.Write("│" + list[i].Ctdlvgt);
                Console.SetCursorPosition(96, y); Console.Write("│" + list[i].Hdh);
                Console.SetCursorPosition(110, y); Console.Write("│" + list[i].Csktlt);
                Console.SetCursorPosition(117, y);Console.Write("│");
                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine("└─────────┴────┴────┴────┴────┴──────────┴───────┴───┴────┴─────────┴─────┴─────────────┴───────┴─────────────┴──────┘");
            Console.Write(tieudecuoi);
            return Console.CursorTop;//Trả về vị trí hàng hiện tại
        }
        

        
        public void ShowScore()
        {

            Console.Clear();
            List<Score> list = GetAllData();
            ShowScore(list, 0, 0, "                 DANH SÁCH THÔNG TIN SINH VIÊN                       ", "Nhấn Enter để thoát!", list.Count);
            Console.ReadLine();
        }
        public Score theomaScore(int masv)
        {
            Score sc = null;
            foreach (Score c in GetAllData())
                if (c.MaSv == masv)
                {
                    sc = new Score(c); break;
                }
            return sc;
        }
        #endregion
    }
}