using System.Web.Mvc;
// ----------------------------------------------------
// fileName : MainController.cs
// description : 경매장
// create : 2023-10-24
// update :
// ----------------------------------------------------
namespace loaup_demo.Areas.Auction
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}