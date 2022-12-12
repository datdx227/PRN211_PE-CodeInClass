using System.Security.Cryptography.X509Certificates;

namespace EventDemo
{
    public class Program
    {
        static int n;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number text: ");
            n = Convert.ToInt32(Console.ReadLine());

            //Mô phỏng thao tác nhấn nút để tạo text
            Console.WriteLine("Press any key to create text!");
            Console.ReadKey();

            // Tạo nút
            Button btnCreate = new Button("Create");

            //Gán sự kiện onClick cho button
            btnCreate.onClick += BtnCreate_onClick;

            //Nhấn nút
            btnCreate.click();

            Console.WriteLine("Press any key to Add checkbox");
            Console.ReadKey(true);

            //Tạo nút Add

            //Gán sự kiện

            //Thực hiện add n checkbox (Text and Checked)
            Button btnAdd = new Button("Add");
            btnAdd.onClick += BtnAdd_onClick;
            btnAdd.click();

            //Mô phỏng sự kiện checkchange cho checkbox
            while (true)
            {
                Console.WriteLine("You choose a checkbox(1,2,3..):");
                int c = Convert.ToInt32(Console.ReadLine());
                if (c > n)
                {
                    break;
                }
                Console.WriteLine("O.Check");
                Console.WriteLine("1. Uncheck");
                int option = Convert.ToInt32(Console.ReadLine());
                if(option == 0)
                {
                    lstCheck[c - 1].Checked = true;
                }
                else
                {
                    lstCheck[c - 1].Checked = false;
                }
            }

            //Mô phỏng sự kiện TextChang của textbox
            //Cứ khi nào giá trị của text bị thay đổi
            //Thì sự kiện xảy ra và 
            //hiển thị: Tên text - old value, new value
        }
        static List<TextBox> lstText = new List<TextBox>();
        static List<CheckBox> lstCheck = new List<CheckBox>();
        public static void BtnAdd_onClick()
        {
            for (int i = 0; i < n; i++)
            {
                CheckBox chk = new CheckBox();
                chk.CheckChanged += Chk_CheckChanged;
                chk.Text = lstText[i].Text;
                lstCheck.Add(chk);
                Console.WriteLine("Check"  +(i+1) + ":" + lstCheck[i].Text + "-Uncheck");
            }
            
        }

        private static void Chk_CheckChanged(string text, bool check)
        {
            Console.WriteLine("Check " + text + "-" + ((check) ? "Checked" : "Uncheck"));

        }

        private static void BtnCreate_onClick()
        {
            //Nơi sẽ viết sự việc sé xảy ra khi nhấn nút
            for(int i = 0; i < n; i++)
            {
                TextBox t = new TextBox();
                Console.WriteLine("Enter text" + (i+1) + ":");
                t.Text = Console.ReadLine();
                lstText.Add(t);
            }
            Console.WriteLine("List Text: ");
            for(int i=0; i < n; i++)
            {
                Console.WriteLine("-Text " + (i+1) + ": " + lstText[i].Text);
            }
        }
    }
}