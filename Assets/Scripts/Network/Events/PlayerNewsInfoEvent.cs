using UnityEngine;
using System.Collections;

public class PlayerNewsInfoEvent : BaseEvent {

	public PlayerNewsInfoEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerNewsInfoResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public PlayerNewsInfoResponse Response
	{
		get{ return response as PlayerNewsInfoResponse;}
	}

}
