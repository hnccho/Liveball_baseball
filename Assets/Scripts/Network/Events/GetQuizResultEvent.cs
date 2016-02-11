using UnityEngine;
using System.Collections;

public class GetQuizResultEvent : BaseEvent {

	public GetQuizResultEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetQuizResultResponse>(data);

		if (checkError ())
						return;

		eventDelegate.Execute ();
	}

	public GetQuizResultResponse Response
	{
		get{ return response as GetQuizResultResponse;}
	}

}
