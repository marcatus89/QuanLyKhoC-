


using System.Security.Cryptography;

class TinhNang
{
    public static SanPham? TimSP(List<SanPham> ds, string a) => ds.FirstOrDefault(x => x.MaSP == a);
    public static string NhapChuoi(string message)
    {

        string s;
        do
        {
            System.Console.WriteLine(message);
            s = Console.ReadLine() ?? "";
        } while (String.IsNullOrWhiteSpace(s));
        return s;
    }
    public static int NhapSo(string message)
    {
        int n;
        do
        {
            System.Console.WriteLine(message);
        }
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0);
        return n;
    }
    public static decimal NhapTien(string message)
    {
        decimal m;
        do
        {
            System.Console.WriteLine(message);
        }
        while(!decimal.TryParse(Console.ReadLine(),out m) || m < 0);
        return m;
    }
    public static void ThemSP(List<SanPham> ds)
    {
        while (true)
        {
            string ma = NhapChuoi("Nhap ma san pham");
            if (ma == "0") break;
            SanPham? sp = TimSP(ds, ma);
            if (sp != null)
            {
                System.Console.WriteLine("Ma san pham nay da ton tai");
                continue;
            }
            string ten = NhapChuoi("Nhap ten san pham");
            ds.Add(new SanPham(ma, ten));
            System.Console.WriteLine("Da them san pham thanh cong");

        }
    }
    public static void NhapHang(List<SanPham> ds,List<LichSuNhap> lichSuNhap)
    {
        while (true)
        {
            string ma = NhapChuoi("Nhap ma san pham");
            if (ma == "0") break;
            SanPham? sp = TimSP(ds, ma);
            if (sp == null)
            {
                System.Console.WriteLine("San pham khong ton tai");
                continue;
            }
            int sl = NhapSo("Nhap vao so luong");
            sp.SoLuong += sl;
            lichSuNhap.Add(new LichSuNhap
            {
                MaSP = sp.MaSP??"",
                TenSP=sp.TenSP??"",
                SoLuongNhap = sl,
                GiaNhap = sp.GiaNhap

            });
            
            System.Console.WriteLine($"Da nhap san pham {sp.TenSP},so luong hien tai {sp.SoLuong}");

        }
    }
    public static void XuatHang(List<SanPham> ds,List<LichSuXuat> lichSuXuat)
    {
        while (true)
        {
            string ma = NhapChuoi("Nhap ma san pham");
            if (ma == "0") break;
            SanPham? sp = TimSP(ds, ma);
            if (sp == null)
            {
                System.Console.WriteLine("San pham khong ton tai");
                continue;
            }
            int sl = NhapSo("Nhap vao so luong");
            if (sp.SoLuong < sl)
            {
                System.Console.WriteLine("So luong ton khong du xuat");
                continue;
            }
            sp.SoLuong -= sl;
            lichSuXuat.Add(new LichSuXuat
            {
                MaSP = sp.MaSP??"",
                TenSP=sp.TenSP??"",
                SoLuongXuat = sl,
                GiaBan = sp.GiaBan

            });
            System.Console.WriteLine($"Da xuat san pham thanh cong {sp.TenSP},so luong hien tai {sp.SoLuong}");
        }
    }
    public static void XoaMa(List<SanPham> ds)
    {
        while (true)
        {
            string ma = NhapChuoi("Nhap vao ma san pham muon xoa");
            if (ma == "0") break;
            SanPham? sp = TimSP(ds, ma);
            if (sp == null)
            {
                System.Console.WriteLine("Ma san pham muon xoa khong ton tai");
                continue;
            }
            string xacNhan = NhapChuoi("Ban co chac chan muon xoa khong? (Y or N)");
            if (xacNhan != "Y" && xacNhan != "N")
            {
                System.Console.WriteLine("Khong co lua chon nay");
                continue;
            }
            else if (xacNhan == "N")
            {
                System.Console.WriteLine("Ban tu choi xoa san pham");
                continue;
            }
            else
            {
                if (sp.SoLuong != 0)
                {
                    System.Console.WriteLine("San pham con so luong khong the xoa");
                    continue;
                }

                ds.Remove(sp);
                System.Console.WriteLine("Chuc mung ban da xoa san pham thanh cong");

            }

        }
    }
    public static void TraCuu(List<SanPham> ds)
    {
        while(true)
        {
            string ma = NhapChuoi("Nhap vao ma muon tra cuu");
            if(ma=="0") break;
            SanPham? sp = TimSP(ds,ma);
            if(sp==null)
            {
                System.Console.WriteLine("San pham khong ton tai");
                continue;
            }
            System.Console.WriteLine($"Ma san pham:{sp.MaSP}-Ten san pham:{sp.TenSP}-So Luong:{sp.SoLuong}");

        }
    }
    public static void HienThiDS(List<SanPham> ds)
    {
        if(!ds.Any())
        {
            System.Console.WriteLine("Danhs sach rong");
            return;
        }
        ds.ForEach(sp => System.Console.WriteLine($"Ma san pham:{sp.MaSP}- Ten san pham: {sp.TenSP}-So Luong:{sp.SoLuong}") );
    }

    //2.Tìm kiếm sản phẩm theo tên (tìm gần đúng)
    public static void TimKiemTheoTen(List<SanPham> ds)
    {
        while(true)
        {
            string tuKhoa = NhapChuoi("Nhap ten san pham tim kiem:");
            if(tuKhoa=="0") break;
            var ketQua = ds.Where(sp => sp.TenSP != null && sp.TenSP.Contains(tuKhoa,StringComparison.OrdinalIgnoreCase)).ToList();
            if(ketQua.Count == 0)
            {
                System.Console.WriteLine($"Khong tim thay san pham chua tu khoa: \"{tuKhoa}\"");
                continue;
            }
            else
            {
                System.Console.WriteLine($"Da tim thay {ketQua.Count} ket qua chua tu khoa \"{tuKhoa}\"");
                ketQua.ForEach(sp => System.Console.WriteLine($"Ma san pham:{sp.MaSP} | Ten san pham:{sp.TenSP} | So Luong:{sp.SoLuong} | Gia ban:{sp.GiaBan} | Gia Nhap:{sp.GiaNhap} | Mo ta:{sp.MoTa}"));
            }


        }
        
    }
    //3.Tìm kiếm sản phẩm theo khoảng giá
    public static void TimKiemTheoGia(List<SanPham> ds)
    {
        decimal giaThap = NhapTien("Nhap gia ban thap nhat: ");
        decimal giaCao = NhapTien("Nhap gia ban cao nhat: ");

        var ketQua = ds.Where(sp => sp.GiaBan >= giaThap && sp.GiaBan <= giaCao).OrderBy(sp => sp.GiaBan).ToList();
        if(ketQua.Count == 0)
        {
            System.Console.WriteLine($"Khong tim thay san pham nao co gia {giaThap} den {giaCao} ");
            return;
        }
        else
        {
            System.Console.WriteLine($"Da tim thay {ketQua.Count} ket qua co gia tu {giaThap} den {giaCao}");
            ketQua.ForEach(sp => System.Console.WriteLine($"Ma san pham:{sp.MaSP} | Ten san pham:{sp.TenSP} | So Luong:{sp.SoLuong} | Gia ban:{sp.GiaBan} | Gia Nhap:{sp.GiaNhap} | Mo ta:{sp.MoTa}"));
        }

    }

    //Báo cáo tồn kho tổng quát (tổng số lượng, tổng giá trị)
    public static void BaoCaoTonKho(List<SanPham> ds)
    {
        if(!ds.Any())
        {
            System.Console.WriteLine("Danh sach san pham hien tai dang trong");
            return;
        }
        int tongSoLuong = ds.Sum(sp => sp.SoLuong);
        int tongSoMa = ds.Count();
        decimal tongGiaBan = ds.Sum(sp => sp.GiaBan);
        decimal tongGiaNhap =ds.Sum(sp =>sp.GiaNhap);
        System.Console.WriteLine($"Tong so ma:{tongSoMa}");
        System.Console.WriteLine($"Tong so luong hang:{tongSoLuong}");
        System.Console.WriteLine($"Tong gia ban:{tongGiaBan}");
        System.Console.WriteLine($"Tong gia nhap:{tongGiaNhap}");
    }
}