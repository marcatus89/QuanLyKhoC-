class LichSuNhap
{
    public DateTime NgayNhap {get; set;}
    public string? MaSP {get; set;}
    public string? TenSP {get;set;}
    public int SoLuongNhap {get;set;}
    public decimal GiaNhap {get;set;}
    public decimal ThanhTienNhap => SoLuongNhap * GiaNhap;
}