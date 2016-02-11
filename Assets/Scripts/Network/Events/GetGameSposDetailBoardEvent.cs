using UnityEngine;
using System.Collections;

public class GetGameSposDetailBoardEvent : BaseEvent {

	public GetGameSposDetailBoardEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetGameSposDetailBoardResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetGameSposDetailBoardResponse Response
	{
		get{ return response as GetGameSposDetailBoardResponse;}
	}

}
