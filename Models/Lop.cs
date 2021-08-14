using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class Lop
    {
        public Lop()
        {
            Chitietbaigiangs = new HashSet<Chitietbaigiang>();
            Chitietlops = new HashSet<Chitietlop>();
            Thoikhoabieus = new HashSet<Thoikhoabieu>();
        }
        
        [DisplayName("Mã lớp")]
        public string LId { get; set; }
        [DisplayName("Tên lớp")]
        public string LTen { get; set; }
        [DisplayName("Mô tả")]
        public string LMota { get; set; }
        [DisplayName("Khóa")]
        public string LKhoa { get; set; }
        [DisplayName("Ngày bắt đầu ")]
        public DateTime? LNgaybatdau { get; set; }
        [DisplayName("Ngày kết thúc")]
        public DateTime? LNgayketthuc { get; set; }
        [DisplayName("Trạng thái")]
        public string LTrangthai { get; set; }

        public virtual ICollection<Chitietbaigiang> Chitietbaigiangs { get; set; }
        public virtual ICollection<Chitietlop> Chitietlops { get; set; }
        public virtual ICollection<Thoikhoabieu> Thoikhoabieus { get; set; }
    }
}
