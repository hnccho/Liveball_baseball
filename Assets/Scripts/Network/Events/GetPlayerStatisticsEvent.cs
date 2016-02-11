using UnityEngine;
using System.Collections;

public class GetPlayerStatisticsEvent : BaseEvent {

	public GetPlayerStatisticsEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetPlayerStatisticsResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetPlayerStatisticsResponse Response
	{
		get{ return response as GetPlayerStatisticsResponse;}
	}

}
