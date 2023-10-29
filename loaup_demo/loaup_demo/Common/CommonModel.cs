// ----------------------------------------------------
// fileName : CommonModel.cs
// description : 인게임 정보 공용모델
// create : 2023-10-13
// update : 
// ----------------------------------------------------
namespace loaup_demo.Areas.Common.Model
{
    // 아이템 정보 공용모델
    public class CommonItem
    {
        public string _type { get; set; }
        public string _name { get; set; }
        public string _icon { get; set; }
        public string _grade { get; set; }
        public string _tooltip { get; set; }
    }
}