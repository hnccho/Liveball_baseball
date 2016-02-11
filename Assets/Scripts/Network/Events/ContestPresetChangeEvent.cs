using UnityEngine;
using System.Collections;

public class ContestPresetChangeEvent : BaseEvent {

	public ContestPresetChangeEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<ContestPresetChangeResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public ContestPresetChangeResponse Response
	{
		get{ return response as ContestPresetChangeResponse;}
	}

}
