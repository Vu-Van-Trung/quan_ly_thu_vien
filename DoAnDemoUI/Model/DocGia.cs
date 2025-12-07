using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("DOCGIA")]
    public class DocGia
    {
        [Key]
        public int MaDocGia { get; set; }

        [StringLength(200)]
        public string TenDocGia { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        // Khóa ngoại
        public int? SoThe { get; set; }
        public int? MaPhieuMuon { get; set; }

        [ForeignKey("SoThe")]
        public virtual TheThuVien TheThuVien { get; set; }

        [ForeignKey("MaPhieuMuon")]
        public virtual PhieuMuon PhieuMuon { get; set; }

        // Một độc giả có thể bị nhiều phiếu phạt
        public virtual ICollection<PhieuPhat> PhieuPhats { get; set; } = new List<PhieuPhat>();
    }
}