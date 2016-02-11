using UnityEngine;
using System.Collections;

public class AccuseContentEvent : BaseEvent {

	public AccuseContentEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<AccuseContentResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public AccuseContentResponse Response{
		get {return response as AccuseContentResponse;}
	}

}
