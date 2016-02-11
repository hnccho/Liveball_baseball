using UnityEngine;
using System.Collections;

public class GetMailEvent : BaseEvent {

	public GetMailEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMailResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public GetMailResponse Response
	{
		get{ return response as GetMailResponse;}
	}

}
