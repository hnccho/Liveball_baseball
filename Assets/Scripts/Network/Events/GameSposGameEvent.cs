using UnityEngine;
using System.Collections;

public class GameSposGameEvent : BaseEvent {

	public GameSposGameEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GameSposGameResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public GameSposGameResponse Response
	{
		get{ return response as GameSposGameResponse;}
	}

}
