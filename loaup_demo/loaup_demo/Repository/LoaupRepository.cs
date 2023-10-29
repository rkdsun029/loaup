using Dapper;
using loaup_demo.Areas.Common.Model;
using loaup_demo.Repository.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
// ----------------------------------------------------
// fileName : LoaupRepository.cs
// description : 로아업용 (실제 인게임 정보랑 무관한거만)
// create : 2023-10-16
// update : 
// ----------------------------------------------------
namespace loaup_demo.Repository
{
    public class LoaupRepository : BaseRepository, IDisposable
    {
        private readonly string _connectionString;
        private readonly DapperContext _context;
        private readonly SqlConnection _connection;

        /*public LoaupRepository(DapperContext context)
        {
            _context = context;
        }*/

        public LoaupRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CONNECTION_LOAUP"].ToString();

            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public void Dispose()
        {
            if (null != _connection)
            { 
                _connection.Dispose();
            }

            //throw new NotImplementedException();
        }

        //LoaupRepository

        public CommonResult GetMenuInfoList(int id, string name)
        {
            CommonResult result = new CommonResult();

            DynamicParameters param = new DynamicParameters();
            OutputParameter<GetMenuInfoListDataModel> outputParameter = new OutputParameter<GetMenuInfoListDataModel>();

            using (SqlConnection conn = new SqlConnection())
            { 
                param.Add("id", id, DbType.Int32, direction: ParameterDirection.Input);

                param.Add("totalCount", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                param.Add("resultCode", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                param.Add("resultMsg", string.Empty, DbType.String, direction: ParameterDirection.InputOutput);

                result._resultCode = conn.Execute("LoaupPublic.InsertMenuInfoProc", param, null, null, CommandType.StoredProcedure);

                outputParameter._resultList = conn.Query<GetMenuInfoListDataModel>("LoaupPublic.GetMenuInfoList", param, null, true, null, CommandType.StoredProcedure).ToList();

                result._resultCode = param.Get<Int32>("resultCode");


            }

            return result;
        }
    }
}