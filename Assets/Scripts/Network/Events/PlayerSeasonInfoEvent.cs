using UnityEngine;
using System.Collections;

public class PlayerSeasonInfoEvent : BaseEvent {

	public PlayerSeasonInfoEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerSeasonInfoResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public PlayerSeasonInfoResponse Response
	{
		get{ return response as PlayerSeasonInfoResponse;}
	}

}
