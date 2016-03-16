using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetPlayerListEvent: BaseEvent {

	public GetPlayerListEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetPlayerListResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetPlayerListResponse Response
	{
		get{ return response as GetPlayerListResponse;}
	}

}
