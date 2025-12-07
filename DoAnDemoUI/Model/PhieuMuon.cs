using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("PHIEUMUON")]
    public class PhieuMuon
    {
        [Key]
        public int MaPhieuMuon { get; set; }

        public DateTime? NgayMuon { get; set; }

        public int? MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        // Một phiếu mượn có nhiều chi tiết sách
        public virtual ICollection<CTPhieuMuon> CTPhieuMuons { get; set; } = new List<CTPhieuMuon>();

        // Theo SQL của bạn: Độc giả trỏ tới Phiếu Mượn
        public virtual ICollection<DocGia> DocGias { get; set; } = new List<DocGia>();
    }
}