using UnityEngine;
using System.Collections;

public class PresetAddEvent : BaseEvent {

	public PresetAddEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<PresetAddResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public PresetAddResponse Response
	{
		get{ return response as PresetAddResponse;}
	}

}
