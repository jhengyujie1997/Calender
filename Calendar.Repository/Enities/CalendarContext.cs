using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Repository.Enities;

public partial class CalendarContext : DbContext
{
    public CalendarContext()
    {
    }

    public CalendarContext(DbContextOptions<CalendarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendar> Calendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=Calendar;User ID=sa;Password=siehueicing86;Integrated Security=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.ToTable("Calendar", tb => tb.HasComment("日歷基本檔"));

            entity.Property(e => e.GroupId).HasComment("流水號");
            entity.Property(e => e.Color).HasComment("背景顏色");
            entity.Property(e => e.End).HasComment("結束時間");
            entity.Property(e => e.Start).HasComment("開始時間");
            entity.Property(e => e.TextColor).HasComment("文字顏色");
            entity.Property(e => e.Title).HasComment("標題");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
