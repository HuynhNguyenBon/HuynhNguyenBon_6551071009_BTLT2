using System;

namespace QuanLySachCoBan
{
    class Sach
    {
        private string _maSach;
        private string _tenSach;
        private string _tacGia;
        private int _namXuatBan;
        private double _giaBan;
        public Sach(string maSach, string tenSach, string tacGia, int namXuatBan, double giaBan)
        {
            _maSach = maSach;
            _tenSach = tenSach;
            _tacGia = tacGia;
            _namXuatBan = namXuatBan;
            _giaBan = giaBan;
        }
        public Sach()
        {
            _maSach = "5000";
            _tenSach = "Chưa có tên";
            _tacGia = "Chưa có tác giả";
            _namXuatBan = DateTime.Now.Year;
            _giaBan = 0;
        }
        public string MaSach
        {
            get { return _maSach; }
        }
        public string TenSach
        {
            get { return _tenSach; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên không được để trống!");
                }
                _tenSach = value;
            }
        }
        public string TacGia
        {
            get { return _tacGia; }
            set => _tacGia = value?.Trim() ?? "Đang cập nhật";
        }
        public int NamXuatBan
        {
            get { return _namXuatBan; }
            set
            {
                int namHienTai = DateTime.Now.Year;
                if (value < 1900 || value > namHienTai)
                {
                    throw new AggregateException($"Năm xuất bản phải từ 1900 đến {namHienTai}!");
                }
                namHienTai = value;
            }
        }
        public double GiaBan
        {
            get { return _giaBan; }
        }
        public void HienThiThongTin()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("           THÔNG TIN SÁCH");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Mã sách      : {_maSach}");
            Console.WriteLine($"Tên sách     : {_tenSach}");
            Console.WriteLine($"Tác giả      : {_tacGia}");
            Console.WriteLine($"Năm xuất bản : {_namXuatBan}");
            Console.WriteLine($"Giá bán      : {_giaBan:N0} VNĐ");
            Console.WriteLine("----------------------------------------");
        }
        public override string ToString()
        {
            return $"{_maSach} - {_tenSach} - {_tacGia} - " +
                   $"{_namXuatBan} - {_giaBan:N0} VNĐ";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // CÁCH 1: Constructor đầy đủ tham số
            Sach sach1 = new Sach(
                "S001",
                "Lập trình C# cơ bản",
                "Nguyễn Văn A",
                2024,
                85000
            );

            // CÁCH 2: Constructor mặc định rồi
            // gán Property
            Sach sach2 = new Sach();

            sach2.TenSach = "Cơ sở dữ liệu";
            sach2.NamXuatBan = 2023;

            // CÁCH 3: Object Initializer
            Sach sach3 = new Sach(
                "S003",
                "Lập trình hướng đối tượng",
                "Trần Văn B",
                2025,
                95000
            )
            {
                TenSach = "Lập trình hướng đối tượng nâng cao",
                NamXuatBan = 2025
            };

            // Hiển thị thông tin
            Console.WriteLine("SÁCH 1:");
            sach1.HienThiThongTin();

            Console.WriteLine("\nSÁCH 2:");
            sach2.HienThiThongTin();

            Console.WriteLine("\nSÁCH 3:");
            sach3.HienThiThongTin();

            // Thử gán năm xuất bản không hợp lệ
            Console.WriteLine("\nTHỬ GÁN GIÁ TRỊ KHÔNG HỢP LỆ:");

            try
            {
                sach1.NamXuatBan = 1800;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            // Thử gán tên sách rỗng
            Console.WriteLine("\nTHỬ GÁN TÊN SÁCH RỖNG:");

            try
            {
                sach1.TenSach = "";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            Console.WriteLine("\nTOSTRING():");
            Console.WriteLine(sach1.ToString());

        }
    }
}