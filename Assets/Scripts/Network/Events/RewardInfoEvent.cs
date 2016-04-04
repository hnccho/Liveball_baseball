using UnityEngine;
using System.Collections;

public class RewardInfoEvent : BaseEvent {

	public RewardInfoEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<RewardInfoResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public RewardInfoResponse Response
	{
		get{ return response as RewardInfoResponse;}
	}

}
