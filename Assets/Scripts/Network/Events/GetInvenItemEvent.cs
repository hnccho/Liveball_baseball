using UnityEngine;
using System.Collections;

public class GetInvenItemEvent : BaseEvent {

	public GetInvenItemEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetInvenItemResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public GetInvenItemResponse Response
	{
		get{ return response as GetInvenItemResponse;}
	}

}
