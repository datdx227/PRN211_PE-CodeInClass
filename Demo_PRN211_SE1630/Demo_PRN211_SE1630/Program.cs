using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Demo_PRN211_SE1630
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1.Basic");
                Console.WriteLine("2.Array");
                Console.WriteLine("3.String");
                Console.WriteLine("4.List");
                Console.WriteLine("0.Exit");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 0: return;
                    case 1:
                        {
                            basic();
                            break;
                        }
                    case 2:
                        {
                            Array();
                            break;
                        }
                    case 3:
                        {
                            StringDemo();
                            break;
                        }
                    case 4:
                        {
                            List();
                            break;
                        }
                    default:
                        break;
                }

            }
        }

        private static void ListDemo()
        {
            //Khoi tao 1 danh sach ho ten sinh vien
            List<string> list = new List<string>
            {  "Nguyen Huu Nam",
                "Ngo Hao Nam",
                "Nguyen Ngoc Bao Chau",
                "Ta Thi Thuong",
                "Bui Hoang Lan"
            };
            Console.WriteLine("Danh sach sinh vien: ");
            foreach (string item in list)
                Console.WriteLine(item);
            //1.Hien thi nhung sinh vien khong phai ho "Nguyen"
            //2. Co bao nhieu sinh vien ten dem co tu 2 tu tro len
            //3. Hien thi nhung sinh vien ma ten gom 3 ky tu
            //4. Co bao nhieu sinh vien co ten ngan nhat(tinh theo so thu tu)
            //5.Hien thi danh sach sinh vien theo format sau:
            // Ten + chu cai dau tien cua ho + cac chu cai dau tien cua ten dem
            //Neu trunng nhau thi phai kem theo stt
        }

        static void List()
        {
            Console.WriteLine("Nhap vao lua chon cua ban: ");
            Console.WriteLine("1.Hien thi nhung sinh vien khong phai ho \"Nguyen\"");
            Console.WriteLine("2. Co bao nhieu sinh vien ten dem co tu 2 tu tro len");
            Console.WriteLine("3. Hien thi nhung sinh vien ma ten gom 3 ky tu");
            Console.WriteLine("4. Co bao nhieu sinh vien co ten ngan nhat(tinh theo so thu tu)");
            Console.WriteLine("5.Hien thi danh sach sinh vien theo format");

            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 0: return;
                case 1:
                    NotNguyen();
                    break;
                case 2:
                    TenDem2Tu();
                    break;
                case 3:
                    Ten3Kitu();
                    break;
                case 4:
                    TenNganNhat();
                    break;
                case 5:
                    theoFormat();
                    break;
                default:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }

        private static void theoFormat()
        {
            List<string> list = new List<string>
            {  "Nguyen Huu Nam",
                "Ngo Hao Nam",
                "Nguyen Ngoc Bao Chau",
                "Ta Thi Thuong",
                "Bui Hoang Lan"
            };
            Console.WriteLine("Danh sach sinh vien: ");
            foreach (string item in list)
            {
                string s = item.Trim();
                string ho = s.Substring(0, s.IndexOf(' '));
                string td = s.Substring(s.IndexOf(' ') + 1, s.LastIndexOf(' ') - ho.Length - 1);
                string ten = s.Substring(s.LastIndexOf(' ') + 1);
                Console.WriteLine(ten+ ho.Substring(0, 1) + td.Substring(0, 1));
            }
        }
        private static void TenNganNhat()
        {
            List<string> list = new List<string>
            {  "Nguyen Huu Nam",
                "Ngo Hao Nam",
                "Nguyen Ngoc Bao Chau",
                "Ta Thi Thuong",
                "Bui Hoang Lan"
            };
            Console.WriteLine("Danh sach sinh vien: ");
            string[] s = list.ToArray();
            string minValue = s[0];
            foreach (string name in s)
            {
                if (name.Length < minValue.Length)
                {
                    minValue = name; 
                }
            }
            Console.WriteLine(minValue);
        }

        private static void DemKiTu()
        {
            List<string> list = new List<string>
            {  "Nguyen Huu Nam",
                "Ngo Hao Nam",
                "Nguyen Ngoc Bao Chau",
                "Ta Thi Thuong",
                "Bui Hoang Lan"
            };
            Console.WriteLine("Danh sach sinh vien: ");
            foreach (string item in list)
            {
                int chu_cai = 0, i = 0, l = 0;
                l = item.Length;
                while (i < l)
                {
                    if ((item[i] >= 'a' && item[i] <= 'z') || (item[i] >= 'A' && item[i] <= 'Z'))
                    {
                        chu_cai++;
                    }
                    i++;
                }
                Console.WriteLine(chu_cai);
            }

        }
        private static void Ten3Kitu()
        {
            List<string> list = new List<string>
            {  "Nguyen Huu Nam",
                "Ngo Hao Nam",
                "Nguyen Ngoc Bao Chau",
                "Ta Thi Thuong",
                "Bui Hoang Lan"
            };
            Console.WriteLine("Danh sach sinh vien: ");
            foreach (string item in list)
            {
                if(DemKhoangTrang(item) == 2)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public static int DemKhoangTrang(string str)
        {
            int bien_dem = 0;
            string str1;
            for (int i = 0; i < str.Length; i++)
            {
                str1 = str.Substring(i, 1);
                if (str1 == " ")
                    bien_dem++;
            }
            return bien_dem;
        }
        private static void TenDem2Tu()
        {
            List<string> list = new List<string>
            {  "Nguyen Huu Nam",
                "Ngo Hao Nam",
                "Nguyen Ngoc Bao Chau",
                "Ta Thi Thuong",
                "Bui Hoang Lan"
            };
            Console.WriteLine("Danh sach sinh vien: ");
            foreach (string item in list)
            {
                string s = item.Trim();
                //string[] arrayStr = item.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                //StringBuilder midleName = new StringBuilder();
                //Lấy tên đệm
                string ho = s.Substring(0, s.IndexOf(' '));
                string td = s.Substring(s.IndexOf(' ') + 1, s.LastIndexOf(' ') - ho.Length - 1);
                string ten = s.Substring(s.LastIndexOf(' ') + 1);

                foreach (char c in td.ToCharArray())
                {
                    if (c == ' ')
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        private static void NotNguyen()
        {
            List<string> list = new List<string>
            {  "Nguyen Huu Nam",
                "Ngo Hao Nam",
                "Nguyen Ngoc Bao Chau",
                "Ta Thi Thuong",
                "Bui Hoang Lan"
            };
            Console.WriteLine("Danh sach sinh vien: ");
            foreach (string item in list)
            {
                //string name = Console.ReadLine().Trim().ToLower();
                // hoac sua dong lenh sau
                string[] s = item.Trim().ToLower().Split(' ');

                string lastname = s[0].Substring(0, 1).ToUpper() + s[0].Substring(1);
                if (String.Compare(lastname, "Nguyen", true) != 0)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void Array()
        {
            Console.WriteLine("Nhap vao lua chon cua ban: ");
            Console.WriteLine("1. Hien thi mang hien tai ");
            Console.WriteLine("2. Hien thi so le trong mang ");
            Console.WriteLine("3. Hien thi so chinh phuong ");
            Console.WriteLine("4. Tong cac so nguyen to trong mang ");
            Console.WriteLine("5. Sap xep cac so trong mang theo thu tu giam dan ");
            Console.WriteLine("6. Sap xep cac so chan trong mang theo thu tu tang dan ");

            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 0: return;
                case 1:
                    ArrayDemo();
                    break;
                case 2:
                    ArrayLe();
                    break;
                case 3:
                    ArrayChinhPhuong();
                    break;
                case 4:
                    tong_so_nguyen_to();
                    break;
                case 5:
                    giamdan();
                    break;
                case 6:
                    tangdan();
                    break;
                default:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }
        static void StringDemo()
        {
            //Nhập 1 chuỗi họ tên
            //Tách ra lastname,firstname và surname
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine().Trim().ToLower();
            // hoac sua dong lenh sau
            string[] s = name.Split(' ');

            string lastname = s[0].Substring(0, 1).ToUpper() + s[0].Substring(1) ;
            Console.WriteLine("Lastname:" + lastname + ".");

            string firstname = s[s.Length - 1];
            Console.WriteLine("Firstname:" + firstname + ".");

            string surname = "";
            for(int i = 0; i < s.Length-1; i++)
            {
                //them 1 dong code o day
                if (!s[i].Trim().Equals(""))
                {
                    surname = s[i];
                }
            }
            surname = surname.Trim();
            Console.WriteLine("Surname: " + surname + ".");
        }
        static void tangdan()
        {
            int tmp;
            int[] a = { 12, 5, 7, 32, 4, 8, 4, 9, 16 };
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        //cach trao doi gia tri
                        tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i]%2 == 0)
                {
                    Console.WriteLine(a[i] + " ");
                }
                
            }
        }

        static void giamdan()
        {
            int tmp;
            int[] a = { 12, 5, 7, 32, 4, 8, 4, 9, 16 };
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] < a[j])
                    {
                        //cach trao doi gia tri
                        tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i] + " ");
            }
        }

        static void ArrayDemo()
        {
            //Khai bao va khoi tao 1 mang so nguyen bat ki
            int[] a = { 12, 5, 7, 32, 4, 8, 4, 9, 16 };
            //Hien thi mang hien tai
            Console.WriteLine("Mang hien tai: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i] + " ");
            }
            //Hien thi so le

            // so chinh phuong
        }



        static void ArrayLe()
        {
            int[] a = { 12, 5, 7, 32, 4, 8, 4, 9, 16 };
            Console.WriteLine("So le trong mang la: ");
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 1)
                {
                    Console.Write(a[i] + " ");
                }
            }
        }
        static bool soCP(int n)
        {
            int sqr = (int)Math.Sqrt(n);
            if (sqr * sqr == n)
            {
                return true;
            }
            else return false;
        }
        static void ArrayChinhPhuong()
        {
            int[] a = { 12, 5, 7, 32, 4, 8, 4, 9, 16 };
            Console.WriteLine("So chinh phuong trong mang la: ");
            for (int i = 0; i < a.Length; i++)
            {
                if (soCP(a[i]))
                {
                    Console.Write(a[i] + " ");
                }
            }
        }
        static Boolean songuyento(int n)
        {
            bool check = true;
            if (n == 1 || n == 2) return true;
            for (int i = 2; i < n; i++)
                if (n % i == 0) check = false;
            if (check) return true;
            else return false;
        }

        static void tong_so_nguyen_to()
        {
            int tong = 0;
            int[] a = { 12, 5, 7, 32, 4, 8, 4, 9, 16 };
            for (int i = 0; i < a.Length; i++)
            {
                if (songuyento(a[i]))
                    tong += a[i];
            }
            Console.Write(tong);
        }


        static void basic()
        {
            //Nhập 1 số nguyên từ bàn phím
            //Nếu nhập n k phải số nguyên >0 thì nhập đến khi nào đúng thì thôi
            //Coi số nguyên đó là tổng số giây
            //Tính toán và hiển thị: hh-mm-ss
            int total;
            do
            {
                try
                {
                    Console.WriteLine("Enter total:");
                    total = Convert.ToInt32(Console.ReadLine());
                    if (total > 0)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid");
                }
            } while (true);

            int s = total % 60;
            int h = (total / 60) / 60;
            int m = (total / 60) % 60;
            Console.WriteLine(h + "-" + m + "-" + s);

            //1.Số nguyên vừa nhập có bao nhiêu chữ số
            //2.Tinh tổng các chữ số lẻ trong số nguyên vừa nhập
            //3.Hiển thị các ước số nguyên tố của số nguyên vừa nhập
        }
    }
}