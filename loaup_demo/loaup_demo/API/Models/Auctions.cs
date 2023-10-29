// ----------------------------------------------------
// file : Auctions.cs
// description : 
// create : 2023-10-20
// update : 
// ----------------------------------------------------
using System.Collections.Generic;

namespace loaup_demo.API.Models
{
    public class AuctionOption
    { 
        public int MaxItemLevel { get; set; }
        public List<int> ItemGradeQualities { get; set; }
        public List<SkillOption> SkillOptions { get; set; }
        public List<EtcOption> EtcOptions { get; set; }
        public List<Category> Categories { get; set; }
        public List<string> ItemGrades { get; set; }
        public List<int> ItemTiers { get; set; }
        public List<string> Classes { get; set; }
    }

    public class SkillOption
    {
        public int Value { get; set; }
        public string Class { get; set; }
        public string Text { get; set; }
        public bool IsSkillGroup { get; set; }
        public List<Tripod> Tripods { get; set; }
    }

    public class Tripod
    { 
        public int Value { get; set; }
        public string Text { get; set; }
        public bool IsGem { get; set; }
    }

    public class EtcOption
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public List<EtcSub> EtcSubs { get; set; }
    }

    public class EtcSub
    { 
        public int Value { get; set; }
        public string Text { get; set; }
        public string Class { get; set; }
    }

    public class RequestAuctionItems
    {
        public int ItemLevelMin { get; set; }
        public int ItemLevelMax { get; set; }
        public int? ItemGradeQuality { get; set; }
        public List<SearchDetailOption> SkillOptions { get; set; }
        public List<SearchDetailOption> EtcOptions { get; set; }
        public string Sort { get; set; }
        public int CategoryCode { get; set; }
        public string CharacterClass { get; set; }
        public int? ItemTier { get; set; }
        public string ItemGrade { get; set; }
        public string ItemName { get; set; }
        public int PageNo { get; set; }
        public string SortCondition { get; set; } // ASC, DESC
    }

    /*
    public Enum Sort 
    {
        BIDSTART_PRICE, BUY_PRICE, EXPIREDATE, ITEM_GRADE, ITEM_LEVEL, ITEM_QUALITY
    } 
    */

    public class SearchDetailOption
    { 
        public int? FirstOption { get; set; }
        public int? SecondOption { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
    }

    public class Auction
    { 
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<AuctionItem> Items { get; set; }
    }

    public class AuctionItem
    {
        public string Name { get; set; }
        public string Grade { get; set; }
        public int Tier { get; set; }
        public int? Level { get; set; }
        public string Icon { get; set; }
        public int? GradeQuality { get; set; }
        public AuctionInfo AuctionInfo { get; set; }
        public List<ItemOption> Options { get; set; }
    }

    public class AuctionInfo
    { 
        public int StartPrice { get; set; }
        public int? BuyPrice { get; set; }
        public int Bidprice { get; set; }
        public string EndDate { get; set; }
        public int BidCount { get; set; }
        public int BidStartPrice { get; set; }
        public bool IsCompetitive { get; set; }
        public int TradeAllowCount { get; set; }
    }

    public class ItemOption
    { 
        public string Type { get; set; }
        public string OptionName { get; set; }
        public string OptionNameTripod { get; set; }
        public int Value { get; set; }
        public bool isPenalty { get; set; }
        public string ClassName { get; set; }
    }

    /*
    public enum Type
    {
        None, 
        SKILL, 
        STAT, 
        ABILITY_ENGRAVE, 
        BRACELET_SPECIAL_EFFECTS, 
        GEM_SKILL_COOLDOWN_REDUCTION, 
        GEM_SKILL_COOLDOWN_REDUCTION_IDENTITY, 
        GEM_SKILL_DAMAGE, 
        GEM_SKILL_DAMAGE_IDENTITY, 
        BRACELET_RANDOM_SLOT
    }
    */
}