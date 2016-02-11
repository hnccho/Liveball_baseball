using UnityEngine;
using System.Collections;

public class GetDoneMailEvent : BaseEvent {

	public GetDoneMailEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetDoneMailResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetDoneMailResponse Response
	{
		get{ return response as GetDoneMailResponse;}
	}

}
