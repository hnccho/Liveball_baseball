using UnityEngine;
using System.Collections;

public class ContestDataEvent : BaseEvent {

	public ContestDataEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<ContestDataResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public ContestDataResponse Response
	{
		get{ return response as ContestDataResponse;}
	}

}
