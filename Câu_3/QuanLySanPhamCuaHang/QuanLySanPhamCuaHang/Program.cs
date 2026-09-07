using System;
using System.Collections.Generic;

namespace QuanLySanPhamCuaHang
{
    class SanPham
    {
        private string _maSP;
        private string _tenSP;
        private decimal _gia;
        private int _soLuongTon;

        // Property
        public string MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set { _tenSP = value; }
        }

        public decimal Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }

        public int SoLuongTon
        {
            get { return _soLuongTon; }
            set { _soLuongTon = value; }
        }

        // Constructor đầy đủ
        public SanPham(string maSP, string tenSP,
                       decimal gia, int soLuongTon)
        {
            _maSP = maSP;
            _tenSP = tenSP;
            _gia = gia;
            _soLuongTon = soLuongTon;
        }

        // Tính giá bán
        public virtual decimal TinhGiaBan()
        {
            return _gia;
        }

        // Mô tả sản phẩm
        public virtual string MoTa()
        {
            return $"Mã SP: {_maSP}, Tên SP: {_tenSP}, " +
                   $"Giá: {_gia:N0} VNĐ, Số lượng tồn: {_soLuongTon}";
        }
    }


    // ==========================================
    // CLASS SAN PHAM THUC PHAM
    // ==========================================
    class SanPhamThucPham : SanPham
    {
        private DateTime _ngayHetHan;
        private int _nhietDoBAoquan;

        public DateTime NgayHetHan
        {
            get { return _ngayHetHan; }
            set { _ngayHetHan = value; }
        }

        public int NhietDoBaoQuan
        {
            get { return _nhietDoBAoquan; }
            set { _nhietDoBAoquan = value; }
        }

        // Constructor gọi base()
        public SanPhamThucPham(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon,
            DateTime ngayHetHan,
            int nhietDoBaoQuan)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _ngayHetHan = ngayHetHan;
            _nhietDoBAoquan = nhietDoBaoQuan;
        }

        // Override TinhGiaBan
        public override decimal TinhGiaBan()
        {
            TimeSpan khoangCach = _ngayHetHan - DateTime.Now;

            if (khoangCach.TotalDays <= 3 &&
                khoangCach.TotalDays >= 0)
            {
                return Gia * 0.7m;
            }

            return Gia;
        }

        // Override MoTa
        public override string MoTa()
        {
            return $"[THỰC PHẨM] {MaSP} - {TenSP} | " +
                   $"Giá bán: {TinhGiaBan():N0} VNĐ | " +
                   $"HSD: {_ngayHetHan:dd/MM/yyyy} | " +
                   $"Nhiệt độ bảo quản: {_nhietDoBAoquan}°C | " +
                   $"Tồn kho: {SoLuongTon}";
        }
    }


    // ==========================================
    // CLASS SAN PHAM DIEN TU
    // ==========================================
    class SanPhamDienTu : SanPham
    {
        private int _baoHanhThang;
        private string _hangSanXuat;

        public int BaoHanhThang
        {
            get { return _baoHanhThang; }
            set { _baoHanhThang = value; }
        }

        public string HangSanXuat
        {
            get { return _hangSanXuat; }
            set { _hangSanXuat = value; }
        }

        // Constructor
        public SanPhamDienTu(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon,
            int baoHanhThang,
            string hangSanXuat)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _baoHanhThang = baoHanhThang;
            _hangSanXuat = hangSanXuat;
        }

        // Override TinhGiaBan
        public override decimal TinhGiaBan()
        {
            if (_baoHanhThang > 12)
            {
                return Gia * 1.1m;
            }

            return Gia;
        }

        // Override MoTa
        public override string MoTa()
        {
            return $"[ĐIỆN TỬ] {MaSP} - {TenSP} | " +
                   $"Giá bán: {TinhGiaBan():N0} VNĐ | " +
                   $"Bảo hành: {_baoHanhThang} tháng | " +
                   $"Hãng: {_hangSanXuat} | " +
                   $"Tồn kho: {SoLuongTon}";
        }
    }


    // ==========================================
    // PROGRAM
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // Tạo List<SanPham> chứa 3 loại sản phẩm
            // ==========================================
            List<SanPham> danhSach = new List<SanPham>
            {
                // Sản phẩm thường
                new SanPham(
                    "SP001",
                    "Bút bi",
                    5000,
                    100
                ),

                // Sản phẩm thực phẩm
                new SanPhamThucPham(
                    "TP001",
                    "Sữa tươi",
                    30000,
                    50,
                    DateTime.Now.AddDays(2),
                    5
                ),

                // Sản phẩm điện tử
                new SanPhamDienTu(
                    "DT001",
                    "Tai nghe Bluetooth",
                    500000,
                    20,
                    24,
                    "Sony"
                )
            };


            // ==========================================
            // Duyệt danh sách bằng foreach
            // ==========================================
            Console.WriteLine("========== DANH SÁCH SẢN PHẨM ==========");

            foreach (SanPham sp in danhSach)
            {
                Console.WriteLine(sp.MoTa());

                Console.WriteLine(
                    $"Giá bán thực tế: {sp.TinhGiaBan():N0} VNĐ"
                );

                Console.WriteLine();
            }


            // ==========================================
            // Tính tổng giá trị kho
            // ==========================================
            decimal tongGiaTriKho = 0;

            foreach (SanPham sp in danhSach)
            {
                tongGiaTriKho +=
                    sp.TinhGiaBan() * sp.SoLuongTon;
            }

            Console.WriteLine("==========================================");
            Console.WriteLine(
                $"TỔNG GIÁ TRỊ KHO: {tongGiaTriKho:N0} VNĐ"
            );
            Console.WriteLine("==========================================");
        }
    }
}