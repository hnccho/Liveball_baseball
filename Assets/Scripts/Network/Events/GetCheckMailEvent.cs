using UnityEngine;
using System.Collections;

public class GetCheckMailEvent : BaseEvent {

	public GetCheckMailEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetCheckMailResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetCheckMailResponse Response
	{
		get{ return response as GetCheckMailResponse;}
	}

}
