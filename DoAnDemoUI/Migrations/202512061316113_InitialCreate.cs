namespace DoAnDemoUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTPHIEUMUON",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayTraDK = c.DateTime(),
                        TrangThai = c.String(maxLength: 50),
                        MaPhieuMuon = c.Int(),
                        MaSach = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PHIEUMUON", t => t.MaPhieuMuon)
                .ForeignKey("dbo.SACH", t => t.MaSach)
                .Index(t => t.MaPhieuMuon)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.PHIEUMUON",
                c => new
                    {
                        MaPhieuMuon = c.Int(nullable: false, identity: true),
                        NgayMuon = c.DateTime(),
                        MaNhanVien = c.Int(),
                    })
                .PrimaryKey(t => t.MaPhieuMuon)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.DOCGIA",
                c => new
                    {
                        MaDocGia = c.Int(nullable: false, identity: true),
                        TenDocGia = c.String(maxLength: 200),
                        DiaChi = c.String(maxLength: 200),
                        SoThe = c.Int(),
                        MaPhieuMuon = c.Int(),
                    })
                .PrimaryKey(t => t.MaDocGia)
                .ForeignKey("dbo.PHIEUMUON", t => t.MaPhieuMuon)
                .ForeignKey("dbo.THETHUVIEN", t => t.SoThe)
                .Index(t => t.SoThe)
                .Index(t => t.MaPhieuMuon);
            
            CreateTable(
                "dbo.PHIEUPHAT",
                c => new
                    {
                        SoPhieuPhat = c.Int(nullable: false, identity: true),
                        NgayLap = c.DateTime(),
                        MaNhanVien = c.Int(),
                        MaDocGia = c.Int(),
                    })
                .PrimaryKey(t => t.SoPhieuPhat)
                .ForeignKey("dbo.DOCGIA", t => t.MaDocGia)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien)
                .Index(t => t.MaNhanVien)
                .Index(t => t.MaDocGia);
            
            CreateTable(
                "dbo.CTPHIEUPHAT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(maxLength: 200),
                        TongTien = c.Decimal(precision: 18, scale: 2),
                        SoPhieuPhat = c.Int(),
                        MaSach = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PHIEUPHAT", t => t.SoPhieuPhat)
                .ForeignKey("dbo.SACH", t => t.MaSach)
                .Index(t => t.SoPhieuPhat)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.SACH",
                c => new
                    {
                        MaSach = c.Int(nullable: false, identity: true),
                        TenSach = c.String(maxLength: 200),
                        NamSX = c.Int(),
                        SoLuong = c.Int(),
                        TrangThai = c.String(maxLength: 200),
                        MaTacGia = c.Int(),
                        MaTheLoai = c.Int(),
                        MaNhaXuatBan = c.Int(),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.NHAXUATBAN", t => t.MaNhaXuatBan)
                .ForeignKey("dbo.TACGIA", t => t.MaTacGia)
                .ForeignKey("dbo.THELOAI", t => t.MaTheLoai)
                .Index(t => t.MaTacGia)
                .Index(t => t.MaTheLoai)
                .Index(t => t.MaNhaXuatBan);
            
            CreateTable(
                "dbo.NHAXUATBAN",
                c => new
                    {
                        MaNhaXuatBan = c.Int(nullable: false, identity: true),
                        TenNhaXuatBan = c.String(maxLength: 200),
                        DiaChi = c.String(maxLength: 200),
                        Email = c.String(maxLength: 100),
                        ThongTinDaiDien = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaNhaXuatBan);
            
            CreateTable(
                "dbo.TACGIA",
                c => new
                    {
                        MaTacGia = c.Int(nullable: false, identity: true),
                        TenTacGia = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaTacGia);
            
            CreateTable(
                "dbo.THELOAI",
                c => new
                    {
                        MaTheLoai = c.Int(nullable: false, identity: true),
                        TenTheLoai = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaTheLoai);
            
            CreateTable(
                "dbo.NHANVIEN",
                c => new
                    {
                        MaNhanVien = c.Int(nullable: false, identity: true),
                        TenNhanVien = c.String(maxLength: 200),
                        NgaySinh = c.DateTime(),
                        SoDienThoai = c.String(maxLength: 20),
                        DiaChi = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.THETHUVIEN",
                c => new
                    {
                        SoThe = c.Int(nullable: false, identity: true),
                        NgayBatDau = c.DateTime(),
                        NgayKetThuc = c.DateTime(),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.SoThe);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        Role = c.String(maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DOCGIA", "SoThe", "dbo.THETHUVIEN");
            DropForeignKey("dbo.PHIEUPHAT", "MaNhanVien", "dbo.NHANVIEN");
            DropForeignKey("dbo.PHIEUMUON", "MaNhanVien", "dbo.NHANVIEN");
            DropForeignKey("dbo.PHIEUPHAT", "MaDocGia", "dbo.DOCGIA");
            DropForeignKey("dbo.SACH", "MaTheLoai", "dbo.THELOAI");
            DropForeignKey("dbo.SACH", "MaTacGia", "dbo.TACGIA");
            DropForeignKey("dbo.SACH", "MaNhaXuatBan", "dbo.NHAXUATBAN");
            DropForeignKey("dbo.CTPHIEUPHAT", "MaSach", "dbo.SACH");
            DropForeignKey("dbo.CTPHIEUMUON", "MaSach", "dbo.SACH");
            DropForeignKey("dbo.CTPHIEUPHAT", "SoPhieuPhat", "dbo.PHIEUPHAT");
            DropForeignKey("dbo.DOCGIA", "MaPhieuMuon", "dbo.PHIEUMUON");
            DropForeignKey("dbo.CTPHIEUMUON", "MaPhieuMuon", "dbo.PHIEUMUON");
            DropIndex("dbo.SACH", new[] { "MaNhaXuatBan" });
            DropIndex("dbo.SACH", new[] { "MaTheLoai" });
            DropIndex("dbo.SACH", new[] { "MaTacGia" });
            DropIndex("dbo.CTPHIEUPHAT", new[] { "MaSach" });
            DropIndex("dbo.CTPHIEUPHAT", new[] { "SoPhieuPhat" });
            DropIndex("dbo.PHIEUPHAT", new[] { "MaDocGia" });
            DropIndex("dbo.PHIEUPHAT", new[] { "MaNhanVien" });
            DropIndex("dbo.DOCGIA", new[] { "MaPhieuMuon" });
            DropIndex("dbo.DOCGIA", new[] { "SoThe" });
            DropIndex("dbo.PHIEUMUON", new[] { "MaNhanVien" });
            DropIndex("dbo.CTPHIEUMUON", new[] { "MaSach" });
            DropIndex("dbo.CTPHIEUMUON", new[] { "MaPhieuMuon" });
            DropTable("dbo.Users");
            DropTable("dbo.THETHUVIEN");
            DropTable("dbo.NHANVIEN");
            DropTable("dbo.THELOAI");
            DropTable("dbo.TACGIA");
            DropTable("dbo.NHAXUATBAN");
            DropTable("dbo.SACH");
            DropTable("dbo.CTPHIEUPHAT");
            DropTable("dbo.PHIEUPHAT");
            DropTable("dbo.DOCGIA");
            DropTable("dbo.PHIEUMUON");
            DropTable("dbo.CTPHIEUMUON");
        }
    }
}
