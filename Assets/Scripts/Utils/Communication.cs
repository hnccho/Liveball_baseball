using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Communication : MonoBehaviour {

	/*
	public WWW Request (ProtocolBase protocol, string url, Hashtable hashTable, Action<bool> isSuccessed)		
	{
		string data = hashTable == null ? "{}" : JsonParser._Instance.HashtableToJsonString (hashTable);

	//Hashtable 유니티 4.5버전에서 Warning 을 띄우네요. WWW 생성자에는 hashTable인자가 여전히 있지만 Dictionary사용을 권장하는군요. Dictionary로 변경했습니다.

		Hashtable header = new Hashtable();
		header.Add ("Content-Type", "application/json; charset=utf-8");
		header.Add ("Content-Length", data.Length );
		
		
		_requestProtocol = protocol;
		WWW www = new WWW (url, Encoding.UTF8.GetBytes(data), header);
		
		#if UNITY_EDITOR
		Logger.Log(string.Concat ("req : ", url, data));
		#endif
		
		StartCoroutine (WaitForRequest (www, isSuccessed)); 
		return www; 
	}



	private IEnumerator WaitForRequest (WWW www, Action<bool> isSuccessed)
	{
		yield return www;
		
		if (www.error == null)
		{
			if (_requestProtocol != null)
			{
				Hashtable hashTable = _requestProtocol.Parse(www.text);
				
				#if UNITY_EDITOR
				string res = www.text;
				Logger.Log(string.Concat("res : ", res));
				#endif
				if (hashTable.ContainsKey(PacketKey.Error))
				{
					string errorMessage = hashTable[PacketKey.Error] is String ? Convert.
						
						ToString (hashTable[PacketKey.Error]) : string.Empty;
					
					
					if (string.IsNullOrEmpty(errorMessage))
					{
						Logger.Error("ErrorMessage is NullOrEmpty");
						Application.Quit ();
					}
					else
					{
						bool isCriticalError = _requestProtocol.Error (errorMessage);
						
						if (isCriticalError)
						{
							Logger.Error(string.Concat("Critical Error ! ", hashTable[PacketKey.Error]));
							Application.Quit();
						}
					}
				}
				
				bool isSuccess = _requestProtocol.ReceivedData(hashTable);
				
				if (!isSuccess)
					Logger.Warning("failed manage receivedData !");
				
				if (isSuccessed != null)
					isSuccessed(isSuccess);
			}
		} 
		else 
		{
			Logger.Error(string.Concat ("www error ! message : ", www.error));
			
			if(isSuccessed != null)
				isSuccessed(false);
		}
	}

*/
}



