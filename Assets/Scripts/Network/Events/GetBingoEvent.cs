using UnityEngine;
using System.Collections;

public class GetBingoEvent : BaseEvent {

	public GetBingoEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetBingoResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetBingoResponse Response
	{
		get{ return response as GetBingoResponse;}
	}

}
