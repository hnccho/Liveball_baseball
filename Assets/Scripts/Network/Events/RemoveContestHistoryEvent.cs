using UnityEngine;
using System.Collections;

public class RemoveContestHistoryEvent : BaseEvent {

	public RemoveContestHistoryEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<RemoveContestHistoryResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public RemoveContestHistoryResponse Response
	{
		get{ return response as RemoveContestHistoryResponse;}
	}

}
