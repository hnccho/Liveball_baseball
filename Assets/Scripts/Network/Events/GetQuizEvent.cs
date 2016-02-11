using UnityEngine;
using System.Collections;

public class GetQuizEvent : BaseEvent {

	public GetQuizEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetQuizResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetQuizResponse Response
	{
		get{ return response as GetQuizResponse;}
	}

}
