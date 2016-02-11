using UnityEngine;
using System.Collections;

public class GetInAppHistoryEvent : BaseEvent {

	public GetInAppHistoryEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetInAppHistoryResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetInAppHistoryResponse Response
	{
		get{ return response as GetInAppHistoryResponse;}
	}

}
