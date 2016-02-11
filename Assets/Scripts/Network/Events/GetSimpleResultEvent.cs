using UnityEngine;
using System.Collections;

public class GetSimpleResultEvent : BaseEvent {

	public GetSimpleResultEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSimpleResultResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetSimpleResultResponse Response
	{
		get{return response as GetSimpleResultResponse;}
		set{response = value;}
	}

}
