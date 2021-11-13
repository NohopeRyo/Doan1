using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Đồ_án_I
{
    public class SinhVien
    {
        private int masv;
        private string hoten;
        private string quequan;
        private int namsinh;
        private string sodienthoai;
        private string email;
        public int MaSv
        {
            get { return masv; }
            set
            {
                if (value >= 1)
                    masv = value;
            }
        }
        public string Hoten
        {
            get { return hoten; }
            set
            {
                if (value != "")
                    hoten = value;
            }
        }

        public string QueQuan
        {
            get { return quequan; }
            set
            {
                if (value != "")
                    quequan = value;
            }
        }

        public int Namsinh
        {
            get { return namsinh; }
            set
            {
                if (value >= 1990&&value<=2021)
                    masv = value;
            }
        }
        public string Sodienthoai
        {
            get { return sodienthoai; }
            set
            {
                if (value != "")
                    sodienthoai = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (value != "")
                    email = value;
            }
        }
        public SinhVien()
        { }
        public SinhVien(SinhVien sv)
        {
            this.masv = sv.masv;
            this.Hoten = sv.Hoten;
            this.quequan = sv.quequan;
            this.namsinh = sv.namsinh;
            this.sodienthoai = sv.sodienthoai;
            this.email = sv.email;
        }
        public SinhVien(int masv, string hoten, string quequan, int namsinh, string sodienthoai, string email)
        {
            this.masv = masv;
            this.hoten = hoten;
            this.quequan = quequan;
            this.namsinh = namsinh;
            this.sodienthoai = sodienthoai;
            this.email = email;
        }
    }
    class QLSV
    {
        private string file = "SinhVien.txt";
        //Lấy toàn bộ dữ liệu có trong file SinhVien.txt đưa vào một danh sách 
        public List<SinhVien> GetAllData2()
        {
            List<SinhVien> list = new List<SinhVien>();
            StreamReader fread = File.OpenText(file);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new SinhVien(int.Parse(a[0]), a[1], a[2], int.Parse(a[3]), a[4], a[5]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //public int Getbookcode()
        //{
        //    StreamReader fread = File.OpenText(txtfile);
        //    string s = fread.ReadLine();
        //    string tmp = "";
        //    while (s != null)
        //    {
        //        if (s != "") tmp = s;
        //        s = fread.ReadLine();
        //    }
        //    fread.Close();
        //    if (tmp == "") return 0;
        //    else
        //    {
        //        tmp = CongCu.ChuanHoaXau(tmp);
        //        string[] a = tmp.Split('#');
        //        return int.Parse(a[0]);
        //    }
        //}
        //Thêm thông tin sinh viên
        public void Insert(SinhVien SV)
        {

            StreamWriter fwrite = File.AppendText(file);
            fwrite.WriteLine();
            fwrite.Write(SV.MaSv + "#" + SV.Hoten + "#" + SV.QueQuan + "#" + SV.Namsinh + "#" + SV.Sodienthoai+"#"+SV.Email);
            fwrite.Close();
        }
        //Xóa một thông tin sinh viên khi biết mã
        public void Delete(string masv)
        {
            List<SinhVien> list = GetAllData2();
            StreamWriter fwrite = File.CreateText(file);
            foreach (SinhVien SV in list)
                if (SV.MaSv >= 1)
                    fwrite.WriteLine(SV.MaSv + "#" + SV.Hoten + "#" + SV.QueQuan + "#" + SV.Namsinh + "#" + SV.Sodienthoai + "#" + SV.Email);
            fwrite.Close();
        }
        //Sửa một thông tin sinh viên
        public void Update(SinhVien edit)
        {
            List<SinhVien> list = GetAllData2();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].MaSv == edit.MaSv)
                {
                    list[i] = edit;
                    break;
                }

            StreamWriter fwrite = File.CreateText(file);
            foreach (SinhVien SV in list)
                fwrite.WriteLine(SV.MaSv + "#" + SV.Hoten + "#" + SV.QueQuan + "#" + SV.Namsinh + "#" + SV.Sodienthoai + "#" + SV.Email);
            fwrite.Close();
        }
        public bool check(int masv)
        {
            bool ok = false;
            foreach (SinhVien SV in GetAllData2())
                if (SV.MaSv == masv)
                {
                    ok = true; break;
                }
            return ok;
        }
        public void Add(SinhVien SV)
        {
            if (SV.MaSv >1  && SV.Hoten != "")
            {
                SV.Hoten = CongCu.ChuanHoaXau(SV.Hoten);
                Insert(SV);
            }
            else
                throw new Exception("Dữ liệu bạn thêm vào bị sai");
        }
        public void DeleteSV(int masv)
        {
            List<SinhVien> list = GetAllData2();
            StreamWriter fwrite = File.CreateText(file);
            foreach (SinhVien sv in list)
                if (sv.MaSv != masv)
                    fwrite.WriteLine(sv.MaSv + "#" + sv.Hoten + "#" + sv.QueQuan + "#" + sv.Namsinh + "#" + sv.Sodienthoai + "#" + sv.Email);
            fwrite.Close();
        }

        public void EditSV(SinhVien SV)
        {
            if (check(SV.MaSv))
                Update(SV);
            else
                throw new Exception("Không tồn tại thông tin sinh viên này");
        }
        //tìm kiếm thông tin sinh viên
        public List<SinhVien> Search(SinhVien SV)
        {
            List<SinhVien> list = GetAllData2();
            List<SinhVien> kq = new List<SinhVien>();
            //Giá trị ngầm định ban đầu
            if (SV.Hoten == null && SV.MaSv == 2)
            {
                kq = list;
            }
            //Tìm theo tên sinh viên
            if (SV.Hoten != null && SV.MaSv<1 )
            {
                foreach (SinhVien c in list)
                    if (c.Hoten.IndexOf(c.Hoten) >= 0)
                    {
                        kq.Add(new SinhVien(c));
                    }
            }
            //Tìm kiếm theo mã
            else if (SV.Hoten != null && SV.MaSv < 1)
            {
                foreach (SinhVien c in list)
                    if (c.MaSv == SV.MaSv)
                    {
                        kq.Add(new SinhVien(c));
                    }
            }
            else
                kq = null;
            Console.WriteLine("Không tìm thấy sinh viên nào hợp lý");
            return kq;
        }
        public int ShowSV(List<SinhVien> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {

            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("------------------------------------------------------");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("Mã sinh viên");
            Console.SetCursorPosition(x + 12, y); Console.Write("Tên sinh viên");
            Console.SetCursorPosition(x + 30, y); Console.Write("Quê Quán");
            Console.SetCursorPosition(x + 35, y); Console.Write("Năm sinh ");
            Console.SetCursorPosition(x + 50, y); Console.Write("Số điện thoại");
            Console.SetCursorPosition(x + 60, y); Console.Write("Email");



            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].MaSv.ToString());
                Console.SetCursorPosition(12, y); Console.Write(list[i].Hoten);
                Console.SetCursorPosition(30, y); Console.Write(list[i].QueQuan);
                Console.SetCursorPosition(35, y); Console.Write(list[i].Namsinh);
                Console.SetCursorPosition(50, y); Console.Write(list[i].Sodienthoai);
                Console.SetCursorPosition(60, y); Console.Write(list[i].Email);

                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine();
            Console.Write(tieudecuoi);
            return Console.CursorTop;//Trả về vị trí hàng hiện tại
        }
        public void ImportSV()
        {
            do
            {
                //Hiên thị mẫu nhập
                Console.Clear();
                Console.WriteLine("                                                                             NHẬP THÔNG TIN SINH VIÊN");
                Console.WriteLine("======================================================================================================================================================================");
                Console.WriteLine("| Mã sinh viên :                                                                   |\n");
                Console.WriteLine("| Họ và tên :                                                                   |\n");
                Console.WriteLine("| Ngày tháng năm sinh :                                                         |\n");
                Console.WriteLine("| Quê quán :                                                                    |\n");
                Console.WriteLine("| Số điện thoại :                                                               |\n");
                Console.WriteLine("| Email :                                                                       |\n");
                Console.WriteLine("======================================================================================================================================================================");
                Console.WriteLine();

                //Hiển thị danh sách đã nhập
                int x = 0;
                int y = 9;
                int v = ShowSV(GetAllData2(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Esc de thoat, Enter de luu!", 9);
                //Yêu cầu nhập thông tin theo mẫu nhập
                SinhVien SV = new SinhVien();
                Console.SetCursorPosition(19, 2); SV.MaSv = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(14, 3); SV.Hoten = Console.ReadLine();
                Console.SetCursorPosition(24, 4); SV.Namsinh = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(13, 6); SV.QueQuan = Console.ReadLine();
                Console.SetCursorPosition(18, 8); SV.Sodienthoai = Console.ReadLine();
                Console.SetCursorPosition(9, 10); SV.Email = Console.ReadLine();
                Console.SetCursorPosition(130, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (kt.Key == ConsoleKey.Enter) Add(SV);
            } while (true);
        }
        public void DeleteSV()
        {
            do
            {
                Console.Clear();
                ShowSV(GetAllData2(), 0, 0, "                 DANH SÁCH THÔNG TIN SINH VIÊN                 ", "Nhập mã sinh viên để xóa, thoát nhấn enter!", 20);
                string d = Console.ReadLine();
                if (d == "") return;
                else Delete(d);
            } while (true);
        }
        //Tìm sách
        public void SearchSV()
        {
            string hoten = "";
            do
            {
                Console.Clear();
                List<SinhVien> list = Search(new SinhVien(0, hoten, null, 0, null,null));
                ShowSV(list, 0, 0, "                 DANH SÁCH THÔNG TIN SINH VIÊN                       ", "Nhập mã sinh viên cần tìm, Nhấn Enter de thoat!", 30);
                hoten = Console.ReadLine();
                if (hoten == "") return;
            } while (true);
        }
        public void ShowSV()
        {

            Console.Clear();
            List<SinhVien> list = GetAllData2();
            ShowSV(list, 0, 0, "                 DANH SÁCH THÔNG TIN SINH VIÊN                       ", "Nhấn Enter để thoát!", list.Count);
            Console.ReadLine();
        }
        public SinhVien theomaSV(int masv)
        {
            SinhVien SV = null;
            foreach (SinhVien c in GetAllData2())
                if (c.MaSv == masv)
                {
                    SV = new SinhVien(c); break;
                }
            return SV;
        }
        //Sửa sách
        public void EditSV()
        {

            string hoten = null;
            string quequan = null;
            int namsinh = 0;
            string sodienthoai = null;
            string email = null;
            //Hiên thị mẫu nhập
            Console.Clear();
            Console.WriteLine("            NHAP THONG TIN SINH VIEN CAN SUA           ");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Ma sinh vien:                                          ");
            Console.WriteLine("Ho ten:                                                ");
            Console.WriteLine("Que quan:                                                ");
            Console.WriteLine("Nam sinh:");
            Console.WriteLine("So dien thoai:");
            Console.WriteLine("Email:");
            int v = Console.CursorTop;
            //Yêu cầu nhập thông tin sinh viên theo mẫu nhập                
            Console.SetCursorPosition(16, 4); int masv = int.Parse( Console.ReadLine());

            SinhVien SV = theomaSV(masv);
            if (SV != null)
            {
                //Hiển thị thông tin sinh viên đã tồn tạI

                Console.SetCursorPosition(51, 5); Console.Write(SV.Hoten);
                Console.SetCursorPosition(12, 6); Console.Write(SV.QueQuan);
                Console.SetCursorPosition(46, 7); Console.Write(SV.Namsinh);
                Console.SetCursorPosition(35, 8); Console.Write(SV.Sodienthoai);
                Console.SetCursorPosition(35, 9);Console.Write(SV.Email);
                Console.SetCursorPosition(0, v);
                //Nhập lại thông tin mới

                Console.SetCursorPosition(70, 5); try { hoten = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(16, 6); try { quequan = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(70, 7); try { namsinh =int.Parse( Console.ReadLine()); } catch { }
                Console.SetCursorPosition(46, 8); try { sodienthoai = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại
                if (SV.Hoten != hoten && hoten != null) SV.Hoten = hoten;
                if (SV.QueQuan != quequan && quequan != null) SV.QueQuan = quequan;
                if (SV.Namsinh >= 1990 && SV.Namsinh <= 2021) SV.Namsinh = namsinh;
                if (SV.Sodienthoai != sodienthoai && sodienthoai != null) SV.Sodienthoai = sodienthoai;
                if (SV.Email != email && email != null) SV.Email = email;

                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) Environment.Exit(0);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    EditSV(SV); return;
                }
            }
            else Console.Write("thông tin sinh viên này không tồn tại hãy nhập lại mã sinh viên "); Console.ReadKey();

        }
    }
}

        
