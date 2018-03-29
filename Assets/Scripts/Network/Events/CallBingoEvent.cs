using UnityEngine;
using System.Collections;

public class CallBingoEvent : BaseEvent {

	public CallBingoEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<CallBingoResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public CallBingoResponse Response
	{
		get{ return response as CallBingoResponse;}
	}

}
