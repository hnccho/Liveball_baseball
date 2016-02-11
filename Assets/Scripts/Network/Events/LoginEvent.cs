using UnityEngine;
using System.Collections;

public class LoginEvent : BaseEvent {

	public LoginEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public LoginResponse Response
	{
		get{return response as LoginResponse;}
	}

}
