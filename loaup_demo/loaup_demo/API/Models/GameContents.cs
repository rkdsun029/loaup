using System.Collections.Generic;
// ----------------------------------------------------
// file : GameContents.cs
// description : 
// create : 2023-10-20
// update : 
// ----------------------------------------------------
namespace loaup_demo.API.Models
{
    public class ChallengeAbyssDungeon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinCharacterLevel { get; set; }
        public int MinItemLevel { get; set; }
        public string AreaName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Image { get; set; }
        public List<RewardItem> RewardItems { get; set; }
    }

    public class RewardItem
    { 
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Grade { get; set; }
        public List<string> StartTimes { get; set; }
    }

    public class ChallengeGuardianRaid
    { 
        public List<GuardianRaid> Raids { get; set; }
        public List<LevelRewardItems> RewardItems { get; set; }
    }

    public class GuardianRaid
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinCharacterLevel { get; set; }
        public int MinItemLevel { get; set; }
        public string RequiredClearRaid { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Image { get; set; }
    }

    public class LevelRewardItems
    { 
        public int ExpeditionItemLevel { get; set; }
        public List<RewardItem> Items { get; set; }
    }

    public class ContentsCalendar 
    { 
        public string CategoryName { get; set; }
        public int _type { get; set; } // Enum >> Constants.CalendarContentsType
        public string ContentsName { get; set; }
        public string ContentsIcon { get; set; }
        public int MinItemLevel { get; set; }
        public List<string> StartTimes { get; set; }
        public string Location { get; set; }
        public List<RewardItem> RewardItems { get; set; }
    }
}