// LOSTARK OPENAPI TOKEN
var _prefix = "bearer";
var _apiKey  = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAzMzQ4NTMifQ.noKOdsu-O4cZdPC5We5nSK_zsL_-BD4TQ6543cddlZc40YjAkljKmN8fz5j7g5WJRF-LOazvPlI_S4J9xG-0xn80tzYdKnC66V4NlEQHF9XC7JPpc340hFlFvV0Kc2bAchh5IIGrlfjjgMfqj4yWLRYh8FB1yy3TDjGFdW3VSr223GzivDcmDTf0CYARTfL0xzDBVf-dNHOO0n2V_ytS1tECieQrLb4bqsRH4HOb1Nwa8y6FgnOCwt4T6ZuiLNtuhXOfzdoq-HyUCERTIRSoasSvU4_dCND0qA_wGms3NYlrSfO4om2ZchM9wkmS1v5gR1JEGfNvS7c0VNj-p9kqPA";

var _token = _prefix + " " + _apiKey;

// URL
var _path   = "https://developer-lostark.game.onstove.com";

var _subPath = [
    {
        "Name" : "markets",
        "Subs" : ["options", "items"]
    },
    {
        "Name" : "gamecontents",
        "Subs" : []
    },
    {
        "Name" : "guilds",
        "Subs" : []
    },
    {
        "Name" : "auctions",
        "Subs" : []
    },
    {
        "Name" : "armories",
        "Subs" : []
    },
    {
        "Name" : "characters",
        "Subs" : []
    },
    {
        "Name" : "news",
        "Subs" : ["notice", "event"]
    }
];

var _defaultSendData = 
{
    "Sort": "CURRENT_MIN_PRICE",	// ENUM STRING [GRADE 등급, YDAY_AVG_PRICE 최근14일평균판매가, RECENT_PRICE 최근거래가, CURRENT_MIN_PRICE 현재거래소최저가]
    "CategoryCode": 60000,   		// int
    "CharacterClass": "",     		// string
    "ItemTier": null,         		// nullable int
    "ItemGrade": "",          		// string
    "ItemName": "",           		// string
    "PageNo": 0,              		// int
    "SortCondition": "ASC"    		// ENUM STRING [ASC, DESC]
}

var _sortType = ["GRADE", "YDAY_AVG_PRICE", "RECENT_PRICE", "CURRENT_MIN_PRICE"]
var _sortCondition = ["ASC", "DESC"];

var _baseData = null;

var _categories = [];
var _classes = [];
var _itemGrades = [];
var _itemTiers = [];

var _minValue = 40000;
var _maxValue = 110000;

/*
    40000 : 각인서
    50000 : 강화재료
    60000 : 배템
    70000 : 요리
    90000 : 생활
    100000 : 모험의서
    110000 : 항해
*/


// 거래소 데이터 검색 파라미터모델
function getDefaultSendData()
{
	var _defaultSendData = 
	{
		"Sort": _sortType[3],
		"CategoryCode": 0,
		"CharacterClass": "",
		"ItemTier": null,
		"ItemGrade": "",
		"ItemName": "",
		"PageNo": 1,
		"SortCondition": _sortCondition[1]
	};

	return _defaultSendData;
}

// 아이템 개당단가
var _unitPrice1 = 14 / 3; // 희귀
var _unitPrice2 = 28 / 3; // 영웅

var _unitPrice3 = 14 / 2; // 빛나는 희귀
var _unitPrice4 = 28 / 2; // 빛나는 영웅





/*
--------------------------------------------------------
news

/news/notices (홈페이지 공지?)
/news/events (인게임 이벤트창)
--------------------------------------------------------
characters

/characters/{characterName}/siblings
--------------------------------------------------------
armories

/armories/characters/{characterName}/
/armories/characters/{characterName}/profiles
/armories/characters/{characterName}/equipment
/armories/characters/{characterName}/avatars
/armories/characters/{characterName}/combat-skills
/armories/characters/{characterName}/engravings
/armories/characters/{characterName}/cards
/armories/characters/{characterName}/gems
/armories/characters/{characterName}/colosseums
/armories/characters/{characterName}/collectibles 내실?
--------------------------------------------------------
auctions

/auctions/options
/auctions/items
--------------------------------------------------------
guilds 

/guilds/rankings
--------------------------------------------------------
markets

/markets/options
/markets/items
/markets/items/{itemId}
--------------------------------------------------------
gamecontents

/gamecontents/challenge-abyss-dungeons (도비스)
/gamecontents/challenge-guardian-raids (도레)
/gamecontents/calendar (캘린더 일정)
--------------------------------------------------------
*/