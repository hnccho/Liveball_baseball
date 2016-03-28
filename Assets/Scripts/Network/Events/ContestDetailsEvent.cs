using UnityEngine;
using System.Collections;

public class ContestDetailsEvent : BaseEvent {

	public ContestDetailsEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<ContestDetailsResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public ContestDetailsResponse Response
	{
		get{ return response as ContestDetailsResponse;}
	}

}
