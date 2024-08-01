namespace Calendar.Web.Models
{
    /// <summary>
    /// Class CalendarViewModel.
    /// </summary>
    public class CalendarViewModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int groupId { get; set; }

        /// <summary>
        /// 標題
        /// </summary>
        public string title { get; set; } = null!;

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
    }
}
