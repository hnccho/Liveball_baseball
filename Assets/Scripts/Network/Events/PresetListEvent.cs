using UnityEngine;
using System.Collections;

public class PresetListEvent : BaseEvent {

	public PresetListEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<PresetListResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public PresetListResponse Response
	{
		get{ return response as PresetListResponse;}
	}

}
