// ----------------------------------------------------
// file : Guilds.cs
// description : 길드
// create : 2023-10-20
// update : 
// ----------------------------------------------------
namespace loaup_demo.API.Models
{
    // 길드랭킹 정보
    // 각 서버 1위 ~ 29위까지 제공
    public class GuildRankInfo
    {
        public int Rank { get; set; }
        public string GuildName { get; set; }
        public string GuildMessage { get; set; }
        public string MasterName { get; set; }
        public int Rating { get; set; }
        public int MemberCount { get; set; }
        public int MaxMemberCount { get; set; }
        public string UpdatedDate { get; set; }
    }
}