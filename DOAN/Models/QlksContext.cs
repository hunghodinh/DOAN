using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DOAN.Models;

public partial class QlksContext : DbContext
{
    public QlksContext()
    {
    }

    public QlksContext(DbContextOptions<QlksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbChucVu> TbChucVus { get; set; }

    public virtual DbSet<TbCthoaDon> TbCthoaDons { get; set; }

    public virtual DbSet<TbCtphieuDangKy> TbCtphieuDangKies { get; set; }

    public virtual DbSet<TbCtphong> TbCtphongs { get; set; }

    public virtual DbSet<TbDvu> TbDvus { get; set; }

    public virtual DbSet<TbHoaDon> TbHoaDons { get; set; }

    public virtual DbSet<TbKhachHang> TbKhachHangs { get; set; }

    public virtual DbSet<TbNhanVien> TbNhanViens { get; set; }

    public virtual DbSet<TbTaiKhoan> TbTaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source= LAPTOP-V7VL83QP\\SQLEXPRESS; initial catalog=QLKS; integrated security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbChucVu>(entity =>
        {
            entity.HasKey(e => e.IdCv);

            entity.ToTable("tb_ChucVu");

            entity.Property(e => e.IdCv)
                .HasMaxLength(50)
                .HasColumnName("ID_CV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(50)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<TbCthoaDon>(entity =>
        {
            entity.HasKey(e => e.IdCthd).HasName("PK_tb_CTHD");

            entity.ToTable("tb_CTHoaDon");

            entity.Property(e => e.IdCthd).HasColumnName("ID_CTHD");
            entity.Property(e => e.IdHd)
                .HasMaxLength(50)
                .HasColumnName("ID_HD");
            entity.Property(e => e.TienDv).HasColumnName("TienDV");

            entity.HasOne(d => d.IdHdNavigation).WithMany(p => p.TbCthoaDons)
                .HasForeignKey(d => d.IdHd)
                .HasConstraintName("FK_tb_CTHoaDon_tb_HoaDon");
        });

        modelBuilder.Entity<TbCtphieuDangKy>(entity =>
        {
            entity.HasKey(e => e.IdCtpdk).HasName("PK_tb_CTPDK");

            entity.ToTable("tb_CTPhieuDangKy");

            entity.Property(e => e.IdCtpdk).HasColumnName("ID_CTPDK");
            entity.Property(e => e.IdKh)
                .HasMaxLength(50)
                .HasColumnName("ID_KH");
            entity.Property(e => e.IdPhong)
                .HasMaxLength(50)
                .HasColumnName("ID_Phong");
            entity.Property(e => e.NgayDen).HasColumnType("datetime");
            entity.Property(e => e.NgayDi).HasColumnType("datetime");

            entity.HasOne(d => d.IdKhNavigation).WithMany(p => p.TbCtphieuDangKies)
                .HasForeignKey(d => d.IdKh)
                .HasConstraintName("FK_tb_CTPhieuDangKy_tb_KhachHang");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.TbCtphieuDangKies)
                .HasForeignKey(d => d.IdPhong)
                .HasConstraintName("FK_tb_CTPhieuDangKy_tb_CTPhong");
        });

        modelBuilder.Entity<TbCtphong>(entity =>
        {
            entity.HasKey(e => e.IdPhong);

            entity.ToTable("tb_CTPhong");

            entity.Property(e => e.IdPhong)
                .HasMaxLength(50)
                .HasColumnName("ID_Phong");
            entity.Property(e => e.GhiChu).HasColumnType("ntext");
            entity.Property(e => e.GiaCt).HasColumnName("GiaCT");
            entity.Property(e => e.LoaiGiuong).HasMaxLength(50);
            entity.Property(e => e.LoaiPhong).HasMaxLength(50);
            entity.Property(e => e.TenPhong).HasMaxLength(50);
        });

        modelBuilder.Entity<TbDvu>(entity =>
        {
            entity.HasKey(e => e.IdDv);

            entity.ToTable("tb_DVu");

            entity.Property(e => e.IdDv)
                .HasMaxLength(50)
                .HasColumnName("ID_DV");
            entity.Property(e => e.TenDv)
                .HasMaxLength(50)
                .HasColumnName("TenDV");
        });

        modelBuilder.Entity<TbHoaDon>(entity =>
        {
            entity.HasKey(e => e.IdHd);

            entity.ToTable("tb_HoaDon");

            entity.Property(e => e.IdHd)
                .HasMaxLength(50)
                .HasColumnName("ID_HD");
            entity.Property(e => e.GhiChu).HasColumnType("ntext");
            entity.Property(e => e.IdDv)
                .HasMaxLength(50)
                .HasColumnName("ID_DV");
            entity.Property(e => e.IdKh)
                .HasMaxLength(50)
                .HasColumnName("ID_KH");
            entity.Property(e => e.NgayLap).HasColumnType("datetime");

            entity.HasOne(d => d.IdDvNavigation).WithMany(p => p.TbHoaDons)
                .HasForeignKey(d => d.IdDv)
                .HasConstraintName("FK_tb_HoaDon_tb_DVu");

            entity.HasOne(d => d.IdKhNavigation).WithMany(p => p.TbHoaDons)
                .HasForeignKey(d => d.IdKh)
                .HasConstraintName("FK_tb_HoaDon_tb_KhachHang");
        });

        modelBuilder.Entity<TbKhachHang>(entity =>
        {
            entity.HasKey(e => e.IdKh);

            entity.ToTable("tb_KhachHang");

            entity.Property(e => e.IdKh)
                .HasMaxLength(50)
                .HasColumnName("ID_KH");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GioTinh).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<TbNhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNv);

            entity.ToTable("tb_NhanVien");

            entity.Property(e => e.IdNv)
                .HasMaxLength(50)
                .HasColumnName("ID_NV");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.IdCv)
                .HasMaxLength(50)
                .HasColumnName("ID_CV");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("TenNV");

            entity.HasOne(d => d.IdCvNavigation).WithMany(p => p.TbNhanViens)
                .HasForeignKey(d => d.IdCv)
                .HasConstraintName("FK_tb_NhanVien_tb_ChucVu");
        });

        modelBuilder.Entity<TbTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdNguoiDung);

            entity.ToTable("tb_TaiKhoan");

            entity.Property(e => e.IdNguoiDung)
                .HasMaxLength(50)
                .HasColumnName("ID_NguoiDung");
            entity.Property(e => e.IdNv)
                .HasMaxLength(50)
                .HasColumnName("ID_NV");
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
