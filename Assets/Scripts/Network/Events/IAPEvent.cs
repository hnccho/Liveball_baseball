using UnityEngine;
using System.Collections;

public class IAPEvent : BaseEvent {

	public IAPEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<IAPResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public IAPResponse Response
	{
		get{ return response as IAPResponse;}
	}

}
