using Dapper;
using loaup_demo.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
// ----------------------------------------------------
// fileName : LoaupCommonModel.cs
// description : 로아업 공용모델
// create : 2023-10-13
// update : 
// ----------------------------------------------------
namespace loaup_demo.Areas.Common.Model
{
    public class CommonResult
    { 
        public int _resultCode { get; set; }
        public string _resultMsg { get; set; }

        public CommonResult()
        {
            _resultCode = 0;
            _resultMsg = string.Empty;
        }
    }

    public class OutputParameter<T>
    {
        public int _resultCode { get; set; }
        public string _resultMsg { get; set; }
        public int _totalCount { get; set; }

        public List<T> _resultList { get; set; }


        public OutputParameter()
        {
            _resultCode = 0;
            _resultMsg  = string.Empty;
            _totalCount = 0;

            _resultList = new List<T>();
        }
    }

    public class TableValuedParameters
    { 
        public DataTable _dataTable { get; set; }

        public TableValuedParameters()
        { 
        
        }
    }

    public class PagingInfo
    { 
        public int _pageNo { get; set; }
        public int _pageSize { get; set; }
        public int _totalCount { get; set; }
        public int _maxPageNo { get; set; }

        public PagingInfo()
        {
            _pageNo     = 1;
            _pageSize   = 10;
            _totalCount = 0;
            _maxPageNo  = 1;
        }
    }

    public class MenuInfo
    {
        public int _menuId { get; set; }
        public int _parentMenuId { get; set; }
        public string _menuKey { get; set; }
        public string _menuName { get; set; }
        public string _path { get; set; }
        public bool _isUse { get; set; }

        public MenuInfo()
        {
            _isUse = true;
        }
    }

    public class LostarkServerInfo
    {
        public int _serverId { get; set; }
        public string _serverName { get; set; }
    }

    public class CalendarContentsType 
    { 
        public string _categoryName { get; set; }
        public bool _isCommon { get; set; } // 전 위치 출현시간이 다똑같은지 : 카게, 필보
    }






    public class TestModel
    {
        public MarketList marketList1 { get; set; }
        public MarketList marketList2 { get; set; }
        public MarketList marketList3 { get; set; }
        public MarketList marketList4 { get; set; }

        public List<Notice> noticeList { get; set; }
        public List<Event> eventList { get; set; }

        public List<ChallengeAbyssDungeon> abyssDungeonList { get; set; }
        public ChallengeGuardianRaid guardianRaid { get; set; }
        public List<ContentsCalendar> contentsList { get; set; }


        public Dictionary<string, List<ContentsCalendar>> todayContents { get; set; }

        public TestModel()
        {
            marketList1 = new MarketList();
            marketList2 = new MarketList();
            marketList3 = new MarketList();
            marketList4 = new MarketList();

            noticeList = new List<Notice>();
            eventList = new List<Event>();

            abyssDungeonList = new List<ChallengeAbyssDungeon>();
            guardianRaid = new ChallengeGuardianRaid();
            contentsList = new List<ContentsCalendar>();

            todayContents = new Dictionary<string, List<ContentsCalendar>>();
        }
    }

}