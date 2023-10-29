using loaup_demo.API;
using loaup_demo.API.Models;
using loaup_demo.Areas.CharacterSearch.Model;
using loaup_demo.Areas.Common.Model;
using loaup_demo.Common.CommonFunctions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
// ----------------------------------------------------
// fileName : MainController.cs
// description : 캐릭터 검색관리
// create : 2023-10-12 
// update :
// ----------------------------------------------------
namespace loaup_demo.Areas.CharacterSearch
{
    public class MainController : Controller
    {
        public ActionResult Index(CharacterSearchParamModel model)
        {
            CharacterSearchResultModel resultModel = new CharacterSearchResultModel();
            APIManager apiManager = new APIManager();

            // 캐릭터명 형식 검증
            if (false == CommonFunctions.ValidateCharacterName(model._characterName))
            {
                return RedirectToAction("/NoResult");
            }

            string response = apiManager.SendRequest($"/armories/characters/{model._characterName}", "GET");
            CharacterInfo characterInfo = JsonConvert.DeserializeObject<CharacterInfo>(response);
            resultModel._characterInfo = characterInfo;




            response = apiManager.SendRequest($"/characters/{model._characterName}/siblings", "GET");
            List<SiblingCharacterInfo> siblingList = JsonConvert.DeserializeObject<List<SiblingCharacterInfo>>(response);
            resultModel._siblingList = siblingList;





            /*string test = resultModel._characterInfo.ArmoryEquipment[0].Tooltip;


            Dictionary<string, JObject> dict = new Dictionary<string, JObject>();
            dict = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(test);

            foreach (string key in dict.Keys)
            {
                JObject obj = dict[key];
            }*/


            /*XDocument xDocument = JsonConvert.DeserializeXNode(test, "Element");
            XDocument resultDoc = new XDocument();

            using (XmlReader reader = xDocument.CreateReader())
            {
                reader.MoveToContent();

                while (!reader.EOF)
                {
                    *//*XElement element = new XElement(reader.x);

                    if (true == string.IsNullOrEmpty(reader.Name))
                    {
                        reader.MoveToElement();
                        continue;
                    }

                    if (reader.ValueType == typeof(XElement) && false == string.IsNullOrEmpty(reader.Value))
                    {
                        resultDoc.Add(reader.Value);
                    }*//*

                    string innerXML = reader.ReadInnerXml();

                    if (string.IsNullOrEmpty(innerXML))
                    {
                        reader.MoveToElement();
                        continue;
                    }


                }
            }*/


            return View(resultModel);
        }

        public ActionResult NoResult()
        {
            return View();
        }
    }
}