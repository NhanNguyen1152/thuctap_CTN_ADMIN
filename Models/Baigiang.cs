using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class Baigiang
    {
        public Baigiang()
        {
            Chitietbaigiangs = new HashSet<Chitietbaigiang>();
        }
        
        [DisplayName("Mã bài giảng")]
        public string BgId { get; set; }
        [DisplayName("Tên bài giảng")]
        public string BgTen { get; set; }
        [DisplayName("Loại bài giảng")]
        public string BgLoai { get; set; }
        [DisplayName("File bài giảng")]
        public string BgFile { get; set; }
        [DisplayName("Trạng thái bài giảng")]
        public string BgTrangthai { get; set; }

        public virtual ICollection<Chitietbaigiang> Chitietbaigiangs { get; set; }
    }
}
