

class LichSuXuat
{
    public DateTime NgayXuat {get; set;}
    public string? MaSP {get;set;}
    public string? TenSP {get;set;}
    public int SoLuongXuat {get;set;}
    public decimal GiaXuat {get;set;}
    public decimal ThanhTienXuat => SoLuongXuat * GiaXuat;

}