class SanPham
{
    public string? TenSP {get;set;}
    public string? MaSP {get;set;}
    public decimal GiaNhap {get;set;}
    public decimal GiaBan {get;set;}
    public string? MoTa {get;set;}
    private int soLuong;
    public int SoLuong
    {
        get => soLuong;
        set => soLuong = value < 0 ? throw new ArgumentException("Khong duoc de so am") : value;

    }
    public SanPham(string maSP,string tenSP,int soLuong = 0,decimal giaNhap = 0,decimal giaBan = 0,string moTa = "")
    {
        MaSP=maSP;
        TenSP=tenSP;
        SoLuong=soLuong;
        GiaBan=giaBan;
        GiaNhap=giaNhap;
        MoTa=moTa;
    }
}