// ----------------------------------------------------
// fileName : Constatns.cs
// description : 공용상수 모음 (최대한 피치못할 경우에만 작성, 사용지양)
// create : 2023-10-11
// update :
// ----------------------------------------------------
using System.Collections.Generic;

namespace loaup_demo.Areas.Common.Model
{
    public static class Constants
    {
        public static string[] CollectibleTypeArr = 
        {
            "모코코 씨앗", 
            "섬의 마음", 
            "위대한 미술품", 
            "거인의 심장", 
            "이그네아의 징표", 
            "항해 모험물", 
            "세계수의 잎", 
            "오르페우스의 별", 
            "기억의 오르골" 
        };

        public static string[] CalendarContentsTypeArr = 
        { 
            "로웬", 
            "모험 섬", 
            "섬", 
            "카오스게이트",
            "태초의 섬", 
            "필드보스", 
            "항해"
        };


        public enum MenuKey
        { 
            NEWS            = 1,
            CLASSCATEGORY   = 2,
            MARKETAUCTION   = 3,
            SPECSUPHELPER   = 4,
            GUILD           = 5,
            WANTED          = 6,
            DICTIONARY      = 7,
            PLAYGROUND      = 8
        }

        public enum ItemGrade
        { 
            일반 = 0,
            고급 = 1,
            희귀 = 2,
            영웅 = 3,
            전설 = 4,
            유물 = 5,
            고대 = 6,
            에스더 = 7,
            미공개 = 8
        }

        public enum CalendarContentsType
        { 
            CALENDAR_UNKNOWN = 0,   // 알수없음
            CALENDAR_1 = 1,         // 로웬
            CALENDAR_2 = 2,         // 모험 섬
            CALENDAR_3 = 3,         // 섬
            CALENDAR_4 = 4,         // 카오스게이트
            CALENDAR_5 = 5,         // 태초의 섬
            CALENDAR_6 = 6,         // 필드보스
            CALENDAR_7 = 7          // 항해
        }
    }
}