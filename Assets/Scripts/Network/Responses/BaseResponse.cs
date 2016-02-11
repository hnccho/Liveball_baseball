using UnityEngine;
using System.Collections;

public class BaseResponse {
	int _code;
	int _result;
	string _message;
	string _queryId;
	string _queryType;

	public int code
	{
		get{return _code;}
		set{ _code = value;}
	}

	public int result
	{
		get{return _result;}
		set{ _result = value;}
	}

	public string message
	{
		get{return _message;}
		set{ _message = value;}
	}

	public string query_id
	{
		get{return _queryId;}
		set{ _queryId = value;}
	}

	public string query_type
	{
		get{return _queryType;}
		set{ _queryType = value;}
	}
}
