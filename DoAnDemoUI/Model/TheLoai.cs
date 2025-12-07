using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("THELOAI")]
    public class TheLoai
    {
        [Key]
        public int MaTheLoai { get; set; }

        [StringLength(200)]
        public string TenTheLoai { get; set; }

        // Một Thể loại có nhiều Sách
        public virtual ICollection<Sach> Sachs { get; set; } = new List<Sach>();
    }
}