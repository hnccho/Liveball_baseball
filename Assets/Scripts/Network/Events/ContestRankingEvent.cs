using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContestRankingEvent : BaseEvent {

	public ContestRankingEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<ContestRankingResponse>(data);

		eventDelegate.Execute ();
	}

	public ContestRankingResponse Response
	{
		get{ return response as ContestRankingResponse;}
	}

}
