using UnityEngine;
using System.Collections;

public class TeamScheduleInfoEvent : BaseEvent {

	public TeamScheduleInfoEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<TeamScheduleInfoResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public TeamScheduleInfoResponse Response
	{
		get{ return response as TeamScheduleInfoResponse;}
	}

}
