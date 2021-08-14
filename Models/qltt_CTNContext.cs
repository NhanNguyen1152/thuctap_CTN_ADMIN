using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace thuctap_CTN_NEW.Models
{
    public partial class qltt_CTNContext : DbContext
    {
        public qltt_CTNContext()
        {
        }

        public qltt_CTNContext(DbContextOptions<qltt_CTNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Baigiang> Baigiangs { get; set; }
        public virtual DbSet<Chitietbaigiang> Chitietbaigiangs { get; set; }
        public virtual DbSet<Chitietlop> Chitietlops { get; set; }
        public virtual DbSet<Hocvien> Hocviens { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<Thoikhoabieu> Thoikhoabieus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-BTNISNBQ;Database=qltt_CTN;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(entity =>
            {
                entity.ToTable("AD");

                entity.Property(e => e.AdId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AD_ID");

                entity.Property(e => e.AdPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AD_PASSWORD");

                entity.Property(e => e.AdTen)
                    .HasMaxLength(50)
                    .HasColumnName("AD_TEN");

                entity.Property(e => e.AdUsername)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AD_USERNAME");
            });

            modelBuilder.Entity<Baigiang>(entity =>
            {
                entity.HasKey(e => e.BgId)
                    .HasName("PK__BAIGIANG__1F3BF74CBD822F21");

                entity.ToTable("BAIGIANG");

                entity.Property(e => e.BgId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("BG_ID");

                entity.Property(e => e.BgFile)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BG_FILE");

                entity.Property(e => e.BgLoai)
                    .HasMaxLength(50)
                    .HasColumnName("BG_LOAI");

                entity.Property(e => e.BgTen)
                    .HasMaxLength(50)
                    .HasColumnName("BG_TEN");

                entity.Property(e => e.BgTrangthai)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BG_TRANGTHAI");
            });

            modelBuilder.Entity<Chitietbaigiang>(entity =>
            {
                entity.HasKey(e => e.CtbgId)
                    .HasName("PK__CHITIETB__F3A7FDA879BCC627");

                entity.ToTable("CHITIETBAIGIANG");

                entity.Property(e => e.CtbgId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CTBG_ID");

                entity.Property(e => e.BgId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("BG_ID");

                entity.Property(e => e.LId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("L_ID");

                entity.HasOne(d => d.Bg)
                    .WithMany(p => p.Chitietbaigiangs)
                    .HasForeignKey(d => d.BgId)
                    .HasConstraintName("FK_CHITIETBAIGIANG_BAIGIANG");

                entity.HasOne(d => d.LIdNavigation)
                    .WithMany(p => p.Chitietbaigiangs)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_CHITIETBAIGIANG_LOP");
            });

            modelBuilder.Entity<Chitietlop>(entity =>
            {
                entity.HasKey(e => e.CtlId)
                    .HasName("PK__CHITIETL__0AA6E7A1C6B19045");

                entity.ToTable("CHITIETLOP");

                entity.Property(e => e.CtlId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CTL_ID");

                entity.Property(e => e.HvId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("HV_ID");

                entity.Property(e => e.LId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("L_ID");

                entity.HasOne(d => d.Hv)
                    .WithMany(p => p.Chitietlops)
                    .HasForeignKey(d => d.HvId)
                    .HasConstraintName("FK_CHITIETLOP_HOCVIEN");

                entity.HasOne(d => d.LIdNavigation)
                    .WithMany(p => p.Chitietlops)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_CHITIETLOP_LOP");
            });

            modelBuilder.Entity<Hocvien>(entity =>
            {
                entity.HasKey(e => e.HvId)
                    .HasName("PK__HOCVIEN__BB0F9415AE3879B8");

                entity.ToTable("HOCVIEN");

                entity.Property(e => e.HvId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("HV_ID");

                entity.Property(e => e.HvDiachi)
                    .HasMaxLength(100)
                    .HasColumnName("HV_DIACHI");

                entity.Property(e => e.HvEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HV_EMAIL");

                entity.Property(e => e.HvGioitinh)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("HV_GIOITINH");

                entity.Property(e => e.HvHinhanh)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("HV_HINHANH");

                entity.Property(e => e.HvNgaysinh)
                    .HasColumnType("date")
                    .HasColumnName("HV_NGAYSINH");

                entity.Property(e => e.HvNgayvao)
                    .HasColumnType("date")
                    .HasColumnName("HV_NGAYVAO");

                entity.Property(e => e.HvSdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HV_SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.HvTen)
                    .HasMaxLength(50)
                    .HasColumnName("HV_TEN");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__LOP__420BA09E61580FBD");

                entity.ToTable("LOP");

                entity.Property(e => e.LId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("L_ID");

                entity.Property(e => e.LKhoa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("L_KHOA");

                entity.Property(e => e.LMota)
                    .HasMaxLength(200)
                    .HasColumnName("L_MOTA");

                entity.Property(e => e.LNgaybatdau)
                    .HasColumnType("date")
                    .HasColumnName("L_NGAYBATDAU");

                entity.Property(e => e.LNgayketthuc)
                    .HasColumnType("date")
                    .HasColumnName("L_NGAYKETTHUC");

                entity.Property(e => e.LTen)
                    .HasMaxLength(50)
                    .HasColumnName("L_TEN");

                entity.Property(e => e.LTrangthai)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("L_TRANGTHAI");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.TkId)
                    .HasName("PK__TAIKHOAN__6416AA1EB3FE79C0");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.TkId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TK_ID");

                entity.Property(e => e.TkPw)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TK_PW");

                entity.Property(e => e.TkUrn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TK_URN");
            });

            modelBuilder.Entity<Thoikhoabieu>(entity =>
            {
                entity.HasKey(e => e.TkbId)
                    .HasName("PK__THOIKHOA__C63105EB2EBCB39F");

                entity.ToTable("THOIKHOABIEU");

                entity.Property(e => e.TkbId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TKB_ID");

                entity.Property(e => e.HvId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("HV_ID");

                entity.Property(e => e.LId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("L_ID");

                entity.Property(e => e.TkbKhunggio)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TKB_KHUNGGIO");

                entity.Property(e => e.TkbLinkhoc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TKB_LINKHOC");

                entity.Property(e => e.TkbMonhoc)
                    .HasMaxLength(50)
                    .HasColumnName("TKB_MONHOC");

                entity.Property(e => e.TkbNgaybatdau)
                    .HasColumnType("date")
                    .HasColumnName("TKB_NGAYBATDAU");

                entity.Property(e => e.TkbNgayketthuc)
                    .HasColumnType("date")
                    .HasColumnName("TKB_NGAYKETTHUC");

                entity.Property(e => e.TkbThu)
                    .HasMaxLength(30)
                    .HasColumnName("TKB_THU");

                entity.HasOne(d => d.Hv)
                    .WithMany(p => p.Thoikhoabieus)
                    .HasForeignKey(d => d.HvId)
                    .HasConstraintName("FK_THOIKHOABIEU_HOCVIEN");

                entity.HasOne(d => d.LIdNavigation)
                    .WithMany(p => p.Thoikhoabieus)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_THOIKHOABIEU_LOP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
