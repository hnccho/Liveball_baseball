using UnityEngine;
using System.Collections;

public class procStoreGachaEvent : BaseEvent {

	public procStoreGachaEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<procStoreGachaResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public procStoreGachaResponse Response
	{
		get{ return response as procStoreGachaResponse;}
	}

}
