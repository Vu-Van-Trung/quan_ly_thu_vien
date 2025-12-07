using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("NHAXUATBAN")]
    public class NhaXuatBan
    {
        [Key]
        public int MaNhaXuatBan { get; set; }

        [StringLength(200)]
        public string TenNhaXuatBan { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string ThongTinDaiDien { get; set; }

        // Một NXB có nhiều Sách
        public virtual ICollection<Sach> Sachs { get; set; } = new List<Sach>();
    }
}