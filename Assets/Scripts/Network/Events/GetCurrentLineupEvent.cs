using UnityEngine;
using System.Collections;

public class GetCurrentLineupEvent : BaseEvent {

	public GetCurrentLineupEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetCurrentLineupResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetCurrentLineupResponse Response
	{
		get{ return response as GetCurrentLineupResponse;}
	}

}
