using System;

namespace DelegateLambda;
public class Program
{
    //Khai báo delegate
    delegate void MyDelegate(int a, int b);
    delegate long MyDelegate2(int n);
    static void Main(string[] args)
    {
        Console.WriteLine("Hello delegate");
        //khi chua su dung delegate
        Console.WriteLine("Not using delegate: ");
        Tong(4, 6);
        UCLN(4, 6);
        Sosanh(4, 6);

        Tong(24, 6);
        UCLN(24, 6);
        Sosanh(24, 6);

        Tong(4, 16);
        UCLN(4, 16);
        Sosanh(4, 16);
        //Khi su dung delegate
        Console.WriteLine("Using delegate: ");
        //Tạo delegate theo Cách 1:
        MyDelegate my = new MyDelegate(Tong);
        my += UCLN; // += thêm việc tính UCLN
        my += Sosanh; 

        my(4,6);
        my -= UCLN; // -= bớt việc tính UCLN
        my(24, 6);
        my(4, 16);
        //Tạo delegate cách 2:
        // Trỏ tới hàm tính giai thừa
        // Bắt đầu vẫn sử dụng C1:
        MyDelegate2 my2 = new MyDelegate2(Giaithua);
        Console.WriteLine(my2(4));
        // Sử dụng cách 2:
        MyDelegate2 my3 = delegate (int n) {
            long gt = 1;
            for (int i = 1; i <= n; i++)
            {
                gt = gt * i;
            }
            return gt;
        };
        Console.WriteLine(my3(4));
        // Biến đổi cách 2 thành biểu thức Lambda
        MyDelegate2 my4 = (int n) => { // kí hiệu "=>" toán tử lambda
            long gt = 1;
            for (int i = 1; i <= n; i++)
            {
                gt = gt * i;
            }
            return gt;
        };
        Console.WriteLine(my4(4));
        // Biến đổi tiếp
        MyDelegate2 my5 = n => {  //nếu chỉ có 1 tham số thì có thể k khai báo kiểu dữ liệu
            long gt = 1;
            for (int i = 1; i <= n; i++)
            {
                gt = gt * i;
            }
            return gt;
        };
        Console.WriteLine(my5(4));
        // Mất hình, tức là không tính giai thừa nữa 
        //mà tính nhân đôi 
        MyDelegate2 my6 = n => n * 2;
        Console.WriteLine(my6(4));
    }
    static void Tong(int a, int b)
    {
        Console.WriteLine("a+b= " + (a + b));
    }
    static void UCLN(int m, int n)
    {
        while (m != n)
        {
            if (m > n) m = m - n;
            else n = n - m;
        }
        Console.WriteLine("UCLN= " +m );
    }
    static void Sosanh(int k, int l)
    {
        if (k == l) Console.WriteLine("k=l");
        if (k > l) Console.WriteLine("k>l");
        if (k < l) Console.WriteLine("k<l");
    }
    static long Giaithua(int n)
    {        
        long gt = 1;
        for(int i = 1; i <= n; i++)
        {
            gt = gt * i;
        }
        return gt;
        //Console.WriteLine(gt);
    }
    
}