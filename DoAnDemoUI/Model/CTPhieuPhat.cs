using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("CTPHIEUPHAT")]
    public class CTPhieuPhat
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string NoiDung { get; set; }

        public decimal? TongTien { get; set; }

        public int? SoPhieuPhat { get; set; }
        public int? MaSach { get; set; }

        [ForeignKey("SoPhieuPhat")]
        public virtual PhieuPhat PhieuPhat { get; set; }

        [ForeignKey("MaSach")]
        public virtual Sach Sach { get; set; }
    }
}