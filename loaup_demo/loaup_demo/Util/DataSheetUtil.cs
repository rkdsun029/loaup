using ExcelDataReader;
using loaup_demo.Areas.Common.Model;
using loaup_demo.Common.CommonFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
// ----------------------------------------------------
// fileName : DataSheetUtil.cs
// description : 엑셀로 관리하는 데이터 읽어오기
// create : 2023-10-13
// update : 
// ----------------------------------------------------
namespace loaup_demo.Util
{
    public class DataSheetUtil
    {
        private static readonly string ROOT_PATH = @"E:/repository/trunk/loaup_demo/loaup_demo/DataSheet";

        private static readonly string MENU_MANAGEMENT  = ROOT_PATH + @"/MenuManagement.xlsx";
        private static readonly string SERVER_INFO      = ROOT_PATH + @"/ServerInfo.xlsx";
        private static readonly string CONTENTS_MANAGER = ROOT_PATH + @"/ContentsManager.xlsx";

        public static List<MenuInfo> _menuList { get; set; }
        public static List<LostarkServerInfo> _serverList { get; set; }

        public static List<CalendarContentsType> _calendarContentsTypeList { get; set; }
        public static List<string> _collectibleTypeList { get; set; } 

        public void LoadData()
        {
            List<SheetInfo> _menuInfoList       = LoadMenuInfo();
            List<SheetInfo> _serverInfoList     = LoadServerInfo();
            List<SheetInfo> _contentsInfoList   = LoadContentsInfo();

            _menuList = new List<MenuInfo>();
            _serverList = new List<LostarkServerInfo>();

            _calendarContentsTypeList = new List<CalendarContentsType>();
            _collectibleTypeList = new List<string>();

            MenuInfo menuInfo = new MenuInfo();
            LostarkServerInfo serverInfo = new LostarkServerInfo();

            foreach (SheetInfo sheet in _menuInfoList)
            {
                if (true == "Top".Equals(sheet._sheetName))
                { 
                    for (int ii = 0; ii < sheet._originalDataTable.Rows.Count; ++ii)
                    {
                        DataRow dataRow = sheet._originalDataTable.Rows[ii];

                        menuInfo = new MenuInfo();

                        menuInfo._menuId        = Convert.ToInt32(dataRow["_menuId"]);
                        menuInfo._parentMenuId  = Convert.ToInt32(dataRow["_parentMenuId"]);
                        menuInfo._menuKey       = dataRow["_menuKey"].ToString();
                        menuInfo._menuName      = dataRow["_menuName"].ToString();
                        menuInfo._path          = dataRow["_path"].ToString();
                        menuInfo._isUse         = Convert.ToBoolean(dataRow["_isUse"]);

                        _menuList.Add(menuInfo);
                    }
                }
            }

            foreach (SheetInfo sheet in _serverInfoList)
            {
                if (true == "Server".Equals(sheet._sheetName))
                { 
                    for (int ii = 0; ii < sheet._originalDataTable.Rows.Count; ++ii)
                    {
                        DataRow dataRow = sheet._originalDataTable.Rows[ii];

                        serverInfo = new LostarkServerInfo();

                        serverInfo._serverId = Convert.ToInt32(dataRow["_serverId"]);
                        serverInfo._serverName = dataRow["_serverName"].ToString();

                        _serverList.Add(serverInfo);
                    }
                }
            }

            foreach (SheetInfo sheet in _contentsInfoList)
            {
                if (true == "calendar".Equals(sheet._sheetName))
                {
                    foreach (DataRow row in sheet._originalDataTable.Rows)
                    {
                        if (null != row["_contentsType"] && false == string.IsNullOrEmpty(row["_contentsType"].ToString()))
                        {
                            CalendarContentsType type = new CalendarContentsType();
                            type._categoryName = row["_contentsType"].ToString();
                            type._isCommon = Convert.ToBoolean(row["_isCommon"]);
                            _calendarContentsTypeList.Add(type);
                        }
                    }
                }
                else if (true == "collectible".Equals(sheet._sheetName))
                {
                    foreach (DataRow row in sheet._originalDataTable.Rows)
                    {
                        if (null != row["_contentsType"] && false == string.IsNullOrEmpty(row["_contentsType"].ToString()))
                        {
                            _collectibleTypeList.Add(row["_contentsType"].ToString());
                        }
                    }
                }
            }

            //END
        }

        public class SheetInfo
        { 
            public string _sheetName { get; set; }
            public int _rowCount { get; set; }
            public int _colCount { get; set; }
            public List<string> _columnList { get; set; }

            public DataTable _originalDataTable { get; set; }

            public SheetInfo()
            {
                _columnList = new List<string>();
                _originalDataTable = new DataTable();
            }
        }

        private List<SheetInfo> ReadDataSheet(string filePath)
        {
            List<SheetInfo> sheetList = null;
            SheetInfo sheetInfo = null;

            sheetList = new List<SheetInfo>();

            string extension = string.Empty;
            DataTableCollection dataTableCollection = null;

            FileStream stream = null;
            IExcelDataReader excelDataReader = null;
            DataSet resultDataSet = null;

            extension = Path.GetExtension(filePath).ToUpper();

            if (false == CommonFunctions.ValidateDataSheetExtension(extension))
            {
                // invalidExtension 로깅
                // return;
            }
            
            stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            if (".XLS".Equals(extension) || ".XLSX".Equals(extension))
            {
                excelDataReader = ExcelReaderFactory.CreateReader(stream);
            }
            else if (".CSV".Equals(extension) || ".TXT".Equals(extension))
            {
                excelDataReader = ExcelReaderFactory.CreateCsvReader(stream);
            }

            resultDataSet = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    EmptyColumnNamePrefix = "Column",
                    UseHeaderRow = true
                }
            });

            dataTableCollection = resultDataSet.Tables;

            foreach (DataTable dataTable in dataTableCollection)
            {
                sheetInfo = new SheetInfo();

                sheetInfo._originalDataTable = dataTable;

                sheetInfo._sheetName = dataTable.TableName;
                sheetInfo._rowCount = dataTable.Rows.Count;
                sheetInfo._colCount = dataTable.Columns.Count;

                for (int ii = 0; ii < sheetInfo._colCount; ++ii)
                {
                    sheetInfo._columnList.Add(dataTable.Rows[0][ii].ToString());
                }

                sheetList.Add(sheetInfo);
            }

            stream.Close();

            return sheetList;
        }

        private List<SheetInfo> LoadMenuInfo()
        {
            List<SheetInfo> sheetList = new List<SheetInfo>();
            sheetList = ReadDataSheet(MENU_MANAGEMENT);

            return sheetList;
        }

        private List<SheetInfo> LoadServerInfo()
        {
            List<SheetInfo> sheetList = new List<SheetInfo>();
            sheetList = ReadDataSheet(SERVER_INFO);

            return sheetList;
        }
        private List<SheetInfo> LoadContentsInfo()
        {
            List<SheetInfo> sheetList = new List<SheetInfo>();
            sheetList = ReadDataSheet(CONTENTS_MANAGER);

            return sheetList;
        }
    }
}