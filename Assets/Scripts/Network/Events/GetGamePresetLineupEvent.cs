using UnityEngine;
using System.Collections;

public class GetGamePresetLineupEvent : BaseEvent {

	public GetGamePresetLineupEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetGamePresetLineupResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetGamePresetLineupResponse Response
	{
		get{ return response as GetGamePresetLineupResponse;}
	}

}
