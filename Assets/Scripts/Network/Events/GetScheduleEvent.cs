using UnityEngine;
using System.Collections;

public class GetScheduleEvent : BaseEvent {

	public GetScheduleEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetScheduleResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetScheduleResponse Response
	{
		get{ return response as GetScheduleResponse;}
	}

}
