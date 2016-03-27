using UnityEngine;
using System.Collections;

public class CardUpEvent : BaseEvent {

	public CardUpEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<CardUpResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public CardUpResponse Response
	{
		get{ return response as CardUpResponse;}
	}

}
