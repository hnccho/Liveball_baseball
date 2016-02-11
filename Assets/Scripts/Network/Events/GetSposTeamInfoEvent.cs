using UnityEngine;
using System.Collections;

public class GetSposTeamInfoEvent : BaseEvent {

	public GetSposTeamInfoEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
//		response = JsonFx.Json.JsonReader.Deserialize<GetSposTeamInfoResponse>(data);
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSposTeamInfoResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public GetSposTeamInfoResponse Response
	{
		get{ return response as GetSposTeamInfoResponse;}
	}

}
