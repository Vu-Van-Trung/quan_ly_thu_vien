using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("SACH")]
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }

        [StringLength(200)]
        public string TenSach { get; set; }

        public int? NamSX { get; set; }
        public int? SoLuong { get; set; }

        [StringLength(200)]
        public string TrangThai { get; set; }

        // Khóa ngoại (Foreign Keys)
        public int? MaTacGia { get; set; }
        public int? MaTheLoai { get; set; }
        public int? MaNhaXuatBan { get; set; }

        // Navigation properties (Liên kết bảng cha)
        [ForeignKey("MaTacGia")]
        public virtual TacGia TacGia { get; set; }

        [ForeignKey("MaTheLoai")]
        public virtual TheLoai TheLoai { get; set; }

        [ForeignKey("MaNhaXuatBan")]
        public virtual NhaXuatBan NhaXuatBan { get; set; }

        // Navigation properties (Liên kết bảng con - Chi tiết)
        public virtual ICollection<CTPhieuMuon> CTPhieuMuons { get; set; } = new List<CTPhieuMuon>();
        public virtual ICollection<CTPhieuPhat> CTPhieuPhats { get; set; } = new List<CTPhieuPhat>();
    }
}