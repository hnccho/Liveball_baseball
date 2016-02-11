using UnityEngine;
using System.Collections;

public class checkRecentMessageEvent : BaseEvent {

	public checkRecentMessageEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<checkRecentMessageResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public checkRecentMessageResponse Response
	{
		get{ return response as checkRecentMessageResponse;}
	}

}
