using UnityEngine;
using System.Collections;

public class ContestListEvent : BaseEvent {

	public ContestListEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<ContestListResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public ContestListResponse Response
	{
		get{ return response as ContestListResponse;}
	}

}
