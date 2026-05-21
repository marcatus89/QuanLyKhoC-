class Program
{
    static void Main(string[] args)
    {
        List<SanPham> ds = new();
        while(true)
        {
            System.Console.WriteLine("1.Them san pham");
            System.Console.WriteLine("2.Nhap hang");
            System.Console.WriteLine("3.Xuat hang");
            System.Console.WriteLine("4.Tra cuu san pham");
            System.Console.WriteLine("5.Tra cuu ten san pham");
            System.Console.WriteLine("6.Cap nhat thong tin san pham");
            System.Console.WriteLine("7.Hien thi toan bo danh sach");
            System.Console.WriteLine("8.Xoa san pham");
            System.Console.WriteLine("9.Tim kiem san pham theo gia ban");
            System.Console.WriteLine("121.Thoat");
            switch(TinhNang.NhapSo("Nhap lua chon"))
            {
                case 1: TinhNang.ThemSP(ds); break;
                case 2: TinhNang.NhapHang(ds); break;
                case 3: TinhNang.XuatHang(ds); break;
                case 4: TinhNang.TraCuu(ds); break;
                case 5: TinhNang.TimKiemTheoTen(ds);break;
                case 7: TinhNang.HienThiDS(ds); break;
                case 8: TinhNang.XoaMa(ds); break;
                case 9: TinhNang.TimKiemTheoGia(ds); break;
                case 121: return;
                default: System.Console.WriteLine("Khong co lua chon nay"); break;
            }
        }
    }
}
