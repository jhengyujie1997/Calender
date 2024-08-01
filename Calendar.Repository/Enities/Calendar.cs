using System;
using System.Collections.Generic;

namespace Calendar.Repository.Enities;

/// <summary>
/// 日歷基本檔
/// </summary>
public partial class Calendar
{
    /// <summary>
    /// 流水號
    /// </summary>
    public int groupId { get; set; }

    /// <summary>
    /// 標題
    /// </summary>
    public int title { get; set; }

    /// <summary>
    /// 開始時間
    /// </summary>
    public DateTime? start { get; set; }

    /// <summary>
    /// 結束時間
    /// </summary>
    public DateTime? end { get; set; }

    /// <summary>
    /// 背景顏色
    /// </summary>
    public string? color { get; set; }

    /// <summary>
    /// 文字顏色
    /// </summary>
    public string? textColor { get; set; }

    /// <summary>
    /// 產生人員
    /// </summary>
    public string? CreateUser { get; set; }

    /// <summary>
    /// 產生日期
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// 異動人員
    /// </summary>
    public string? LogUser { get; set; }

    /// <summary>
    /// 異動時間
    /// </summary>
    public DateTime LogDate { get; set; }

    /// <summary>
    /// 異動版本
    /// </summary>
    public byte[] LogSN { get; set; } = null!;
}
