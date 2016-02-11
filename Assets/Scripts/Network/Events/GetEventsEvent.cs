using UnityEngine;
using System.Collections;

public class GetEventsEvent : BaseEvent {
	GetEventsResponse mResponse;

	public GetEventsEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

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
