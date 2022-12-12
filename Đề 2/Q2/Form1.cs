using Microsoft.EntityFrameworkCore;
using Q2.Models;

namespace Q2
{
    public partial class Form1 : Form
    {
        PRN211_Spr22Context context = new PRN211_Spr22Context();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var data1 = context.Rooms
                    .Select(m => new { m.Title })
                    .Distinct()
                    .ToList();
            comboBox1.DataSource = data1;
            comboBox1.DisplayMember = "Title";
            var data2 = context.Services
                    .Select(m => new { m.FeeType })
                    .Distinct()
                    .ToList();
            comboBox2.DataSource = data2;
            comboBox2.DisplayMember = "FeeType";
            var data = context.Services
                    .Select(item => new
                    {
                        RoomTitle = item.RoomTitle,
                        Month = item.Month,
                        Year = item.Year,
                        FeeType = item.FeeType,
                        Amount = item.Amount,
                        PaymentDate = item.PaymentDate,
                        Employee = item.Employee,
                    }).ToList();
            var data3 = context.Rooms
                    .Select(item => new
                    {
                        Room = item.Title,
                        Floor = item.Floor,
                        Square = item.Square,
                    }).ToList();
            var query = from s in data
                        join r in data3 on s.RoomTitle equals r.Room
                        select new
                        {
                            RoomTitle = s.RoomTitle,
                            Floor = r.Floor,
                            Square = r.Square,
                            Month = s.Month,
                            Year = s.Year,
                            FeeType = s.FeeType,
                            Amount = s.Amount,
                            PaymentDate = s.PaymentDate,
                            Employee = s.Employee,
                        };
            var data4 = query.ToList();
            dgvFee.DataSource = data4;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = context.Services
                    .Select(item => new
                    {
                        RoomTitle = item.RoomTitle,
                        Month = item.Month,
                        Year = item.Year,
                        FeeType = item.FeeType,
                        Amount = item.Amount,
                        PaymentDate = item.PaymentDate,
                        Employee = item.Employee,
                    }).ToList();
            var data3 = context.Rooms
                    .Select(item => new
                    {
                        Room = item.Title,
                        Floor = item.Floor,
                        Square = item.Square,
                    }).ToList();
            var query = from s in data
                        join r in data3 on s.RoomTitle equals r.Room
                        select new
                        {
                            RoomTitle = s.RoomTitle,
                            Floor = r.Floor,
                            Square = r.Square,
                            Month = s.Month,
                            Year = s.Year,
                            FeeType = s.FeeType,
                            Amount = s.Amount,
                            PaymentDate = s.PaymentDate,
                            Employee = s.Employee,
                        };
            var data4 = query
                .Where(item => item.RoomTitle.Contains(comboBox1.Text))
                .ToList();
            dgvFee.DataSource = data4;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = context.Services
                    .Select(item => new
                    {
                        RoomTitle = item.RoomTitle,
                        Month = item.Month,
                        Year = item.Year,
                        FeeType = item.FeeType,
                        Amount = item.Amount,
                        PaymentDate = item.PaymentDate,
                        Employee = item.Employee,
                    }).ToList();
            var data3 = context.Rooms
                    .Select(item => new
                    {
                        Room = item.Title,
                        Floor = item.Floor,
                        Square = item.Square,
                    }).ToList();
            var query = from s in data
                        join r in data3 on s.RoomTitle equals r.Room
                        select new
                        {
                            RoomTitle = s.RoomTitle,
                            Floor = r.Floor,
                            Square = r.Square,
                            Month = s.Month,
                            Year = s.Year,
                            FeeType = s.FeeType,
                            Amount = s.Amount,
                            PaymentDate = s.PaymentDate,
                            Employee = s.Employee,
                        };
            var data4 = query
                .Where(item => item.RoomTitle.Contains(comboBox1.Text))
                .ToList();
            var data5 = data4
                .Where(item => item.FeeType.Contains(comboBox2.Text))
                .ToList();
            dgvFee.DataSource = data5;
        }
    }
}