using System;

namespace TinhLuongNhanVien
{
    class NhanVien
    {
        private string _maNV;
        private string _hoTen;
        private decimal _luongCoBan;
        private int _soNgayLam;
        private int _soNgayNghiPhep;

        // ==========================================
        // Constructor không tham số
        // ==========================================
        public NhanVien()
        {
            _maNV = "NV000";
            _hoTen = "Chưa có tên";
            _luongCoBan = 5_000_000;
            _soNgayLam = 26;
            _soNgayNghiPhep = 0;
        }

        // ==========================================
        // Constructor nhận mã NV và họ tên
        // ==========================================
        public NhanVien(string maNV, string hoTen)
        {
            _maNV = maNV;
            _hoTen = hoTen;
            _luongCoBan = 5_000_000;
            _soNgayLam = 26;
            _soNgayNghiPhep = 0;
        }

        // ==========================================
        // Constructor đầy đủ tham số
        // ==========================================
        public NhanVien(string maNV, string hoTen,
                        decimal luongCoBan, int soNgayLam,
                        int soNgayNghiPhep)
        {
            _maNV = maNV;
            _hoTen = hoTen;
            LuongCoBan = luongCoBan;
            SoNgayLam = soNgayLam;
            _soNgayNghiPhep = soNgayNghiPhep;
        }

        // ==========================================
        // Constructor có Optional Parameters
        // ==========================================
        public NhanVien(string maNV, string hoTen,
                        decimal luong = 5_000_000,
                        int soNgayLam = 26)
        {
            _maNV = maNV;
            _hoTen = hoTen;
            LuongCoBan = luong;
            SoNgayLam = soNgayLam;
            _soNgayNghiPhep = 0;
        }

        // ==========================================
        // Property HoTen
        // ==========================================
        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        // ==========================================
        // Property LuongCoBan
        // Validate >= 0
        // ==========================================
        public decimal LuongCoBan
        {
            get { return _luongCoBan; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "Lương cơ bản không được nhỏ hơn 0!");
                }

                _luongCoBan = value;
            }
        }

        // ==========================================
        // Property SoNgayLam
        // Validate từ 0 đến 31
        // ==========================================
        public int SoNgayLam
        {
            get { return _soNgayLam; }

            set
            {
                if (value < 0 || value > 31)
                {
                    throw new ArgumentException(
                        "Số ngày làm phải từ 0 đến 31!");
                }

                _soNgayLam = value;
            }
        }

        // ==========================================
        // Property LuongThucNhan
        // Chỉ đọc, tính tự động
        // ==========================================
        public decimal LuongThucNhan
        {
            get
            {
                decimal khauTruBHXH = _luongCoBan * 8 / 100;

                return _luongCoBan / 26 * _soNgayLam
                       - khauTruBHXH;
            }
        }

        // ==========================================
        // TinhThuong() - không tham số
        // ==========================================
        public decimal TinhThuong()
        {
            return 0;
        }

        // ==========================================
        // TinhThuong(decimal heSo)
        // ==========================================
        public decimal TinhThuong(decimal heSo)
        {
            return _luongCoBan * heSo;
        }

        // ==========================================
        // TinhThuong(decimal heSo, bool coPhucLoi)
        // ==========================================
        public decimal TinhThuong(decimal heSo, bool coPhucLoi)
        {
            decimal thuong = _luongCoBan * heSo;

            if (coPhucLoi)
            {
                thuong += 500_000;
            }

            return thuong;
        }

        // ==========================================
        // Hiển thị thông tin
        // ==========================================
        public void HienThiThongTin()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("        THÔNG TIN NHÂN VIÊN");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Mã NV          : {_maNV}");
            Console.WriteLine($"Họ tên          : {_hoTen}");
            Console.WriteLine($"Lương cơ bản    : {_luongCoBan:N0} VNĐ");
            Console.WriteLine($"Số ngày làm     : {_soNgayLam}");
            Console.WriteLine($"Số ngày nghỉ    : {_soNgayNghiPhep}");
            Console.WriteLine($"Lương thực nhận : {LuongThucNhan:N0} VNĐ");
            Console.WriteLine("----------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // NHÂN VIÊN 1
            // Dùng constructor không tham số
            // ==========================================
            NhanVien nv1 = new NhanVien();

            nv1.HoTen = "Nguyễn Văn An";
            nv1.LuongCoBan = 8_000_000;
            nv1.SoNgayLam = 26;

            // ==========================================
            // NHÂN VIÊN 2
            // Dùng constructor mã NV + họ tên
            // ==========================================
            NhanVien nv2 = new NhanVien("NV002", "Trần Văn Bình");

            nv2.LuongCoBan = 7_000_000;
            nv2.SoNgayLam = 24;

            // ==========================================
            // NHÂN VIÊN 3
            // Dùng constructor Optional Parameters
            // và Named Arguments
            // ==========================================
            NhanVien nv3 = new NhanVien(
                maNV: "NV001",
                hoTen: "Lê Văn An",
                soNgayLam: 20
            );

            // ==========================================
            // Hiển thị thông tin
            // ==========================================
            Console.WriteLine("NHÂN VIÊN 1:");
            nv1.HienThiThongTin();

            Console.WriteLine("\nNHÂN VIÊN 2:");
            nv2.HienThiThongTin();

            Console.WriteLine("\nNHÂN VIÊN 3:");
            nv3.HienThiThongTin();

            // ==========================================
            // Gọi 3 overload TinhThuong
            // ==========================================
            Console.WriteLine("\n========== TÍNH THƯỞNG ==========");

            Console.WriteLine("\nNhân viên 1:");

            Console.WriteLine(
                $"TinhThuong(): " +
                $"{nv1.TinhThuong():N0} VNĐ");

            Console.WriteLine(
                $"TinhThuong(0.1): " +
                $"{nv1.TinhThuong(0.1m):N0} VNĐ");

            Console.WriteLine(
                $"TinhThuong(0.1, true): " +
                $"{nv1.TinhThuong(0.1m, true):N0} VNĐ");


            Console.WriteLine("\nNhân viên 2:");

            Console.WriteLine(
                $"TinhThuong(): " +
                $"{nv2.TinhThuong():N0} VNĐ");

            Console.WriteLine(
                $"TinhThuong(0.1): " +
                $"{nv2.TinhThuong(0.1m):N0} VNĐ");

            Console.WriteLine(
                $"TinhThuong(0.1, true): " +
                $"{nv2.TinhThuong(0.1m, true):N0} VNĐ");


            Console.WriteLine("\nNhân viên 3:");

            Console.WriteLine(
                $"TinhThuong(): " +
                $"{nv3.TinhThuong():N0} VNĐ");

            Console.WriteLine(
                $"TinhThuong(0.1): " +
                $"{nv3.TinhThuong(0.1m):N0} VNĐ");

            Console.WriteLine(
                $"TinhThuong(0.1, true): " +
                $"{nv3.TinhThuong(0.1m, true):N0} VNĐ");


            // ==========================================
            // Thử nhập giá trị không hợp lệ
            // ==========================================
            Console.WriteLine("\n========== KIỂM TRA VALIDATE ==========");

            try
            {
                nv1.LuongCoBan = -1_000_000;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            try
            {
                nv1.SoNgayLam = 40;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

        }
    }
}