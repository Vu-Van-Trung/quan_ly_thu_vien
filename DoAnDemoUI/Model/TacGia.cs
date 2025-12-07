using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnDemoUI.Model
{
    [Table("TACGIA")]
    public class TacGia
    {
        [Key]
        public int MaTacGia { get; set; }

        [StringLength(200)]
        public string TenTacGia { get; set; }

        // Một Tác giả có nhiều Sách
        public virtual ICollection<Sach> Sachs { get; set; } = new List<Sach>();
    }
}