using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("CTPHIEUMUON")]
    public class CTPhieuMuon
    {
        [Key]
        public int Id { get; set; }

        public DateTime? NgayTraDK { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public int? MaPhieuMuon { get; set; }
        public int? MaSach { get; set; }

        [ForeignKey("MaPhieuMuon")]
        public virtual PhieuMuon PhieuMuon { get; set; }

        [ForeignKey("MaSach")]
        public virtual Sach Sach { get; set; }
    }
}