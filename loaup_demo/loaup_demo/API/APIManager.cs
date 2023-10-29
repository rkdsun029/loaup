using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
// ----------------------------------------------------
// fileName : APIManager.cs
// description : Lostark 공식 API 요청 관리
// create : 2023-10-12
// update :
// ----------------------------------------------------
namespace loaup_demo.API
{
    public class APIKeyInfo
    {
        public string _token { get; set; }
        public int _currentRequestCount { get; set; }
    }

    public class APICommonResult
    {
        public int _resultCode { get; set; }
        public string _resultMsg { get; set; }
        public HttpStatusCode _statusCode { get; set; }
        public string _resultJsonString { get; set; }
    }

    // 이러면 스태틱으로 가야하지않나..
    // 만약 횟수때문에 실패한거면 초당 1회씩 계속 시도한다?
    public class APIManager
    {
        private static readonly string LOSTARK_OFFICIAL_API_PATH  = "https://developer-lostark.game.onstove.com";
        private static readonly string PREFIX = "bearer";
        private static readonly string DUMMY_KEY = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAzMzQ4NTMifQ.noKOdsu-O4cZdPC5We5nSK_zsL_-BD4TQ6543cddlZc40YjAkljKmN8fz5j7g5WJRF-LOazvPlI_S4J9xG-0xn80tzYdKnC66V4NlEQHF9XC7JPpc340hFlFvV0Kc2bAchh5IIGrlfjjgMfqj4yWLRYh8FB1yy3TDjGFdW3VSr223GzivDcmDTf0CYARTfL0xzDBVf-dNHOO0n2V_ytS1tECieQrLb4bqsRH4HOb1Nwa8y6FgnOCwt4T6ZuiLNtuhXOfzdoq-HyUCERTIRSoasSvU4_dCND0qA_wGms3NYlrSfO4om2ZchM9wkmS1v5gR1JEGfNvS7c0VNj-p9kqPA";

        // 키 개당 최대 요청 가능횟수 (1분) Reponse Header Key : X_RATELIMIT_LIMIT
        private static readonly int MAX_REQUEST_COUNT_PER_MINUTE = 100;

        public List<APIKeyInfo> _currentRunningKeyList { get; set; }

        public APIManager()
        {
            _currentRunningKeyList = new List<APIKeyInfo>();
        }

        public string SendRequest(string subPath, string method, string requestParam = "", APIKeyInfo keyInfo = null)
        {
            string result = string.Empty;
            string path   = string.Empty;
            string token  = DUMMY_KEY;

            path = LOSTARK_OFFICIAL_API_PATH + subPath;

            if (null != keyInfo && false == string.IsNullOrEmpty(keyInfo._token))
            {
                token = keyInfo._token;

                int keyIndex = _currentRunningKeyList.FindIndex(x => x._token.Equals(keyInfo._token));
                if (-1 == keyIndex)
                {
                    ++keyInfo._currentRequestCount;
                    _currentRunningKeyList.Add(keyInfo);
                }
                else
                {
                    ++_currentRunningKeyList[keyIndex]._currentRequestCount;
                }
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            request.Method      = method.ToUpper();
            request.ContentType = "application/json";
            request.Accept      = "application/json";
            request.Headers.Add("Authorization", PREFIX + " " + token);

            Stream requestStream = null;

            if (false == string.IsNullOrEmpty(requestParam))
            { 
                requestStream = request.GetRequestStream();
                byte[] byteArray = Encoding.UTF8.GetBytes(requestParam);
                requestStream.Write(byteArray, 0, byteArray.Length);
                requestStream.Close();
            }

            // 응답
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (HttpStatusCode.OK != response.StatusCode)
            { 
                // 오류처리
            }

            // 응답 Stream 읽기
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8, true);

            // 응답 Stream -> 응답 String 변환
            result = streamReader.ReadToEnd();

            streamReader.Close();

            return result;
        }

    }
}