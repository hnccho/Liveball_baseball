using UnityEngine;
using System.Collections;

public class PresetUpdateEvent : BaseEvent {

	public PresetUpdateEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<PresetUpdateResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public PresetUpdateResponse Response
	{
		get{ return response as PresetUpdateResponse;}
	}

}
