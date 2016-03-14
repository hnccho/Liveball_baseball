using UnityEngine;
using System.Collections;

public class GetEventsEvent : BaseEvent {
	GetEventsResponse mResponse;

	public GetEventsEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		mResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetEventsResponse>(data);

		eventDelegate.Execute ();
	}

	public GetEventsResponse Response
	{
		get{ return mResponse;}
	}

}
