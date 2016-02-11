using UnityEngine;
using System.Collections;

public class CheckVersionEvent : BaseEvent {

	public CheckVersionEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = (CheckVersionResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(data, typeof(CheckVersionResponse));
//		Newtonsoft.Json.JsonConvert.DeserializeObject(

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public CheckVersionResponse Response
	{
		get{ return response as CheckVersionResponse;}
	}

}
