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
    class QLScore
    {
        private string txtfile = "Score.txt";
        //Lấy toàn bộ dữ liệu có trong file Score.txt đưa vào một danh sách 
        public List<Score> GetAllData2()
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
                    list.Add(new Score(int.Parse(a[0]), double.Parse(a[1]),double.Parse(a[2]),double.Parse(a[3]),double.Parse(a[4]),double.Parse(a[5]),double.Parse(a[6]), double.Parse(a[7]), double.Parse(a[8]), double.Parse(a[9]), double.Parse(a[10]), double.Parse(a[11]),double.Parse(a[12]), double.Parse(a[13]), double.Parse(a[14])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Thêm thông tin điểm sinh viên
        public void Insert(Score sc)
        {

            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(sc.MaSv + "#" + sc.Dstt+"#"+sc.Gdtc + "#"+sc.Ktmt + "#"+sc.Dhnn + "#" + sc.Ltpcb + "#" + sc.Gdqpvan + "#" + sc.Knm + "#" + sc.Pldc + "#" + sc.Gt + "#" + sc.Gdtc2 + "#" + sc.Mmm + "#" + sc.Ctdlvgt + "#" + sc.Hdh + "#" + sc.Csktlt );
            fwrite.Close();
        }
        //Xóa một thông tin điểm sinh viên khi biết mã sinh viên
        public void Delete(int masv)
        {
            List<Score> list = GetAllData2();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Score sc in list)
                if (sc.MaSv != masv)
                    fwrite.WriteLine(sc.MaSv + "#" + sc.Dstt + "#" + sc.Gdtc + "#" + sc.Ktmt + "#" + sc.Dhnn + "#" + sc.Ltpcb + "#" + sc.Gdqpvan + "#" + sc.Knm + "#" + sc.Pldc + "#" + sc.Gt + "#" + sc.Gdtc2 + "#" + sc.Mmm + "#" + sc.Ctdlvgt + "#" + sc.Hdh + "#" + sc.Csktlt);
            fwrite.Close();
        }
        //Sửa một thông tin điểm sinh viên
        public void Update(Score x)
        {
            List<Score> list = GetAllData2();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].MaSv == x.MaSv)
                {
                    list[i] = x;
                    break;
                }

            StreamWriter fwrite = File.AppendText(txtfile);
            foreach (Score sc in list)
                fwrite.WriteLine(sc.MaSv + "#" + sc.Dstt + "#" + sc.Gdtc + "#" + sc.Ktmt + "#" + sc.Dhnn + "#" + sc.Ltpcb + "#" + sc.Gdqpvan + "#" + sc.Knm + "#" + sc.Pldc + "#" + sc.Gt + "#" + sc.Gdtc2 + "#" + sc.Mmm + "#" + sc.Ctdlvgt + "#" + sc.Hdh + "#" + sc.Csktlt);
            fwrite.Close();
        }
        public bool check(int masv)
        {
            bool ok = false;
            foreach (Score sc in GetAllData2())
                if (sc.MaSv == masv)
                {
                    ok = true; break;
                }
            return ok;
        }
        public void Add(Score sc)
        {
            if (sc.MaSv > 1 )
            { 
                Insert(sc);
            }
            else
                throw new Exception("Dữ liệu bạn thêm vào bị sai");
        }
        public void DeleteScore(int masv)
        {
            List<Score> list = GetAllData2();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Score sc in list)
                if (sc.MaSv != masv)
                    fwrite.WriteLine(sc.MaSv + "#" + sc.Dstt + "#" + sc.Gdtc + "#" + sc.Ktmt + "#" + sc.Dhnn + "#" + sc.Ltpcb + "#" + sc.Gdqpvan + "#" + sc.Knm + "#" + sc.Pldc + "#" + sc.Gt + "#" + sc.Gdtc2 + "#" + sc.Mmm + "#" + sc.Ctdlvgt + "#" + sc.Hdh + "#" + sc.Csktlt);
            fwrite.Close();
        }

        public void EditScore(Score sc)
        {
            if (check(sc.MaSv))
                Update(sc);
            else
                throw new Exception("Không tồn tại thông tin điểm sinh viên này");
        }
        //tìm kiếm thông tin sinh viên
        public List<Score> Search(Score sc)
        {
            List<Score> list = GetAllData2();
            List<Score> kq = new List<Score>();
            //Giá trị ngầm định ban đầu
            if (sc.MaSv == 0)
            {
                kq = list;
            }
            //Tìm kiếm theo mã
            else if (sc.MaSv < 1)
            {
                foreach (Score c in list)
                    if (c.MaSv == sc.MaSv)
                    {
                        kq.Add(new Score(c));
                    }
            }
            else
                kq = null;
            //Console.WriteLine("Không tìm thấy mã sinh viên nào hợp lý để tìm thấy điểm");
            return kq;
        }
        public int ShowScore(List<Score> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {

            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("------------------------------------------------------");
            y = y + 5;
            Console.SetCursorPosition(x + 1, y); Console.Write("Mã SV");
            Console.SetCursorPosition(x + 10, y); Console.Write("ĐSTT");
            Console.SetCursorPosition(x + 15, y); Console.Write("GDTC");
            Console.SetCursorPosition(x + 20, y); Console.Write("KTMT ");
            Console.SetCursorPosition(x + 25, y); Console.Write("ĐHNN");
            Console.SetCursorPosition(x + 30, y); Console.Write("LTPythonCB");
            Console.SetCursorPosition(x + 41, y);Console.Write("GDQP&AN");
            Console.SetCursorPosition(x + 49, y);Console.Write("KNM");
            Console.SetCursorPosition(x + 53, y);Console.Write("PLĐC");
            Console.SetCursorPosition(x + 58, y);Console.Write("Giải tích");
            Console.SetCursorPosition(x + 68, y);Console.Write("GDTC2");
            Console.SetCursorPosition(x + 74, y);Console.Write("Mạng máy tính");
            Console.SetCursorPosition(x + 88, y);Console.Write("CTDL&GT");
            Console.SetCursorPosition(x + 96, y);Console.Write("Hệ điều hành");
            Console.SetCursorPosition(x + 110, y);Console.Write("CSKTLT");



            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].MaSv.ToString());
                Console.SetCursorPosition(10, y); Console.Write(list[i].Dstt);
                Console.SetCursorPosition(15, y); Console.Write(list[i].Gdtc);
                Console.SetCursorPosition(20, y); Console.Write(list[i].Ktmt);
                Console.SetCursorPosition(25, y); Console.Write(list[i].Dhnn);
                Console.SetCursorPosition(30, y); Console.Write(list[i].Ltpcb);
                Console.SetCursorPosition(41, y);Console.Write(list[i].Gdqpvan);
                Console.SetCursorPosition(49, y);Console.Write(list[i].Knm);
                Console.SetCursorPosition(53, y);Console.Write(list[i].Pldc);
                Console.SetCursorPosition(58, y);Console.Write(list[i].Gt);
                Console.SetCursorPosition(68, y);Console.Write(list[i].Gdtc2);
                Console.SetCursorPosition(74, y);Console.Write(list[i].Mmm);
                Console.SetCursorPosition(88, y);Console.Write(list[i].Ctdlvgt);
                Console.SetCursorPosition(96, y);Console.Write(list[i].Hdh);
                Console.SetCursorPosition(110, y);Console.Write(list[i].Csktlt);
                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine();
            Console.Write(tieudecuoi);
            return Console.CursorTop;//Trả về vị trí hàng hiện tại
        }
        public void ImportScore()
        {
            do
            {
                //Hiên thị mẫu nhập
                Console.Clear();
                Console.WriteLine("                           NHẬP THÔNG TIN ĐIỂM SINH VIÊN");
                Console.WriteLine("====================================================================================");
                Console.WriteLine("| Mã sinh viên :                                                                   |\n");
                Console.WriteLine("| Điểm môn Đại số tuyến tính :                                                     |\n");
                Console.WriteLine("| Điểm môn Giáo dục thể chất :                                                     |\n");
                Console.WriteLine("| Điểm môn Kỹ thuật máy tính :                                                     |\n");
                Console.WriteLine("| Điểm môn Định hướng nghề nghiệp :                                                |\n");
                Console.WriteLine("| Điểm môn Lập trình Python cơ bản :                                               |\n");
                Console.WriteLine("| Điểm môn Giáo dục quốc phòng và an ninh :                                        |\n");
                Console.WriteLine("| Điểm môn Kỹ năng mềm :                                                           |\n");
                Console.WriteLine("| Điểm môn Pháp luật đại cương :                                                   |\n");
                Console.WriteLine("| Điểm môn Giải tích :                                                             |\n");
                Console.WriteLine("| Điểm môn Giáo dục thể chất 2:                                                    |\n");
                Console.WriteLine("| Điểm môn Mạng máy tính:                                                          |\n");
                Console.WriteLine("| Điểm môn Cấu trúc dữ liệu và giải thuật:                                         |\n");
                Console.WriteLine("| Điểm môn Hệ điều hành:                                                           |\n");
                Console.WriteLine("| Điểm môn Cơ sở kỹ thuật lập trình:                                               |\n");
                Console.WriteLine("====================================================================================");
                Console.WriteLine();

                //Hiển thị danh sách đã nhập
                int x = 0;
                int y = 32;
                int v = ShowScore(GetAllData2(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Esc de thoat, Enter de luu!", 15);
                //Yêu cầu nhập thông tin theo mẫu nhập
                Score sc = new Score();
                Console.SetCursorPosition(19, 2); sc.MaSv = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(30, 4); sc.Dstt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(30, 6); sc.Gdtc = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(30, 8); sc.Ktmt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(35, 10); sc.Dhnn = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(36, 12); sc.Ltpcb = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(43, 14); sc.Gdqpvan = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(24, 16); sc.Knm = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(32, 18); sc.Pldc = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(22, 20); sc.Gt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(43, 22);sc.Gdtc2 = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(40, 24);sc.Mmm = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(60, 26);sc.Ctdlvgt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(40, 28);sc.Hdh = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(60, 30);sc.Csktlt = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(60, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (kt.Key == ConsoleKey.Enter) Add(sc);
            } while (true);
        }
        public void DeleteScore()
        {
            do
            {
                Console.Clear();
                ShowScore(GetAllData2(), 0, 0, "                 DANH SÁCH THÔNG TIN ĐIỂM SINH VIÊN                 ", "Nhập mã sinh viên để xóa, thoát nhấn số 0!", 20);
                int d = int.Parse(Console.ReadLine());
                ConsoleKeyInfo kt = Console.ReadKey();
                if (d==0) return;
                else Delete(d);
            } while (true);
        }
        //Tìm điểm của 1 sinh viên
        public void SearchScore()
        {
            string hoten = "";
            do
            {
                Console.Clear();
                List<Score> list = Search(new Score(0,0,0, 0, 0,0,0,0,0,0,0,0,0,0,0));
                ShowScore(list, 0, 0, "                 DANH SÁCH THÔNG TIN ĐIỂM SINH VIÊN                       ", "Nhập mã sinh viên cần tìm, Nhấn Enter de thoat!", 30);
                hoten = Console.ReadLine();
                if (hoten == "") return;
            } while (true);
        }
        public void ShowScore()
        {

            Console.Clear();
            List<Score> list = GetAllData2();
            ShowScore(list, 0, 0, "                 DANH SÁCH THÔNG TIN SINH VIÊN                       ", "Nhấn Enter để thoát!", list.Count);
            Console.ReadLine();
        }
        public Score theomaScore(int masv)
        {
            Score sc = null;
            foreach (Score c in GetAllData2())
                if (c.MaSv == masv)
                {
                    sc = new Score(c); break;
                }
            return sc;
        }
        //Sửa điểm sinh viên
        public void EditScore()
        {
            double dstt = 0;
            double gdtc = 0;
            double ktmt = 0;
            double dhnn = 0;
            double ltpcb = 0;
            double gdqpvan = 0;
            double knm = 0;
            double pldc = 0;
            double gt = 0;
            double gdtc2 = 0;
            double mmm = 0;
            double ctdlvgt = 0;
            double hdh = 0;
            double csktlt = 0;
            //Hiên thị mẫu nhập
            Console.Clear();
            Console.WriteLine("            NHAP THONG TIN SINH VIEN CAN SUA           ");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("| Ma sinh vien:                                      |\n");
            Console.WriteLine("| Điểm môn Đại số tuyến tính :                       |\n");
            Console.WriteLine("| Điểm môn Giáo dục thể chất :                       |\n");
            Console.WriteLine("| Điểm môn Kỹ thuật máy tính :                       |\n");
            Console.WriteLine("| Điểm môn Định hướng nghề nghiệp :                  |\n");
            Console.WriteLine("| Điểm môn Lập trình Python cơ bản :                 |\n");
            Console.WriteLine("| Điểm môn Giáo dục quốc phòng và an ninh :          |\n");
            Console.WriteLine("| Điểm môn Kỹ năng mềm :                             |\n");
            Console.WriteLine("| Điểm môn Pháp luật đại cương :                     |\n");
            Console.WriteLine("| Điểm môn Giải tích :                               |\n");
            Console.WriteLine("| Điểm môn Giáo dục thể chất 2:                      |\n");
            Console.WriteLine("| Điểm môn Mạng máy tính:                            |\n");
            Console.WriteLine("| Điểm môn Cấu trúc dữ liệu và giải thuật:           |\n");
            Console.WriteLine("| Điểm môn Hệ điều hành:                             |\n");
            Console.WriteLine("| Điểm môn Cơ sở kỹ thuật lập trình:                 |\n");
            int v = Console.CursorTop;
            //Yêu cầu nhập thông tin sinh viên theo mẫu nhập                
            Console.SetCursorPosition(16, 3); int masv = int.Parse(Console.ReadLine());

            Score sc = theomaScore(masv);
            if (sc != null)
            {
                //Hiển thị thông tin sinh viên đã tồn tạI

                Console.SetCursorPosition(51, 5); Console.Write(sc.Dstt);
                Console.SetCursorPosition(51, 7); Console.Write(sc.Gdtc);
                Console.SetCursorPosition(51, 9); Console.Write(sc.Ktmt);
                Console.SetCursorPosition(51, 11); Console.Write(sc.Dhnn);
                Console.SetCursorPosition(51, 13); Console.Write(sc.Ltpcb);
                Console.SetCursorPosition(51, 15);Console.Write(sc.Gdqpvan);
                Console.SetCursorPosition(51, 17);Console.Write(sc.Knm);
                Console.SetCursorPosition(51, 19);Console.Write(sc.Pldc);
                Console.SetCursorPosition(51, 21);Console.Write(sc.Gt);
                Console.SetCursorPosition(51, 23);Console.Write(sc.Gdtc2);
                Console.SetCursorPosition(51, 25);Console.Write(sc.Mmm);
                Console.SetCursorPosition(51, 27);Console.Write(sc.Ctdlvgt);
                Console.SetCursorPosition(51, 29);Console.Write(sc.Hdh);
                Console.SetCursorPosition(51, 31);Console.Write(sc.Csktlt);
                Console.SetCursorPosition(0, v);
                //Nhập lại thông tin mới

                Console.SetCursorPosition(54, 5); try { dstt = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 7); try { gdtc = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 9); try { ktmt = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 11); try { dhnn = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 13); try { ltpcb = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 15); try { gdqpvan = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 17); try { knm = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 19); try { pldc = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 21); try { gt = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 23); try { gdtc2 = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 25); try { mmm = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 27); try { ctdlvgt = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 29); try { hdh = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(54, 31); try { csktlt = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại
                if (sc.Dstt != dstt && dstt != 0) sc.Dstt = dstt;
                if (sc.Gdtc != gdtc && gdtc != 0) sc.Gdtc = gdtc;
                if (sc.Ktmt != ktmt && ktmt != 0) sc.Ktmt = ktmt;
                if (sc.Dhnn != dhnn && dhnn != 0) sc.Dhnn = dhnn;
                if (sc.Ltpcb != ltpcb && ltpcb != 0) sc.Ltpcb = ltpcb;
                if (sc.Gdqpvan != gdqpvan && gdqpvan != 0) sc.Gdqpvan = gdqpvan;
                if (sc.Knm != knm && knm != 0) sc.Knm = knm;
                if (sc.Pldc != pldc && pldc != 0) sc.Pldc = pldc;
                if (sc.Gt != gt && gt != 0) sc.Gt = gt;
                if (sc.Gdtc2 != gdtc2 && gdtc2 != 0) sc.Gdtc2 = gdtc2;
                if (sc.Mmm != mmm && mmm != 0) sc.Mmm = mmm;
                if (sc.Ctdlvgt != ctdlvgt && ctdlvgt != 0) sc.Ctdlvgt = ctdlvgt;
                if (sc.Hdh != hdh && hdh != 0) sc.Hdh = hdh;
                if (sc.Csktlt != csktlt && csktlt != 0) sc.Csktlt = csktlt;
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) Environment.Exit(0);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    EditScore(sc); return;
                }
            }
            else Console.Write("thông tin sinh viên này không tồn tại hãy nhập lại mã sinh viên "); Console.ReadKey();

        }
    }
}


