using loaup_demo.Areas.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
// ----------------------------------------------------
// fileName : CommonFunctions.cs
// description : 공용 함수모음 (재활용가능 로직만)
// create : 2023-10-13
// update : 2023-10-13, 강선영, 내용예시
// ----------------------------------------------------
namespace loaup_demo.Common.CommonFunctions
{
    public class CommonFunctions
    {
        // 캐릭터명 형식 검사
        public static bool ValidateCharacterName(string characterName)
        {
            characterName = characterName.Trim();

            if (true == string.IsNullOrWhiteSpace(characterName))
            {
                return false;
            }

            return true;
        }

        // 엑셀 데이터시트 파일 확장자 검사
        public static bool ValidateDataSheetExtension(string extension)
        {
            bool result = false;
            string[] _availableExtensionArr = { ".XLS", ".XLSX", ".CSV", "TXT" };

            if (true == _availableExtensionArr.Contains(extension.ToUpper()))
            {
                return true;
            }

            return result;
        }

        public static List<MenuInfo> GetMainMenuList()
        {
            List<MenuInfo> result = new List<MenuInfo>();


            return result;
        }

        public static string ConvertTimeFormatString(string timeString, string format = "")
        {
            string result = string.Empty;
            DateTime dateTime = DateTime.Now;
            bool isValid = DateTime.TryParse(timeString, out dateTime);

            if (false == isValid)
            {
                // 오류메시지
                return "-";
            }

            if (true == string.IsNullOrEmpty(format))
            { 
                result = dateTime.ToString("MM'/'dd HH:mm");
            }
            else
            {
                result = dateTime.ToString(format);
            }

            return result;
        }

        // 아이템 등급 숫자로 변환 (Enum >> Constants.ItemGrade)
        public static int ConvertGradeToInt(string grade)
        {
            int result = 0;

            if (true == string.IsNullOrEmpty(grade))
            {
                return 0;
            }

            result = (int) Enum.Parse(typeof(Constants.ItemGrade), grade);

            return result;
        }
    }
}