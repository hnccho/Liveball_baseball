using UnityEngine;
using System.Collections;

public class GetGameParticipantRankingEvent : BaseEvent {

	public GetGameParticipantRankingEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetGameParticipantRankingResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetGameParticipantRankingResponse Response
	{
		get{ return response as GetGameParticipantRankingResponse;}
	}

}
