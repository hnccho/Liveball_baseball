using UnityEngine;
using System.Collections;

public class RemoveContestPresetEvent : BaseEvent {

	public RemoveContestPresetEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<RemoveContestPresetResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public RemoveContestPresetResponse Response
	{
		get{ return response as RemoveContestPresetResponse;}
	}

}
