using loaup_demo.API;
using loaup_demo.API.Models;
using loaup_demo.Areas.Common.Model;
using Newtonsoft.Json;
using System.Web.Mvc;
// ----------------------------------------------------
// fileName : MainController.cs
// description : 거래소
// create : 2023-10-24
// update :
// ----------------------------------------------------
namespace loaup_demo.Areas.Market
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            APIManager apiManager = new APIManager();
            RequestMarketItems requestMarketItems = null;
            string requestParam = string.Empty;
            string response = string.Empty;

            TestModel testModel = new TestModel();

            // 융화재료
            requestMarketItems = new RequestMarketItems(50010, "오레하 융화 재료");
            requestParam = JsonConvert.SerializeObject(requestMarketItems);
            response = apiManager.SendRequest("/markets/items", "POST", requestParam);
            MarketList marketList1 = JsonConvert.DeserializeObject<MarketList>(response);

            // 돌파석
            requestMarketItems = new RequestMarketItems(50010, "명예의 돌파석");
            requestParam = JsonConvert.SerializeObject(requestMarketItems);
            response = apiManager.SendRequest("/markets/items", "POST", requestParam);
            MarketList marketList2 = JsonConvert.DeserializeObject<MarketList>(response);

            // 보조재료
            requestMarketItems = new RequestMarketItems(50020, "태양의");
            requestParam = JsonConvert.SerializeObject(requestMarketItems);
            response = apiManager.SendRequest("/markets/items", "POST", requestParam);
            MarketList marketList3 = JsonConvert.DeserializeObject<MarketList>(response);

            // 보조재료
            requestMarketItems = new RequestMarketItems(50010, "명예의 파편 주머니");
            requestParam = JsonConvert.SerializeObject(requestMarketItems);
            response = apiManager.SendRequest("/markets/items", "POST", requestParam);
            MarketList marketList4 = JsonConvert.DeserializeObject<MarketList>(response);


            testModel.marketList1 = marketList1;
            testModel.marketList2 = marketList2;
            testModel.marketList3 = marketList3;
            testModel.marketList4 = marketList4;

            return View(testModel);
        }
    }
}