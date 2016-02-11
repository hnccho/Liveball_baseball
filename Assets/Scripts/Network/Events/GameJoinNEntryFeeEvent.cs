using UnityEngine;
using System.Collections;

public class GameJoinNEntryFeeEvent : BaseEvent {

	public GameJoinNEntryFeeEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GameJoinNEntryFeeResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public GameJoinNEntryFeeResponse Response
	{
		get{ return response as GameJoinNEntryFeeResponse;}
	}

}
