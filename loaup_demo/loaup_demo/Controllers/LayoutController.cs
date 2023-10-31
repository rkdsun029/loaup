using loaup_demo.API;
using loaup_demo.API.Models;
using loaup_demo.Areas.Common.Model;
using loaup_demo.Common.CommonFunctions;
using loaup_demo.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
// ----------------------------------------------------
// fileName : Layoutontroller.cs
// description : 
// create : 2023-10-13
// update : 
// ----------------------------------------------------
namespace loaup_demo.Controllers
{
    [ChildActionOnly]
    public class LayoutController : Controller
    {
        public ActionResult Calendar()
        {
            APIManager apiManager = new APIManager();
            string requestParam = string.Empty;
            string response = string.Empty;

            TestModel testModel = new TestModel();

            response = apiManager.SendRequest("/gamecontents/calendar", "GET");
            List<ContentsCalendar> contentsList = JsonConvert.DeserializeObject<List<ContentsCalendar>>(response);


            string currentDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
            List<ContentsCalendar> todayList = new List<ContentsCalendar>();
            List<string> _todayCategoryList = new List<string>();

            Dictionary<string, List<ContentsCalendar>> dict = new Dictionary<string, List<ContentsCalendar>>();

            foreach (ContentsCalendar contents in contentsList)
            {
                int categoryIndex = _todayCategoryList.FindIndex(x => x.Equals(contents.CategoryName));

                if (-1 == categoryIndex && -1 != DataSheetUtil._calendarContentsTypeList.FindIndex(x => x._categoryName.Equals(contents.CategoryName)))
                {
                    _todayCategoryList.Add(contents.CategoryName);
                    dict.Add(contents.CategoryName, new List<ContentsCalendar>());
                }

                // 오늘 출현하는 섬인지 판별
                List<string> todayTimeList = new List<string>();

                foreach (string data in contents.StartTimes)
                {
                    string converted = CommonFunctions.ConvertTimeFormatString(data, "yyyy-MM-dd");

                    DateTime dateTime = DateTime.Now;
                    bool isValid = DateTime.TryParse(data, out dateTime);

                    if (true == isValid && true == converted.Equals(currentDateTimeString) && DateTime.Now.AddMinutes(-3) <= dateTime && dateTime < DateTime.Now.AddMinutes(30))
                    { 
                        todayTimeList.Add(data);
                    }
                }

                if (0 == todayTimeList.Count)
                {
                    continue;
                }

                contents.StartTimes = todayTimeList;
                todayList.Add(contents);

                dict[contents.CategoryName].Add(contents);

                int index = todayList.Count - 1;

                List<RewardItem> itemList = new List<RewardItem>();

                if (null != todayList[index].RewardItems)
                {
                    foreach (RewardItem item in todayList[index].RewardItems)
                    {
                        if (null == item.StartTimes)
                        {
                            itemList.Add(item);
                            continue;
                        }

                        List<string> timeList = new List<string>();

                        foreach (string data in item.StartTimes)
                        {
                            string converted = CommonFunctions.ConvertTimeFormatString(data, "yyyy-MM-dd");
                            if (true == converted.Equals(currentDateTimeString))
                            {
                                timeList.Add(data);
                            }
                        }

                        if (0 < timeList.Count)
                        {
                            item.StartTimes = timeList;
                            itemList.Add(item);
                        }
                    }
                }

                todayList[index].RewardItems = itemList;
            }

            testModel.contentsList = todayList;
            testModel.todayContents = dict;

            return View("_CalendarLayout", testModel);
        }

        public ActionResult Footer()
        {
            return View("_Footer");
        }
    }
}