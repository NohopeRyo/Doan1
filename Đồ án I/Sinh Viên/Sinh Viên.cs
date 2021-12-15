using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Đồ_án_I
{
    public class SinhVien
    {
        #region Các thành phần dữ liệu
        private int masv;
        private string hoten;
        private string quequan;
        private string namsinh;
        private string sodienthoai;
        private string email;
        #endregion
        #region Các thuộc tính 
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

        public string Namsinh
        {
            get { return namsinh; }
            set
            {
                if (value != "")
                    namsinh = value;
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
        #endregion
        #region Các phương thức
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
        public SinhVien(int masv, string hoten, string quequan, string namsinh, string sodienthoai, string email)
        {
            this.masv = masv;
            this.hoten = hoten;
            this.quequan = quequan;
            this.namsinh = namsinh;
            this.sodienthoai = sodienthoai;
            this.email = email;
        }
        #endregion
    }
    class QLSV
    {
        #region Làm việc với tệp và danh sách
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
                    list.Add(new SinhVien(int.Parse(a[0]), a[1], a[2], (a[3]), a[4], a[5]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Thêm thông tin sinh viên
        public void Insert(SinhVien SV)
        {

            StreamWriter fwrite = File.AppendText(file);
            fwrite.WriteLine();
            fwrite.Write(SV.MaSv + "#" + SV.Hoten + "#" + SV.QueQuan + "#" + SV.Namsinh + "#" + SV.Sodienthoai + "#" + SV.Email);
            fwrite.Close();
        }
        //Xóa một thông tin sinh viên khi biết mã
        public void Delete(int masv)
        {
            List<SinhVien> list = GetAllData2();
            StreamWriter fwrite = File.CreateText(file);
            foreach (SinhVien SV in list)
                if (SV.MaSv != masv)
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
        #endregion
        public bool check(int masv)
        {

            foreach (SinhVien SV in GetAllData2())
                if (SV.MaSv != masv)
                {
                    return true;
                }
            return false;
        }
        #region Hàm thêm sinh viên
        public void Add(SinhVien SV)
        {
            if (SV.MaSv > 1 && SV.Hoten != "")
            {
                SV.Hoten = CongCu.ChuanHoaXau(SV.Hoten);
                Insert(SV);
            }
            else
                throw new Exception("Dữ liệu bạn thêm vào bị sai");
        }
        public void ImportSV()
        {
            do
            {
                //Hiên thị mẫu nhập
                Console.Clear();
                Console.WriteLine("                              NHẬP THÔNG TIN SINH VIÊN");
                Console.WriteLine("=================================================================================");
                Console.WriteLine("| Mã sinh viên :                                                                |");
                Console.WriteLine("| Họ và tên :                                                                   |");
                Console.WriteLine("| Ngày tháng năm sinh :                                                         |");
                Console.WriteLine("| Quê quán :                                                                    |");
                Console.WriteLine("| Số điện thoại :                                                               |");
                Console.WriteLine("| Email :                                                                       |");
                Console.WriteLine("=================================================================================");
                Console.WriteLine();

                //Hiển thị danh sách đã nhập
                int x = 0;
                int y = 10;
                int v = ShowSV(GetAllData2(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Esc de thoat, Enter de luu!", 15);
                //Yêu cầu nhập thông tin theo mẫu nhập
                SinhVien SV = new SinhVien();
                List<SinhVien> a = GetAllData2();
                Console.SetCursorPosition(19, 2);
                int i;
                do
                {
                    SV.MaSv = int.Parse(Console.ReadLine());
                    for (i = a.Count - 1; i >= 0; --i)
                    {
                        if (a[i].MaSv == SV.MaSv)
                        {
                            Console.SetCursorPosition(30, 2); Console.Write("Mã nhập bị trùng hãy nhập lại ấn enter");
                            ConsoleKeyInfo ktmn = Console.ReadKey();
                            if (ktmn.Key == ConsoleKey.Enter)
                            {
                                ImportSV();
                            }
                            break;
                        }
                    }
                } while (i >= 0);
                Console.SetCursorPosition(14, 3); SV.Hoten = Console.ReadLine();
                Console.SetCursorPosition(24, 4); SV.Namsinh = Console.ReadLine();
                Console.SetCursorPosition(13, 5); SV.QueQuan = Console.ReadLine();
                Console.SetCursorPosition(18, 6); SV.Sodienthoai = Console.ReadLine();
                Console.SetCursorPosition(9, 7); SV.Email = Console.ReadLine();
                Console.SetCursorPosition(35, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else if (kt.Key == ConsoleKey.Enter) Add(SV);
            } while (true);
        }
        #endregion
        #region Hàm xoá sinh viên
        public void DeleteSV(int masv)
        {
            List<SinhVien> list = GetAllData2();
            StreamWriter fwrite = File.CreateText(file);
            foreach (SinhVien sv in list)
                if (sv.MaSv != masv)
                    fwrite.WriteLine(sv.MaSv + "#" + sv.Hoten + "#" + sv.QueQuan + "#" + sv.Namsinh + "#" + sv.Sodienthoai + "#" + sv.Email);
            fwrite.Close();
        }
        public void DeleteSV()
        {
            do
            {
                Console.Clear();
                ShowSV(GetAllData2(), 0, 0, "                 DANH SÁCH THÔNG TIN SINH VIÊN                 ", "Nhập mã sinh viên để xóa, thoát nhấn số 0!", 20);
                int d = int.Parse(Console.ReadLine());
                if (d == 0) return;
                else Delete(d);
            } while (true);
        }
        #endregion
        #region Hàm sửa sinh viên
        public void EditSV(SinhVien SV)
        {
            if (check(SV.MaSv))
                Update(SV);
            else
                throw new Exception("Không tồn tại thông tin sinh viên này");
        }
        //Sửa sinh viên
        public void EditSV()
        {

            string hoten = null;
            string quequan = null;
            string namsinh = null;
            string sodienthoai = null;
            string email = null;
            ////Hiên thị mẫu nhập
            Console.Clear();

            Console.WriteLine("            NHAP THONG TIN SINH VIEN CAN SUA           ");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("|Ma sinh vien:                                         | ");
            Console.WriteLine("|Ho ten:                                               | ");
            Console.WriteLine("|Que quan:                                             |   ");
            Console.WriteLine("|Nam sinh:                                             |");
            Console.WriteLine("|So dien thoai:                                        |");
            Console.WriteLine("|Email:                                                |");
            Console.WriteLine("-------------------------------------------------------");
            int v = Console.CursorTop;
            //Yêu cầu nhập thông tin sinh viên theo mẫu nhập                
            Console.SetCursorPosition(16, 2); int masv = int.Parse(Console.ReadLine());

            SinhVien SV = theomaSV(masv);
            if (SV != null)
            {
                //Hiển thị thông tin sinh viên đã tồn tại

                Console.SetCursorPosition(8, 3); Console.Write(SV.Hoten);
                Console.SetCursorPosition(12, 4); Console.Write(SV.QueQuan);
                Console.SetCursorPosition(15, 5); Console.Write(SV.Namsinh);
                Console.SetCursorPosition(15, 6); Console.Write(SV.Sodienthoai);
                Console.SetCursorPosition(15, 7); Console.Write(SV.Email);
                Console.SetCursorPosition(0, v);
                //    //Nhập lại thông tin mới

                Console.SetCursorPosition(38, 3); try { hoten = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(38, 4); try { quequan = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(38, 5); try { namsinh = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(38, 6); try { sodienthoai = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(38, 7); try { email = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại
                if (SV.Hoten != hoten && hoten != null) SV.Hoten = hoten;
                if (SV.QueQuan != quequan && quequan != null) SV.QueQuan = quequan;
                if (SV.Namsinh != namsinh && namsinh != null) SV.Namsinh = namsinh;
                if (SV.Sodienthoai != sodienthoai && sodienthoai != null) SV.Sodienthoai = sodienthoai;
                if (SV.Email != email && email != null) SV.Email = email;

                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter)
                {
                    EditSV(SV); return;
                }
            }
            else Console.Write("thông tin sinh viên này không tồn tại hãy nhập lại mã sinh viên "); Console.ReadKey();

        }
        #endregion
        #region Hàm tìm kiếm sinh viên
        //tìm kiếm thông tin sinh viên
        public List<SinhVien> Search(SinhVien SV)
        {
            int masvcheck;
            List<SinhVien> list = GetAllData2();
            List<SinhVien> kq = new List<SinhVien>();
            Console.Write("Nhập mã sinh viên cần tìm:");
            masvcheck = int.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].MaSv == masvcheck)
                    kq.Add(new SinhVien(list[i]));
            }
            return kq;
        }
        //Tìm sinh viên
        public void SearchSV()
        {
            Console.Clear();
            List<SinhVien> list = Search(new SinhVien(0, null, null, null, null, null));
            ShowSV2(list, 0, 0, "                 DANH SÁCH THÔNG TIN SINH VIÊN                       ", "Nhấn Enter de thoat!", 35);
            Console.ReadLine();
        }
        public int ShowSV2(List<SinhVien> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {

            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("┌────────────┬──────────────┬─────────────────┬──────────┬───────────────┬───────────────────────────┐");
            y = y + 4;
            Console.SetCursorPosition(x, y); Console.Write("│Mã sinh viên│");
            Console.SetCursorPosition(x + 14, y); Console.Write("Tên sinh viên │");
            Console.SetCursorPosition(x + 34, y); Console.Write("Quê Quán    │");
            Console.SetCursorPosition(x + 48, y); Console.Write("Năm sinh │");
            Console.SetCursorPosition(x + 59, y); Console.Write("Số điện thoại │");
            Console.SetCursorPosition(x + 85, y); Console.Write("Email           │");
            Console.WriteLine();

            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(0, y); Console.Write("│" + list[i].MaSv.ToString());
                Console.SetCursorPosition(13, y); Console.Write("│" + list[i].Hoten);
                Console.SetCursorPosition(28, y); Console.Write("│" + list[i].QueQuan);
                Console.SetCursorPosition(46, y); Console.Write("│" + list[i].Namsinh.ToString());
                Console.SetCursorPosition(57, y); Console.Write("│" + list[i].Sodienthoai);
                Console.SetCursorPosition(73, y); Console.Write("│" + list[i].Email);
                Console.SetCursorPosition(101, y); Console.Write("│");
                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine("└────────────┴──────────────┴─────────────────┴──────────┴───────────────┴───────────────────────────┘");
            Console.Write(tieudecuoi);
            return Console.CursorTop;//Trả về vị trí hàng hiện tại
        }
        #endregion
        #region Hàm hiển thị sinh viên
        public int ShowSV(List<SinhVien> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {

            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("┌────────────┬──────────────┬─────────────────┬──────────┬───────────────┬───────────────────────────┐");
            y = y + 3;
            Console.SetCursorPosition(x , y); Console.Write("│Mã sinh viên│");
            Console.SetCursorPosition(x + 14, y); Console.Write("Tên sinh viên │");
            Console.SetCursorPosition(x + 34, y); Console.Write("Quê Quán    │");
            Console.SetCursorPosition(x + 48, y); Console.Write("Năm sinh │");
            Console.SetCursorPosition(x + 59, y); Console.Write("Số điện thoại │");
            Console.SetCursorPosition(x + 85, y); Console.Write("Email           │");
            Console.WriteLine();

            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(0, y); Console.Write("│"+list[i].MaSv.ToString());
                Console.SetCursorPosition(13, y); Console.Write("│"+ list[i].Hoten);
                Console.SetCursorPosition(28, y); Console.Write("│"+ list[i].QueQuan);
                Console.SetCursorPosition(46, y); Console.Write("│"+ list[i].Namsinh.ToString());
                Console.SetCursorPosition(57, y); Console.Write("│"+ list[i].Sodienthoai);
                Console.SetCursorPosition(73, y); Console.Write("│"+ list[i].Email);
                Console.SetCursorPosition(101, y);Console.Write("│");
                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine("└────────────┴──────────────┴─────────────────┴──────────┴───────────────┴───────────────────────────┘");
            Console.Write(tieudecuoi);
            return Console.CursorTop;//Trả về vị trí hàng hiện tại
        }
       
        
        
        public void ShowSV()
        {
            Console.Clear();
            List<SinhVien> list = GetAllData2();
            ShowSV(list, 0, 0, "                 DANH SÁCH THÔNG TIN SINH VIÊN                       ", "Nhấn Enter để thoát!", list.Count);
            Console.ReadLine();
        }
        #endregion
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
        
    }
}

        
