using System.ComponentModel.DataAnnotations;
// ----------------------------------------------------
// fileName : SpecsUpHelper.cs
// description : 
// updateDate : 2023-10-20
// ----------------------------------------------------
namespace loaup_demo.Areas.SpecsUpHelper.Model
{
    public class RunApiModeParamModel // _isApiMode를 받아서 api모드가 true일 경우만 개인 api 키쓰는걸로
    {
        [Required]
        public string _userApiKey { get; set; }
    }
}