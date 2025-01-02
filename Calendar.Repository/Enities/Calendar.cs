using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Repository.Enities;

/// <summary>
/// 日歷基本檔
/// </summary>
[Table("Calendar")]
public partial class Calendar
{
    /// <summary>
    /// 流水號
    /// </summary>
    [Key]
    [Column("groupId")]
    public int GroupId { get; set; }

    /// <summary>
    /// 標題
    /// </summary>
    [Column("title")]
    [StringLength(20)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// 開始時間
    /// </summary>
    [Column("start", TypeName = "datetime")]
    public DateTime? Start { get; set; }

    /// <summary>
    /// 結束時間
    /// </summary>
    [Column("end", TypeName = "datetime")]
    public DateTime? End { get; set; }

    /// <summary>
    /// 背景顏色
    /// </summary>
    [Column("color")]
    [StringLength(10)]
    public string? Color { get; set; }

    /// <summary>
    /// 文字顏色
    /// </summary>
    [Column("textColor")]
    [StringLength(10)]
    public string? TextColor { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }
}
