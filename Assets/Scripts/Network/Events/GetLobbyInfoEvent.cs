using UnityEngine;
using System.Collections;

public class GetLobbyInfoEvent : BaseEvent {

	public GetLobbyInfoEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);
		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = (GetLobbyInfoResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(data, typeof(GetLobbyInfoResponse));
		eventDelegate.Execute ();
	}

	public GetLobbyInfoResponse Response
	{
		get{ return response as GetLobbyInfoResponse;}
	}

}
