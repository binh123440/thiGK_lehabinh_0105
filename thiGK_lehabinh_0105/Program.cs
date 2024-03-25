using System;
using System.Collections.Generic;
using System.Linq;

class TaiLieu
{
    public string MaXuatBan { get; set; }
    public string TenTaiLieu { get; set; }
    public string NhaPhatHanh { get; set; }
}

class DanhMuc
{
    public string ID { get; set; }
    public string TenDanhMuc { get; set; }
}

class Sach : TaiLieu
{
    public string TenTacGia { get; set; }
    public int SoTrang { get; set; }
}

class Bao : TaiLieu
{
    public string NgayPhatHanh { get; set; }
}

class TapChi : TaiLieu
{
    public int SoPhatHanh { get; set; }
    public int TrangPhatHanh { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<TaiLieu> taiLieus = new List<TaiLieu>
        {
            new Sach { MaXuatBan = "001", TenTaiLieu = "Sach A", NhaPhatHanh = "NXB A", TenTacGia = "Tac Gia A", SoTrang = 100 },
            new Sach { MaXuatBan = "004", TenTaiLieu = "Sach A2", NhaPhatHanh = "NXB A2", TenTacGia = "Tac Gia A2", SoTrang = 100 },
            new Sach { MaXuatBan = "005", TenTaiLieu = "Sach A3", NhaPhatHanh = "NXB A3", TenTacGia = "Tac Gia A3", SoTrang = 100 },
            new Sach { MaXuatBan = "006", TenTaiLieu = "Sach A4", NhaPhatHanh = "NXB A4", TenTacGia = "Tac Gia A4", SoTrang = 100 },
            new Bao { MaXuatBan = "002", TenTaiLieu = "Bao B", NhaPhatHanh = "NXB B", NgayPhatHanh = "01/11/2023" },
            new Bao { MaXuatBan = "002", TenTaiLieu = "Bao B1", NhaPhatHanh = "NXB B", NgayPhatHanh = "24/03/2024" },
            new Bao { MaXuatBan = "002", TenTaiLieu = "Bao B2", NhaPhatHanh = "NXB B", NgayPhatHanh = "24/03/2024" },
            new TapChi { MaXuatBan = "003", TenTaiLieu = "Tap Chi C", NhaPhatHanh = "NXB C", SoPhatHanh = 3, TrangPhatHanh = 50 },
        };

        List<DanhMuc> danhMucs = new List<DanhMuc>
        {
            new DanhMuc { ID = "S", TenDanhMuc = "Sach" },
            new DanhMuc { ID = "B", TenDanhMuc = "Bao" },
            new DanhMuc { ID = "TC", TenDanhMuc = "Tap Chi" }
        };

        TaiLieuTheoDanhMuc(taiLieus, danhMucs);
        TaiLieuTheoNgayPhatHanh(taiLieus);
    }

    static void TaiLieuTheoDanhMuc(List<TaiLieu> taiLieus, List<DanhMuc> danhMucs)
    {
        Console.WriteLine("Nhap danh muc (S, B, TC):");
        string danhMuc = Console.ReadLine();

        var ketQua = taiLieus.Where(t => (t is Sach && danhMuc == "S") || (t is Bao && danhMuc == "B") || (t is TapChi && danhMuc == "TC") || (t is Sach && danhMuc == "s") || (t is Bao && danhMuc == "b") || (t is TapChi && danhMuc == "tc"))
                             .Select(t => new { TaiLieu = t, DanhMuc = danhMucs.FirstOrDefault(d => d.ID == (t is Sach ? "S" : t is Bao ? "B" : "TC")) });

        foreach (var item in ketQua)
        {
            Console.WriteLine($"Tai lieu: {item.TaiLieu.TenTaiLieu}, Danh muc: {item.DanhMuc.TenDanhMuc}");
        }
    }

    static void TaiLieuTheoNgayPhatHanh(List<TaiLieu> taiLieus)
    {
        Console.WriteLine("Nhap ngay phat hanh (dd/mm/yyyy):");
        string ngayPhatHanh = Console.ReadLine();

        var ketQua = taiLieus.OfType<Bao>().Where(b => b.NgayPhatHanh == ngayPhatHanh);

        foreach (var item in ketQua)
        {
            Console.WriteLine($"Bao co ngay phat hanh {ngayPhatHanh}: {item.TenTaiLieu}");
        }
    }
}
