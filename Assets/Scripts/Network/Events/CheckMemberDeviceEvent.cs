using UnityEngine;
using System.Collections;

public class CheckMemberDeviceEvent : BaseEvent {

	public CheckMemberDeviceEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<CheckMemberDeviceResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public CheckMemberDeviceResponse Response
	{
		get{ return response as CheckMemberDeviceResponse;}
	}

}
