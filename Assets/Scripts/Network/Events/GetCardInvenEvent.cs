using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetCardInvenEvent : BaseEvent {

	public GetCardInvenEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetCardInvenResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetCardInvenResponse Response
	{
		get{ return response as GetCardInvenResponse;}
	}

}
