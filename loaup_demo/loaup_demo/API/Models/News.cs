// ----------------------------------------------------
// file : News.cs
// description : 
// create : 2023-10-20
// update : 
// ----------------------------------------------------
namespace loaup_demo.API.Models
{
    public class Notice
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Link { get; set; }
        public string Type { get; set; } // 공지, 점검, 상점, 이벤트
    }

    public class Event
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Link { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string RewardDate { get; set; }
    }
}