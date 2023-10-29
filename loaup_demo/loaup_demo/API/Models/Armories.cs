using System.Collections.Generic;
// ----------------------------------------------------
// file : Armories.cs
// description : 
// create : 2023-10-20
// update : 
// ----------------------------------------------------
namespace loaup_demo.API.Models
{
    public class CharacterInfo
    { 
        public ArmoryProfile ArmoryProfile { get; set; }
        public List<ArmoryEquipment> ArmoryEquipment { get; set; }
        public List<ArmoryAvatar> ArmoryAvatars { get; set; }
        public List<ArmorySkill> ArmorySkills { get; set; }
        public ArmoryEngraving ArmoryEngraving { get; set; }
        public ArmoryCard ArmoryCard { get; set; }
        public ArmoryGem ArmoryGem { get; set; }
        public ColosseumInfo ColosseumInfo { get; set; }
        public List<Collectible> Collectibles { get; set; }
    }

    public class ArmoryProfile
    { 
        public string CharacterImage { get; set; }
        public int ExpeditionLevel { get; set; }
        public string PvpGradeName { get; set; }
        public int? TownLevel { get; set; }
        public string TownName { get; set; }
        public string Title { get; set; }
        public string GuildMemberGrade { get; set; }
        public string GuildName { get; set; }
        public int UsingSkillPoint { get; set; }
        public int TotalSkillPoint { get; set; }
        public List<Stat> Stats { get; set; } 
        public List<Tendency> Tendencies { get; set; }
        public string ServerName { get; set; }
        public string CharacterName { get; set; }
        public int CharacterLevel { get; set; }
        public string CharacterClassName { get; set; }
        public string ItemAvgLevel { get; set; }
        public string ItemMaxLevel { get; set; }
    }

    public class Stat
    { 
        public string Type { get; set; }
        public string Value { get; set; }
        public List<string> Tooltip { get; set; }
    }

    public class Tendency
    { 
        public string Type { get; set; }
        public int Point { get; set; }
        public int MaxPoint { get; set; }
    }

    public class ArmoryEquipment
    { 
        public string Type { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Grade { get; set; }
        public string Tooltip { get; set; }
    }

    public class ArmoryAvatar
    { 
        public string Type { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Grade { get; set; }
        public bool IsSet { get; set; }
        public bool IsInner { get; set; }
        public string Tooltip { get; set; }
    }

    public class ArmorySkill
    { 
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Level { get; set; }
        public string Type { get; set; } // 일반, 지점, 홀딩, 차지 ...
        public bool IsAwakening { get; set; } // 각성기
        public List<SkillTripod> Tripods { get; set; }
        public SkillRune Rune { get; set; }
        public string Tooltip { get; set; }
    }

    public class SkillTripod
    { 
        public int Tier { get; set; }
        public int Slot { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Level { get; set; }
        public bool IsSelected { get; set; }
        public string Tooltip { get; set; }
    }

    public class SkillRune
    { 
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Grade { get; set; }
        public string Tooltip { get; set; }
    }

    public class ArmoryEngraving
    { 
        public List<Engraving> Engravings { get; set; }
        public List<EngravingEffect> Effects { get; set; }
    }

    // 장착 각인
    public class Engraving 
    { 
        public int Slot { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Tooltip { get; set; }
    }

    // 총 활성 각인
    public class EngravingEffect
    { 
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ArmoryCard
    { 
        public List<Card> Cards { get; set; }
        public List<CardEffect> Effects { get; set; }
    }

    public class Card
    {
        public int Slot { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int AwakeCount { get; set; }
        public int AwakeTotal { get; set; }
        public string Grade { get; set; }
        public string Tooltip { get; set; }
    }

    public class CardEffect
    { 
        public int Index { get; set; }
        public List<int> CardSlots { get; set; }
        public List<Effect> Items { get; set; }
    }

    public class Effect
    { 
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ArmoryGem
    { 
        public List<Gem> Gems { get; set; }
        public List<GemEffect> Effects { get; set; }
    }

    public class Gem
    {
        public int Slot { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Level { get; set; }
        public string Grade { get; set; }
        public string Tooltip { get; set; }
    }

    public class GemEffect
    { 
        public int GemSlot { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Tooltip { get; set; }
    }

    public class ColosseumInfo
    { 
        public int Rank { get; set; }
        public int PreRank { get; set; }
        public int Exp { get; set; }
        public List<Colosseum> Colosseums { get; set; }
    }

    public class Colosseum
    {
        public string SeasonName { get; set; }
        public AggregationTeamDeathMatchRank Competitive { get; set; }
        public Aggregation TeamDeathMatch { get; set; }
        public Aggregation DeathMatch { get; set; }
        public AggregationElimination TeamElimination { get; set; }
        public Aggregation CoOpBattle { get; set; }
    }

    public class AggregationTeamDeathMatchRank
    {
        public int Rank { get; set; }
        public string RankName { get; set; }
        public string RankIcon { get; set; }
        public int RankLastMmr { get; set; }
        public int PlayCount { get; set; }
        public int VictoryCount { get; set; }
        public int LoseCount { get; set; }
        public int TieCount { get; set; }
        public int KillCount { get; set; }
        public int AceCount { get; set; }
        public int DeathCount { get; set; }
    }

    public class Aggregation
    {
        public int PlayCount { get; set; }
        public int VictoryCount { get; set; }
        public int LoseCount { get; set; }
        public int TieCount { get; set; }
        public int KillCount { get; set; }
        public int AceCount { get; set; }
        public int DeathCount { get; set; }
    }

    public class AggregationElimination
    {
        public int FirstWinCount {get; set;}
        public int SecondWinCount {get; set;}
        public int ThirdWinCount {get; set;}
        public int FirstPlayCount{get; set;}
        public int SecondPlayCount{get; set;}
        public int ThirdPlayCount{get; set;}
        public int AllKillcount{get; set;}
        public int PlayCount{get; set;}
        public int VictoryCount{get; set;}
        public int LoseCount{get; set;}
        public int TieCount{get; set;}
        public int KillCount{get; set;}
        public int AceCount{get; set;}
        public int DeathCount{get; set;}
    }


    public class Collectible
    { 
        public string Type { get; set; }
        public string Icon { get; set; }
        public int Point { get; set; }
        public int MaxPoint { get; set; }
        public List<CollectiblePoint> CollectiblePoints { get; set; }
    }

    public class CollectiblePoint
    { 
        public string PointName { get; set; }
        public int Point { get; set; }
        public int MaxPoint { get; set; }
    }




    public class ToolTip
    { 
        public string type { get; set; }
        public string value { get; set; }
    }
}