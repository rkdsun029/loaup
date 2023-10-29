using loaup_demo.API.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// ----------------------------------------------------
// fileName : CharacterSearch.cs
// description : 
// updateDate : 2023-10-10
// ----------------------------------------------------
namespace loaup_demo.Areas.CharacterSearch.Model
{
    public class CharacterSearchParamModel
    {
        [Required]
        public string _characterName { get; set; }
    }

    public class CharacterSearchResultModel
    {
        public CharacterInfo _characterInfo { get; set; }

        public List<SiblingCharacterInfo> _siblingList { get; set; }

        public CharacterSearchResultModel()
        {
            _characterInfo = new CharacterInfo();
            _siblingList = new List<SiblingCharacterInfo>();
        }
    }
}