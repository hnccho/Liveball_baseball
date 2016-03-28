using UnityEngine;
using System.Collections;

public class GetLineupEvent : BaseEvent {

	public GetLineupEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetLineupResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetLineupResponse Response
	{
		get{ return response as GetLineupResponse;}
	}

}
