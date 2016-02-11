using UnityEngine;
using System.Collections;

public class PresetDataEvent : BaseEvent {

	public PresetDataEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<PresetDataResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public PresetDataResponse Response
	{
		get{ return response as PresetDataResponse;}
	}

}
