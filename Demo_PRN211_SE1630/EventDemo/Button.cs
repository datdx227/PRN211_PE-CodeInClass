namespace EventDemo
{
    public class Button
    {
        public string Caption { get; set; }
        public Button()
        {

        }

        public Button(string caption)
        {
            Caption = caption;
        }

        //Tạo sự kiện onClick
        public delegate void handle();
        public event handle onClick;

        //vậy thì khi nào sự kiện onClick được kích hoạt
        // Khi nhấn nút
        // --> Mô phỏng thao tác nhấn nút
        public void click()
        {
            if(onClick != null) //nút gọi hàm click có gán sự khiện onClick hay không?
            {
                onClick();
            }    
        }

    }
}