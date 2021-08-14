using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class Chitietbaigiang
    {
        [DisplayName("Mã chi tiết bài giảng")]
        public string CtbgId { get; set; }
        [DisplayName("Mã lớp")]
        public string LId { get; set; }
        [DisplayName("Mã bài giảng")]
        public string BgId { get; set; }

        public virtual Baigiang Bg { get; set; }
        public virtual Lop LIdNavigation { get; set; }
    }
}
