using UnityEngine;
using System.Collections;

public class GameResultEvent : BaseEvent {

	public GameResultEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GameResultResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GameResultResponse Response
	{
		get{ return response as GameResultResponse;}
	}

}
