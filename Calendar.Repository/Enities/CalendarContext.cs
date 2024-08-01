using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Repository.Enities;

public partial class CalendarContext : DbContext
{
    private readonly string _connectionString;

    public CalendarContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public CalendarContext(DbContextOptions<CalendarContext> options): base(options)
    {
    }

    public virtual DbSet<Calendar> Calendar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasKey(e => e.groupId);

            entity.ToTable(tb => tb.HasComment("日歷基本檔"));

            entity.Property(e => e.groupId).HasComment("流水號");
            entity.Property(e => e.CreateDate)
                .HasComment("產生日期")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUser)
                .HasMaxLength(10)
                .HasComment("產生人員");
            entity.Property(e => e.LogDate)
                .HasComment("異動時間")
                .HasColumnType("datetime");
            entity.Property(e => e.LogSN)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasComment("異動版本");
            entity.Property(e => e.LogUser)
                .HasMaxLength(10)
                .HasComment("異動人員");
            entity.Property(e => e.color)
                .HasMaxLength(10)
                .HasComment("背景顏色");
            entity.Property(e => e.end)
                .HasComment("結束時間")
                .HasColumnType("datetime");
            entity.Property(e => e.start)
                .HasComment("開始時間")
                .HasColumnType("datetime");
            entity.Property(e => e.textColor)
                .HasMaxLength(10)
                .HasComment("文字顏色");
            entity.Property(e => e.title).HasComment("標題");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
