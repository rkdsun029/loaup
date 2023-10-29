using System.Collections.Generic;
// ----------------------------------------------------
// file : Markets.cs
// description : 
// create : 2023-10-20
// update : 
// ----------------------------------------------------
namespace loaup_demo.API.Models
{
    public class MarketOption 
    {
        public Category Categories { get; set; }
        public string ItemGrades { get; set; }
        public int ItemTiers { get; set; }
        public string Classes { get; set; } 
    }

    public class Category
    { 
        public List<CategoryItem> Subs { get; set; }
        public int Code { get; set; }
        public string CodeName { get; set; }
    }
    
    public class CategoryItem
    { 
        public int Code { get; set; }
        public string CodeName { get; set; }
    }

    public class MarketItemStats
    { 
        public string Name { get; set; }
        public int? TradeRemainCount { get; set; }
        public int BundleCount { get; set; }
        public List<MarketStatsInfo> Stats { get; set; }
        public string ToolTip { get; set; }
    }

    public class MarketStatsInfo
    { 
        public string Date { get; set; }
        public double AvgPrice { get; set; }
        public int TradeCount { get; set; }
    }

    public class RequestMarketItems
    { 
        public string Sort { get; set; }
        public int CategoryCode { get; set; }
        public string CharacterClass { get; set; }
        public int? ItemTier { get; set; }
        public string ItemGrade { get; set; }
        public string ItemName { get; set; }
        public int PageNo { get; set; }
        public string SortCondition { get; set; }

        public RequestMarketItems()
        { 
        
        }

        public RequestMarketItems(int categoryCode, string itemName)
        {
            Sort = "CURRENT_MIN_PRICE";
            CategoryCode = categoryCode;
            CharacterClass = "";
            ItemTier = null;
            ItemGrade = "";
            ItemName = itemName;
            PageNo = 1;
            SortCondition = "DESC";
        }
    }

    /*
    public enum Sort
    { 
        GRADE,
        YDAY_AVG_PRICE,
        RECENT_PRICE,
        CURRENT_MIN_PRICE
    }
    */

    /*
    public enum SortCondition
    { 
        ASC,
        DESC
    }
    */

    public class MarketList
    { 
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<MarketItem> Items { get; set; }
    }

    public class MarketItem
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Icon { get; set; }
        public int BundleCount { get; set; }
        public int? TradeRemainCount { get; set; }
        public double YDayAvgPrice { get; set; }
        public int RecentPrice { get; set; }
        public int CurrentMinPrice { get; set; }
    }
}