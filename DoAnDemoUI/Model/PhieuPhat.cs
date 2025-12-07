using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("PHIEUPHAT")]
    public class PhieuPhat
    {
        [Key]
        public int SoPhieuPhat { get; set; }

        public DateTime? NgayLap { get; set; }

        public int? MaNhanVien { get; set; }
        public int? MaDocGia { get; set; }

        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey("MaDocGia")]
        public virtual DocGia DocGia { get; set; }

        // Chi tiết phiếu phạt
        public virtual ICollection<CTPhieuPhat> CTPhieuPhats { get; set; } = new List<CTPhieuPhat>();
    }
}