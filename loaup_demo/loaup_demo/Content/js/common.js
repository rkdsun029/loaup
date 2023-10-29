// 요청전송 기본양식
function sendRequest(url, method, sendData, callback)
{
	var result = new Object();

	$.ajax(
	{
		url : _path + url,
	  	beforeSend : function(xhr)
		{
			xhr.setRequestHeader("Authorization", _token);
		},
		method : method,
		data : sendData,
		success : function(result) 
		{
			// 성공콜백
			// callback 실행
			return result;
		},
		error : function(jqxhr, errorThrown) 
		{
			//실패콜백
			//공용 콜백로직 만들기
			return null;
		}
	});
}